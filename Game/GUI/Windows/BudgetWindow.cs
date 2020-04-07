using System;
using System.Collections.Generic;
using System.Text;

namespace Game.GUI
{
    class BudgetWindow : Window
    {

        public BudgetWindow() : base(0, 0, 120, 30, '$')
        {

        }

        public override void Render()
        {
            base.Render();
            Console.SetCursorPosition(0, 0);
        }



    }
}
