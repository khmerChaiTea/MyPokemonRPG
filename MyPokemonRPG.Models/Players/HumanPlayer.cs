using MyPokemonRPG.Models.Items;
using MyPokemonRPG.Models.Monsters;
using System;
using System.Text;
using System.Threading;

namespace MyPokemonRPG.Models.Players
{
    public class HumanPlayer : BasePlayer
    {
        private IDisplayManager _displayManager;
        private IUserInputManager _inputManager;

        public HumanPlayer(string name, IUserInputManager inputManager, IDisplayManager displayManager) : base(name)
        {
            _displayManager = displayManager;
            _inputManager = inputManager;
        }

        public override void StartTurn()
        {
            // Get current/active pokemon
            var pokemon = Party?.Where(p => p.Hp > 0)?.FirstOrDefault();
            if (pokemon == null)
            {
                _displayManager.DisplayMessage($"{Name} is out of pokemon. {Name} black out.");
                return;
            }

            var userChoice = _inputManager.GetUserSelection($"It is {Name}'s turn. what would you like to do?\n" +
                        $"\n\t1. Fight" +
                        $"\n\t2. Pokemon" +
                        $"\n\t3. Bag" +
                        $"\n\t4. Run", 1, 4);

            IList<INamed> emptyItemList = new List<INamed>();

            switch (userChoice)
            {
                case 1: // Fight
                    MakeSelection(pokemon.MoveList, $"What do you want {pokemon.Name} to do?");
                    break;

                case 2: // Pokemon
                    MakeSelection(Party, $"Which pokemon would you like to swap in?");
                    break;

                case 3: // Bag
                    MakeSelection(emptyItemList, "Bag is empty.");
                    // Only option should be 'Cancel'
                    break;

                case 4: // Run
                    // If in a wild encounter, try to escape
                    // --TODO: Handle Wild Encounter

                    // If in a trainer battle, this isn't allowed.
                    // For now, force this second path.
                    MakeSelection(emptyItemList, "Cannot run from a trainer battle.");
                    break;

                default: // Should be unreachable
                    break;
            }
        }

        private void MakeSelection<T>(IList<T>? collection, string prompt) where T : INamed
        {
            if (collection == null)
            {
                _displayManager.DisplayMessage("Collection is null.");
                return;
            }

            var sb = new StringBuilder();
            var index = 0;
            foreach (var item in collection)
            {
                sb.AppendLine($"{++index}. {item.Name}");
            }
            sb.AppendLine($"{++index}. Cancel");
            var userChoice = _inputManager.GetUserSelection($"{prompt} \n{sb}", 1, index);
            if (userChoice == index)
            {
                // Cancel
                StartTurn();
                return;
            }
            else
            {
                var item = collection[userChoice - 1];
                _displayManager.DisplayMessage("Selected " + item.Name);
            }
        }
    }
}
