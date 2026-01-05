using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_012026.ConsoleApp
{
    public class Bai3
    {
        public void Chuyen_Do()
        {
            Console.WriteLine("Nhap vao nhiet do: ");
            string input_temp = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input_temp))
            {
                Console.WriteLine("Khong duoc de trong du lieu");
                return;
            }
            if (!double.TryParse(input_temp, out double c))
            {
                Console.WriteLine("Vui long nhap so");
                return;
            }
            double k = c + 273.15;
            double f = (c * 9 / 5) + 32;

            Console.WriteLine($"Nhiet do k: {k} ");
            Console.WriteLine($"Nhiet do f: {f} ");

        }
    }
}
