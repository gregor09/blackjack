using System;
using System.Collections.Generic;
using Game.GUI;
using Game.Controllers;
using System.Linq;
namespace Game

{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            GameController game = new GameController();
            game.Play();



            Console.ReadKey();

        }
    }
}
