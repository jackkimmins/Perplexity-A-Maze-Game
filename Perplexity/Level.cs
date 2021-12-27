using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perplexity
{
    class Level
    {
        public string LevelName { get; set; }
        public LevelData lData { get; }
        
        public Level(string levelName)
        {
            LevelName = levelName;

            lData = new LevelData();
            lData.Add(new List<int> { 1, 2, 1, 3, 1 });
            lData.Add(new List<int> { 1, 0, 1, 0, 1 });
            lData.Add(new List<int> { 1, 0, 1, 0, 1 });
            lData.Add(new List<int> { 1, 0, 0, 0, 1 });
            lData.Add(new List<int> { 1, 1, 1, 1, 1 });
        }

        public Coordinate GetStartCoordinates()
        {
            var coordinates = lData.Select((row, rowIndex) => row.IndexOf(2)).ToList();
            return new Coordinate(coordinates[0], coordinates[1] + 1);
        }

        public Coordinate GetEndCoordinates()
        {
            var coordinates = lData.Select((row, rowIndex) => row.IndexOf(3)).ToList();
            return new Coordinate(coordinates[0], coordinates[1] + 1);
        }

        public char GetMazeDisplayChar(int value)
        {
            switch (value)
            {
                case 0:
                    return ' ';
                case 1:
                    return '█';
                case 2:
                    return 'S';
                case 3:
                    return 'E';
                case 4:
                    return '*';
                default:
                    return ' ';
            }
        }

        public void DrawLevel(Coordinate playerPos = null)
        {
            for (int i = 0; i < lData.Count(); i++)
            {
                for (int j = 0; j < lData[i].Count(); j++)
                {
                    //Set the console cursor position
                    Console.SetCursorPosition(j, i);

                    if (playerPos != null && playerPos.X == j && playerPos.Y == i)
                    {
                        Console.Write(GetMazeDisplayChar(4));
                    }
                    else
                    {
                        Console.Write(GetMazeDisplayChar(lData[i][j]));
                    }
                }
            }
        }

        public bool IsValidMove(Coordinate coordinate)
        {
            if (coordinate.X < 0 || coordinate.X >= lData[0].Count())
            {
                return false;
            }

            if (coordinate.Y < 0 || coordinate.Y >= lData.Count())
            {
                return false;
            }

            if (lData[coordinate.Y][coordinate.X] == 3)
            {
                return true;
            }

            if (lData[coordinate.Y][coordinate.X] != 0)
            {
                return false;
            }
            
            return true;
        }

        public bool IsValidMove(int x, int y)
        {
            return IsValidMove(new Coordinate(x, y));
        }
    }
}
