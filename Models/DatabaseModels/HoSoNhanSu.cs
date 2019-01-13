namespace KL.Models.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoSoNhanSu")]
    public partial class HoSoNhanSu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoSoNhanSu()
        {
            CongViecs = new HashSet<CongViec>();
            CongViecCaNhans = new HashSet<CongViecCaNhan>();
            CongViecPhongs = new HashSet<CongViecPhong>();
            Users = new HashSet<User>();
        }

        public string ID { get; set; }

        public string MaHoSo { get; set; }

        public string TenNhanSu { get; set; }

        public DateTime? NgaySinh { get; set; }

        public string GhiChu { get; set; }

        [StringLength(128)]
        public string IDChucVu { get; set; }

        [StringLength(128)]
        public string IDPhongBan { get; set; }

        public string GioiTinh { get; set; }

        public string HinhAnh { get; set; }

        [StringLength(128)]
        public string IDViTriViecLam { get; set; }

        public string TenDayDu { get; set; }

        public virtual ChucVu ChucVu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CongViec> CongViecs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CongViecCaNhan> CongViecCaNhans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CongViecPhong> CongViecPhongs { get; set; }

        public virtual PhongBan PhongBan { get; set; }

        public virtual ViTriViecLam ViTriViecLam { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
    }
}
