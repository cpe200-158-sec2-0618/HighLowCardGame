using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowCardGame
{
    class Game
    {
        private List<Player> player = new List<Player>();
        private Deck allCard;

        public List<Player> Player 
        {
            get { return player; }
        }

        public Deck AllCard
        {
            get { return allCard; }
            set { allCard = value; }
        }

        public Game()
        {
            Player.Add(new Player());
            Player.Add(new Player());
            StartGame();
        }

        public void StartGame()
        {
            Console.WriteLine(" (:3[___] STARTING GAME _(:3JL)_ =3");
            Console.Write(" =w= Please Enter Player 1 Name : ");
            Player[0].Name = Console.ReadLine();
            do
            {
                Console.Write(" =w= Please Enter Player 2 Name : ");
                Player[1].Name = Console.ReadLine();
            } while (Player[0].Name == Player[1].Name);
            AllCard = new Deck();
            AllCard.Shuffle();
            Deal();
        }

        public void Deal()
        {
            while (AllCard.Card.Count() != 0) 
            {
                for(int i=0; i< Player.Count(); i++)
                {
                    Player[i].Pile.Card.Add(AllCard.Card[0]);
                    AllCard.Card.RemoveAt(0);
                }
            }
            Console.WriteLine(" >> Card is Dealed...");
        }

        public int TopCard(int numplayer)
        {
            string[] face = { "Ace", "Deuce", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
            string[] suit = { "Clubs", "Diamonds", "Hearts", "Spades" };
            int card = Player[numplayer].Pile.Card[0];
            int cardface = (card % 13 != 0 ? card % 13 : 13);
            int cardsuit = (card % 13 != 0 ? card / 13 : (card / 13 )- 1);
            Player[numplayer].Pile.Card.RemoveAt(0);
            Console.WriteLine(" \"" + Player[numplayer].Name + "\" draws a " + face[cardface-1] + ' ' + suit[cardsuit]);
            return cardface;
        }

        public void Compared()
        {
            Console.WriteLine();
            Console.WriteLine("New Turn");
            int cardP1 = TopCard(0);
            int cardP2 = TopCard(1);
            if (cardP1 == cardP2)
            {
                Console.WriteLine(" >> This turn both players have the same rank");
                Console.WriteLine(" >> Both player draw cards equal that rank and turn over the last card and compare");
                if (Player[0].Pile.Card.Count() == 0 || Player[1].Pile.Card.Count() == 0)
                {
                    Console.WriteLine(" >> Draw ! <last card of all player is equal> ");
                }
                else if (cardP1 > Player[0].Pile.Card.Count() || cardP2 > Player[1].Pile.Card.Count())
                {
                    Console.WriteLine(" >> Each player has card in their pile less than that rank");
                    Console.Write(" >> " + Player[0].Name + ' ');
                    Player[0].Pile.Card.Add(cardP1);
                    Player[0].Pile.Shuffle();
                    Console.Write(" >> " + Player[1].Name + ' ');
                    Player[1].Pile.Card.Add(cardP2);
                    Player[1].Pile.Shuffle();
                }
                else if (Player[0].Pile.Card[cardP1 - 1] == Player[1].Pile.Card[cardP2 - 1])
                {
                    Console.WriteLine(" >> Both players have the same rank again");
                    Console.Write(" >> " + Player[0].Name + ' ');
                    Player[0].Pile.Card.Add(cardP1);
                    Player[0].Pile.Shuffle();
                    Console.Write(" >> " + Player[1].Name + ' ');
                    Player[1].Pile.Card.Add(cardP2);
                    Player[1].Pile.Shuffle();
                }
                else if (Player[0].Pile.Card[cardP1-1] != Player[1].Pile.Card[cardP2-1])
                {
                    int hold = cardP1;
                    int scoretemp = 2;
                    for (int i=0; i < hold; i++)
                    {
                        cardP1 = TopCard(0);
                        cardP2 = TopCard(1);
                        scoretemp += 2;
                    }
                    if (cardP1 < cardP2)
                    {
                        Console.WriteLine(" >> This turn " + Player[0].Name + " is winner");
                        Player[0].Score += scoretemp;
                    }
                    else if (cardP1 > cardP2)
                    {
                        Console.WriteLine(" >> This turn " + Player[1].Name + " is winner");
                        Player[1].Score += scoretemp;
                    }
                }
            }
            else if (cardP1 < cardP2)
            {
                Console.WriteLine(" >> This turn " + Player[0].Name + " is winner");
                Player[0].Score += 2;
            }
            else if (cardP1 > cardP2)
            {
                Console.WriteLine(" >> This turn " + Player[1].Name + " is winner");
                Player[1].Score += 2;
            }
        }

        public bool IsEnd()
        {
            if (Player[0].Pile.Card.Count() == 0 || Player[1].Pile.Card.Count() == 0)
            {
                Console.WriteLine(" ===================================================");
                if (Player[0].Score == Player[1].Score)
                {
                    Console.WriteLine(" >> DRAW ! ");
                }
                else
                {
                    Console.WriteLine(" >> The winner is " + ((Player[0].Score > Player[1].Score) ? Player[0].Name : Player[1].Name));
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
