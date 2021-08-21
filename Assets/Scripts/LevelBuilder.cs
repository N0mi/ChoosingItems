using AmayaSoft.TestTask.Data;
using Utilites;

namespace AmayaSoft.TestTask
{
    public class LevelBuilder
    {
        public Level CreateLevel(Grid grid)
        {
            return new Level(grid, GetTask(grid));
        }
        private CardData GetTask(Grid grid)
        {
            //Add check repeat card
            return grid.Items.GetRandom();
        }
    }
}