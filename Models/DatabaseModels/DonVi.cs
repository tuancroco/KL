namespace KL.Models.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonVi")]
    public partial class DonVi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonVi()
        {
            PhongBans = new HashSet<PhongBan>();
        }

        public string ID { get; set; }

        public string MaCongViec { get; set; }

        public string TenDonVi { get; set; }

        public string DiaChi { get; set; }

        public string SoDienThoai { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhongBan> PhongBans { get; set; }
    }
}
