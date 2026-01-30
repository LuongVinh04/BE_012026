using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_012026.DataAccess.AstractClass
{
    public class Bird : Animal
    {
        public override void Eat()
        {
            Console.WriteLine("The bird is pecking at seeds.");
        }
        public override void MakeSound()
        {
            Console.WriteLine("The bird chirps melodiously.");
        }
    }
}
