using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpaceShooter
{
    /// <summary>
    /// Класс UfoYellow наследуется от класса Ufo и представляет желтую НЛО в игре
    /// </summary>
    class UfoYellow : Ufo
    {

        Lazer lazerUp;
        Lazer lazerDown;
        Lazer lazerLeft;
        Lazer lazerRight;

        Timer shootTimer = new Timer();

        Form gameScreen; // объект типа Form, на котором отрисовывается игра

        Random randomNum = new Random(); // объект типа Random, предназначенный для генерации случайных чисел

        /// <summary>
        /// Метод для создания объекта желтого НЛО на форме
        /// </summary>
        /// <param name="form">Форма</param>
        public override void SpawnUFO(Form form)
        {
            base.SpawnUFO(form);

            UFOSpawn.Left = randomNum.Next(-200, 1200);
            UFOSpawn.Top = randomNum.Next(-100, 0);
            gameScreen = form;
            UFOSpawn.Image = Properties.Resources.ufoYellow;
            gameScreen.Controls.Add(UFOSpawn);
            UFOSpawn.BringToFront();

            shootTimer.Interval = 1000;
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
                lazerUp = null;
                lazerDown = null;
                lazerLeft = null;
                lazerRight = null;
                shootTimer.Stop();
            }

            else
            {
                lazerUp = new LazerGreen();
                lazerDown = new LazerGreen();
                lazerLeft = new LazerGreen();
                lazerRight = new LazerGreen();

                lazerUp.Direction = Direction.up;
                lazerUp.LazerPosLeft = UFOSpawn.Left + (UFOSpawn.Width / 2);
                lazerUp.LazerPosTop = UFOSpawn.Top + (UFOSpawn.Height / 2);
                lazerUp.CreateLazer(gameScreen);

                lazerDown.Direction = Direction.down;
                lazerDown.LazerPosLeft = UFOSpawn.Left + (UFOSpawn.Width / 2);
                lazerDown.LazerPosTop = UFOSpawn.Top + (UFOSpawn.Height / 2);
                lazerDown.CreateLazer(gameScreen);

                lazerLeft.Direction = Direction.left;
                lazerLeft.LazerPosLeft = UFOSpawn.Left + (UFOSpawn.Width / 2);
                lazerLeft.LazerPosTop = UFOSpawn.Top + (UFOSpawn.Height / 2);
                lazerLeft.CreateLazer(gameScreen);

                lazerRight.Direction = Direction.right;
                lazerRight.LazerPosLeft = UFOSpawn.Left + (UFOSpawn.Width / 2);
                lazerRight.LazerPosTop = UFOSpawn.Top + (UFOSpawn.Height / 2);
                lazerRight.CreateLazer(gameScreen);
            }
        }
    }
}
