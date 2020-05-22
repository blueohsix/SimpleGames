using System;
using Microsoft.AspNetCore.Components.Web;

namespace SimpleGames.Data
{
    public class Cell
    {
        public string Symbol { get; set; } = "_";
        public string Location { get; set; }

    }

    public class Board
    {
        public int Size { get; private set; }
        public bool XTurn { get; private set; } = true;
        public string XorO { get; private set; } = "X";
        public Cell[,] Grid { get; private set; }

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

        private void InitializeBoardValues(int size)
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

        public void Move(MouseEventArgs e, string location, Board board)
        {
            var first = int.Parse(location[0].ToString());
            var second = int.Parse(location[1].ToString());
            Console.WriteLine("first = " + first);
            Console.WriteLine("second = " + second);
            var cell = board.Grid[first, second];
            if (ValidateMove(first, second, board))
            {
                cell.Symbol = board.XorO;
                Console.WriteLine("new value = " + cell.Symbol);
                board.XTurn = !board.XTurn;
                board.XorO = board.XTurn ? "X" : "O";

            }
        }

        private bool ValidateMove(int first, int second, Board board)
        {

            int size = (int)Math.Sqrt(board.Grid.Length);
            if ((first >= 0 && first <= size - 1) && (second >= 0 && second <= size - 1))
            {
                if (board.Grid[first, second].Symbol.Equals("_") &&
                    !board.Grid[first, second].Symbol.Equals("X") &&
                    !board.Grid[first, second].Symbol.Equals("O"))
                {
                    return true;
                }
            }
            return false;
        }

        public void ResetBoard(Board board)
        {
            board.InitializeBoardValues(board.Size);
            board.XTurn = true;
            board.XorO = "X";
        }
    }
}
