using MyPokemonRPG.Models.Monsters;
using MyPokemonRPG.Repositories;
using System;

namespace MyPokemonRPG.Respositories.Tests
{
    public class BattleMonsterRespositoryTests
    {
        private BattleMonsterRespository _repo;

        public BattleMonsterRespositoryTests()
        {
            _repo = new BattleMonsterRespository();
        }

        [Fact]
        public void Get_Returns_BattleMonster()
        {
            var item = _repo.Get(1);
            Assert.NotNull(item);
        }

        [Fact]
        public void Get_Returns_Null()
        {
            var item = _repo.Get(-1);
            Assert.Null(item);
        }

        [Fact]
        public void GetAll_Returns_NotNull()
        {
            var items = _repo.GetAll();
            Assert.NotNull(items);
        }

        [Fact]
        public void GetAll_Returns_Items()
        {
            var items = _repo.GetAll();
            Assert.True(items?.Count > 0);
        }

        [Fact]
        public void Save_Adds_Item_And_Delete_Removes_It()
        {
            var newPokemon = new BattleMonster(0, "Test Pokemon", Models.MonsterType.Dragon, 100, 50, 50, 45);
            var newId = _repo.Save(newPokemon);
            Assert.True(newId >  0);
            Assert.True(_repo.Delete(newId));
        }

        [Fact]
        public void Save_Updates_Item()
        {
            // Get a pokemon from the data source and ensure not null
            var existingPokemon =  _repo.GetAll().First();
            Assert.NotNull(existingPokemon);

            // Cache name and create a new, random name
            var existingName = existingPokemon.Name;
            var newName = Guid.NewGuid().ToString();
            existingPokemon.Name = newName;

            // Updating the entry
            var id = _repo.Save(existingPokemon);
            Assert.True(id == existingPokemon.Id);

            // Verify update worked
            var copy = _repo.Get(id);
            Assert.NotNull(copy);
            //Assert.True(copy.Name.Equals(newName));
            Assert.Equal(newName, copy.Name);
            Assert.True(copy.Attack.Equals(existingPokemon.Attack));
            //Assert.False(copy.Name.Equals(existingName));
            Assert.NotEqual(existingName, copy.Name);

            // Resetting the entry to previous fields
            existingPokemon.Name = existingName;
            id = _repo.Save(existingPokemon);
            Assert.True(id == existingPokemon.Id);
        }

        [Fact]
        public void Save_Disallows_Update_When_False()
        {
            // Get a pokemon from the data source and ensure not null
            var existingPokemon = _repo.GetAll().First();
            Assert.NotNull(existingPokemon);

            // Cache name and create a new, random name
            var existingName = existingPokemon.Name;
            var newName = Guid.NewGuid().ToString();
            existingPokemon.Name = newName;

            // Updating the entry
            var id = _repo.Save(existingPokemon, false);
            Assert.True(id == -1);
        }

        [Fact]
        public void Delete_Returns_False_On_Fail()
        {
            // Pokemon id is greater 0, so -1 __shouldn't__ exist
            Assert.False(_repo.Delete(-1));
        }
    }
}
