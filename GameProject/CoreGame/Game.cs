using GameProject.CoreGame;
using GameProject.CoreGame.Saves;
using GameProject.GameplaySystems;
using GameProject.Map;
using GameProject.Models.Characters;
using GameProject.Models.Enums;
using GameProject.Models.Items.Base;

namespace GameProject.Core
{
    public class Game
    {
        ILocation currentLocation;
        Player player;
        private readonly SaveSystem _saveSystem = new SaveSystem();

        public void Start()
        {
            GameStart();
            GameLoop();
        }

        public void GameStart()
        {
            if (_saveSystem.SaveExists())
            {
                Console.Clear();
                Console.WriteLine("Save data found.");
                Console.WriteLine("1. Continue");
                Console.WriteLine("2. New Game");
                string choice = Console.ReadLine()?.Trim();
                if (choice == "1")
                {
                    LoadGame();
                    return;
                }
            }

            player = new Player("Survivor", 80, 10, 0);

            currentLocation = new Location(
                "Police Station Entrance",
                "You stand outside the police station. The building looms above you.",
                false,
                LocationType.Entrance
            );
        }

        public void LoadGame()
        {
            SaveData save = _saveSystem.Load();

            player = new Player(save.PlayerName, save.PlayerMaxHealth, save.PlayerDamage, 0);
            player.Health = save.PlayerHealth;

            foreach (var item in save.Inventory.Where(i => i.HealAmount > 0))
                player.AddItem(new HealingItem(item.Name, item.Quantity, item.HealAmount));

            foreach (var item in save.Inventory.Where(i => i.HealAmount == 0))
            {
                var baseItem = new BaseItem(item.Name, item.Quantity);
                baseItem.IsKey = item.IsKey;
                player.AddItem(baseItem);
            }

            currentLocation = BuildLocation(save.CurrentLocation);
        }

        private Location BuildLocation(LocationType type)
        {
            switch (type)
            {
                case LocationType.Corridor:
                    var corridor = new Location("Police Station Lobby", "You are in the front corridor.", false, LocationType.Corridor);
                    return corridor;
                case LocationType.MainLobby:
                    var lobby = new Location("Main Lobby", "You are in the main lobby.", false, LocationType.MainLobby);
                    lobby.Interactibles.Add(new Typewriter());
                    return lobby;
                default:
                    return new Location("Police Station Entrance", "You stand outside the police station.", false, LocationType.Entrance);
            }
        }

        public void GameLoop()
        {
            while (true)
            {
                currentLocation.ShowMap();

                string hpBar = "";
                int filled = player.Health * 20 / player.MaxHealth;
                for (int i = 0; i < 20; i++)
                {
                    if (i < filled)
                        hpBar += "|";
                    else
                        hpBar += "-";
                }

                string hpText = player.Health + "/" + player.MaxHealth;
                string fullBar = "HP [" + hpBar + "] " + hpText;

                int savedLeft = Console.CursorLeft;
                int savedTop = Console.CursorTop;

                Console.SetCursorPosition(Console.WindowWidth - fullBar.Length - 1, 0);
                Console.Write("HP [");
                if (player.Health > player.MaxHealth / 2)
                    Console.ForegroundColor = ConsoleColor.Green;
                else if (player.Health > player.MaxHealth / 4)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                else
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(hpBar);
                Console.ResetColor();
                Console.Write("] " + hpText);

                Console.SetCursorPosition(savedLeft, savedTop);

                currentLocation.ShowOptions();

                string input = Console.ReadLine();

                GameInput(input);
            }
        }

        public void GameInput(string input)
        {
            var next = currentLocation.HandleInput(input, player);
            if (next != null)
                currentLocation = next;
        }
    }
}
