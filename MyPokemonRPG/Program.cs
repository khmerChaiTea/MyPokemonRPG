using MyPokemonRPG.Models.Monsters;
using MyPokemonRPG.Models.Players;
using MyPokemonRPG.Repositories;
using System;

namespace MyPokemonRPG;

public class Program
{
    public static void Main(string[] args)
    {
        var battleManager = new BattleSystem.BattleManager();

        var player1 = new COMPlayer("AI player 1");
        var player2 = new COMPlayer("AI player 2");

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

        battleManager.StartBattle(player1, player2);

        Console.ReadLine();
    }
}
