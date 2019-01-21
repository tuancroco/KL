namespace KL.Models.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhanHoiCV")]
    public partial class PhanHoiCV
    {
        public string ID { get; set; }

        [StringLength(128)]
        public string IDLanhDao { get; set; }

        [StringLength(128)]
        public string IDCongviecPhong { get; set; }

        public string Noidung { get; set; }

        public int? TrangThai { get; set; }

        public virtual CongViecPhong CongViecPhong { get; set; }

        public virtual HoSoNhanSu HoSoNhanSu { get; set; }
    }
}
