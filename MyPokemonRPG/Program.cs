using MyPokemonRPG.Models.Monsters;
using MyPokemonRPG.Models.Players;
using MyPokemonRPG.Repositories;
using MyPokemonRPG.BattleSystem.Exceptions;
using System;

namespace MyPokemonRPG;

public class Program
{
    public static void Main(string[] args)
    {
        var inputManager = new UserInputManager();
        var displayManager = new DisplayManager();
        var battleManager = new BattleSystem.BattleManager();

        var player1 = new HumanPlayer("Chai Tea", inputManager, displayManager);
        var player2 = new HumanPlayer("AI player 2", inputManager, displayManager);

        var moveRepository = new BattleMoveRespository();
        var monsterRepository = new BattleMonsterRespository();

        var tackle = moveRepository.Get(2);
        var growl = moveRepository.Get(3);

        var bulbasaur = monsterRepository.Get(1);
        bulbasaur?.MoveList.Add(tackle);
        bulbasaur?.MoveList.Add(growl);
        var charmander = monsterRepository.Get(4);
        charmander?.MoveList.Add(tackle);
        charmander?.MoveList.Add(growl);

        player1.Party = new List<BattleMonster>
        {
            // Add Bulbasaur
            bulbasaur
        };

        player2.Party = new List<BattleMonster>
        {
            // Add Charmander
            charmander
        };

        try
        {
            displayManager.DisplayMessage($"Starting battle between {player1.Name} and {player2.Name}!" +
                $"\n\t{player1.Name}'s Party:\n\t- {player1.ListParty()}" + 
                $"\n\t{player2.Name}'s Party:\n\t- {player2.ListParty()}");

            battleManager.StartBattle(player1, player2);
        }
        catch (BattleStateException e)
        {
            displayManager.DisplayMessage("Battle State Exception caught" + e.Message);
        }

        Console.ReadLine();
    }
}
