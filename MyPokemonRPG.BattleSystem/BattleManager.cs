using MyPokemonRPG.Models.Players;
using System;

namespace MyPokemonRPG.BattleSystem
{
    public class BattleManager
    {
        public BattleManager()
        { 

        }

        public void StartBattle(BasePlayer playerOne, BasePlayer playerTwo)
        {
            Console.WriteLine($"Starting battle between {playerOne.Name} and {playerTwo.Name}!");
            Console.WriteLine($"\t{playerOne.Name}'s Party: \n\t - {playerOne.ListParty()}\n");
            Console.WriteLine($"\t{playerTwo.Name}'s Party: \n\t - {playerTwo.ListParty()}");
        }
    }
}
