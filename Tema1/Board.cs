using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1
{
    class Board
    {
        private int Lines;
        private int Cols;
        public Board(int lines, int cols)
        {
            Data = new Tuple<bool, string>[lines, cols];
            Lines = lines;
            Cols = cols;
        }

        public Tuple<bool, string>[,] Data { get; set; }

        public Tuple<bool, string> this[int line, int col]
        {
            get
            { // Check that the index is within bounds.
                if (line < 0 || line >= Lines)
                {
                    throw new IndexOutOfRangeException();
                }
                if (col < 0 || line >= Cols)
                {
                    throw new IndexOutOfRangeException();
                }

                // Return the value at the specified index.
                return Data[line,col];
            }
            set{
                if (line < 0 || line >= Lines)
                {
                    throw new IndexOutOfRangeException();
                }
                if (col < 0 || line >= Cols)
                {
                    throw new IndexOutOfRangeException();
                }

                Data[line,col] = value;
            }
        }
    }
}
