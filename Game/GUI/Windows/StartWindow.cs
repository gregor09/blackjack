using System;
using System.Collections.Generic;
using System.Text;

namespace Game.GUI.Windows
{
    class StartWindow : Window
    {

        private Frame yesFrame;
        private Frame noFrame;
        private TextBlock titleTextBlock;

        public StartWindow() : base(0, 0, 120, 30, '$')
        {
            titleTextBlock = new TextBlock(10, 5, 100, new List<string> { "Wellcome to Black Jack Casino!" });

            yesFrame = new Frame(44, 10, 32, 5, '*');

            noFrame = new Frame(44, 17, 32, 5, '*');
        }

    

        public override void Render()
        {
            base.Render();
            titleTextBlock.Render();
            yesFrame.Render();
            Console.SetCursorPosition(48, 12);
            Console.WriteLine("Press Enter to Start");
            noFrame.Render();
            Console.SetCursorPosition(52, 19);
            Console.WriteLine("Press Esc to Quit");

            Console.SetCursorPosition(0, 0);

        }
    }
}
