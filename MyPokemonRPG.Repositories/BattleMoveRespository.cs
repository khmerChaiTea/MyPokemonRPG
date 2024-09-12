using MyPokemonRPG.Models.Moves;
using System;

namespace MyPokemonRPG.Repositories
{
    public class BattleMoveRespository : BaseRepository<BattleMove>
    {
        protected override IList<BattleMove> Items { get; } = new List<BattleMove>()
        {
            new Struggle(),
            new BattleMove(2, "Tackle", Models.MonsterType.Normal, 35, "A physical attack in which the user charges, full body, into the foe.", 40, 100),
            new BattleMove(3, "Growl", Models.MonsterType.Normal, 40, "The user growls in an endearing way, making the fow less wary. The target's Attack stat is lowered.", 0, 100)
        };
    }
}
