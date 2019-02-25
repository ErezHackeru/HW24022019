using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HW2402_Serializatin
{
    public class Car
    {
        public string Model { get; set; }
        public int Brand { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        private int codan;
        protected int numberOfSeats;
        

        public Car()
        {

        }

        public Car(string fileName)
        {
            XmlSerializer myXmlSerializer = new XmlSerializer(typeof(Car));
            Car c2;
            using (Stream file = new FileStream(fileName, FileMode.Open))
            {
                c2 = myXmlSerializer.Deserialize(file) as Car;
            }
            Model = c2.Model;
            Brand = c2.Brand;
            Year = c2.Year;
            Color = c2.Color;
            this.codan = c2.codan;
            this.numberOfSeats = c2.numberOfSeats;
        }
        public Car(string model, int brand, int year, string color, int codan, int numberOfSeats)
        {
            Model = model;
            Brand = brand;
            Year = year;
            Color = color;
            this.codan = codan;
            this.numberOfSeats = numberOfSeats;
        }

        public override string ToString()
        {
            return $"Car model {Model}, brand {Brand}, year {Year}, color {Color}, codan {codan}, numberOfSeats {numberOfSeats}";
        }

        public int GetCodan()
        {
            return codan;
        }

        public int GetNumberOfSeats()
        {
            return numberOfSeats;
        }

        protected void ChangeNumberOfSeats(int newNumOfSeats)
        {
            this.numberOfSeats = newNumOfSeats;
        }

        public bool CarCompare(string fileName)
        {
            Car carToCompare = DeserializeACar(fileName);
            return ((this.Model == carToCompare.Model) && (this.Brand == carToCompare.Brand) &&
                (this.Color == carToCompare.Color) && (this.Year == carToCompare.Year));
        }

        //===========================
        //Static Part of the Class
        //===========================
        public static void SerializeACar(string fileName, Car car)
        {
            XmlSerializer myXmlSerializer = new XmlSerializer(typeof(Car));
            using (Stream file = new FileStream(fileName, FileMode.Create))
            {
                myXmlSerializer.Serialize(file, car);
            }
        }
        public static void SerializerCarArray(string fileName, Car[] cars)
        {
            XmlSerializer myXmlSerializer = new XmlSerializer(typeof(Car[]));
            using (Stream file = new FileStream(fileName, FileMode.Create))
            {
                myXmlSerializer.Serialize(file, cars);
            }
        }
        public static Car DeserializeACar(string fileName)
        {
            Car c2;
            XmlSerializer myXmlSerializer = new XmlSerializer(typeof(Car));
            using (Stream file = new FileStream(fileName, FileMode.Open))
            {
                c2 = myXmlSerializer.Deserialize(file) as Car;
            }
            return c2;
        }
        public static Car[] DeserializerCarArray(string fileName)
        {
            Car[] carsFromFile;
            XmlSerializer myXmlSerializer = new XmlSerializer(typeof(Car[]));
            using (Stream file = new FileStream(fileName, FileMode.Open)) // creating new file stream
            {
                carsFromFile = myXmlSerializer.Deserialize(file) as Car[];
            }
            return carsFromFile;
        }
        
    }
}
