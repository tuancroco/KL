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

        public string NoiDungPhanHoi { get; set; }

        [StringLength(128)]
        public string IDCongViec { get; set; }
    }
}
