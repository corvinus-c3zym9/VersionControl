using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroSzimuláció.Entities
{
    public class Person
    {
        public int BirthYear { get; set; }
        public Gender Gender { get; set; }
        public int NbrOfChildren { get; set; }
        public bool IsAlive { get; set; }

        //bool változókat szokás IS-zel kezdeni
        //a boolra azért van szükség, hogyha esetleg meghalnak emberek adott évben pl össze lehessen számolni és nem törlődjön automatikusan

        public Person()
        {
            IsAlive = true;
        }
    }
}
