using System;
using System.Collections.Generic;
using System.Text;

namespace Game.GUI
{
    class GameWindow : Window
    {
        private Button dealerButton;
        private Button playerButton;
        private TextBlock titleTextBlock;

        public List<Button> buttons = new List<Button>();

        public GameWindow() : base(0, 0, 120, 30, '$')
        {
            titleTextBlock = new TextBlock(4, 12, 100, new List<string> { "Press:", "D to Deal", "Enter to Hit", "Space to Stand", "S to split"});
            dealerButton = new Button(51, 2, 15, 5, "DEALER");
            playerButton = new Button(51, 23, 15, 5, "PLAYER");

            AddButtonList();
        }

        private void AddButtonList()
        {
            buttons.Add(dealerButton);
            buttons.Add(playerButton);
        }

        public override void Render()
        {
            base.Render();
            titleTextBlock.RenderText();

            foreach (Button item in buttons)
            {
                item.Render();
            }

            Console.SetCursorPosition(0, 0);

        }


    }
}
