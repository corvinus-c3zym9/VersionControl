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

            
            BirthProbabilities = GetBirthProbabilities(@"C:\Users\User\Desktop\BCE\5\IRF\Temp\születés.csv");
            DeathProbabilities = GetDeathProbabilities(@"C:\Users\User\Desktop\BCE\5\IRF\Temp\halál.csv");

            
        }

        private void StartSimulation(int endYear, string csvPath)
        {
            Population = GetPopulation(@"C:\Users\User\Desktop\BCE\5\IRF\Temp\nép-teszt.csv"); //C:\Users\User\Desktop\BCE\5\IRF\Temp

            // Végigmegyünk a vizsgált éveken
            for (int year = 2005; year <= endYear; year++)
            {
                // Végigmegyünk az összes személyen
                for (int i = 0; i < Population.Count; i++)
                {
                    // Ide jön a szimulációs lépés
                    SimStep(year, Population[i]);
                }

                int nbrOfMales = (from x in Population
                                  where x.Gender == Gender.Male && x.IsAlive
                                  select x).Count();
                int nbrOfFemales = (from x in Population
                                    where x.Gender == Gender.Female && x.IsAlive
                                    select x).Count();
               richTextBox1.Text += (
                    string.Format("Szimuláció éve:{0}\n\tFiúk:{1}\n\tLányok:{2}\n\t", year, nbrOfMales, nbrOfFemales));
            }
        }

        private void SimStep(int year, Person person)
        {
            //Ha halott akkor kihagyjuk, ugrunk a ciklus következő lépésére
            if (!person.IsAlive) return;

            // Letároljuk az életkort, hogy ne kelljen mindenhol újraszámolni
            byte age = (byte)(year - person.BirthYear);

            // Halál kezelése
            // Halálozási valószínűség kikeresése
            double pDeath = (from x in DeathProbabilities
                             where x.Gender == person.Gender && x.Age == age
                             select x.P).FirstOrDefault();
            // Meghal a személy?
            if (rng.NextDouble() <= pDeath)
                person.IsAlive = false;

            //Születés kezelése - csak az élő nők szülnek
            if (person.IsAlive && person.Gender == Gender.Female)
            {
                //Szülési valószínűség kikeresése
                double pBirth = (from x in BirthProbabilities
                                 where x.Age == age
                                 select x.P).FirstOrDefault();
                //Születik gyermek?
                if (rng.NextDouble() <= pBirth)
                {
                    Person újszülött = new Person();
                    újszülött.BirthYear = year;
                    újszülött.NbrOfChildren = 0;
                    újszülött.Gender = (Gender)(rng.Next(1, 3));
                    Population.Add(újszülött);
                }
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

        private void button2_Click(object sender, EventArgs e)
        {
            StartSimulation((int)numericUpDown1.Value, textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            textBox1.Text = ofd.FileName;
        }
    }
}
