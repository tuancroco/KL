namespace KL.Models.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CongViecCaNhan")]
    public partial class CongViecCaNhan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CongViecCaNhan()
        {
            PhanHois = new HashSet<PhanHoi>();
        }

        public string ID { get; set; }

        public string NoiDungCongViec { get; set; }

        [StringLength(128)]
        public string IDHoSoNhanSu { get; set; }

        public string SanPhamCaNhan { get; set; }

        public string NguoiThamGia { get; set; }

        public int Kieu { get; set; }

        public DateTime? ThoiGianHoanThanh { get; set; }

        public string CongVanDinhKemCaNhan { get; set; }

        [StringLength(128)]
        public string IDCongViecPhong { get; set; }

        public int? PhanHoi { get; set; }

        public DateTime? ThoiHanHoanThanh { get; set; }

        public DateTime? Datecreate { get; set; }

        public int? TrangThai { get; set; }

        [StringLength(128)]
        public string Ten { get; set; }

        public int? New { get; set; }

        public virtual CongViecPhong CongViecPhong { get; set; }

        public virtual HoSoNhanSu HoSoNhanSu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanHoi> PhanHois { get; set; }
    }
}
