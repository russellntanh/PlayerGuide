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
                PuzzleGame game = new PuzzleGame(4);
                game.DisplayCurrentTiles();



                while (true)
                {
                    // input the tile to move
                    Console.Write("Please input tile to move (111 to quit): ");
                    int tileNumber = Int32.Parse(Console.ReadLine());

                    if (tileNumber == 111) break;
                    if (tileNumber < 0 || tileNumber > game.Size * game.Size)
                    {
                        Console.WriteLine($"Invalid number (0 - {game.Size * game.Size - 1})");
                    }

                    // get selected tile
                    Tile selectedTile = game.GetSelectedTile(tileNumber);

                    // check movable tile
                    if (!game.IsMovable(selectedTile))
                    {
                        Console.WriteLine($"{tileNumber} can't move");
                    }
                    else
                    {
                        Console.WriteLine($"{tileNumber} possible to move");
                        game.MoveTile(selectedTile);
                        game.DisplayCurrentTiles();

                        // test case
                        //int[,] solvedState =
                        //{
                        //    {1, 2, 3, 4},
                        //    {5, 6, 7, 8},
                        //    {9, 10, 11, 12},
                        //    {13, 14, 15, 0}
                        //};

                        //for (int i = 0; i < 4; i++)
                        //{
                        //    for (int j = 0; j < 4; j++)
                        //    {
                        //        var Tiles = game.GetPuzzleBoard();

                        //        if (Tiles[i, j].Number == solvedState[i, j])
                        //            Console.WriteLine("PASS");
                        //    }
                        //}

                        if (game.IsWon())
                        {
                            Console.WriteLine("You are WON");
                            Console.Write("Do you continue y/n?: ");
                            string playAgain = Console.ReadLine();
                            if (playAgain != "y") break;
                            game = new PuzzleGame(4);
                            game.DisplayCurrentTiles();
                        }
                    }
                }
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

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class Tile
    {
        public int Number { get; set; }
        public Point Position { get; set; }
        public Tile() { }

        public Tile(int number, Point position)
        {
            Number = number;
            Position = position;
        }
    }

    public class PuzzleBoard
    {
        public Tile[,] Tiles { get; set; } // 2D array of tiles
        public int Size { get; set; }  // 3x3 or 4x4 or 5x5 ...
        public PuzzleBoard(int size)
        {
            Size = size;
            Tiles = new Tile[size, size];

            // initialize the tile randomly
            InitializeTiles();
        }
        private void InitializeTiles()
        {
            int number = 0;
            int tilesSize = Size * Size;

            List<int> tiles = new List<int>();
            for (int i = 0; i < tilesSize; i++) tiles.Add(i);

            FisherYatesAlgorithm(tiles);

            number = 0;
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    Tiles[i, j] = new Tile(tiles[number++], new Point(i, j));
        }

        // create random tile by Fisher-Yates algorithm
        private void FisherYatesAlgorithm(List<int> nums)
        {
            Random random = new Random();
            for (int i = nums.Count - 1; i > 0; i--)
            {
                int tmp = nums[i];
                int j = random.Next(i - 1);
                nums[i] = nums[j];
                nums[j] = tmp;
            }
        }
    }

    public class PuzzleGame
    {
        // create a puzzle board
        PuzzleBoard board;
        public int Size { get { return board.Size; } }

        public PuzzleGame(int size)
        {
            board = new PuzzleBoard(size);
        }

        // display tiles
        public void DisplayCurrentTiles()
        {
            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    Console.Write($"  {board.Tiles[i, j].Number}");
                }
                Console.WriteLine();
            }
        }

        // check movable
        public bool IsMovable(Tile tile)
        {
            int x = tile.Position.X;
            int y = tile.Position.Y;

            // check left
            if (x > 0 && board.Tiles[x - 1, y].Number == 0)
                return true;

            // check right
            if (x < Size - 1 && board.Tiles[x + 1, y].Number == 0)
                return true;

            // check up
            if (y > 0 && board.Tiles[x, y - 1].Number == 0)
                return true;

            // check down
            if (y < Size - 1 && board.Tiles[x, y + 1].Number == 0)
                return true;

            return false;
        }

        public Tile GetSelectedTile(int inputNumber)
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (board.Tiles[i, j].Number == inputNumber)
                        return board.Tiles[i, j];
                }
            }
            return null;
        }

        public Tile GetEmptyTile()
        {
            return board.Tiles.Cast<Tile>().FirstOrDefault(tile => tile.Number == 0);
        }

        public Tile[,] GetPuzzleBoard()
        {
            return board.Tiles;
        }

        public void SwapTwoTile(Tile t1, Tile t2)
        {
            // Find positions of both tiles
            int selectedX = t1.Position.X;
            int selectedY = t1.Position.Y;
            int selectedNum = t1.Number;
            int emptyX = t2.Position.X;
            int emptyY = t2.Position.Y;
            int emptyNum = t2.Number;


            // Swap the tiles in the array
            board.Tiles[selectedX, selectedY] = t2;
            board.Tiles[selectedX, selectedY].Number = emptyNum;
            board.Tiles[emptyX, emptyY] = t1;
            board.Tiles[emptyX, emptyY].Number = selectedNum;

            // Update positions
            t1.Position = new Point(emptyX, emptyY);
            t2.Position = new Point(selectedX, selectedY);
        }

        public void MoveTile(Tile tile)
        {
            SwapTwoTile(tile, GetEmptyTile());
        }

        public bool IsWon()
        {
            int num = 1;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (i == Size - 1 && j == Size - 1)
                        return board.Tiles[i, j].Number == 0;
                    if (board.Tiles[i, j].Number != num++)
                        return false;
                }
            }
            return true;
        }
    }
}
