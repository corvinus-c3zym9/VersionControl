using MikroSzimuláció.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MikroSzimuláció
{
    public partial class Form1 : Form
    {
        List<Person> Population = null;
        List<BirthProbability> BirthProbabilities = null;
        List<DeathProbability> DeathProbabilities = null;

        public Form1()
        {
            InitializeComponent();

            Population = GetPopulation(@"C:\Temp\nép-teszt.csv");
            //BirthProbabilities = GetBirthProbabilities(@"C:\Temp\születés.csv");
            //DeathProbabilities = GetDeathProbabilities(@"C:\Temp\halál.csv");
        }

        public List<Person> GetPopulation(string csvpath) //létrehozunk egy változót
        {
            List<Person> population = new List<Person>(); //létrehozunk egy függvényt

            using (var sr = new StreamReader(csvpath, Encoding.Default))
            {
                //ha lenne header, akkor sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    population.Add(new Person()
                    {
                        BirthYear = int.Parse(line[0]),
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[1]),
                        NbrOfChildren = int.Parse(line[2])
                    });
                }
            }

            return population; //visszaadjuk a belső függvény értékét
        }

    }
}
