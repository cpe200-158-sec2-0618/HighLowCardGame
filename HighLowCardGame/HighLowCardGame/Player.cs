using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowCardGame
{
    class Player
    {
        private string name;
        private int score;
        private Deck pile = new Deck();
    
        public Deck Pile
        {
            get { return pile; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public Player()
        {
            Name = "No name";
            Score = 0;
            Pile.Card.Clear();
        }
    }
}
