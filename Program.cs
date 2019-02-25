using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HW2402_Serializatin
{
    class Program
    {
        static void Main(string[] args)
        {
            Car c1 = new Car("Volvo", 600, 2017, "Brown", 3229, 10);
            XmlSerializer myXmlSerializer = new XmlSerializer(typeof(Car));
            Car c2;
            Car[] cars =
            {
                new Car("Suzuki", 500, 2020, "Green", 5478, 5),
                new Car("Mitsu", 2502, 2016, "Yellow", 4321, 7),
                new Car("Ferari", 332, 2018, "Blue", 2489, 4)
            };
            
            /*Stage A
             * 
             Car c1 = new Car("Suzuki", 500, 2020, "Green", 5478, 5);

            XmlSerializer myXmlSerializer = new XmlSerializer(typeof(Car));
            using (stream file = new filestream(@"d:\temppp\carxmlfile.xml", filemode.create))
            {
                myxmlserializer.serialize(file, c1);
            }

            Car c2;
            using (Stream file = new FileStream(@"d:\Temppp\CarXmlFile.xml", FileMode.Open))
            {
                c2 = myXmlSerializer.Deserialize(file) as Car;
            }
            
            Car[] cars =
            {
                new Car("Suzuki", 500, 2020, "Green", 5478, 5),
                new Car("Mitsu", 2502, 2016, "Yellow", 4321, 7),
                new Car("Ferari", 332, 2018, "Blue", 2489, 4)
            };
            XmlSerializer myXmlSerializer = new XmlSerializer(typeof(Car[]));
            using (Stream file = new FileStream(@"d:\Temppp\CarArrayXmlFile.xml", FileMode.Create))
            {
                myXmlSerializer.Serialize(file, cars);
            }

            Car[] carsFromFile;
            using (Stream file = new FileStream(@"d:\Temppp\CarArrayXmlFile.xml", FileMode.Open)) // creating new file stream
            {
                carsFromFile = myXmlSerializer.Deserialize(file) as Car[];
            }
            */

            //Stage B:
            string fileNameCar = @"d:\temppp\carxmlfile2.xml";
            Car.SerializeACar(fileNameCar, c1);
            c2 = Car.DeserializeACar(fileNameCar);

            string fileNameCarArr = @"d:\temppp\carxmlArrayfile2.xml";
            Car.SerializerCarArray(fileNameCarArr, cars);
            Car[] carsFromFile = Car.DeserializerCarArray(fileNameCarArr);

            Car c3 = new Car(fileNameCar);
            bool check1 = c3.CarCompare(fileNameCar);
            bool check2 = c3.CarCompare(@"d:\temppp\carxmlfile.xml");

            Console.WriteLine($"check 1 {check1}, check 2 {check2}");

            Console.ReadKey();
        }
    }
}
