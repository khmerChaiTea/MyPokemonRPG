using MyPokemonRPG.Models;
using System;

namespace MyPokemonRPG
{
    public class UserInputManager : IUserInputManager
    {
        public UserInputManager() { }

        public int GetUserSelection(string prompt, int min, int max)
        {
            var userChoice = 0;
            do
            {
                Console.WriteLine(prompt);
            } while (!int.TryParse(Console.ReadLine(), out userChoice) || userChoice < min || userChoice > max);
            return userChoice;
        }
    }
}
