namespace KL.Models.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FormCv")]
    public partial class FormCv
    {
        public string ID { get; set; }

        public string FormFiled { get; set; }
    }
}
