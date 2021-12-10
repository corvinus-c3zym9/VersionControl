using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldsHardestGame;

namespace EvolutionExample
{
    public partial class Form1 : Form
    {
        GameController gc = new GameController(); //ezt hivatkozva tudunk új játékot indítani
        GameArea ga = null;

        int populationSize = 100; //hány darab populációt hozunk létre
        int nbrOfSteps = 10; //hány lépést tehet egy játékos
        int nbrOfStepsIncrement = 10;
        int generation = 1;

        public Form1()
        {
            InitializeComponent();

            gc.GameOver += Gc_GameOver; //ez akkor fog lefutni, ha az összes aktív játékos meghalt

            ga = gc.ActivateDisplay(); //bekapcsolja a mostani game area példányt
            this.Controls.Add(ga);

            for (int i = 0; i < populationSize; i++) //annyi darab legyen, mint ahány populáció
            {
                gc.AddPlayer(nbrOfSteps); //hozzáadunk egy új játékost
            }

            gc.Start(false); //elindítja a játékot és ha igaz akkor gépileg lehet irányítani a játékot
        }

        private void Gc_GameOver(object sender)
        {
            generation++;
            label1.BringToFront(); //játék elé tehetjük a labelt
            label1.Text = generation.ToString() + ". generáció";

            //label1.Text = string.Format(
            //    "{0}. generáció",
            //    generation);

            var playerList = from p in gc.GetCurrentPlayers()
                             orderby p.GetFitness() descending
                             select p; //legjobb teljesítmény alapján sorrendbe rendezzük

            var topPerformers = playerList.Take(populationSize/2).ToList(); //a legjobb 50 db kell nekünk
            //a ToList nagyon fontos lépés
            //A játékosok listájának lekérdezése egy referencia típusú változót ad eredményül.
            //A továbbiakban a játékot újra fogjuk indítani, és az új játék járékoslistáját ez alapján a lista alapján szeretnénk felépíteni.
            //Az újraindítás azonban törölni fogja az eredeti játékoslistát, így a referencia típusú listánk is kiürülne, tehát nem férnénk hozzá a lementett játékosainkhoz.
            //A ToList metódus hivatkozás helyett egy új listát generál, amely a megfelelő játékosokra hivatkozik, így már nem jelent problémát, hogy az eredeti lista időközben kiürül.

            gc.ResetCurrentLevel();
            foreach (var p in topPerformers)
            {
                //var brain = p.Brain.Clone();
                //gc.AddPlayer(brain);
                //gc.AddPlayer(brain.Mutate()); //fogjuk a legjobb játékost és újra hozzáadjuk egy kis mutációval

                var b = p.Brain.Clone();
                if (generation % 3 == 0)
                    gc.AddPlayer(b.ExpandBrain(nbrOfStepsIncrement));
                else
                    gc.AddPlayer(b);

                if (generation % 3 == 0)
                    gc.AddPlayer(b.Mutate().ExpandBrain(nbrOfStepsIncrement));
                else
                    gc.AddPlayer(b.Mutate());
            }
            gc.Start();
        }
    }
}
