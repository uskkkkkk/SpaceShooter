using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpaceShooter
{
    /// <summary>
    /// Класс отвечает за спавн объектов на игровом поле
    /// </summary>
    public class SpawnManager
    {
        SpaceShooter gameScreen; // экземпляр игрового поля
        Random randomSpawn = new Random(); // случайный генератор для задания времени спавна объектов
        Timer spawnTimer = new Timer(); // таймер для спавна объектов
        Pill pill;
        bool isPill = false;  // флаг, есть ли на поле лекарство

        public bool IsPill { get => isPill; set => isPill = value; }

        /// <summary>
        /// Конструктор класса SpawnManager
        /// </summary>
        /// <param name="game">Игровое поле</param>
        public SpawnManager(SpaceShooter game)
        {
            gameScreen = game;

            spawnTimer.Interval = 1000; // интервал времени между спавнами
            spawnTimer.Tick += new EventHandler(SpawnTick);
            spawnTimer.Start();
        }

        /// <summary>
        /// Метод вызывается каждый раз, когда сработает таймер 
        /// В нем реализована логика спавна объектов
        /// </summary>
        /// <param name="sender">Объект, который вызвал событие</param>
        /// <param name="e">Объект KeyEventArgs, содержащий информацию о событии нажатия клавиши</param>
        private void SpawnTick(object sender, EventArgs e)
        {
            if (randomSpawn.Next(0, 1000) < 500)
            {
                if (!IsPill)
                {
                    SpawnPill();
                }
            }

            if (randomSpawn.Next(0, 1000) < 100)
            {
                SpawnYellowUFO();
            }

            if (randomSpawn.Next(0, 2000) < 100)
            { 
                SpawnRedUFO();
            }
        }

        /// <summary>
        /// Метод создает желтый НЛО на игровом поле
        /// </summary>
        private void SpawnYellowUFO()
        {
            Ufo ufo = new UfoYellow();
            ufo.SpawnUFO(gameScreen);
        }

        /// <summary>
        /// Метод создает красный НЛО на игровом поле
        /// </summary>
        private void SpawnRedUFO()
        {
            Ufo ufo = new UfoRed();
            ufo.SpawnUFO(gameScreen);
        }

        /// <summary>
        /// Метод создает лекарство на игровом поле
        /// </summary>
        private void SpawnPill()
        {
            pill = new Pill();

            pill.PillPosLeft = randomSpawn.Next(20, gameScreen.ClientSize.Width - pill.PillSpawn.Width);
            pill.PillPosTop = randomSpawn.Next(20, gameScreen.ClientSize.Height - pill.PillSpawn.Height);

            pill.SpawnPill(gameScreen);

            IsPill = true;
        }
    }
}
