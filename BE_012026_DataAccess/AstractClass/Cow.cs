using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_012026.DataAccess.AstractClass
{
    public class Cow : Animal
    {
        public override void Eat()
        {
            Console.WriteLine("The cow is grazing on grass.");
        }
        public override void MakeSound()
        {
            Console.WriteLine("The cow says Moo!");
        }
    }
}
