using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
namespace POiG_lista_TO_DO.Model
{
    public class Serialization
    {
        //metoda zapisująca do pliku 
        public static void Serialize(string path, Studies studies)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Studies));
            using (Stream s = File.Create(path))
                serializer.Serialize(s, studies);
        }

        //metoda odczytująca z pliku
        public static Studies Deserialize(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Studies));
            Studies studies;
            using (Stream s = File.OpenRead(path))
                studies = (Studies)serializer.Deserialize(s);
            return studies;
        }
    }
}