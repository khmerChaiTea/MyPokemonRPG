using System;

namespace MyPokemonRPG.Models
{
    public interface IUserInputManager
    {
        int GetUserSelection(string prompt, int min, int max);
    }
}
