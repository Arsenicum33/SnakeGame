using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame__TODO_ML_
{
    class Food
    {
        private Random foodRandom = new Random();
        private int mapWidthFieldsNumber;
        private int mapHeightFieldsNumber;
        public int foodWidth { get; private set; }
        public int foodHeight { get; private set; }

        Field foodField;
        public Food(int mapWidthFieldsNumber, int mapHeightFieldsNumber)
        {
            this.mapWidthFieldsNumber = mapWidthFieldsNumber;
            this.mapHeightFieldsNumber = mapHeightFieldsNumber;
            CreateNewFood();
        }
        public void CreateNewFood()
        {
            var newFoodWidth = foodRandom.Next() % mapWidthFieldsNumber;
            var newFoodHeight = foodRandom.Next() % mapHeightFieldsNumber;
            foodField = new Field(newFoodWidth, newFoodHeight);
            foodWidth = foodField.X;
            foodHeight = foodField.Y;
        }
    }
}

