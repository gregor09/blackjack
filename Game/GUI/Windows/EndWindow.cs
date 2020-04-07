using System;
using System.Collections.Generic;
using System.Text;

namespace Game.GUI
{
    class EndWindow : Window
    {
        private TextBlock endTextBlock;

        public EndWindow() : base(0, 0, 120, 30, '$')
        {
            endTextBlock = new TextBlock(10, 10, 100, new List<string> { "YOU ARE OUT OF MONEY!", "GO HOME!" });
        }

        public override void Render()
        {
            base.Render();
            endTextBlock.Render();
            Console.SetCursorPosition(0, 0);
        }



    }
}
