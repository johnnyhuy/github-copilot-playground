using System;
using System.Threading;
using System.Collections.Generic;

namespace Playground
{
    class Program
    {
        static int birdPositionRow;
        static int birdPositionCol;
        static List<int[]> obstacles = new List<int[]>();
        static int score;
        static bool isGameRunning;
        static Random random = new Random();

        static void Main(string[] args)
        {
            SetupGame();
            while (isGameRunning)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.Spacebar)
                    {
                        Flap();
                    }
                }

                MoveObstacles();
                CheckCollision();
                UpdateScreen();

                Thread.Sleep(200);
            }

            Console.WriteLine("Game over!");
            Console.WriteLine($"Score: {score}");
        }

        static void SetupGame()
        {
            birdPositionRow = 10;
            birdPositionCol = 5;
            score = 0;
            isGameRunning = true;
            Console.CursorVisible = false;
        }

        static void Flap()
        {
            birdPositionRow -= 2;
        }

        static void MoveObstacles()
        {
            for (int i = 0; i < obstacles.Count; i++)
            {
                obstacles[i][1]--;
            }

            if (random.Next(0, 5) == 1) // Randomly add new obstacles
            {
                obstacles.Add(new int[] { random.Next(0, Console.WindowHeight), Console.WindowWidth - 1 });
            }
        }

        static void CheckCollision()
        {
            foreach (var obstacle in obstacles)
            {
                if (obstacle[1] == birdPositionCol && (obstacle[0] == birdPositionRow || obstacle[0] + 1 == birdPositionRow))
                {
                    isGameRunning = false;
                }
            }

            if (birdPositionRow < 0 || birdPositionRow >= Console.WindowHeight)
            {
                isGameRunning = false;
            }
        }

        static void UpdateScreen()
        {
            Console.Clear();
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                for (int j = 0; j < Console.WindowWidth; j++)
                {
                    if (i == birdPositionRow && j == birdPositionCol)
                    {
                        Console.Write("O"); // Bird character
                    }
                    else if (obstacles.Exists(obstacle => obstacle[0] == i && obstacle[1] == j))
                    {
                        Console.Write("#"); // Obstacle character
                    }
                    else
                    {
                        Console.Write(" "); // Empty space
                    }
                }
                Console.WriteLine();
            }

            birdPositionRow++; // Gravity effect
            CleanupObstacles();
            score++;
        }

        static void CleanupObstacles()
        {
            obstacles.RemoveAll(obstacle => obstacle[1] < 0);
        }
    }
}
