using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter
{
    /// <summary>
    /// Класс MainMenu является частичным классом формы Windows Forms
    /// и содержит реализации обработчиков событий для элементов управления на форме:
    /// начать игру и выйти из игры
    /// </summary>
    public partial class MainMenu : Form
    {
        /// <summary>
        /// Конструктор инициализирует компоненты формы с помощью метода InitializeComponent()
        /// </summary>
        public MainMenu()
        {
            InitializeComponent();
        }

        private void labelTitle_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Метод обрабатывает нажатие кнопки "Start" на форме
        /// </summary>
        /// <param name="sender">объект-источник события</param>
        /// <param name="e">аргументы события</param>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            SpaceShooter game = new SpaceShooter();
            game.ShowDialog();
        }

        /// <summary>
        /// Метод обрабатывает нажатие кнопки "Exit" на форме и закрывает текущее окно
        /// </summary>
        /// <param name="sender">объект-источник события</param>
        /// <param name="e">аргументы события</param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
