using System;
using System.Collections.Generic;
using System.Text;
using Game.GUI;
using Game.Controllers;


namespace Game
{
    class GameController
    {
        private Game game;
        private Player player;
        private Result result = new Result();

        public void Play()
        {
            Screen.StartWindowRender();
            ConsoleKeyInfo pressedChar = Console.ReadKey(true);
            int hashCode = pressedChar.Key.GetHashCode();
            if (pressedChar.Key == ConsoleKey.Enter)
            {
                EnterBudget();
                InitGame();
                StartGameLoop();
            }
            else
            {
                Screen.GoodByeRender();
            }
            
        }

        public void EnterBudget()
        {
            Screen.BudgetWindowRender();
            player = new Player();
            player.AskName();
            string name = Console.ReadLine();
            player.GetBudget(name);
        }

        public void InitGame()
        {
            game = new Game();
            Screen.GameWindowRender();
            player.Render();
        }


        public void StartAgain()
        {
            game.PlayAgain();
            Screen.GameWindowRender();
            player.Render();
            StartGameLoop();
        }


        public void StartGameLoop()
        {
            ConsoleKeyInfo pressedChar;

            while (player.Balance >= player.Bet)
            {

                do
                {
                    pressedChar = Console.ReadKey(true);
                    int hashCode = pressedChar.Key.GetHashCode();
                    switch (pressedChar.Key)
                    {
                        case ConsoleKey.D:
                            Deal();
                            break;
                        case ConsoleKey.Enter:
                            Hit();
                            break;
                        case ConsoleKey.Spacebar:
                            Stand();
                            break;
                        case ConsoleKey.D0:
                            StartAgain();
                            break;
                        case ConsoleKey.S:
                            Split();
                            break;
                    }
                }
                while (pressedChar.Key != ConsoleKey.Escape);
                Screen.GoodByeRender();
            }
            Screen.EndWindowRender();
        }



        public void Deal()
        {
            game.PrintCards();
            game.PrintDealerCard1();
            player.MakeBet(player.Name);
            player.Render();
            if (result.CheckPlayerWin(game.CountHandPoints(game.hand)))
            {
                Console.SetCursorPosition(54, 14);
                result.PrintWin();
                player.AddWin(player.Name);
            }
        }

        public void Hit()
        {
            game.AddCard(game.hand);
            game.PrintCards();
            player.Render();
            if (result.CheckPlayerWin(game.CountHandPoints(game.hand)))
            {
                Console.SetCursorPosition(54, 14);
                result.PrintWin();
                player.AddWin(player.Name);
            }
            if (result.CheckPlayerLoss(game.CountHandPoints(game.hand)))
            {
                Console.SetCursorPosition(54, 14);
                result.PrintLoss();
            }
        }

        public void Stand()
        {
            game.PrintAllDealerCards();
            while (game.dealerHand.CountHandPoints() < 17)
            {
                game.AddCard(game.dealerHand);
                game.PrintAllDealerCards();
            }

            if (result.FindWinner(game.CountHandPoints(game.hand), game.CountHandPoints(game.dealerHand)))
            {
                Console.SetCursorPosition(54, 14);
                result.PrintWin();
                player.AddWin(player.Name);
            }
            else if (result.CheckPush(game.CountHandPoints(game.hand), game.CountHandPoints(game.dealerHand)))
            {
                Console.SetCursorPosition(54, 14);
                result.PrintPush();
                player.ReturnBet(player.Name);
            }
            else
            {
                Console.SetCursorPosition(54, 14);
                result.PrintLoss();
            }

        }

        public void Split()
        {
            game.SplitCards();
            game.PrintAfterSplit();
            player.MakeBet(player.Name);
            player.Render();
            game.PlayAfterSplit();
            game.PrintAllDealerCards();
            while (game.dealerHand.CountHandPoints() < 17)
            {
                game.AddCard(game.dealerHand);
                game.PrintAllDealerCards();
            }

            if (result.CheckPlayerWin(game.CountHandPoints(game.hand)))
            {
                result.PrintHand1();
                result.PrintWin();
                player.AddWin(player.Name);
                player.Render();
            }
            else if (result.FindWinner(game.CountHandPoints(game.hand), game.CountHandPoints(game.dealerHand)))
            {
                result.PrintHand1();
                result.PrintWin();
                player.AddWin(player.Name);
                player.Render();
            }
            else if (result.CheckPush(game.CountHandPoints(game.hand), game.CountHandPoints(game.dealerHand)))
            {
                result.PrintHand1();
                result.PrintPush();
                player.ReturnBet(player.Name);
                player.Render();
            }
            else
            {
                result.PrintHand1();
                result.PrintLoss();
            }

            if (result.CheckPlayerWin(game.CountHandPoints(game.hand2)))
            {
                result.PrintHand2();
                result.PrintWin();
                player.AddWin(player.Name);
                player.Render();
            }
            else if (result.FindWinner(game.CountHandPoints(game.hand2), game.CountHandPoints(game.dealerHand)))
            {
                result.PrintHand2();
                result.PrintWin();
                player.AddWin(player.Name);
                player.Render();
            }
            else if (result.CheckPush(game.CountHandPoints(game.hand2), game.CountHandPoints(game.dealerHand)))
            {
                result.PrintHand2();
                result.PrintPush();
                player.ReturnBet(player.Name);
                player.Render();
            }
            else
            {
                result.PrintHand2();
                result.PrintLoss();
            }
        }

    }


}

