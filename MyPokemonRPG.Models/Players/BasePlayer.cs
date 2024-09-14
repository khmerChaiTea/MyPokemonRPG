using MyPokemonRPG.Models.Monsters;
using System;
using System.Text;

namespace MyPokemonRPG.Models.Players
{
    public abstract class BasePlayer
    {
        public string Name { get; set; }

        public BasePlayer(string name)
        {  
            Name = name;
        }

        // Current party of pokemon. Max of 6 and need controls/restrictions
        // for swapping new pokemon with existing.
        public virtual IList<BattleMonster>? Party { get; set; }

        public virtual string ListParty()
        {
            if (Party == null)
                return $"{Name} is out of Battle Monsters";
            var sb = new StringBuilder();

            foreach (var monster in Party)
            {
                sb.AppendLine($"{monster.Name} (Lv. {monster.Level})");
            }
            return sb.ToString();
        }

        public abstract void StartTurn();
    }
}
