using System;

namespace Maze
{
    public class Labyrynth
    {
        public delegate void LabyrynthHandler(Labyrynth maze);
        public event LabyrynthHandler DisplayMaze;
        private Random random;
        public Labyrynth(int _height, int _width, int _pathPercentages)
        {
            width = _width;
            height = _height;
            pathVSwallsPercentage = _pathPercentages;
            random = new Random();
            recursiveFunctionSteps = 0;
            GenerateLabyrynth();
        }
        public int width { get; set; }
        public int height { get; set; }
        public int pathVSwallsPercentage { get; set; }
        public MazeExit mazeExit { get; set; }
        public int entrancePointonFirstRow { get; set; }
        public bool[,] matrix { get; set; }
        public bool[,] recursiveFuncPath { get; set; }
        public bool[,] recursiveCorrectPath { get; set; }
        public int recursiveFunctionSteps { get; set; }

        /// <summary>
        /// Generating new matrix for labyrynth
        /// </summary>
        public void GenerateLabyrynth()
        {
            matrix = new bool[width, height];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    bool value = random.NextDouble() < pathVSwallsPercentage / 100.0;
                    matrix.SetValue(value, i, j);
                }
            }
            SetEntrancePoint();
        }

        /// <summary>
        /// Setting a new entrance point
        /// </summary>
        public void SetEntrancePoint()
        {
            //checkiing if there is no entrance at all, if so reGenerate labyrynth
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[0, i])
                    break;
                if (i == matrix.GetLength(0) - 1) GenerateLabyrynth();
            }
            entrancePointonFirstRow = random.Next(0, matrix.GetLength(1));
            while (!matrix[0, entrancePointonFirstRow])
            {
                entrancePointonFirstRow = random.Next(0, matrix.GetLength(1));
            }
            mazeExit = MazeExit.NotSolved;
        }
        public void FindExitFromEntrance()
        {
            recursiveFunctionSteps = 0;
            recursiveFuncPath = new bool[width, height];
            recursiveCorrectPath = new bool[width, height];
            var hasExit = RecursiveSolve(0, entrancePointonFirstRow);
            if (hasExit)
                mazeExit = MazeExit.HaveExit;
            else
                mazeExit = MazeExit.HaveNotExit;
            DisplayMaze?.Invoke(this);
        }
        /// <summary>
        /// Recursive exit path search
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool RecursiveSolve(int x, int y)
        {            
            recursiveFunctionSteps++;
            if (x == matrix.GetLength(0) - 1)
            {
                recursiveCorrectPath[x, y] = true;
                return true;
            }
            if (!matrix[x, y] || recursiveFuncPath[x, y]) return false;
            recursiveFuncPath[x, y] = true;
            if (x != 0)
                if (RecursiveSolve(x - 1, y))
                {
                    recursiveCorrectPath[x, y] = true;
                    return true;
                }
            if (x != width - 1)
                if (RecursiveSolve(x + 1, y))
                {
                    recursiveCorrectPath[x, y] = true;
                    return true;
                }
            if (y != 0)
                if (RecursiveSolve(x, y - 1))
                {
                    recursiveCorrectPath[x, y] = true;
                    return true;
                }
            if (y != height - 1)
                if (RecursiveSolve(x, y + 1))
                {
                    recursiveCorrectPath[x, y] = true;
                    return true;
                }
            return false;
        }
    }
}
