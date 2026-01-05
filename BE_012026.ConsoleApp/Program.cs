using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_012026.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Bai1 bai1 = new Bai1();
            bai1.TongHaiSo();

            Bai1 bai1_hieu = new Bai1();
            bai1.HieuHaiSo();

            Bai1 bai1_tich = new Bai1();
            bai1.TichHaiSo();

            Bai2 bai2_pt1 = new Bai2();
            bai2_pt1.Pt_BacNhat();

            Bai2 bai2_pt2 = new Bai2();
            bai2_pt2.Pt_BacHai();

            Bai3 bai3 = new Bai3();
            bai3.Chuyen_Do();


        }
    }
}
