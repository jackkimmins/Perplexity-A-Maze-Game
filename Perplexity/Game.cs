using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perplexity
{
    class Game
    {
        public Level Level { get; set; }
        public Player Player { get; set; }

        public Game()
        {
            Level = new Level("Level 1");
            Player = new Player(Level.GetStartCoordinates());
        }

        private bool GetPlayerInput()
        {
            var key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (Level.IsValidMove(Player.PlayerPos.X, Player.PlayerPos.Y - 1))
                    {
                        Player.PlayerPos.Y--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (Level.IsValidMove(Player.PlayerPos.X, Player.PlayerPos.Y + 1))
                    {
                        Player.PlayerPos.Y++;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (Level.IsValidMove(Player.PlayerPos.X - 1, Player.PlayerPos.Y))
                    {
                        Player.PlayerPos.X--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (Level.IsValidMove(Player.PlayerPos.X + 1, Player.PlayerPos.Y))
                    {
                        Player.PlayerPos.X++;
                    }
                    break;
                case ConsoleKey.Escape:
                    return false;
                default:
                    break;
            }

            return true;
        }

        public void Start()
        {
            Console.CursorVisible = false;

            while (true)
            {
                Level.DrawLevel(Player.PlayerPos);

                if (!GetPlayerInput())
                {
                    break;
                }

                if (Player.PlayerPos.X == Level.GetEndCoordinates().X && Player.PlayerPos.Y == Level.GetEndCoordinates().Y)
                {
                    Console.Clear();
                    Console.WriteLine("You won!");
                    break;
                }
            }

            Console.CursorVisible = true;
        }
    }
}
