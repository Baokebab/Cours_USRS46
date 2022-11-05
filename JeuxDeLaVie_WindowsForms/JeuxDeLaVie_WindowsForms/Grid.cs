using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace JeuxDeLaVie_WindowsForms
{
    class Grid
    {
        private int _n;
        public Cell[,] TabCells;
        public bool hasChanged = false;

        public int n
        {
            get { return _n; }
            set { _n = value; }
        }
        public Grid(int nbCells, List<Coords> AliveCellsCoords)
        {
            _n = nbCells;
            TabCells = new Cell[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    TabCells[i, j] = new Cell(false);
                }
            }
            for (int p = 0; p < AliveCellsCoords.Count; p++)
            {
                TabCells[AliveCellsCoords[p].x, AliveCellsCoords[p].y] = new Cell(true) ;
            }
            
        }
        public int GetNbAliveNeighboor(int i, int j)
        {
            int res = 0;
            //Haut
            if (i > 0 && TabCells[i - 1, j].isAlive) res++;
            if (i > 0 && j > 0 && TabCells[i - 1, j - 1].isAlive) res++;
            if (i > 0 && j < n - 1 && TabCells[i - 1, j + 1].isAlive) res++;
            //Bas
            if (i < n-1 && TabCells[i + 1, j].isAlive) res++;
            if (i < n - 1 && j > 0 && TabCells[i + 1, j - 1].isAlive) res++;
            if (i < n - 1 && j < n - 1 && TabCells[i + 1, j + 1].isAlive) res++;
            //Gauche
            if (j > 0 &&  TabCells[i, j - 1].isAlive) res++;
            //Droite
            if (j < n-1 && TabCells[i, j + 1].isAlive) res++;

            return res;
        }
        public List<Coords> getCoordsNeighboors(int i, int j)
        {
            List<Coords> res = new List<Coords>();
            //Haut
            if (i > 0) res.Add(new Coords(i-1,j));
            if (i > 0 && j > 0) res.Add(new Coords(i-1,j-1));
            if (i > 0 && j < n - 1) res.Add(new Coords(i-1,j+1));
            //Bas
            if (i < n - 1) res.Add(new Coords(i+1,j));
            if (i < n - 1 && j > 0) res.Add(new Coords(i+1,j-1));
            if (i < n - 1 && j < n - 1) res.Add(new Coords(i+1,j+1));
            //Gauche
            if (j > 0) res.Add(new Coords(i,j-1));
            //Droite
            if (j < n - 1) res.Add(new Coords(i,j+1));

            return res;
        }
        public List<Coords> getCoordsCellsAlive()
        {
            List<Coords> res = new List<Coords>();
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (TabCells[i, j].isAlive) res.Add(new Coords(i, j));
                }
            }
            return res;
        }
        public void DisplayGrid()
        {
            Console.WriteLine(string.Concat(Enumerable.Repeat("+---", n)) +"+");         
            for(int i = 0; i < n; i++)
            {
               
               StringBuilder temp = new StringBuilder();
               temp.Insert(0, "|   ", n); temp.Append("|");
               for(int j = 0; j < n; j++)
               {
                   if (TabCells[i, j].isAlive) temp[4*j+2] = 'X';
               }
               Console.WriteLine(temp);
               Console.WriteLine(string.Concat(Enumerable.Repeat("+---", n)) + "+");
            }
        }
        public void UpdateGrid()
        {
            
            hasChanged = false;
            for(int i = 0; i < n; i ++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (!TabCells[i, j].isAlive && GetNbAliveNeighboor(i, j) == 3) TabCells[i, j].nextState = true;
                    else if (TabCells[i, j].isAlive)
                    {
                        if(GetNbAliveNeighboor(i, j) == 3 || GetNbAliveNeighboor(i, j) == 2) TabCells[i, j].nextState = true;
                        else TabCells[i, j].nextState = false;
                    }
                    else
                    {
                        TabCells[i, j].nextState = false;
                    }
                    if (!hasChanged && TabCells[i, j].isAlive != TabCells[i, j].nextState)
                    {
                        hasChanged = true;
                    }
                }
            }
            if(hasChanged)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        TabCells[i, j].Update();
                    }
                }
            }

        }

    }
}
