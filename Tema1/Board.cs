using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tema1
{
    [XmlRoot(ElementName = "Column")]
    public class Column
    {

        [XmlElement(ElementName = "Item1")]
        public bool Item1 { get; set; }

        [XmlElement(ElementName = "Item2")]
        public string Item2 { get; set; }

        public Column()
        {

        }

        public Column(bool state, string path)
        {
            Item1 = state;
            Item2 = path;
        }
    }


    [XmlRoot(ElementName = "Row")]
    public class Row
    {
        [XmlElement(ElementName = "Column")]
        public Column[] Data { get; set; }

        public int Size;

        public Row()
        {

        }
        public Row(int length)
        {
            Data = new Column[length];
            Size = length;
        }

        public Column this[int index]
        {
            get
            {
                if (index < 0 || index >= Size)
                    throw new IndexOutOfRangeException();

                return Data[index];
            }
            set
            {
                if (index < 0 || index >= Size)
                    throw new IndexOutOfRangeException();

                Data[index] = value;
            }
        }
    }



    [XmlRoot(ElementName = "Board")]
    public class Board
    {
        public int Height=0;
        public int Width=0;

        [XmlElement(ElementName = "Row")]
        public Row[] rows;

        public Board()
        {

        }
        public Board(int height, int width)
        {
            Height = height;
            Width = width;
            rows = new Row[height];
            for (int i = 0; i < height; i++)
            {
                rows[i] = new Row(width);
            }
        }

        public Column this[int line, int col]
        {
            get
            { // Check that the index is within bounds.
                if (line < 0 || line >= Height)
                {
                    throw new IndexOutOfRangeException();
                }
                if (col < 0 || line >= Width)
                {
                    throw new IndexOutOfRangeException();
                }

                // Return the value at the specified index.
                return rows[line].Data[col];
            }
            set{
                if (line < 0 || line >= Height)
                {
                    throw new IndexOutOfRangeException();
                }
                if (col < 0 || line >= Width)
                {
                    throw new IndexOutOfRangeException();
                }

                rows[line].Data[col] = value;
            }
        }
    }
}
