using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_012026.ConsoleApp.Class
{
    public class Car
    {
        //get de lay gia tri, set de gan gia tri
        public int Id { set; get; }
        public string Brand { set; get; }   
        public string Color { set; get; }
        public string Model { set; get; }
        public int Year { set; get; }

        //phuong thuc khoi tao khong tham so
        public Car()
        {
        }


        //phuong thuc khoi tao co tham so
        public Car(int id, string brand, string color, string model, int year)
        {
            Id = id;
            Brand = brand;
            Color = color;
            Model = model;
            Year = year;
        }


        //phuong thuc hien thi thong tin xe
        public void DisplayInfo()
        {
            Console.WriteLine($"Car ID: {Id}");
            Console.WriteLine($"Brand: {Brand}");
            Console.WriteLine($"Color: {Color}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Year: {Year}");
        }
    }
}
