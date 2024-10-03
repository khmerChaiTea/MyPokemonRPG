using MyPokemonRPG.Models;
using System;

namespace MyPokemonRPG.Repositories
{
    public interface IRepository<T> where T : class, IIdentifiable
    {
        T? Get(int id);

        IList<T> GetAll();

        // Save an item by Create or Update if allowUpdate is true.
        // Otherwise it will return -1 if the item already exists.
        int Save(T item, bool allowUpdate = true);

        bool Delete(T item);
        bool Delete(int id);
    }
}
