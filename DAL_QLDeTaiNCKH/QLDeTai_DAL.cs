using DTO_QLDeTaiNCKH;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace DAL_QLDeTaiNCKH
{
    public class QLDeTai_DAL
    {
        public List<DeTaiDTO> ReadFileXML(string filePath)
        {
            Console.WriteLine(Path.GetFullPath(filePath));

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File không tồn tại.");
                return new List<DeTaiDTO>();
            }

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(DeTaiListWrapper));

                using (StreamReader reader = new StreamReader(filePath))
                {
                    var wrappedData = (DeTaiListWrapper)serializer.Deserialize(reader);
                    return wrappedData.DeTaiList;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi đọc file XML: " + ex.Message);
                return new List<DeTaiDTO>();
            }
        }
    }
}
