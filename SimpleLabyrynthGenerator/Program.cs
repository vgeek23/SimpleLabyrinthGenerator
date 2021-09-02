using Maze;
using System;

namespace SimpleLabyrynthGenerator
{
    class Program
    {        
        static void Main(string[] args)
        {
            try
            {
                Console.SetWindowSize(110, Console.WindowHeight + 20);                
                Console.SetCursorPosition(0, 1);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;                
                var width = 64;
                var height = 32;
                var pathPercentage = 60;
                Labyrynth maze = new Labyrynth(width, height, pathPercentage);
                maze.DisplayMaze += DisplayMaze;
                Console.WriteLine("Press ESC to stop");
                Console.WriteLine("Generating new labyrynth!---->");
                bool @continue = true;
                while (@continue)
                {
                    maze.FindExitFromEntrance();
                    //DisplayMaze(maze);                   
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    //Console.WriteLine($"Number of steps taken to solve maze: {maze.recursiveFunctionSteps}");
                    //DisplayMaze(maze);                    
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                        @continue = false;
                    else
                    {
                        Console.SetCursorPosition(0, 2);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Generating new labyrynth!---->");
                        maze.GenerateLabyrynth();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
        private static void DisplayMaze(Labyrynth maze)
        {            
            Console.SetCursorPosition(3, 3);
            Console.WriteLine("_____________Your maze is ready!------->" + Environment.NewLine);
            for (int i = 0; i < maze.matrix.GetLength(0); i++)
            {
                if (i == 0)
                {
                    for (int k = 0; k < maze.matrix.GetLength(1) + 2; k++)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        if (k == maze.entrancePointonFirstRow + 1) 
                            Console.BackgroundColor = ConsoleColor.Red;//displayentrance
                        Console.Write(MazeElements.noNeighbours);
                    }
                    Console.WriteLine();
                }
                for (int j = 0; j < maze.matrix.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(MazeElements.noNeighbours);
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    char value = MazeElements.floor;
                    if (maze.matrix[i, j] == false)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        value = MazeElements.noNeighbours;
                    }
                    
                    Console.Write($"{value}");

                    //Mark walked path
                    if (maze.recursiveFuncPath[i, j])
                    {
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(MazeElements.walkedSteps);
                    }
                    //Mark exit path
                    if (maze.recursiveCorrectPath[i, j])
                    {
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(MazeElements.correctPath);
                    }                   
                    if (j == maze.matrix.GetLength(1) - 1)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(MazeElements.noNeighbours);
                    }
                }
                Console.WriteLine();
                if (i == maze.matrix.GetLength(0) - 1)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    for (int k = 0; k < maze.matrix.GetLength(1) + 2; k++)
                    {
                        Console.Write(MazeElements.noNeighbours);
                    }
                    Console.WriteLine();
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
            if (maze.mazeExit == MazeExit.HaveNotExit)             
                Console.WriteLine("Maze have no exit from entrance point.");
            else
                Console.WriteLine("Maze have exit.                        ");
            Console.WriteLine($"Number of steps taken to solve maze: {maze.recursiveFunctionSteps}");
        }
        public static void DisplayMazeWalls()
        {
            Console.WriteLine(MazeElements.allNeighbours);
            Console.WriteLine($"{MazeElements.nesNeighbours}{MazeElements.nswNeighbours}{MazeElements.eswNeighbours}{MazeElements.newNeighbours}");
            Console.WriteLine($"{MazeElements.ewNeighbours}{MazeElements.nsNeighbours}{MazeElements.esNeighbours}{MazeElements.swNeighbours}{MazeElements.neNeighbours}{MazeElements.nwNeighbours}");
            Console.WriteLine($"{MazeElements.ewNeighboursEnd}{MazeElements.nsNeighboursEnd}");
            Console.WriteLine($"{MazeElements.noNeighbours}");
        }

    }
}
