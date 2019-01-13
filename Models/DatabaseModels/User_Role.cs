namespace KL.Models.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User_Role
    {
        public string ID { get; set; }

        [StringLength(128)]
        public string UserID { get; set; }

        [StringLength(128)]
        public string RoleID { get; set; }
    }
}
