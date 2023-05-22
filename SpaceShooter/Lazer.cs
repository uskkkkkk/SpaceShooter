using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter
{
    /// <summary>
    /// Класс представляет лазерный луч, который можно создать в игре
    /// </summary>
    public abstract class Lazer
    {
        Direction direction;

        int lazerPosLeft;
        int lazerPosTop;

        int speed = 20;

        PictureBox lazer = new PictureBox();

        Timer lazerTimer = new Timer();

        // направление движения лазера
        public Direction Direction { get => direction; set => direction = value; }

        // координата левой границы лазера по горизонтали
        public int LazerPosLeft { get => lazerPosLeft; set => lazerPosLeft = value; }

        // координата верхней границы лазера по вертикали
        public int LazerPosTop { get => lazerPosTop; set => lazerPosTop = value; }

        // скорость движения лазера
        public int Speed { get => speed; set => speed = value; }

        // объект PictureBox, отображающий лазер
        public PictureBox CurrentLazer { get => lazer; set => lazer = value; }

        //  таймер, отвечающий за движение лазера
        public Timer LazerTimer { get => lazerTimer; set => lazerTimer = value; }

        /// <summary>
        ///  Метод создает объект лазера на экране формы и запускает его движение с заданной скоростью
        /// </summary>
        /// <param name="form">Форма</param>
        public virtual void CreateLazer(Form form)
        {
            CurrentLazer.BackColor = Color.Transparent;
            CurrentLazer.Left = lazerPosLeft;
            CurrentLazer.Top = lazerPosTop;
            CurrentLazer.BringToFront();
            form.Controls.Add(CurrentLazer);

            lazerTimer.Interval = Speed;
            lazerTimer.Tick += new EventHandler(LazerTick);

            lazerTimer.Start();

        }

        /// <summary>
        /// Обработчик события таймера для движения лазера
        /// </summary>
        /// <param name="sender">объект-источник события</param>
        /// <param name="e">аргументы события</param>
        private void LazerTick(object sender, EventArgs e)
        {
            if (Direction == Direction.left)
            {
                CurrentLazer.Left -= Speed;
            }

            if (Direction == Direction.right)
            {
                CurrentLazer.Left += Speed;
            }

            if (Direction == Direction.up)
            {
                CurrentLazer.Top -= Speed;
            }

            if (Direction == Direction.down)
            {
                CurrentLazer.Top += Speed;
            }

            if (CurrentLazer.Right < 0 || CurrentLazer.Left > 1000 || CurrentLazer.Top > 900 || CurrentLazer.Bottom < 0)
            {
                lazerTimer.Stop();
                lazerTimer.Dispose();
                CurrentLazer.Dispose();

                lazerTimer = null;
                CurrentLazer = null;
            }
        }
    }
}
