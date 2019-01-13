namespace KL.Models.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViTriViecLam")]
    public partial class ViTriViecLam
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ViTriViecLam()
        {
            HoSoNhanSus = new HashSet<HoSoNhanSu>();
        }

        public string ID { get; set; }

        public string MaViTriViecLam { get; set; }

        public string TenViTriViecLam { get; set; }

        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoSoNhanSu> HoSoNhanSus { get; set; }
    }
}
