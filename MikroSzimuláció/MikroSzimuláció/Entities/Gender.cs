using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroSzimuláció.Entities
{
    public enum Gender
    {
        Male = 1,
        Female = 2
    }
    //mostantól férfi érték = Gender.Male
    //női nem --> Gender évaNeme = (Gender)2 (átkasztoljuk a 2-es megadott értéket
    // + egyszerűbb if --> if(évaNeme == Gender.Female)
}
