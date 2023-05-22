using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter
{
    /// <summary>
    /// Метод устанавливает изображение зеленого лазера для НЛО, устанавливает тег для созданного лазера 
    /// и вызывает метод CreateLazer базового класса для отображения лазера на форме 
    /// </summary>
    /// <param name="form">Форма</param>
    class LazerGreen : Lazer
    {
        public override void CreateLazer(Form form)
        {
            if (Direction == Direction.left)
            {
                CurrentLazer.Image = Properties.Resources.laserGreenLeft;
            }

            if (Direction == Direction.right)
            {
                CurrentLazer.Image = Properties.Resources.laserGreenRight;
            }

            if (Direction == Direction.up)
            {
                CurrentLazer.Image = Properties.Resources.laserGreenUp;
            }

            if (Direction == Direction.down)
            {
                CurrentLazer.Image = Properties.Resources.laserGreenDown;
            }

            CurrentLazer.Tag = "enemyLazer";
            base.CreateLazer(form);
        }
    }
}
