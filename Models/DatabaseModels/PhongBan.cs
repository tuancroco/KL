namespace KL.Models.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhongBan")]
    public partial class PhongBan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhongBan()
        {
            HoSoNhanSus = new HashSet<HoSoNhanSu>();
        }

        public string ID { get; set; }

        public string MaPhongBan { get; set; }

        public string TenPhongBan { get; set; }

        public string DienThoai { get; set; }

        public string GhiChu { get; set; }

        [StringLength(128)]
        public string IDDonVi { get; set; }

        [StringLength(128)]
        public string IDCongViec { get; set; }

        public virtual CongViec CongViec { get; set; }

        public virtual DonVi DonVi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoSoNhanSu> HoSoNhanSus { get; set; }
    }
}
