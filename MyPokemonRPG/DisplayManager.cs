using MyPokemonRPG.Models;
using System;

namespace MyPokemonRPG
{
    public class DisplayManager : IDisplayManager
    {
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
