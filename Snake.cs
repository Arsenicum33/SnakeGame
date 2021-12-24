using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SnakeGame__TODO_ML_
{
    enum Direction
    {
        Up = 0,
        Right = 1,
        Down = 2,
        Left = 3
    }
    class Snake
    {

        private Direction m_snakeDirection;
        public Direction snakeDirection { get { return m_snakeDirection; } }
        private int m_length = 1;
        public int length { get { return m_length; } private set { m_length = value; } }
        private List<Field> m_SnakeFields = new List<Field>();
        public List<Field> SnakeFields { get { return m_SnakeFields; } }
        public Snake(int initialSnakeFieldX, int initialSnakeFieldY)
        {
            m_snakeDirection = Direction.Up;
            m_SnakeFields.Add(new Field(initialSnakeFieldX, initialSnakeFieldY));
        }
        public void ChangeDirection(Direction direction)
        {
            m_snakeDirection = direction;
        }
        public void Move(Food food)
        {
            Field prevHeadField;
            Field lastTailField = SnakeFields[length - 1];
            switch (m_snakeDirection)
            {
                case Direction.Up:
                    prevHeadField = SnakeFields[0];
                    SnakeFields[0] = new Field(SnakeFields[0].X, SnakeFields[0].Y - 1);
                    break;
                case Direction.Right:
                    prevHeadField = SnakeFields[0];
                    SnakeFields[0] = new Field(SnakeFields[0].X + 1, SnakeFields[0].Y);
                    break;
                case Direction.Down:
                    prevHeadField = SnakeFields[0];
                    SnakeFields[0] = new Field(SnakeFields[0].X, SnakeFields[0].Y + 1);
                    break;
                case Direction.Left:
                    prevHeadField = SnakeFields[0];
                    SnakeFields[0] = new Field(SnakeFields[0].X - 1, SnakeFields[0].Y);
                    break;
                default: return;
            }

            MoveTail(prevHeadField);
            if (food.foodWidth == m_SnakeFields[0].X && food.foodHeight == m_SnakeFields[0].Y)
            {
                m_SnakeFields.Add(lastTailField);
                length++;
                food.CreateNewFood();
            }
        }
        private void MoveTail(Field prevField)
        {
            for (int i = 1; i < length; i++)
            {
                Field temp = m_SnakeFields[i];
                m_SnakeFields[i] = prevField;
                prevField = temp;

            }
        }
        public bool CheckDeath(int mapWidthFieldsNumber, int mapHeightFieldsNumber)
        {
            if (SnakeFields[0].X<0|| SnakeFields[0].X> mapWidthFieldsNumber|| SnakeFields[0].Y<0|| SnakeFields[0].Y>= mapHeightFieldsNumber)
            {
                return true;
            }
            for (int i=1;i<length;i++)
            {
                if (SnakeFields[0].X == SnakeFields[i].X && SnakeFields[0].Y == SnakeFields[i].Y)
                    return true;
            }
            return false;
        }

    }
}
