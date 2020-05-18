using System;

namespace SimpleGames.Data
{
    public class Cell
    {
        public string Symbol { get; set; } = "_";
        public string Location { get; set; }

    }

    public class Board
    {
        public int Size { get; set; }
        public bool XTurn { get; set; } = true;
        public string XorO { get; set; } = "X";
        public Cell [,] Grid { get; set; }

        public Board()
        {

        }
        public Board(Board board)
        {
            Size = board.Size;
            Grid = board.Grid;
        }
        public Board(int size)
        {
            Size = size;
            InitializeBoardValues(size);
        }

    public void InitializeBoardValues(int size)
        {
            Grid = new Cell[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Grid[i, j] = new Cell();
                    Grid[i, j].Location = String.Format("{0}{1}", i, j);
                }
            }
        }
    }
}
