using System;
using System.Collections.Generic;
using System.Text;

namespace JeuxDeLaVie_WindowsForms
{
    public struct Coords
    {
        private int _x;
        private int _y;

        public int x
        {
            get { return _x; }
            set { _x = value; }
        }
        public int y
        {
            get { return _y; }
            set { _y = value; }
        }
        public Coords(int x, int y)
        {
            _x = x;
            _y = y;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
