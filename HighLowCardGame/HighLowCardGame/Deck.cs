using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowCardGame
{
    class Deck
    {
        private List<int> card = new List<int>();

        public List<int> Card
        {
            get { return card;}
            set
            {
                card = new List<int>(value);
            }
        }

        public Deck()
        {
            for (int i=0; i<52; i++)
            {
                Card.Add(i+1);
            }
        }

        public void Shuffle()
        {
            List<int> copy = new List<int>(Card);
            Card.Clear();
            Random rand = new Random();
            while(copy.Count() != 0)
            {
                int index = rand.Next(copy.Count());
                Card.Add(copy[index]);
                copy.RemoveAt(index);
            }
            Console.WriteLine(" >> Card is Shuffled...");
        }
    }
}
