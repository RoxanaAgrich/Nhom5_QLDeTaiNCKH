using DTO_QLDeTaiNCKH;
using DAL_QLDeTaiNCKH;
using System;
using System.Collections.Generic;
using System.Linq;

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

        //Sửa ở đây
        public void AddDeTai(DeTaiDTO deTai)
        {
            if (DanhSachDeTai == null)
            {
                DanhSachDeTai = new List<DeTaiDTO>();
            }
            DanhSachDeTai.Add(deTai);
            Console.WriteLine("Đề tài mới đã được thêm thành công.");
        }

        // Sửa ở đây
        public void DisplayDeTai()
        {
            if (DanhSachDeTai == null)
            {
                return;
            }
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

        // Sửa ở đây
        public void UpdateKinhPhi()
        {
            if (DanhSachDeTai == null)
            {
                Console.WriteLine("Danh sách đề tài rỗng. Không thể cập nhật kinh phí.");
                return; 
            }

            foreach (var deTai in DanhSachDeTai)
            {
                deTai.KinhPhi *= 1.1;
            }
            Console.WriteLine("Cập nhật kinh phí thành công.");
        }

        public List<DeTaiDTO> GetDeTaiWithKinhPhiAbove(double amount)
        {
            if (DanhSachDeTai == null)
            {
                Console.WriteLine("Danh sách đề tài rỗng.");
                return null;
            }
            return DanhSachDeTai.Where(d => d.KinhPhi > amount).ToList();
        }

        public List<DeTaiNCLT_DTO> GetDeTaiTheoreticalAndPractical()
        {
            if (DanhSachDeTai == null)
            {
                Console.WriteLine("Danh sách đề tài rỗng.");
                return null;
            }
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
