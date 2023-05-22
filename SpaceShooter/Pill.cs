using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter
{
    /// <summary>
    /// Класс представляет собой объект "таблетки"  в игре
    /// </summary>
    class Pill
    {
        PictureBox pillSpawn = new PictureBox();

        bool pillExist;

        int pillPosLeft;
        int pillPosTop;

        //  объект класса PictureBox, отображающий таблетку
        public PictureBox PillSpawn { get => pillSpawn; set => pillSpawn = value; }

        // логическое значение, указывающее, существует ли таблетка на игровом поле
        public bool PillExist { get => pillExist; set => pillExist = value; }

        // координаты таблетки на игровом поле.
        public int PillPosLeft { get => pillPosLeft; set => pillPosLeft = value; }
        public int PillPosTop { get => pillPosTop; set => pillPosTop = value; }

        /// <summary>
        /// Метод, который отображает таблетку на игровом поле
        /// Он устанавливает изображение таблетки, ее размер, теги и позицию на игровом поле
        /// </summary>
        /// <param name="form">Форма</param>
        public void SpawnPill(Form form)
        {
            PillSpawn.Image = Properties.Resources.pill;
            PillSpawn.SizeMode = PictureBoxSizeMode.AutoSize;
            PillSpawn.Tag = "pill";
            PillSpawn.Left = PillPosLeft;
            PillSpawn.Top = PillPosTop;

            form.Controls.Add(PillSpawn);
            PillSpawn.BringToFront();

        }
    }
}
