using System;
using System.Collections.Generic;
using System.Text;
using Game.GUI;
using Game.GUI.Windows;

namespace Game.Controllers
{
    static class Screen
    {
        public static GameWindow gameWindow;
        public static BudgetWindow budgetWindow;
        public static GoodByeWindow goodBye;
        public static EndWindow endWindow;
        public static StartWindow startWindow;


        public static void StartWindowRender()
        {
            startWindow = new StartWindow();
            startWindow.Render();
        }

        public static void GameWindowRender()
        {
            gameWindow = new GameWindow();
            gameWindow.Render();
        }

        public static void BudgetWindowRender()
        {
            budgetWindow = new BudgetWindow();
            budgetWindow.Render();
        }

        public static void GoodByeRender()
        {
            goodBye = new GoodByeWindow();
            goodBye.Render();
        }

        public static void EndWindowRender()
        {
            endWindow = new EndWindow();
            endWindow.Render();
        }


    }
}
