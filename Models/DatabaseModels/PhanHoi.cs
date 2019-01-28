namespace KL.Models.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhanHoi")]
    public partial class PhanHoi
    {
        public string ID { get; set; }

        [StringLength(128)]
        public string IDCongviecCaNhan { get; set; }

        public string NoiDung { get; set; }

        [StringLength(128)]
        public string IDTruongPhong { get; set; }

        public int? TrangThai { get; set; }

        public DateTime? Datecreate { get; set; }

        public virtual CongViecCaNhan CongViecCaNhan { get; set; }

        public virtual HoSoNhanSu HoSoNhanSu { get; set; }
    }
}
