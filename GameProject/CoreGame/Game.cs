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
        Location currentLocation;
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
                currentLocation.ShowOptions();

                string input = Console.ReadLine();

                GameInput(input);
            }
        }

        public void GameInput(string input)
        {
            switch (currentLocation.Type)
            {
                case LocationType.Entrance:
                    GameInputEntrance(input);
                    break;

                case LocationType.Corridor:
                    GameInputCorridor(input);
                    break;

                case LocationType.MainLobby:
                    GameInputMainLobby(input);
                    break;
            }
        }

        public void GameInputEntrance(string input)
        {
            if (input == "1")
            {
                currentLocation = new Location(
                    "Police Station Lobby",
                    "You enter the police station lobby.",
                    false,
                    LocationType.Corridor
                );
            }
            else if (input == "2")
            {
                Console.WriteLine("You leave the area.");
                Environment.Exit(0);
            }
        }

        public void GameInputCorridor(string input)
        {
            if (input == "1")
            {                
                if (player.HasKey())
                {
                    currentLocation = new Location(
                        "Main Lobby",
                        "Door unlocked, you entered Main Lobby",
                        false,
                        LocationType.MainLobby
                    );
                    currentLocation.Interactibles.Add(new Typewriter());
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Door is locked.");
                    Console.WriteLine("\n[Press any key...]");
                    Console.ReadKey();
                }
            }
            else if (input == "2")
            {
                Console.Clear();
                Console.WriteLine(@"Entrance Desk (Police Department Corridor)

A scuffed wooden reception desk sits just past the station’s front doors. 
An overturned coffee mug has left a dark stain across a pile of outdated forms, 
and a desk lamp flickers faintly, threatening to give out at any moment.

Among the clutter lies an official memo, stamped with quiet urgency. 
It instructs all personnel to suspend civilian intake until further notice.

The wording is clinical, almost detached — but certain phrases stand out:

'Containment protocols in effect.'
'Reports of unusual aggression.'
'Do not engage without proper clearance.'

No clear explanation is given.

They knew something was wrong long before everything fell apart.");
                Console.WriteLine("\n[Press any key...]");
                Console.ReadKey();
            }
            else if(input == "3") {
                Console.Clear();

                var battle = new BattleSystem();
                bool survived = battle.StartBattle(player, new Enemy("Infected Officer", 50, 8, 20));

                if (!survived)
                {
                    Console.Clear();
                    Console.WriteLine("YOU DIED");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You found a key");
                    Console.WriteLine("\n[Key added to inventory]");
                    Console.WriteLine("\n[Press any key..]");
                    Console.ReadKey();
                    var key = new BaseItem("Main Lobby Key", 1);
                    key.IsKey = true;
                    player.AddItem(key);
                }
            }
        }

        public void GameInputMainLobby(string input)
        {
            if (input == "1")
            {
                Console.Clear();
                Console.WriteLine("You examine the body. Nothing useful.");
                Console.WriteLine("\n[Press any key...]");
                Console.ReadKey();
            }
            else if (input == "2")
            {
                Console.Clear();
                Console.WriteLine("You search the area but find nothing.");
                Console.WriteLine("\n[Press any key...]");
                Console.ReadKey();
            }
            else if (input == "3")
            {
                var typewriter = currentLocation.Interactibles.OfType<Typewriter>().FirstOrDefault();
                typewriter?.Interact(player, currentLocation.Type);
            }
        }
    }
}