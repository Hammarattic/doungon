using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doungon
{
    internal class Game
    {
        
        static bool key = false;
        static int[] playerPosition = new int[2]; // [X, Y]
        static char[,] maze =
        {
            { '#', '#', '#', '#', '#', '#', '#', '#', 'E', '#' },
            { '#', 'P', ' ', ' ', '#', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', '#', ' ', '#', ' ', '#', '#', ' ', '#' },
            { '#', ' ', '#', ' ', ' ', ' ', ' ', '#', ' ', '#' },
            { '#', ' ', '#', '#', '#', '#', ' ', '#', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', '#' },
            { '#', '#', '#', '#', 'F', '#', '#', '#', ' ', '#' },
            { '#', 'K', 'F', '#', ' ', ' ', ' ', '#', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
        };

        public static void SetUpGame()
        {
            DrawMaze();


            playerPosition[0] = 1; // X position
            playerPosition[1] = 1; // Y position
        }


        static public void MovePlayer(int deltaY, int deltaX)
        {
            int newY = playerPosition[0] + deltaY; // Calculate new Y position
            int newX = playerPosition[1] + deltaX; // Calculate new X position

            // if you touch a F you fell in a trap
            if (maze[newY, newX] == 'F')
            {
                Console.WriteLine("YOU FELL IN A TRAP MOUHAHA");
                maze[playerPosition[0], playerPosition[1]] = ' '; // Clear old position
                Console.Clear();
                key = false;
                Console.WriteLine("press wasd to start again");
                SetUpGame();
            }
            //if you touch the K you will recive a key
            if (maze[newY, newX] == 'K')
            {
                Console.WriteLine("you collected a key");
                key = true;
            }
            //if you have key and is touching E you win
            if (maze[newY, newX] == 'E' && key == true)
            {
                Console.WriteLine("you won");
                Playagain();
            }
            
            //marks where you can walk
            if (maze[newY, newX] == ' ')
            {
                // Clear the old position
                maze[playerPosition[0], playerPosition[1]] = ' ';
                // Update player's position
                playerPosition[0] = newY;
                playerPosition[1] = newX;
                // Place player in new position
                maze[playerPosition[0], playerPosition[1]] = 'P';
                // Redraw the maze
                Console.Clear();
                DrawMaze();
            }



        }
        //draws the maze
        public static void DrawMaze()
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    Console.Write(maze[i, j]);

                }
                Console.WriteLine();
            }
        }
        //ask the player if you wanan play again
        public static void Playagain()
        {
            Console.WriteLine("wanna play again yes, no?");
            string Tryagian=Console.ReadLine().ToLower();

            if (Tryagian == "yes" || Tryagian== "ja")
            {
                key=false;
                Console.Clear();
                maze[playerPosition[0], playerPosition[1]] = ' ';
                Console.WriteLine("press wasd to move");
                SetUpGame();
            }
            if (Tryagian == "no" || Tryagian == "nej")
            {
                Console.Clear();
                Environment.Exit(0);
            }
        }
      

    }
}
