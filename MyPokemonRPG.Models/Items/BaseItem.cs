using System;

namespace MyPokemonRPG.Models.Items
{
    public class BaseItem : IIdentifiable, INamed
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public BaseItem(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
