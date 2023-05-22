using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter
{
    /// <summary>
    /// Класс LazerRed наследуется от класса Lazer 
    /// и переопределяет метод CreateLazer для создания красного лазера для игрока
    /// </summary>
    class LazerRed : Lazer
    {
        /// <summary>
        /// Метод устанавливает изображение красного лазера для игрока, устанавливает тег для созданного лазера 
        /// и вызывает метод CreateLazer базового класса для отображения лазера на форме 
        /// </summary>
        /// <param name="form">Форма</param>
        public override void CreateLazer(Form form)
        {
            if (Direction == Direction.left)
            {
                CurrentLazer.Image = Properties.Resources.laserLeft;
            }

            if (Direction == Direction.right)
            {
                CurrentLazer.Image = Properties.Resources.laserRight;
            }

            if (Direction == Direction.up)
            {
                CurrentLazer.Image = Properties.Resources.laserUp;
            }

            if (Direction == Direction.down)
            {
                CurrentLazer.Image = Properties.Resources.laserDown;
            }

            CurrentLazer.Tag = "playerLazer";

            base.CreateLazer(form);

        }
    }
}
