using DTO_QLDeTaiNCKH;
using DAL_QLDeTaiNCKH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_QLDeTaiNCKH
{
    public class QLDeTai_BLL
    {
        private QLDeTai_DAL dal = new QLDeTai_DAL();
        public List<DeTaiDTO> DanhSachDeTai { get; set; }

        public void LoadDeTai(string filePath)
        {
            DanhSachDeTai = dal.ReadFileXML(filePath);
        }

        public void AddDeTai(DeTaiDTO deTai)
        {
            DanhSachDeTai.Add(deTai);
        }

        public void DisplayDeTai()
        {
            Console.WriteLine($"{"Mã Đề Tài",-15} {"Tên Đề Tài",-20} {"Kinh Phí",-10} {"Chủ Trì",-15} {"Ngày Bắt Đầu",-15} {"Ngày Kết Thúc",-15} {"GV Hướng Dẫn",-15}");
            foreach (var deTai in DanhSachDeTai)
            {
                deTai.xuatThongTin();
            }
        }

        public List<DeTaiDTO> SearchDeTai(string keyword)
        {
            return DanhSachDeTai.Where(d =>
                d.MaDeTai.Contains(keyword) ||
                d.TenDeTai.Contains(keyword) ||
                d.ChuTriDeTai.Contains(keyword) ||
                d.GiangVienHuongDan.Contains(keyword)).ToList();
        }

        public List<DeTaiDTO> GetDeTaiByGiangVien(string giangVien)
        {
            return DanhSachDeTai.Where(d => d.GiangVienHuongDan == giangVien).ToList();
        }

        public void UpdateKinhPhi()
        {
            foreach (var deTai in DanhSachDeTai)
            {
                deTai.KinhPhi *= 1.1; // Tăng 10%
            }
        }

        public List<DeTaiDTO> GetDeTaiWithKinhPhiAbove(double amount)
        {
            return DanhSachDeTai.Where(d => d.KinhPhi > amount).ToList();
        }

        public List<DeTaiNCLT_DTO> GetDeTaiTheoreticalAndPractical()
        {
            return DanhSachDeTai.OfType<DeTaiNCLT_DTO>()
                .Where(d => d.ApDungThucTe).ToList();
        }

        public List<DeTaiKinhTe_DTO> GetDeTaiWithSoCauHoiAbove(int count)
        {
            return DanhSachDeTai.OfType<DeTaiKinhTe_DTO>()
                .Where(d => d.SoCauHoiKhaoSat > count).ToList();
        }

        public List<DeTaiDTO> GetDeTaiWithDurationMoreThan(int months)
        {
            return DanhSachDeTai.Where(d => (d.NgayKetThuc - d.NgayBatDau).TotalDays > months * 30).ToList();
        }
    }
}
