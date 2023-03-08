using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SateliteImageAPIViewer.enums;

namespace SateliteImageAPIViewer.Models
{
    public class SatelliteAPIModelList :ObservableCollection<SatelliteData>
    {

    }
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
        [Required(ErrorMessage = "입력하시오")]
        [Column(TypeName = "NVarChar(255)")]
        [Display(Name = "위성영상 타입")]
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
