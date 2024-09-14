using MyPokemonRPG.Models.Players;
using MyPokemonRPG.BattleSystem.Exceptions;
using System;

namespace MyPokemonRPG.BattleSystem
{
    public class BattleManager
    {
        public void StartBattle(BasePlayer playerOne, BasePlayer playerTwo)
        {
            var playerOneMonster = playerOne.Party?.Where(p => p.Hp >0)?.FirstOrDefault();
            var playerTwoMonster = playerTwo.Party?.Where(p => p.Hp > 0)?.FirstOrDefault();

            if (playerOneMonster == null || playerTwoMonster == null)
            {
                // We cannot battle
                throw new BattleStateException("A player's party does not have a valid battle monster.");
            }

            // Check speed of each starting Pokemon
            var startingPlayer = playerTwo;
            if (playerOneMonster.Speed >= playerTwoMonster.Speed)
            {
                startingPlayer = playerOne;
            }

            startingPlayer.StartTurn();
        }
    }
}
