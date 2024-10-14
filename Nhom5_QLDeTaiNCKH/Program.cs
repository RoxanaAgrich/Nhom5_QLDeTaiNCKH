using BLL_QLDeTaiNCKH;
using DTO_QLDeTaiNCKH;
using System;
using System.Text;

namespace Nhom5_QLDeTaiNCKH
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GUI_Menu.menu();
            /*
            
                        // Hiển thị danh sách đề tài
                        deTaiBLL.DisplayDeTai();

                        // Thêm mới đề tài
                        AddNewDeTai(deTaiBLL);

                        // Tìm kiếm đề tài
                        SearchDeTai(deTaiBLL);

                        // Cập nhật kinh phí
                        deTaiBLL.UpdateKinhPhi();
                        Console.WriteLine("Sau khi cập nhật kinh phí:");
                        deTaiBLL.DisplayDeTai();

                        // Xuất danh sách đề tài có kinh phí trên 10 triệu
                        var deTaiTren10Trieu = deTaiBLL.GetDeTaiWithKinhPhiAbove(10);
                        Console.WriteLine("Danh sách đề tài có kinh phí trên 10 triệu:");
                        foreach (var deTai in deTaiTren10Trieu)
                        {
                            deTai.xuatThongTin();
                        }

                        // Xuất danh sách đề tài thuộc lĩnh vực nghiên cứu lý thuyết và có khả năng triển khai vào thực tế
                        var deTaiLyThuyet = deTaiBLL.GetDeTaiTheoreticalAndPractical();
                        Console.WriteLine("Danh sách đề tài lý thuyết có khả năng triển khai thực tế:");
                        foreach (var deTai in deTaiLyThuyet)
                        {
                            deTai.xuatThongTin();
                        }

                        // In ra danh sách đề tài có số câu hỏi khảo sát trên 100 câu
                        var deTaiTren100Cau = deTaiBLL.GetDeTaiWithSoCauHoiAbove(100);
                        Console.WriteLine("Danh sách đề tài có số câu hỏi khảo sát trên 100 câu:");
                        foreach (var deTai in deTaiTren100Cau)
                        {
                            deTai.xuatThongTin();
                        }

                        // In ra danh sách đề tài có thời gian thực hiện trên 4 tháng
                        var deTaiTren4Thang = deTaiBLL.GetDeTaiWithDurationMoreThan(4);
                        Console.WriteLine("Danh sách đề tài có thời gian thực hiện trên 4 tháng:");
                        foreach (var deTai in deTaiTren4Thang)
                        {
                            deTai.xuatThongTin();
                        }
                    }

                    static void AddNewDeTai(QLDeTai_BLL deTaiBLL)
                    {
                        Console.Write("Mã đề tài: ");
                        string maDeTai = Console.ReadLine();
                        Console.Write("Tên đề tài: ");
                        string tenDeTai = Console.ReadLine();
                        Console.Write("Kinh phí: ");
                        double kinhPhi = double.Parse(Console.ReadLine());
                        Console.Write("Chủ trì đề tài: ");
                        string chuTriDeTai = Console.ReadLine();
                        Console.Write("Ngày bắt đầu (yyyy-mm-dd): ");
                        DateTime ngayBatDau = DateTime.Parse(Console.ReadLine());
                        Console.Write("Ngày kết thúc (yyyy-mm-dd): ");
                        DateTime ngayKetThuc = DateTime.Parse(Console.ReadLine());
                        Console.Write("Giảng viên hướng dẫn: ");
                        string giangVienHuongDan = Console.ReadLine();
                        Console.Write("Số câu hỏi khảo sát: ");
                        int soCauHoiKhaoSat = int.Parse(Console.ReadLine());
                        Console.Write("Áp dụng thực tế (true/false): ");
                        bool apDungThucTe = bool.Parse(Console.ReadLine());

                        var newDeTai = new DeTaiNCLT_DTO
                        {
                            MaDeTai = maDeTai,
                            TenDeTai = tenDeTai,
                            KinhPhi = kinhPhi,
                            ChuTriDeTai = chuTriDeTai,
                            NgayBatDau = ngayBatDau,
                            NgayKetThuc = ngayKetThuc,
                            GiangVienHuongDan = giangVienHuongDan,
                            SoCauHoiKhaoSat = soCauHoiKhaoSat,
                            ApDungThucTe = apDungThucTe
                        };
                        deTaiBLL.AddDeTai(newDeTai);
                    }

                    static void SearchDeTai(QLDeTai_BLL deTaiBLL)
                    {
                        Console.Write("Nhập từ khóa tìm kiếm: ");
                        string keyword = Console.ReadLine();
                        var results = deTaiBLL.SearchDeTai(keyword);
                        Console.WriteLine("Kết quả tìm kiếm:");
                        foreach (var deTai in results)
                        {
                            deTai.xuatThongTin();
                        }
            */
        }

    }

}
