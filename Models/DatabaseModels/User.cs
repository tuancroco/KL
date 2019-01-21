namespace KL.Models.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [Key]
        [Column(Order = 0)]
        public string ID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? Gender { get; set; }

        public string Phone { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public string Avatar { get; set; }

        [StringLength(128)]
        public string IDHoSoNhanSu { get; set; }

        public virtual HoSoNhanSu HoSoNhanSu { get; set; }
    }
}
