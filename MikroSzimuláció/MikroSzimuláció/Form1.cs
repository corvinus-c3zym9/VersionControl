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
        Random rng = new Random(1234); //1234-től generáljon véletlenszámokat

        List<Person> Population = null;
        List<BirthProbability> BirthProbabilities = null;
        List<DeathProbability> DeathProbabilities = null;

        public Form1()
        {
            InitializeComponent();

            Population = GetPopulation(@"C:\Users\User\Desktop\BCE\5\IRF\Temp\nép-teszt.csv"); //C:\Users\User\Desktop\BCE\5\IRF\Temp
            BirthProbabilities = GetBirthProbabilities(@"C:\Users\User\Desktop\BCE\5\IRF\Temp\születés.csv");
            DeathProbabilities = GetDeathProbabilities(@"C:\Users\User\Desktop\BCE\5\IRF\Temp\halál.csv");
            
            
            // Végigmegyünk a vizsgált éveken
            for (int year = 2005; year <= 2024; year++)
            {
                // Végigmegyünk az összes személyen
                for (int i = 0; i < Population.Count; i++)
                {
                    // Ide jön a szimulációs lépés
                }

                int nbrOfMales = (from x in Population
                                  where x.Gender == Gender.Male && x.IsAlive
                                  select x).Count();
                int nbrOfFemales = (from x in Population
                                    where x.Gender == Gender.Female && x.IsAlive
                                    select x).Count();
                Console.WriteLine(
                    string.Format("Év:{0} Fiúk:{1} Lányok:{2}", year, nbrOfMales, nbrOfFemales));
            }
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

        //lemásoljuk a GetPopulation függvényt
        public List<BirthProbability> GetBirthProbabilities(string csvpath) //létrehozunk egy változót
        {
            List<BirthProbability> population = new List<BirthProbability>(); //létrehozunk egy függvényt

            using (var sr = new StreamReader(csvpath, Encoding.Default))
            {
                //ha lenne header, akkor sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    population.Add(new BirthProbability()
                    {
                        Age = int.Parse(line[0]),
                        NbrOfChildren = int.Parse(line[1]),
                        P = double.Parse(line[2])
                    });
                }
            }

            return population; //visszaadjuk a belső függvény értékét
        }

        //lemásoljuk a GetPopulation függvényt
        public List<DeathProbability> GetDeathProbabilities(string csvpath) //létrehozunk egy változót
        {
            List<DeathProbability> population = new List<DeathProbability>(); //létrehozunk egy függvényt

            using (var sr = new StreamReader(csvpath, Encoding.Default))
            {
                //ha lenne header, akkor sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    population.Add(new DeathProbability()
                    {
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[0]),
                        Age = int.Parse(line[1]),
                        P = double.Parse(line[2])
                    });
                }
            }

            return population; //visszaadjuk a belső függvény értékét
        }

        
    }
}
