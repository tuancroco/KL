namespace KL.Models.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CongViec")]
    public partial class CongViec
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CongViec()
        {
            CongViecPhongs = new HashSet<CongViecPhong>();
            PhongBans = new HashSet<PhongBan>();
        }

        public string ID { get; set; }

        public string MaCongViec { get; set; }

        public string NoiDung { get; set; }

        public string GhiChu { get; set; }

        public DateTime? ThoiGianHoanThanh { get; set; }

        [StringLength(128)]
        public string IDLoaiCongViec { get; set; }

        [StringLength(128)]
        public string IDNoiYeuCau { get; set; }

        [StringLength(128)]
        public string IDPhongBan { get; set; }

        [StringLength(128)]
        public string IDHoSoNhanSu { get; set; }

        public DateTime? NgayNhan { get; set; }

        public int DaDuyet { get; set; }

        public string CongVanDinhKem { get; set; }

        public string SoCongVanDi { get; set; }

        public DateTime? NgayGuiCongVanDi { get; set; }

        public string DinhKemCongVanDi { get; set; }

        public DateTime? NgayHoanThanh { get; set; }

        [StringLength(128)]
        public string IDLanhDao { get; set; }

        public DateTime? NgayDieuChinh { get; set; }

        public int? TrangThai { get; set; }

        public virtual HoSoNhanSu HoSoNhanSu { get; set; }

        public virtual LoaiCongViec LoaiCongViec { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CongViecPhong> CongViecPhongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhongBan> PhongBans { get; set; }
    }
}
