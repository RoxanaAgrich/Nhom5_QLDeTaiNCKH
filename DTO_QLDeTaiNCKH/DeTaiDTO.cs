using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DTO_QLDeTaiNCKH
{
    [XmlRoot("DeTaiListWrapper")]
    public class DeTaiListWrapper
    {
        [XmlArray("DeTaiList")]
        [XmlArrayItem("DeTai")]
        public List<DeTaiDTO> DeTaiList { get; set; } = new List<DeTaiDTO>();
    }

    public class DeTaiDTO
    {
        [XmlElement("MaDeTai")]
        public string MaDeTai { get; set; }
        [XmlElement("TenDeTai")]
        public string TenDeTai { get; set; }

        [XmlElement("KinhPhi")]
        public double KinhPhi { get; set; }

        [XmlElement("ChuTriDeTai")]
        public string ChuTriDeTai { get; set; }

        [XmlElement("NgayBatDau")]
        public DateTime NgayBatDau { get; set; }

        [XmlElement("NgayKetThuc")]
        public DateTime NgayKetThuc { get; set; }

        [XmlElement("GiangVienHuongDan")]
        public string GiangVienHuongDan { get; set; }

        [XmlElement("SoCauHoiKhaoSat")]
        public int SoCauHoiKhaoSat { get; set; }

        public virtual void xuatThongTin()
        {
            Console.WriteLine($"{MaDeTai,-15} {TenDeTai,-20} {KinhPhi,-10} {ChuTriDeTai,-15} {NgayBatDau.ToShortDateString(),-15} {NgayKetThuc.ToShortDateString(),-15} {GiangVienHuongDan,-15}");
        }
    }

    public class DeTaiNCLT_DTO : DeTaiDTO
    {
        public bool ApDungThucTe { get; set; }

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
