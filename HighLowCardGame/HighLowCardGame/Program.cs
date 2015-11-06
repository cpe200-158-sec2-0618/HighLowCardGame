using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowCardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game HLGame;
            string playagian = "n";
            do
            {
                HLGame = new Game();
                while (!HLGame.IsEnd())
                {
                    HLGame.Compared();
                    Console.WriteLine(" Press Enter to play new turn.....");
                    Console.ReadKey();
                }
                Console.WriteLine("  ####################");
                Console.WriteLine("  # PLAY AGIAN (y/n) #");
                Console.Write("  ####################   =>  ");
                playagian = Console.ReadLine();
            } while (playagian == "Y" || playagian == "y");
        }
    }
}
