namespace KL.Models.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CongViecPhong")]
    public partial class CongViecPhong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CongViecPhong()
        {
            CongViecCaNhans = new HashSet<CongViecCaNhan>();
            PhanHoiCVs = new HashSet<PhanHoiCV>();
        }

        public string ID { get; set; }

        public string NoiDungChitiet { get; set; }

        public DateTime? ThoiGianHoanThanh { get; set; }

        public string GhiChu { get; set; }

        [StringLength(128)]
        public string IDCongViec { get; set; }

        [StringLength(128)]
        public string IDHoSoNhanSuPhuTrach { get; set; }

        public int? DaChon { get; set; }

        public int? DaDuyet { get; set; }

        public string NguoiThamGia { get; set; }

        public DateTime? NgayDieuChinh { get; set; }

        public int? PhanHoi { get; set; }

        public string NoiDungPhanHoi { get; set; }

        public DateTime? ThoiHanHoanThanh { get; set; }

        public string CongVanDinhKem { get; set; }

        [StringLength(128)]
        public string Ten { get; set; }

        public DateTime? Datecreate { get; set; }

        public int? TrangThai { get; set; }

        public int? New { get; set; }

        public string upload { get; set; }

        [StringLength(128)]
        public string IDLoaiCv { get; set; }

        public virtual CongViec CongViec { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CongViecCaNhan> CongViecCaNhans { get; set; }

        public virtual HoSoNhanSu HoSoNhanSu { get; set; }

        public virtual LoaiCongViec LoaiCongViec { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanHoiCV> PhanHoiCVs { get; set; }
    }
}
