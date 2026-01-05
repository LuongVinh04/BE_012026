using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_012026.ConsoleApp
{
    public class Bai2
    {
        public void Pt_BacNhat()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Nhap he so a: ");
            string input_a = Console.ReadLine();
            Console.WriteLine("Nhap he so b: ");
            string input_b = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input_a) || string.IsNullOrWhiteSpace(input_b))
            {
                Console.WriteLine("Khong duoc de trong du lieu");
                return;
            }
            if (!double.TryParse(input_a, out double a) || !double.TryParse(input_b, out double b))
            {
                Console.WriteLine("Vui long nhap so");
                return;
            }
            if (a == 0)
            {
                if (b == 0)
                {
                    Console.WriteLine("Phuong trinh vo so nghiem");
                }
                else
                {
                    Console.WriteLine("Phuong trinh vo nghiem");
                }
            }
            else
            {
                double x = -b / a;
                Console.WriteLine("Nghiem cua phuong trinh la: x = " + x);
            }
            Console.WriteLine();
        }
        public void Pt_BacHai()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Nhap he so a: ");
            string input_a = Console.ReadLine();
            Console.WriteLine("Nhap he so b: ");
            string input_b = Console.ReadLine();
            Console.WriteLine("Nhap he so c: ");
            string input_c = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input_a) || string.IsNullOrWhiteSpace(input_b) || string.IsNullOrWhiteSpace(input_c))
            {
                Console.WriteLine("Khong duoc de trong du lieu");
                return;
            }
            if (!double.TryParse(input_a, out double a) || !double.TryParse(input_b, out double b) || !double.TryParse(input_c, out double c))
            {
                Console.WriteLine("Vui long nhap so");
                return;
            }
            if (a == 0)
            {
                // Gọi phương trình bậc nhất
                Bai2 bai2 = new Bai2();
                bai2.Pt_BacNhat();
                return;
            }
            double delta = b * b - 4 * a * c;
            if (delta < 0)
            {
                Console.WriteLine("Phuong trinh vo nghiem");
            }
            else if (delta == 0)
            {
                double x = -b / (2 * a);
                Console.WriteLine("Phuong trinh co nghiem kep: x1 = x2 = " + x);
            }
            else
            {
                double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                Console.WriteLine("Phuong trinh co hai nghiem phan biet: x1 = " + x1 + ", x2 = " + x2);
            }
            Console.WriteLine();
        }
    }
}
