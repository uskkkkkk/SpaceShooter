using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter
{
    /// <summary>
    /// Класс LazerRedBig наследуется от класса Lazer 
    /// и предназначен для создания объектов красных лазеров врага
    /// </summary>
    internal class LazerRedBig: Lazer
    {
        /// <summary>
        /// Метод создает красный лазер врага на переданной форме и задает его изображение и тег
        /// </summary>
        /// <param name="form">Форма</param>
        public override void CreateLazer(Form form)
        {
            CurrentLazer.Image = Properties.Resources.laserRed08;

            CurrentLazer.Tag = "enemyLazer";
            // Вызываем метод родительского класса для создания лазера на форме
            base.CreateLazer(form);  
        }
    }
}
