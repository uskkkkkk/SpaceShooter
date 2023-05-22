using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter
{
    /// <summary>
    /// Класс, представляющий основную форму игры
    /// </summary>
    public partial class SpaceShooter : Form
    {
        SpawnManager spawnManage;  // Менеджер спавна объектов
        CollisionManager collisionManage;  // Менеджер обнаружения столкновений
        EnemyMovement movementManager;  // Менеджер движения врагов

        bool goLeft, goRight, goUp, goDown;  // Флаги направления движения игрока

        int playerShield = 100; // Значение здоровья игрока

        int speed = 10; // Скорость перемещения игрока

        int score = 0;  // Счет игрока

        Direction playerDirection; // Направление героя

        // Свойство для получения экземпляра менеджера спавна
        public SpawnManager SpawnManage { get => spawnManage; }

        // Свойство для получения/изменения значения здоровья игрока
        public int PlayerShield { get => playerShield; set => playerShield = value; }

        // Свойство для получения/изменения значения счета игрока
        public int Score { get => score; set => score = value; }

        /// <summary>
        /// Конструктор класса SpaceShooter
        /// </summary>
        public SpaceShooter()
        {
            spawnManage = new SpawnManager(this);
            collisionManage = new CollisionManager(this);
            movementManager = new EnemyMovement(this);

            InitializeComponent();
        }

        /// <summary>
        /// Метод для перемещения героя в зависимости от установленных флагов направления
        /// </summary>
        private void MovePlayer()
        {
            if (goLeft == true && player.Left > 0)
            {
                player.Left -= speed;
            }

            if (goRight == true && player.Left + player.Width < this.ClientSize.Width)
            {
                player.Left += speed;
            }

            if (goUp == true && player.Top > 0)
            {
                player.Top -= speed;
            }

            if (goDown == true && player.Top + player.Height < this.ClientSize.Height - 100)
            {
                player.Top += speed;
            }
        }

        /// <summary>
        ///  Метод для проверки жизнеспособности игрока(корабля)
        /// </summary>
        private void IsPlayerAlive()
        {
            if (PlayerShield > 1)
            {
                shieldsBar.Value = PlayerShield;
            }
            else
            {
                gameTimer.Stop();
            }
        }

        // Обработчик нажатия на кнопку
        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Обработчик нажатия на полосу прогресса
        private void progressBar1_Click(object sender, EventArgs e)
        {
            
        }

        // Обработчик загрузки формы
        private void SpaceShooter_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Метод, вызываемый при каждом тике игрового таймера
        /// Обновляет игровые параметры и проверяет столкновения
        /// </summary>
        /// <param name="sender">Объект, который вызвал событие</param>
        /// <param name="e">Объект KeyEventArgs, содержащий информацию о событии нажатия клавиши</param>
        private void GameTick(object sender, EventArgs e)
        {
            player.BringToFront();

            IsPlayerAlive();

            labelScore.Text = "Рекорд: " + Score;

            MovePlayer();

            collisionManage.DetectCollision();
            movementManager.MoveUFO();
        }

        /// <summary>
        /// Метод проверяет, нажата ли клавиша в данный момент
        ///  и обновляет изображение проигрывателя в зависимости от нажатой клавиши направления
        /// </summary>
        /// <param name="sender">Объект, который вызвал событие</param>
        /// <param name="e">Объект KeyEventArgs, содержащий информацию о событии нажатия клавиши</param>
        private void IsKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
                playerDirection = Direction.left;
                player.Image = Properties.Resources.ShipLeft;
            }

            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
                playerDirection = Direction.right;
                player.Image = Properties.Resources.ShipRight;
            }

            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
                playerDirection = Direction.up;
                player.Image = Properties.Resources.ShipUp;
            }

            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
                playerDirection = Direction.down;
                player.Image = Properties.Resources.ShipDown ;
            }
        }

        /// <summary>
        /// Метод является обработчиком события KeyUp, 
        /// который вызывается при отпускании клавиши на клавиатуре
        /// </summary>
        /// <param name="sender">Объект, который вызвал событие</param>
        /// <param name="e">Объект KeyEventArgs, содержащий информацию о событии нажатия клавиши</param>
        private void IsKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }

            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }

            if (e.KeyCode == Keys.Space)
            {
                ShootLaser(playerDirection);
            }
        }

        /// <summary>
        /// Метод для выстрела лазером в заданном направлении
        /// </summary>
        /// <param name="direction">Направление выстрела</param>
        private void ShootLaser(Direction direction)
        {
            Lazer newlaser = new LazerRed();

            newlaser.Direction = playerDirection;
            newlaser.LazerPosLeft = player.Left + (player.Width / 2);
            newlaser.LazerPosTop = player.Top + (player.Height / 2);

            newlaser.CreateLazer(this);
        }
    }
}
