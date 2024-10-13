using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DTO_QLDeTaiNCKH
{
    public class DeTaiListWrapper
    {
        public List<DeTaiDTO> DeTaiList  = new List<DeTaiDTO>();
    }

    public class DeTaiDTO
    {
        private string maDeTai;
        private string tenDeTai;
        private double kinhPhi;
        private string chuTriDeTai;
        private DateTime ngayBatDau;
        private DateTime ngayKetThuc;
        private string giangVienHuongDan;
        private int soCauHoiKhaoSat;

        public string MaDeTai { get => maDeTai; set => maDeTai = value; }
        public string TenDeTai { get => tenDeTai; set => tenDeTai = value; }
        public double KinhPhi { get => kinhPhi; set => kinhPhi = value; }
        public string ChuTriDeTai { get => chuTriDeTai; set => chuTriDeTai = value; }
        public DateTime NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public DateTime NgayKetThuc { get => ngayKetThuc; set => ngayKetThuc = value; }
        public string GiangVienHuongDan { get => giangVienHuongDan; set => giangVienHuongDan = value; }
        public int SoCauHoiKhaoSat { get => soCauHoiKhaoSat; set => soCauHoiKhaoSat = value; }

        public virtual void xuatThongTin()
        {
            Console.WriteLine($"{MaDeTai,-15} {TenDeTai,-20} {KinhPhi,-10} {ChuTriDeTai,-15} {NgayBatDau.ToShortDateString(),-15} {NgayKetThuc.ToShortDateString(),-15} {GiangVienHuongDan,-15}");
        }
    }

    public class DeTaiNCLT_DTO : DeTaiDTO
    {
        public bool ApDungThucTe ;

        public override void xuatThongTin()
        {
            base.xuatThongTin();
            Console.WriteLine($"Áp dụng thực tế: {ApDungThucTe}");
        }
    }

    public class DeTaiKinhTe_DTO : DeTaiDTO
    {
        // Các thuộc tính riêng cho lớp này
    }
}
