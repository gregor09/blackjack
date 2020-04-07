using System;
using System.Collections.Generic;
using System.Text;

namespace Game.GUI
{
    class GoodByeWindow : Window
    {

        private TextBlock byeTextBlock;

        public GoodByeWindow() : base(0, 0, 120, 30, '$')
        {
            byeTextBlock = new TextBlock(10, 10, 100, new List<string> { "GOODBYE!!!" });
        }

        public override void Render()
        {
            base.Render();
            byeTextBlock.Render();
            Console.SetCursorPosition(0, 0);
        }


    }
}
