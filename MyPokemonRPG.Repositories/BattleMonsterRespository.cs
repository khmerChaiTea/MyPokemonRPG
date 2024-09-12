using MyPokemonRPG.Models.Monsters;
using MyPokemonRPG.Models.Moves;
using System;

namespace MyPokemonRPG.Repositories
{
    public class BattleMonsterRespository : BaseRepository<BattleMonster>
    {
        protected override List<BattleMonster> Items { get; } = new List<BattleMonster>()
        {
            new BattleMonster(1, "Bulbasaur", Models.MonsterType.Grass, 45, 49, 49, 45, null),
            new BattleMonster(4, "Charmander", Models.MonsterType.Fire, 39,52, 43, 65, null),
            new BattleMonster(7, "Squirtle", Models.MonsterType.Water, 44, 48, 65, 43, null)
        };
    }
}
