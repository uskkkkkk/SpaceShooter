using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter
{
    /// <summary>
    /// Класс UfoRed наследуется от класса Ufo и представляет желтую НЛО в игре
    /// </summary>
    internal class UfoRed: Ufo
    {
        Lazer lazerLeft;

        Timer shootTimer = new Timer();
        Form gameScreen;
        Random random = new Random();

        /// <summary>
        /// Метод для создания объекта красного НЛО на форме
        /// </summary>
        /// <param name="form">Форма</param>
        public override void SpawnUFO(Form form)
        {
            base.SpawnUFO(form);

            gameScreen = form;

            UFOSpawn.Left = random.Next(1000, 1200);
            UFOSpawn.Top = random.Next(200, 600);

            UFOSpawn.Image = Properties.Resources.ufoRed;
            gameScreen.Controls.Add(UFOSpawn);
            UFOSpawn.BringToFront();

            shootTimer.Interval = 1200;
            shootTimer.Tick += new EventHandler(ShootTick);
            shootTimer.Start();
        }

        /// <summary>
        /// Метод отвечает за выстрелы из НЛО
        /// </summary>
        /// <param name="sender">объект-источник события</param>
        /// <param name="e">аргументы события</param>
        private void ShootTick(object sender, EventArgs e)
        {
            if (!gameScreen.Controls.Contains(UFOSpawn))
            {
                lazerLeft = null;

                shootTimer.Stop();
            }

            else
            {
                lazerLeft = new LazerRedBig();

                lazerLeft.Direction = Direction.left;
                lazerLeft.LazerPosLeft = UFOSpawn.Left + (UFOSpawn.Width / 2);
                lazerLeft.LazerPosTop = UFOSpawn.Top + (UFOSpawn.Height / 2);
                lazerLeft.CreateLazer(gameScreen);
            }
        }
    }
}
