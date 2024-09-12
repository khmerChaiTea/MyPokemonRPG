using System;

namespace MyPokemonRPG.Models.Moves
{
    public class BattleMove : IIdentifiable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MonsterType Type { get; set; }
        public int MaxPP { get; set; }
        public int CurrentPP { get; set; }
        public string Description { get; set; }
        public int Power { get; set; }
        public int Accuracy { get; set; }

        public BattleMove(int id, string name, MonsterType type,  int maxPP, string description, int power, int accuracy)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Type = type;
            MaxPP = maxPP;
            CurrentPP = maxPP;
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Power = power;
            Accuracy = accuracy;
        }
    }
}
