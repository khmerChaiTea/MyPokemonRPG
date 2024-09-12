using MyPokemonRPG.Models;
using MyPokemonRPG.Models.Moves;
using System;

namespace MyPokemonRPG.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class, IIdentifiable
    {
        protected abstract IList<T> Items { get; }

        public T? Get(int id)
        {
            return Items.Where(m => m.Id == id).FirstOrDefault();
        }

        public IList<T> GetAll()
        {
            return Items;
        }

        public int Save(T item, bool allowUpdate = true)
        {
            var existing = Get(item.Id);
            if (item.Id > 0 && existing != null)
            {
                // We have a match, item is existing.
                if (allowUpdate)
                {
                    // Update existing
                    Items[Items.IndexOf(existing)] = item;
                    return item.Id;
                }
                return -1;
            }
            // Add new item
            item.Id = Items.OrderBy(m => m.Id).Last().Id + 1;
            Items.Add(item);
            return item.Id;
        }
    }
}
