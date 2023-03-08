using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SateliteImageAPIViewer.Helpers
{
    public class PasswordEncryptionHelper
    {
        private string _password;
        public PasswordEncryptionHelper(string password)
        {
            _password = password;
        }
        public string GetEncryptionPassword()
        {
            using (SymmetricAlgorithm symmetricAlgorithm = Aes.Create())
            {
                symmetricAlgorithm.GenerateIV();
                byte[] passwordByte = Encoding.UTF8.GetBytes(_password);
                //대칭 키로 비밀번호 암호화
                byte[] encrypedPassword = EncryptWithSymmetricKey(passwordByte, symmetricAlgorithm);
                // 대칭 키를 암호화 하는데 사용되는 인증서 가져오기
                X509Certificate2 certificate = GetCerificate();
                //인증서로 대칭키 암호화
                byte[] encrypteKey = EncryptWithCertificate(symmetricAlgorithm.Key, certificate);

                //PKCS 메세지 생성
                SignedCms signedCms = new SignedCms(new ContentInfo(encrypedPassword), true);
                EnvelopedCms envelopedCms = new EnvelopedCms(new ContentInfo(encrypedPassword));
                // 암호화된 대칭 키를 수신자 정보로 추가합니다.
                CmsRecipient recipient = new CmsRecipient(certificate);
                envelopedCms.Encrypt(recipient);
                //envelopedCms.ContentEncryptionAlgorithm = new Oid(symmetricAlgorithm.KeyExchangeAlgorithm);
                //envelopedCms.ContentEncryptionAlgorithm.Parameters.Add(new AsnEncodedData(symmetricAlgorithm.KeyExchangeAlgorithm, encryptedKey));

                //Encode the PKCS #7 message

                byte[] encodedMessage = envelopedCms.Encode();

                _password = Convert.ToBase64String(encodedMessage);
            }
            return _password;
        }
        public string GetSHAEncryptedPassword()
        {
            var passwordBytes = this.HashPassword(_password);
            //_password = Encoding.UTF8.GetString(passwordBytes);
            _password = BitConverter.ToString(passwordBytes).Replace("-", "");            
            return _password;
        }

        private byte[] EncryptWithCertificate(byte[] key, X509Certificate2 certificate)
        {
            using (RSA rsa = certificate.GetRSAPrivateKey())
            {
                return rsa.Encrypt(key,RSAEncryptionPadding.OaepSHA256);
            }
        }

        private X509Certificate2 GetCerificate()
        {
            X509Certificate2 certificate = new X509Certificate2("certificate.pfx", "password");
            return certificate;           
        }

        private byte[] EncryptWithSymmetricKey(byte[] data , SymmetricAlgorithm symmetricAlgorithm)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                memoryStream.Write(symmetricAlgorithm.IV,0,symmetricAlgorithm.IV.Length);
                using(ICryptoTransform cryptoTransform = symmetricAlgorithm.CreateEncryptor())
                using(CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(data,0,data.Length);
                }
                return memoryStream.ToArray();
            }
        }
        private byte[] HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                return sha256.ComputeHash(passwordBytes);
            }
        }
    }
}
