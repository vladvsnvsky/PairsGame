using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tema1
{
    class GameController
    {
        private List<string> images = new List<string>();

        private Random random = new Random(DateTime.Now.Millisecond);

        //public Tuple<bool, string>[,] gameBoard;

        public Board gameBoard;

        public Tuple<int, int> selected1;
        public Tuple<int, int> selected2;

        public bool gameIsActive = false;

        public int score = 0;

        private int lines = 3;
        private int cols = 3;
        private int items = 9;

        public GameController(int nrLines, int nrColumns)
        {
            lines = nrLines;
            cols = nrColumns;
            items = lines * cols;
            gameBoard = new Board(lines, cols);

        }

        public GameController(Board b)
        {
            lines = b.Height;
            cols = b.Width;
            items = lines * cols;
            gameBoard = b;
            for (int i = 0; i < lines; i++)
            {
                for(int j=0;j<cols;j++)
                    if (gameBoard[i, j].Item1 == true)
                        score++;
            }
        }

        private void assignImagesToButtons()
        {
            //for every button on the grid
            for (int l = 0; l < lines; l++)
            {
                for (int c = 0; c < cols; c++)
                {
                    var pathIndex = random.Next(images.Count());
                    if (images.Count() > 0)
                    {
                        gameBoard[l, c] = new Column(
                            false, images[pathIndex]
                        );
                        images.RemoveAt(pathIndex);
                    }

                    
                }

            }
            
        }

        public void startGame()
        {
            gameIsActive = true;
            score = 0;
            
            items = lines * cols;
            gameBoard = new Board(lines, cols);

            for (int i = 1; i <= items / 2; i++)
            {
                string path = "Assets/Images/" + i.ToString() + ".png";
                images.Add(path);
                images.Add(path);
            }

            assignImagesToButtons();
        }

        public void mark(int line1, int col1, int line2, int col2)
        {
            gameBoard[line1,col1] = new Column(true, gameBoard[line1, col1].Item2);
            gameBoard[line2, col2]= new Column(true, gameBoard[line2, col2].Item2);
            this.score += 2;
        }

        public void stopGame()
        {
            this.gameIsActive = false;
        }

        public void saveGame(Player p)
        {

        }
    }
}
