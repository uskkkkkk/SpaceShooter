using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpaceShooter
{
    /// <summary>
    /// Класс отвечает за движение вражеских объектов 
    /// </summary>
    public class EnemyMovement
    {
        SpaceShooter gameScreen;

        Timer gameTime = new Timer();

        int speed = 1;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="game"> Экземпляр игры, на котором происходит движение врагов</param>
        public EnemyMovement(SpaceShooter game)
        {
            gameScreen = game;

            gameTime.Interval = 20000;
            gameTime.Start();
            gameTime.Tick += new EventHandler(GameTick);
        }

        /// <summary>
        /// Метод для перемещения НЛО на игровом экране
        /// </summary>
        public void MoveUFO()
        {
            foreach (Control x in gameScreen.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "ufo")
                {
                    if (x.Left > gameScreen.player.Left)
                    {
                        x.Left -= speed;
                    }

                    if (x.Left < gameScreen.player.Left)
                    {
                        x.Left += speed;
                    }

                    if (x.Top > gameScreen.player.Top)
                    {
                        x.Top -= speed;
                    }

                    if (x.Top < gameScreen.player.Top)
                    {
                        x.Top += speed;
                    }
                }
            }
        }

        /// <summary>
        /// Обработчик события, происходящего каждые 20 секунд. 
        /// Увеличивает скорость движения врагов на 1 единицу
        /// </summary>
        /// <param name="sender">Объект, который вызвал событие</param>
        /// <param name="e">аргумент события</param>
        private void GameTick(object sender, EventArgs e)
        {
            speed++;
        }
    }
}
