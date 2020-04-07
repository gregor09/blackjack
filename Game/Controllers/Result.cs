using System;
using System.Collections.Generic;
using System.Text;
using Game.GUI;

namespace Game.Controllers
{
    class Result
    {
        private TextBlock againTextBlock;
        private bool isWin;


        public bool CheckPlayerWin(int playerPoints)
        {
            if (playerPoints == 21)
                return true;
            else
                return false;
        }

        public bool CheckPlayerLoss(int playerPoints)
        {
            if (playerPoints > 21)
                return true;
            else
                return false;
        }


        public bool FindWinner(int playerPoints, int dealerPoints)
        {
            if (playerPoints < 21 && dealerPoints < 21)
            {
                if ((21 - playerPoints) < (21 - dealerPoints))
                {
                    isWin = true;
                }
                else
                {
                    isWin = false;
                }
            }
            else if (dealerPoints > 21)
            {
                isWin = true;
            }
            else if (dealerPoints == 21)
            {
                isWin = false;
            }

            return isWin;
        }

        public bool CheckPush(int playerPoints, int dealerPoints)
        {
            if (playerPoints == dealerPoints)
                return true;
            else
                return false;
        }


        public void PrintWin()
        {
            Console.Write("YOU WON!");
            PrintAgainText();
        }

        public void PrintLoss()
        {
            Console.Write("YOU LOST!");
            PrintAgainText();
        }

        public void PrintPush()
        {
            Console.Write("PUSH!");
            PrintAgainText();
        }

        public void PrintAgainText()
        {
            Console.SetCursorPosition(34, 18);
            Console.WriteLine("                                     ");
            againTextBlock = new TextBlock(34, 17, 50, new List<string> { "Press 0 for a new Deal", "Press Esc to Quit" });
            againTextBlock.Render();
        }

        public void PrintHand1()
        {
            Console.SetCursorPosition(50, 14);
            Console.Write("Hand 1");
            Console.SetCursorPosition(58, 14);
        }

        public void PrintHand2()
        {
            Console.SetCursorPosition(50, 15);
            Console.Write("Hand 2");
            Console.SetCursorPosition(58, 15);
        }


    }
}
