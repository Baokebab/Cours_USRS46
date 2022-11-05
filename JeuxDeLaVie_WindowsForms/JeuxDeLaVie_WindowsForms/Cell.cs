using System;
using System.Collections.Generic;
using System.Text;

namespace JeuxDeLaVie_WindowsForms
{
    public class Cell
    {
        private bool _isAlive;
        private bool _nextState;

        public bool isAlive
        {
            get { return _isAlive; }
            set { _isAlive = value; }
        }

        public bool nextState
        {
            get { return _nextState; }
            set { _nextState = value; }
        }
        public Cell(bool state = false)
        {
            _isAlive = state;
        }

        /*
        public void ComeAlive()
        {
            nextState = true;
        }

        public void PassAway()
        {
            nextState = false;
        }
        */
        public void Update()
        {
            isAlive = nextState;
        }
    }
}
