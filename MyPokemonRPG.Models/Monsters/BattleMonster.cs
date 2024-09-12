using MyPokemonRPG.Models.Moves;
using System;

namespace MyPokemonRPG.Models.Monsters
{
    public class BattleMonster : IIdentifiable
    {
        // Pokemon Number
        public int Id { get; set; }

        // Monster's Name
        public string Name { get; set; }

        // Experience Level
        public int Level { get; set; } = 1;

        // Pokemon Type
        public MonsterType Type { get; set; }

        // Health
        public int Hp { get; set; }

        // Base Arrack Stat (Physical and Special)
        public int Attack { get; set; }

        // Base Defense Stat (Physical and Special)
        public int Defense { get; set; }

        // Base Speed Stat (used to determine round order)
        public int Speed { get; set; }

        // Up to 4 Moves that the monster knows
        // --TODO: Add controls/restrictions for learning new moves.
        // -- NOTE: When learning a 5th move, it actually needs to replace
        // -- one of the existing 4 moves.
        public virtual IList<BattleMove> MoveList { get; set; }

        public BattleMonster(int id, string name, MonsterType type,  int hp, int attack, int defense, int speed, IList<BattleMove> moveList)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Type = type;
            Hp = hp;
            Attack = attack;
            Defense = defense;
            Speed = speed;
            if (moveList == null || moveList.Count == 0)
                moveList = new List<BattleMove> { new Struggle() };
            MoveList = moveList;
        }
    }
}
