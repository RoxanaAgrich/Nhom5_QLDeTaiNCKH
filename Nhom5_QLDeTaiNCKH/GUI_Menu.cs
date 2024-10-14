
using BLL_QLDeTaiNCKH;
using DTO_QLDeTaiNCKH;
using System;
using System.Globalization;
using System.Linq;
using System.Text;


namespace Nhom5_QLDeTaiNCKH
{
    internal class GUI_Menu
    {
        public static void menu()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            QLDeTai_BLL deTaiBLL = new QLDeTai_BLL();
            string filePath = @"D:\Nhom5_QLDeTaiNCKH\Nhom5_QLDeTaiNCKH\DanhSachDeTai.xml";
            while (true)
            {
                Console.WriteLine("\n===== QUẢN LÝ ĐỀ TÀI =====");
                Console.WriteLine("1. Đọc và hiển thị  danh sách đề tài từ file XML");
                Console.WriteLine("2. Thêm đề tài mới");
                Console.WriteLine("3. Tìm kiếm đề tài khi biết tên đề tài / mã số/ tên người hướng dẫn/tên người chủ trì ");
                Console.WriteLine("4. Xuất danh sách cái đề tài khi biết tên giảng viên hướng dẫn  ");
                Console.WriteLine("5. Cập nhật kinh phí thực hiện tăng 10%");
                Console.WriteLine("6. Xuất danh sách các đề tài có kinh phí trên 10 triệu");
                Console.WriteLine("7. Xuất đề tài lý thuyết có khả năng triển khai thực tế");
                Console.WriteLine("8. Xuất đề tài kinh tế với số câu hỏi khảo sát > 100");
                Console.WriteLine("9. Xuất đề tài có thời gian thực hiện trên 4 tháng");
                Console.WriteLine("0. Thoát");

                Console.Write("Nhập lựa chọn: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Tải danh sách đề tài
                        deTaiBLL.LoadDeTai(filePath);
                        deTaiBLL.DisplayDeTai();
                        break;
                    case "2":

                        AddNewDeTai(deTaiBLL);
                        deTaiBLL.DisplayDeTai();
                        break;
                    case "3":

                        // Tìm kiếm đề tài
                        SearchDeTai(deTaiBLL);
                        break;
                    case "4":
                        // Tìm kiếm các  đề tài khi biết giao viên hướng dẫn 
                        SearchTopics(deTaiBLL);
                        break;
                    case "5":
                        //Update kinh phí
                        deTaiBLL.UpdateKinhPhi();
                        deTaiBLL.DisplayDeTai();
                        break;
                    case "6":
                        //Xuất danh sách các đề tài có kinh phí trên 10 triệu
                        var deTaiAbove = deTaiBLL.GetDeTaiWithKinhPhiAbove(10);
                        if (deTaiAbove != null && deTaiAbove.Count > 0)
                        {
                            Console.WriteLine("Danh sách các đề tài có kinh phí trên 10 triệu:");
                            foreach (var deTai in deTaiAbove)
                            {
                                deTai.xuatThongTin();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Không có đề tài nào có kinh phí trên 10 triệu.");
                        }
                        break;
                    case "7":
                        //Xuất đề tài lý thuyết có khả năng triển khai thực tế
                        var deTaiThucTe = deTaiBLL.GetDeTaiTheoreticalAndPractical();
                        if (deTaiThucTe != null && deTaiThucTe.Count > 0)
                        {
                            Console.WriteLine("Danh sách các đề tài lý thuyết có khả năng triển khai thực tế");
                            foreach (var deTai in deTaiThucTe)
                            {
                                deTai.xuatThongTin();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Không có đề tài lý thuyết có khả năng triển khai thực tế");
                        }
                        break;

                    case "8":
                        // Xuất danh sách đề tài có  số câu hỏi khảo sát > 100
                        var questionAbove  = deTaiBLL.GetDeTaiWithQuestionAbove(100);
                        if (questionAbove != null && questionAbove.Count > 0)
                        {
                            Console.WriteLine("Danh  sách đề tài có  số câu hỏi khảo sát > 100");
                            foreach (var deTai in questionAbove)
                            {
                                deTai.xuatThongTin();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Không có đề tài nào có  số câu hỏi khảo sát > 100.");
                        }
                        break;

                    case "9":
                        // Xuất đề tài có thời gian thực hiện trên 4 tháng
                        var topicsOver4Months = deTaiBLL.GetDeTaiWithTopicsOver4Months(4);
                        if (topicsOver4Months != null && topicsOver4Months.Count > 0)
                        {
                            Console.WriteLine("Danh  sách đề tài có  số câu hỏi khảo sát > 100");
                            foreach (var deTai in topicsOver4Months)
                            {
                                deTai.xuatThongTin();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Không có đề tài nào có thời gian thực hiện trên 4 tháng.");
                        }
                        break;
                    case "0": return;
                    default: Console.WriteLine("Lựa chọn không hợp lệ!"); break;
                }
            }
        }


        static void AddNewDeTai(QLDeTai_BLL deTaiBLL)
        {
            // Input for MaDeTai
            Console.Write("Mã đề tài: ");
            string maDeTai = Console.ReadLine();

            // Input for TenDeTai
            Console.Write("Tên đề tài: ");
            string tenDeTai = Console.ReadLine();

            // Input for KinhPhi with validation
            double kinhPhi;
            Console.Write("Kinh phí: ");
            while (!double.TryParse(Console.ReadLine(), out kinhPhi) || kinhPhi < 0)
            {
                Console.WriteLine("Vui lòng nhập số hợp lệ cho kinh phí (phải là số dương).");
            }

            // Input for ChuTriDeTai
            Console.Write("Chủ trì đề tài: ");
            string chuTriDeTai = Console.ReadLine();

            // Input for NgayBatDau with date validation
            DateTime ngayBatDau;
            Console.Write("Ngày bắt đầu (yyyy-mm-dd): ");
            string inputBatDau = Console.ReadLine();
            while (!DateTime.TryParseExact(inputBatDau, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngayBatDau))
            {
                Console.WriteLine("Định dạng không hợp lệ. Vui lòng nhập lại (yyyy-mm-dd): ");
                inputBatDau = Console.ReadLine();
            }

            // Input for NgayKetThuc with date validation
            DateTime ngayKetThuc;
            Console.Write("Ngày kết thúc (yyyy-mm-dd): ");
            string inputKetThuc = Console.ReadLine();
            while (!DateTime.TryParseExact(inputKetThuc, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngayKetThuc) || ngayKetThuc < ngayBatDau)
            {
                Console.WriteLine("Định dạng không hợp lệ hoặc ngày kết thúc phải sau ngày bắt đầu. Vui lòng nhập lại (yyyy-mm-dd): ");
                inputKetThuc = Console.ReadLine();
            }

            // Input for GiangVienHuongDan
            Console.Write("Giảng viên hướng dẫn: ");
            string giangVienHuongDan = Console.ReadLine();

            // Input for SoCauHoiKhaoSat with validation
            int soCauHoiKhaoSat;
            Console.Write("Số câu hỏi khảo sát: ");
            while (!int.TryParse(Console.ReadLine(), out soCauHoiKhaoSat) || soCauHoiKhaoSat < 0)
            {
                Console.WriteLine("Vui lòng nhập số hợp lệ cho số câu hỏi khảo sát (phải là số nguyên dương).");
            }

            // Input for ApDungThucTe with validation
            bool apDungThucTe;
            Console.Write("Áp dụng thực tế (true/false): ");
            while (!bool.TryParse(Console.ReadLine(), out apDungThucTe))
            {
                Console.WriteLine("Vui lòng nhập 'true' hoặc 'false' cho áp dụng thực tế.");
            }

            // Creating new DeTaiNCLT_DTO instance
            var newDeTai = new DeTaiDTO()
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

            // Adding the new DeTai to the BLL
            deTaiBLL.AddDeTai(newDeTai);

        }
        static void SearchDeTai(QLDeTai_BLL deTaiBLL)
        {
            Console.Write("Nhập từ khóa tìm kiếm: ");
            string keyword = Console.ReadLine();
            var results = deTaiBLL.SearchDeTai(keyword);
            Console.WriteLine("Kết quả tìm kiếm:");
            if (results != null)
            {
                foreach (var deTai in results)
                {
                    deTai.xuatThongTin();
                }
            }
            else
            {
                Console.WriteLine("Khong tim thấy");
            }

        }
        static void SearchTopics(QLDeTai_BLL deTaiBLL)
        {
            Console.Write("Nhập tên  giáo viên hướng dẫn  ");
            string giang_vien    = Console.ReadLine();
            var results = deTaiBLL.GetTopicsByLecturer(giang_vien);
            Console.WriteLine("Kết quả tìm kiếm:");
            if (results != null && results.Any())
            {
                Console.WriteLine($"Danh sach de tai do giang vien {giang_vien}  \t ");
                foreach (var deTai in results)
                {
                    Console.WriteLine($"{deTai.TenDeTai} \t");
                }
            }
            else
            {
                Console.WriteLine("Khong tim thấy");
            }

        }
    }
}
