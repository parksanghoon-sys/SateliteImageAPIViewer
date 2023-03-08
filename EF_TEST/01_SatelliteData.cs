using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_TEST
{
    /// <summary>
    /// 기본 클래스 공통 특성들을 모두 모아 놓은 모델 클레스
    /// </summary>
    public class SatelliteDataBase
    {
        /// <summary>
        /// 일련번호 Serial Number
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "번호")]
        public int NumberID { get; set; }
        /// <summary>
        /// 위성 영상 타입
        /// </summary>
        [StringLength(255)]
        [Required(ErrorMessage ="입력하시오")]
        [Column(TypeName ="NVarChar(255)")]
        [Display(Name ="위성영상 타입")]
        public string SatelliteType { get; set; }
        /// <summary>
        /// 위성 영상 지역
        /// </summary>
        [StringLength(255)]
        public string SatelliteArea { get; set; }
        /// <summary>
        /// 파일 생성 날짜
        /// </summary>

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime FileCreateDate { get; set; }
        /// <summary>
        /// 파일의 경로
        /// </summary>
        [StringLength(255)]
        public string FilePath { get; set; }
        /// <summary>
        /// 유저 아이디
        /// </summary>
        [StringLength(100)]
        public string UserID { get; set; }

    }
    [Table("SatelliteData")]
    public class SatelliteData : SatelliteDataBase
    {
        // Empty
    }
}

