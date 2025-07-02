namespace PuzzleTile
{
    // 1. Create a tile class
    // 2. Create a method to check if the puzzle is solved
    // 3. Create a method to check if the puzzle is solvable
    // 4. Create a method to print the puzzle

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("=== PUZZLE 15 TILES");
                Puzzle puzzle = new Puzzle(3);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class Tile
    {
        public int Number { get; set; }
        public Point Position { get; set; }

        public Tile(int number, Point position)
        {
            Number = number;
            Position = position;
        }
    }

    public class Puzzle
    {
        public Tile[,] Tiles { get; set; }
        public int Size { get; set; }
        public Puzzle(int size)
        {
            Size = size;
            Tiles = new Tile[size, size];
            InitializeTiles();
        }
        private void InitializeTiles()
        {
            int number = 1;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {

                    if (number < Size * Size)
                    {
                        Tiles[i, j] = new Tile(number++, new Point { X = i, Y = j });
                    }
                    else
                    {
                        Tiles[i, j] = new Tile(0, new Point { X = i, Y = j }); // Empty tile
                    }
                    Console.Write($"  {Tiles[i, j].Number}");
                }
                Console.WriteLine();
            }
        }
        // Additional methods to check if the puzzle is solved, solvable, and to print the puzzle can be added here.
    }
}
