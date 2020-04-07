using System;
using System.Collections.Generic;
using System.Text;

namespace Game.GUI
{
    class Button : GuiObject
    {
        private Frame frame;
        private TextLine textLine;
        public string Label
        {
            get { return textLine.Label; }
            set { textLine.Label = value; }
        }

        public Button(int x, int y, int width, int height, string buttonText) : base(x, y, width, height)
        {
            frame = new Frame(x, y, width, height, '$');
            textLine = new TextLine(x + 1, y + 1 + ((height - 2) / 2), width - 2, buttonText);
        }

        public override void Render()
        {
            frame.Render();
            textLine.Render();
        }


    }
}
