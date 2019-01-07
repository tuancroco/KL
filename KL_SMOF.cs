namespace KL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class KL_SMOF : DbContext
    {
        public KL_SMOF()
            : base("name=KL_SMOF")
        {
        }

        public virtual DbSet<CongVan> CongVans { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhongBan> PhongBans { get; set; }
        public virtual DbSet<Truong> Truongs { get; set; }
        public virtual DbSet<QuanLy> QuanLies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CongVan>()
                .Property(e => e.TenCongVan)
                .IsFixedLength();

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.TenNhanVien)
                .IsFixedLength();

            modelBuilder.Entity<PhongBan>()
                .Property(e => e.TenPhongBan)
                .IsFixedLength();

            modelBuilder.Entity<Truong>()
                .Property(e => e.TenTruong)
                .IsFixedLength();
        }
    }
}
