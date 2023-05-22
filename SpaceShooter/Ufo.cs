using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter
{
    /// <summary>
    /// Абстрактный класс для создания объекта НЛО
    /// </summary>
    public abstract class Ufo
    {
        PictureBox ufo;

        int ufoPosLeft;
        int ufoPosTop;

        // Свойство UFOSpawn предоставляет доступ к объекту PictureBox
        public PictureBox UFOSpawn { get => ufo; set => ufo = value; }

        //  Свойство UfoPosLeft позволяют получить или установить позицию объекта НЛО по горизонтали
        public int UfoPosLeft { get => ufoPosLeft; set => ufoPosLeft = value; }

        //  Свойств UfoPosTop позволяют получить или установить позицию объекта НЛО по вертикали
        public int UfoPosTop { get => ufoPosTop; set => ufoPosTop = value; }

        /// <summary>
        /// Метод для создания объекта PictureBox с размером, 
        /// установкой свойства Tag и добавлением на форму
        /// </summary>
        /// <param name="form">Форма</param>
        public virtual void SpawnUFO(Form form)
        {
            ufo = new PictureBox();
            UFOSpawn.Tag = "ufo";
            UFOSpawn.SizeMode = PictureBoxSizeMode.AutoSize;
        }
    }
}
