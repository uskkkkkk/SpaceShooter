 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter
{
    /// <summary>
    /// Класс отвечает за обнаружение столкновений в игре
    /// </summary>
    public class CollisionManager
    {
        SpaceShooter gameScreen;

        /// <summary>
        /// Конструктор класса CollisionManager
        /// </summary>
        /// <param name="game">Игровое поле</param>
        public CollisionManager(SpaceShooter game)
        {
            gameScreen = game;
        }

        /// <summary>
        /// Метод проходится по всем элементам на экране игры 
        /// и вызывает соответствующие методы, в зависимости от типа объекта
        /// </summary>
        public void DetectCollision()
        {
            foreach (Control x in gameScreen.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "pill")
                {
                    PillHit(x);
                }

                foreach (Control y in gameScreen.Controls)
                {
                    if (y is PictureBox && (string)y.Tag == "playerLazer" && x is PictureBox && (string)x.Tag == "ufo")
                    {
                        UfoHit(y, x);
                    }

                    if (y is PictureBox && (string)y.Tag == "player" && x is PictureBox && (string)x.Tag == "enemyLazer")
                    {
                        PlayerHit(y, x);
                    }

                    if (y is PictureBox && (string)y.Tag == "playerLazer" && x is PictureBox && (string)x.Tag == "ufo")
                    {
                        PlayerHit(y, x);
                    }
                }
            }
        }

        /// <summary>
        /// Метод PillHit удаляет объект типа "pill" 
        /// и увеличивает защиту игрока на 20 единиц, если игрок сталкивается с ним
        /// </summary>
        /// <param name="x">объект, представляющий игрока на игровом экране</param>
        public void PillHit(Control x)
        {
            if (gameScreen.player.Bounds.IntersectsWith(x.Bounds) && gameScreen.PlayerShield < 80)
            {
                gameScreen.Controls.Remove(x);
                ((PictureBox)x).Dispose();
                gameScreen.SpawnManage.IsPill = false;
                gameScreen.PlayerShield += 20;

            }

        }

        /// <summary>
        /// Метод удаляет объект типа "ufo" и "playerLazer" 
        /// и увеличивает счет игрока на 10 единиц, если они сталкиваются
        /// </summary>
        /// <param name="x">объект, представляющий игрока на игровом экране</param>
        /// <param name="y">объект, представляющий объект врага на игровом экране</param>
        public void UfoHit(Control x, Control y)
        {
            if (x.Bounds.IntersectsWith(y.Bounds))
            {
                gameScreen.Controls.Remove(x);
                ((PictureBox)x).Dispose();
                gameScreen.Controls.Remove(y);
                ((PictureBox)y).Dispose();
                gameScreen.Score += 10;
            }
        }

        /// <summary>
        /// Метод уменьшает защиту игрока на 5 единиц, 
        /// если объект типа "player" и "enemyLazer" сталкиваются
        /// </summary>
        /// <param name="x">объект, представляющий игрока на игровом экране</param>
        /// <param name="y">объект, представляющий объект врага на игровом экране</param>
        public void PlayerHit(Control x, Control y)
        {
            if (x.Bounds.IntersectsWith(y.Bounds))
            {
                gameScreen.Controls.Remove(y);
                ((PictureBox)y).Dispose();
                gameScreen.PlayerShield -= 5;
            }
        }
    }
}
