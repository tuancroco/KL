namespace KL.Models.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CongViecCaNhan")]
    public partial class CongViecCaNhan
    {
        public string ID { get; set; }

        public string NoiDungCongViec { get; set; }

        [StringLength(128)]
        public string IDHoSoNhanSu { get; set; }

        public string SanPhamCaNhan { get; set; }

        public string NguoiThamGia { get; set; }

        public int? TrangThai { get; set; }

        public DateTime? ThoiGianHoanThanh { get; set; }

        public string CongVanDinhKemCaNhan { get; set; }

        [StringLength(128)]
        public string IDCongViecPhong { get; set; }

        public virtual CongViecPhong CongViecPhong { get; set; }

        public virtual HoSoNhanSu HoSoNhanSu { get; set; }
    }
}
