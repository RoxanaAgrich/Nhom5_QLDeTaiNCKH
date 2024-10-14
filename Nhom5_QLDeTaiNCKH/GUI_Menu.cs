
using BLL_QLDeTaiNCKH;
using DTO_QLDeTaiNCKH;
using System;
using System.Globalization;
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
            string filePath = @"D:\\Visual studio\\MY_Clone\\Nhom5_QLDeTaiNCKH\\Nhom5_QLDeTaiNCKH\\DanhSachDeTai.xml";
            while (true)
            {
                Console.WriteLine("\n===== QUẢN LÝ ĐỀ TÀI =====");
                Console.WriteLine("1. Đọc và hiển thị  danh sách đề tài từ file XML");
                Console.WriteLine("2. Thêm đề tài mới");
                Console.WriteLine("3. Tìm kiếm đề tài");
                Console.WriteLine("4. Cập nhật kinh phí thực hiện tăng 10%");
                Console.WriteLine("5. Xuất danh sách các đề tài có kinh phí trên 10 triệu");
                Console.WriteLine("6. Xuất đề tài lý thuyết có khả năng triển khai thực tế");
                Console.WriteLine("7. Xuất đề tài kinh tế với số câu hỏi khảo sát > 100");
                Console.WriteLine("8. Xuất đề tài có thời gian thực hiện trên 4 tháng");
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
                        //Update kinh phí
                            deTaiBLL.UpdateKinhPhi();
                            deTaiBLL.DisplayDeTai();
                        break;
                    case "5":
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
                    case "6":
                        //Xuất danh sách các đề tài thuộc lĩnh vực nghiên cứu lý thuyết và có khả năng triển khai vào thực tế.
                        var deTaiPractical = deTaiBLL.GetDeTaiTheoreticalAndPractical();

                        if (deTaiPractical != null && deTaiPractical.Count > 0)
                        {
                            Console.WriteLine("Danh sách các đề tài thực tế:");
                            foreach (var deTai in deTaiPractical)
                            {
                                deTai.xuatThongTin();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Không có đề tài nào thực tế.");
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
    }
}
