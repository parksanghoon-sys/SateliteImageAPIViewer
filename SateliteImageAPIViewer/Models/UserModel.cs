using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SateliteImageAPIViewer.Models
{
    public class UserModelList : ObservableCollection<UserData>
    {

    }
    public class UserDataBase
    {
        [Key]
        [StringLength(255)]
        [Display(Name = "아이디")]        
        public string Id { get; set; }

        [StringLength(255)]
        [Display(Name = "비밀번호")]
        public string Password { get; set; }
        [StringLength(255)]
        [Display(Name = "핸드폰 번호")]
        public string PhoneNumber { get; set; }
        [StringLength(255)]
        [Display(Name = "가입일")]
        public DateTime JoinDatetime { get; set; }
        [StringLength(255)]
        [Display(Name = "이메일")]
        public string Email { get; set; }

    }


    [Table("UserData")]
    public class UserData : UserDataBase
    {
        // Empty
    }
}
