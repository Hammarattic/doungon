namespace doungon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO THE DOUNGON GAME");
            Game.SetUpGame();


            Console.WriteLine("press wasd to move");
            

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.W:
                        Game.MovePlayer(-1, 0); // Move up
                        break;
                    case ConsoleKey.S:
                        Game.MovePlayer(1, 0); // Move down
                        break;
                    case ConsoleKey.A:
                        Game.MovePlayer(0, -1); // Move left
                        break;
                    case ConsoleKey.D:
                        Game.MovePlayer(0, 1); // Move right
                        break;
                }
            }
        }


    }
}

