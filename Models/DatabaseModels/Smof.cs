namespace KL.Models.DatabaseModels
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Smof : DbContext
    {
        public Smof()
            : base("name=Smof8")
        {
        }

        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<CongViec> CongViecs { get; set; }
        public virtual DbSet<CongViecCaNhan> CongViecCaNhans { get; set; }
        public virtual DbSet<CongViecPhong> CongViecPhongs { get; set; }
        public virtual DbSet<DonVi> DonVis { get; set; }
        public virtual DbSet<HoSoNhanSu> HoSoNhanSus { get; set; }
        public virtual DbSet<LoaiCongViec> LoaiCongViecs { get; set; }
        public virtual DbSet<PhanHoi> PhanHois { get; set; }
        public virtual DbSet<PhanHoiCV> PhanHoiCVs { get; set; }
        public virtual DbSet<PhongBan> PhongBans { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User_Role> User_Role { get; set; }
        public virtual DbSet<ViTriViecLam> ViTriViecLams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChucVu>()
                .HasMany(e => e.HoSoNhanSus)
                .WithOptional(e => e.ChucVu)
                .HasForeignKey(e => e.IDChucVu);

            modelBuilder.Entity<CongViec>()
                .HasMany(e => e.CongViecPhongs)
                .WithOptional(e => e.CongViec)
                .HasForeignKey(e => e.IDCongViec);

            modelBuilder.Entity<CongViec>()
                .HasMany(e => e.PhongBans)
                .WithOptional(e => e.CongViec)
                .HasForeignKey(e => e.IDCongViec);

            modelBuilder.Entity<CongViecCaNhan>()
                .HasMany(e => e.PhanHois)
                .WithOptional(e => e.CongViecCaNhan)
                .HasForeignKey(e => e.IDCongviecCaNhan);

            modelBuilder.Entity<CongViecPhong>()
                .HasMany(e => e.CongViecCaNhans)
                .WithOptional(e => e.CongViecPhong)
                .HasForeignKey(e => e.IDCongViecPhong);

            modelBuilder.Entity<CongViecPhong>()
                .HasMany(e => e.PhanHoiCVs)
                .WithOptional(e => e.CongViecPhong)
                .HasForeignKey(e => e.IDCongviecPhong);

            modelBuilder.Entity<DonVi>()
                .HasMany(e => e.PhongBans)
                .WithOptional(e => e.DonVi)
                .HasForeignKey(e => e.IDDonVi);

            modelBuilder.Entity<HoSoNhanSu>()
                .HasMany(e => e.CongViecs)
                .WithOptional(e => e.HoSoNhanSu)
                .HasForeignKey(e => e.IDHoSoNhanSu);

            modelBuilder.Entity<HoSoNhanSu>()
                .HasMany(e => e.CongViecCaNhans)
                .WithOptional(e => e.HoSoNhanSu)
                .HasForeignKey(e => e.IDHoSoNhanSu);

            modelBuilder.Entity<HoSoNhanSu>()
                .HasMany(e => e.CongViecPhongs)
                .WithOptional(e => e.HoSoNhanSu)
                .HasForeignKey(e => e.IDHoSoNhanSuPhuTrach);

            modelBuilder.Entity<HoSoNhanSu>()
                .HasMany(e => e.PhanHois)
                .WithOptional(e => e.HoSoNhanSu)
                .HasForeignKey(e => e.IDTruongPhong);

            modelBuilder.Entity<HoSoNhanSu>()
                .HasMany(e => e.PhanHoiCVs)
                .WithOptional(e => e.HoSoNhanSu)
                .HasForeignKey(e => e.IDLanhDao);

            modelBuilder.Entity<HoSoNhanSu>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.HoSoNhanSu)
                .HasForeignKey(e => e.IDHoSoNhanSu);

            modelBuilder.Entity<LoaiCongViec>()
                .HasMany(e => e.CongViecs)
                .WithOptional(e => e.LoaiCongViec)
                .HasForeignKey(e => e.IDLoaiCongViec);

            modelBuilder.Entity<PhongBan>()
                .HasMany(e => e.HoSoNhanSus)
                .WithOptional(e => e.PhongBan)
                .HasForeignKey(e => e.IDPhongBan);

            modelBuilder.Entity<ViTriViecLam>()
                .HasMany(e => e.HoSoNhanSus)
                .WithOptional(e => e.ViTriViecLam)
                .HasForeignKey(e => e.IDViTriViecLam);
        }
    }
}
