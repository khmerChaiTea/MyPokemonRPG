using System;

namespace MyPokemonRPG.BattleSystem.Exceptions
{
    public class BattleStateException : Exception
    {
        public BattleStateException(string? message) : base(message) { }
    }
}
