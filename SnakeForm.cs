using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace SnakeGame__TODO_ML_
{
    public partial class SnakeForm : Form
    {
        string pointsLabelText;
        private int score=0;
        private System.Timers.Timer moveDelayTimer = new System.Timers.Timer();
        private Direction desiredDirection;
        public readonly int MapWidthFieldsNumber;
        public readonly int MapHeightFieldsNumber;
        private readonly Field[,] Map;
        private Food food;
        Random foodRandom = new Random();
        
        Snake snake;
        public SnakeForm()
        {
            KeyPreview = true;
            InitializeComponent();
            MapWidthFieldsNumber = GameCanvas.Width / GameSettings.FieldWidth;
            MapHeightFieldsNumber = GameCanvas.Height / GameSettings.FieldHeight;
            snake = new Snake(MapWidthFieldsNumber / 2, MapHeightFieldsNumber / 2);
            food = new Food(MapWidthFieldsNumber, MapHeightFieldsNumber);
            pointsLabelText = "Points: 0";
            pointsLabel.Text = pointsLabelText;
            //Map = new Field[MapWidthFieldsNumber, MapHeightFieldsNumber];
            //for (int i=0;i<MapWidthFieldsNumber;i++)
            //{
            //    for (int j=0;j<MapHeightFieldsNumber;j++)
            //    {
            //        Map[i, j] = new Field(i,j);
            //    }
            //}

        }

        private void StartButtonClick(object sender, EventArgs e)
        {
            GameCanvas.BackColor = Color.Silver;
            desiredDirection = Direction.Up;
            snake = new Snake(MapWidthFieldsNumber / 2, MapHeightFieldsNumber / 2);
            food = new Food(MapWidthFieldsNumber, MapHeightFieldsNumber);
            SetTimer();
        }

        private void UpdateGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            Brush snakeColor = Brushes.Black;
            for (int i=0;i<snake.length;i++)
            {
                canvas.FillRectangle(snakeColor, new Rectangle(snake.SnakeFields[i].X*GameSettings.FieldWidth,
                    snake.SnakeFields[i].Y*GameSettings.FieldHeight,GameSettings.FieldWidth, GameSettings.FieldHeight));
            }
            Brush foodColor = Brushes.Red;
            canvas.FillRectangle(foodColor, new Rectangle(food.foodWidth * GameSettings.FieldWidth,
                food.foodHeight * GameSettings.FieldHeight, GameSettings.FieldWidth, GameSettings.FieldHeight));
        }

        private void SnakeFormKeyDown(object sender, KeyEventArgs e)
        {
            
            switch(e.KeyCode)
            {
                case Keys.W: desiredDirection = Direction.Up;
                    break;
                case Keys.D:
                    desiredDirection = Direction.Right;
                    break;
                case Keys.S:
                    desiredDirection = Direction.Down;
                    break;
                case Keys.A:
                    desiredDirection = Direction.Left;
                    break;
                default: return;
            }
            
        }

        private void SetTimer()
        {
            moveDelayTimer.Stop();
            moveDelayTimer = new System.Timers.Timer(GameSettings.TimerTime);
            moveDelayTimer.Elapsed += OnMoveDelayTimerElapsed;
            moveDelayTimer.AutoReset = true;
            moveDelayTimer.Enabled = true;
        }
        private void OnMoveDelayTimerElapsed(object sender, ElapsedEventArgs e)
        {
          

            if (Math.Abs((UInt16)desiredDirection - (UInt16)snake.snakeDirection) != 2)
            {
                snake.ChangeDirection(desiredDirection);
            }
            snake.Move(food);
            if (snake.CheckDeath(MapWidthFieldsNumber, MapHeightFieldsNumber))
            {
                moveDelayTimer.Stop();
                GameCanvas.BackColor = Color.IndianRed;
            }
            score = snake.length - 1;
            GameCanvas.Invalidate();

            pointsLabelText = "Points: " + score;

            pointsLabel.Invoke(new Action(() => this.pointsLabel.Text = pointsLabelText));

        }

    }
}
