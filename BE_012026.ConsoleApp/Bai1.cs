using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_012026.ConsoleApp
{
    public class Bai1
    {
        public void TongHaiSo()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Nhap so thu nhat: ");
            string input_a = Console.ReadLine();
            Console.WriteLine("Nhap so thu hai: ");
            string input_b = Console.ReadLine();
            if (!double.TryParse(input_a, out double a) || !double.TryParse(input_b, out double b))
            {
                Console.WriteLine("Vui long nhap so");
                return;
            }

            Console.WriteLine("Tong hai so la: " + (a + b));
            Console.WriteLine();
        }
        public void HieuHaiSo()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Nhap so thu nhat: ");
            string input_a = Console.ReadLine();
            Console.WriteLine("Nhap so thu hai: ");
            string input_b = Console.ReadLine();
            if (!double.TryParse(input_a, out double a) || !double.TryParse(input_b, out double b))
            {
                Console.WriteLine("Vui long nhap so");
                return;
            }

            Console.WriteLine("Tong hai so la: " + (a - b));
            Console.WriteLine();
        }
        public void TichHaiSo()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Nhap so thu nhat: ");
            string input_a = Console.ReadLine();
            Console.WriteLine("Nhap so thu hai: ");
            string input_b = Console.ReadLine();
            if (!double.TryParse(input_a, out double a) || !double.TryParse(input_b, out double b))
            {
                Console.WriteLine("Vui long nhap so");
                return;
            }
            Console.WriteLine("Tong hai so la: " + (a * b));
            Console.WriteLine();
        }
    }
}
