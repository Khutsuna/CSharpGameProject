using GameProject.GameplaySystems;
using GameProject.Models.Characters;
using GameProject.Models.Enums;
using GameProject.Models.Items.Base;

namespace GameProject.Map
{
    public class Location : ILocation
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public LocationType Type { get; set; }
        public bool IsLocked { get; set; } = false;
        public List<IInteractible> Interactibles { get; set; }

        public Location(string name, string description, bool isLocked, LocationType type)
        {
            Name = name;
            Description = description;
            IsLocked = isLocked;
            Type = type;
            Interactibles = new List<IInteractible>();
        }

        public void ShowMap()
        {
            Console.Clear();

            switch (Type)
            {
                case LocationType.Entrance:
                    Entrance();
                    break;
                case LocationType.Corridor:
                    Corridor();
                    break;
                case LocationType.MainLobby:
                    MainLobby();
                    break;
                case LocationType.InterrogationRoom:
                    InterrogationRoom();
                    break;
                case LocationType.LockerRoom:
                    LockerRoom();
                    break;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n  {Name}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"  {Description}");
            Console.ResetColor();
        }

        public void ShowOptions()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nWhat do you want to do?");
            Console.ResetColor();

            switch (Type)
            {
                case LocationType.Entrance:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("  1. ");
                    Console.ResetColor();
                    Console.WriteLine("Enter the Police Department");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("  2. ");
                    Console.ResetColor();
                    Console.WriteLine("Look around");
                    break;
                case LocationType.Corridor:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("  1. ");
                    Console.ResetColor();
                    Console.WriteLine("Enter Main Lobby");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("  2. ");
                    Console.ResetColor();
                    Console.WriteLine("Check Desk");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("  3. ");
                    Console.ResetColor();
                    Console.WriteLine("Check Body");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("  4. ");
                    Console.ResetColor();
                    Console.WriteLine("Go Back");
                    break;
                case LocationType.MainLobby:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("  1. ");
                    Console.ResetColor();
                    Console.WriteLine("Try Door on the Left");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("  2. ");
                    Console.ResetColor();
                    Console.WriteLine("Try Door on the Right");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("  3. ");
                    Console.ResetColor();
                    Console.WriteLine("Try Door on Top");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("  4. ");
                    Console.ResetColor();
                    Console.WriteLine("Check Cabinet");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("  5. ");
                    Console.ResetColor();
                    Console.WriteLine("Check the Window");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("  6. ");
                    Console.ResetColor();
                    Console.WriteLine("Use Typewriter");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("  7. ");
                    Console.ResetColor();
                    Console.WriteLine("Go Back");
                    break;
                case LocationType.LockerRoom:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("  1. ");
                    Console.ResetColor();
                    Console.WriteLine("Check the Body");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("  2. ");
                    Console.ResetColor();
                    Console.WriteLine("Check the Bag");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("  3. ");
                    Console.ResetColor();
                    Console.WriteLine("Go Back");
                    break;
            }
        }

        public ILocation? HandleInput(string input, Player player)
        {
            switch (Type)
            {
                case LocationType.Entrance: return HandleEntranceInput(input);
                case LocationType.Corridor: return HandleCorridorInput(input, player);
                case LocationType.MainLobby: return HandleMainLobbyInput(input, player);
                case LocationType.LockerRoom: return HandleLockerRoomInput(input, player);
                default: return null;
            }
        }

        private Location? HandleEntranceInput(string input)
        {
            if (input == "1")
                return new Location("Police Station Lobby", "You enter the police station lobby.", false, LocationType.Corridor);
            if (input == "2")
            {
                Console.WriteLine("You leave the area.");
                Environment.Exit(0);
            }
            return null;
        }

        private Location? HandleCorridorInput(string input, Player player)
        {
            if (input == "1")
            {
                if (player.HasKey())
                {
                    var lobby = new Location("Main Lobby", "Door unlocked, you entered Main Lobby", false, LocationType.MainLobby);
                    lobby.Interactibles.Add(new Typewriter());
                    return lobby;
                }
                Console.Clear();
                Console.WriteLine("Door is locked.");
                Console.WriteLine("\n[Press any key...]");
                Console.ReadKey();
            }
            else if (input == "2")
            {
                Console.Clear();
                Console.WriteLine(@"Entrance Desk (Police Department Corridor)

A scuffed wooden reception desk sits just past the station's front doors. 
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
            else if (input == "3")
            {
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
            else if (input == "4")
                return new Location("Police Station Entrance", "You stand outside the police station. The building looms above you.", false, LocationType.Entrance);
            return null;
        }

        private Location? HandleMainLobbyInput(string input, Player player)
        {
            if (input == "1")
            {
                Console.Clear();
                Console.WriteLine(@"Interrogation Room Door

The door won't budge.

Next to the handle is a small keypad, its worn buttons labeled 1 through 9. 
Faint smudges cover the surface, as if it's been used in a hurry... or too many times.
The lock emits a dull red glow, waiting for input.

A code is required.");
                Console.WriteLine("\n[Press any key..]");
                Console.ReadKey();
                Console.Clear();
                Console.Write("\nEnter keypad code: ");
                string code = Console.ReadLine()?.Trim();
                if (code == "1397")
                {
                    Console.WriteLine("\nThe keypad flashes green. The door unlocks.");
                    Console.WriteLine("\n[Press any key..]");
                    Console.ReadKey();
                    return new Location("Interrogation Room", "You step into the Interrogation Room, awful smell hits you", false, LocationType.InterrogationRoom);
                }
                else
                    Console.WriteLine("\nIncorrect code.");
                Console.WriteLine("\n[Press any key..]");
                Console.ReadKey();
            }
            else if (input == "2")
            {
                Console.Clear();
                Console.WriteLine("Door is locked.");
                Console.WriteLine("\n[Press any key...]");
                Console.ReadKey();
            }
            else if (input == "3")
            {
                Console.Clear();
                Console.WriteLine(@"Changing Room

You step inside—

A figure lunges from the darkness.

Rotting skin. Hollow eyes.

No time to think.");
                var battle = new BattleSystem();
                bool survived = battle.StartBattle(player, new Enemy("Changing Officer", 50, 8, 20));
                if (survived)
                    return new Location("Locker Room", "After surviving the attack, you're left in what looks like a Changing room", false, LocationType.LockerRoom);
            }
            else if (input == "4")
            {
                Console.Clear();
                bool alreadyHasFirstAid = player.Inventory.Any(i => i.Name == "First Aid Kit");
                if (!alreadyHasFirstAid)
                {
                    Console.WriteLine(@"Filing Cabinet

A dented metal cabinet stands against the wall, its top drawer left ajar.

Inside, buried under scattered folders, you find a First Aid Kit.

Still sealed.");
                    Console.WriteLine("\n[First Aid Kit added to inventory]");
                    player.Inventory.Add(new HealingItem("First Aid Kit", 1, 40));
                }
                else
                {
                    Console.WriteLine(@"Filing Cabinet

A dented metal cabinet stands against the wall, its top drawer left ajar.

Nothing useful remains inside.");
                }
                Console.WriteLine("\n[Press any key...]");
                Console.ReadKey();
            }
            else if (input == "5")
            {
                Console.Clear();
                Console.WriteLine("You look through the window. Nothing but darkness outside.");
                Console.WriteLine("\n[Press any key...]");
                Console.ReadKey();
            }
            else if (input == "6")
            {
                var typewriter = Interactibles.OfType<Typewriter>().FirstOrDefault();
                typewriter?.Interact(player, Type);
            }
            else if (input == "7")
                return new Location("Police Station Lobby", "You are in the front corridor.", false, LocationType.Corridor);
            return null;
        }

        private Location? HandleLockerRoomInput(string input, Player player)
        {
            if (input == "1")
            {
                Console.Clear();
                Console.WriteLine(@"The body lies still now.

Up close, the decay is impossible to ignore — grey skin stretched tight over bone, 
veins dark and twisted beneath the surface.

Its jaw hangs slightly open, teeth stained and broken.

Whatever it once was… isn't human anymore.");
                Console.WriteLine("\n[Press any key..]");
                Console.ReadKey();
            }
            else if (input == "2")
            {
                Console.Clear();
                Console.WriteLine(@"Locker Room Bag

A worn duffel bag rests on the bench, half-zipped.

Inside, you find a phone.

Still on.

No lock.

The screen lights up to a message thread between two officers.

-'You still remember the code, right?'

-'Yeah. Didn't forget.'

'Remember, Square clockwise. If Sergeant has to reset the code again because of us, we're f***ed. '

There's the hint you were looking for but Square? Clockwise?. Interesting.");

                Console.WriteLine("\n[Press any key..]");
                Console.ReadKey();
            }
            else if (input == "3")
            {
                var lobby = new Location("Main Lobby", "You are in the main lobby.", false, LocationType.MainLobby);
                lobby.Interactibles.Add(new Typewriter());
                return lobby;
            }
            return null;
        }

        private void Entrance()
        {
            string[] policeStation =
            {
                @"                         .::.  .::.                               ",
                @"                       .::::::::::::.                             ",
                @"           ___________|::POLICE HQ::|______________               ",
                @"          |     ____  |:::::::::::::|    ____     |               ",
                @"          |    /####\ |:::::::::::::|   /####\    |               ",
                @"          |   |# ** #||_____________|  |# ** #|   |               ",
                @"     _____|   |#    #|  ____________   |#    #|   |_____          ",
                @"    |/////|   |######| |   POLICE   |  |######|   |/////|         ",
                @"    |/////|   |######| | DEPARTMENT |  |######|   |/////|         ",
                @"    |/////|___|######| |____________|  |######|___|/////|         ",
                @"    |/////|   |######|                 |######|   |/////|         ",
                @"    |=====|***|======|=================|======|***|=====|         ",
                @"    |/////|***| .--. |   __________    | .--. |***|/////|         ",
                @"    |/////|***||    ||  |  ______  |   ||    ||***|/////|         ",
                @"    |/////|***||    ||  | |  []  | |   ||    ||***|/////|         ",
                @"    |/////|***||    ||  | |  []  | |   ||    ||***|/////|         ",
                @"    |/////|***||    ||  | |______| |   ||    ||***|/////|         ",
                @"    |/////|***| '--' |  |          |   | '--' |***|/////|         ",
                @"    |/////|***|      |   [ENTRANCE]    |      |***|/////|         ",
                @"    |_____|___|______|_________________|______|___|_____|         ",
                @"    ||||||||||||||||||||------------||||||||||||||||||||||||      ",
                @"    |------------------|------------|----------------------|      ",
                @"    |                __|------------|__                    |      ",
                @"    |-------------/                      \-----------------|      ",
                @"    ==============|    |=============|    |=================       ",
                @"                  |    |             |    |                        ",
                @"   //-------------|    |-------------|    |-----------------\\     ",
                @"  //========================================================\\    ",
                @" //----------------------------------------------------------\\   "
            };

            foreach (var line in policeStation)
            {
                Console.WriteLine(line);
            }
        }

        private void Corridor()
        {
            string[] corridor =
            {
                @"+---------------------------+------+------------------+------+---------------------------+ ",
                @"|                           |      |                  |      |                           | ",
                @"|                           |      |                  |      |                           | ",
                @"|                           |      |                  |      |                           | ",
                @"|                           |      |                  |      |                           | ",
                @"+-----------------॥॥--------+      +-------॥॥---------+      +--------॥॥-----------------+ ",
                @"                   |                       ॥॥                         ॥॥                   ",
                @"                   |   |-----------------------------------------------|                   ",
                @"                   |   |                                               |                   ",
                @"+------------------+   |                                               |   +--------------+",
                @"|                  =---<                                               >---=              |",
                @"|                  |   |                                               |   |              |",
                @"|                  |   -------------                      --------------   |              |",
                @"|                 =>---<=                                              =---=              |",
                @"+------------------+   |                                               |   +--------------+",
                @"                   |   |                                               |                   ",
                @"+------------------+   |                                               |   +--------------+",
                @"|                  >---<                                               >---=              |",
                @"|                  |   |                                               |   |              |",
                @"|                  |   |                                               |   |              |",
                @"|                  |   |                                               |   |              |",
                @"|                  +---+-----------------------------------------------+   +--------------+",
                @"+------------------+                 ॥॥                                                    ",
                @"                                     ॥॥                                                    ",
                @"                   +###############[DOOR]######################################+           ",
                @"                   #                             [BODY]                        #           ",
                @"                   #                     FRONT CORRIDOR                        #           ",
                @"                   #                         [DESK]                            #           ",
                @"                   #                                                           #           ",
                @"                   +#########॥॥###################॥॥###################॥॥######+          ",
                @"                             ॥॥                   ॥॥                   ॥॥                  ",
                @"                   +----------+------+    +---------+---------+    +----+----------+       ",
                @"                   |                 |    |                   |    |               |       ",
                @"                   |     ENTRANCE    |    |                   |    |               |       ",
                @"                   |                 |    |                   |    |               |       ",
                @"                   +-----------------+    +-------------------+    +---------------+       "
            };

            foreach (var line in corridor)
            {
                Console.WriteLine(line);
            }
        }

        private void MainLobby()
        {
            string[] mainLobby =
            {
                @"+---------------------------+------+------------------+------+---------------------------+ ",
                @"|                           |      |                  |      |                           | ",
                @"|                           |      |                  |      |                           | ",
                @"|                           |      |                  |      |                           | ",
                @"|                           |      |                  |      |                           | ",
                @"+-----------------॥॥--------+      +-------॥॥---------+      +--------॥॥-----------------+ ",
                @"                   |                       ॥॥                         ॥॥                   ",
                @"                   |   |#################[DOOR]########################|                   ",
                @"                   |   |                                               |                   ",
                @"+------------------+   |                                               |   +--------------+",
                @"|                  =---=                                               =---=              |",
                @"|                  |   |                                               |   |              |",
                @"|                  |   -############                      ##############   |              |",
                @"|                 =>---|                                    [CABINET]  =---=              |",
                @"+------------------+   |                                               |   +--------------+",
                @"                   |   |                  MAIN LOBBY                   |                   ",
                @"+------------------+   |                                               |   +--------------+",
                @"|                  >---<[DOOR]                                   [DOOR]>---=              |",
                @"|                  |   |                                               |   |              |",
                @"|                  |   |[???]                                          |   |              |",
                @"|                  |   |                                [TYPEWRITER]   |   |              |",
                @"|                  +---+###########[DOOR]##############################+   +--------------+",
                @"+------------------+                 ॥॥                                                    ",
                @"                                     ॥॥                                                    ",
                @"                   +-----------------------------------------------------------+           ",
                @"                   |                                                           |           ",
                @"                   |                     FRONT CORRIDOR                        |           ",
                @"                   |                                                           |           ",
                @"                   |                                                           |           ",
                @"                   +-----------------------------------------------------------+          ",
                @"                             ॥॥                   ॥॥                   ॥॥                  ",
                @"                   +----------+------+    +---------+---------+    +----+----------+       ",
                @"                   |                 |    |                   |    |               |       ",
                @"                   |     ENTRANCE    |    |                   |    |               |       ",
                @"                   |                 |    |                   |    |               |       ",
                @"                   +-----------------+    +-------------------+    +---------------+       "
            };

            foreach (var line in mainLobby)
            {
                Console.WriteLine(line);
            }
        }

        private void InterrogationRoom()
        {
            string[] interrogation =
            {
                @"+---------------------------+------+------------------+------+---------------------------+ ",
                @"|                           |      |                  |      |                           | ",
                @"|                           |      |                  |      |                           | ",
                @"|                           |      |                  |      |                           | ",
                @"|                           |      |                  |      |                           | ",
                @"+-----------------॥॥--------+      +-------॥॥---------+      +--------॥॥-----------------+ ",
                @"                   |                       ॥॥                         ॥॥                   ",
                @"                   |   |-----------------------------------------------|                   ",
                @"                   |   |                                               |                   ",
                @"+------------------+   |                                               |   +--------------+",
                @"|                  =---=                                               =---=              |",
                @"|                  |   |                                               |   |              |",
                @"|                  |   -------------                      --------------   |              |",
                @"|                 =>---|                                               =---=              |",
                @"+------------------+   |                                               |   +--------------+",
                @"                   |   |                  MAIN LOBBY                   |                   ",
                @"+##################+   |                                               |   +--------------+",
                @"#            [DOOR]>---<                                               >---=              |",
                @"#  INTERROGATION   #   |                                               |   |              |",
                @"#                  #   |                                               |   |              |",
                @"#      [DESK]      #   |                                               |   |              |",
                @"#    [BODY]        +---+-----------------------------------------------+   +--------------+",
                @"+##################+                 ॥॥                                                    ",
                @"                                     ॥॥                                                    ",
                @"                   +-----------------------------------------------------------+           ",
                @"                   |                                                           |           ",
                @"                   |                     FRONT CORRIDOR                        |           ",
                @"                   |                                                           |           ",
                @"                   |                                                           |           ",
                @"                   +-----------------------------------------------------------+          ",
                @"                             ॥॥                   ॥॥                   ॥॥                  ",
                @"                   +----------+------+    +---------+---------+    +----+----------+       ",
                @"                   |                 |    |                   |    |               |       ",
                @"                   |     ENTRANCE    |    |                   |    |               |       ",
                @"                   |                 |    |                   |    |               |       ",
                @"                   +-----------------+    +-------------------+    +---------------+       "
            };

            foreach (var line in interrogation)
            {
                Console.WriteLine(line);
            }
        }

        private void LockerRoom()
        {
            string[] lockerRoom =
            {
                @"+---------------------------+------+##################+------+---------------------------+ ",
                @"|                           |      #]           [BAG][#      |                           | ",
                @"|                           |      #]     LOCKER     [#      |                           | ",
                @"|                           |      #]                [#      |                           | ",
                @"|                           |      #] [BODY]         [#      |                           | ",
                @"+-----------------॥॥--------+      +#######॥॥#########+      +--------॥॥-----------------+ ",
                @"                   |                       ॥॥                         ॥॥                   ",
                @"                   |   |-----------------------------------------------|                   ",
                @"                   |   |                                               |                   ",
                @"+------------------+   |                                               |   +--------------+",
                @"|                  =---=                                               =---=              |",
                @"|                  |   |                                               |   |              |",
                @"|                  |   -------------                      --------------   |              |",
                @"|                 =>---|                                               =---=              |",
                @"+------------------+   |                                               |   +--------------+",
                @"                   |   |                  MAIN LOBBY                   |                   ",
                @"+------------------+   |                                               |   +--------------+",
                @"|                  >---<                                               >---=              |",
                @"|  INTERROGATION   |   |                                               |   |              |",
                @"|                  |   |                                               |   |              |",
                @"|                  |   |                                               |   |              |",
                @"|                  +---+-----------------------------------------------+   +--------------+",
                @"+------------------+                 ॥॥                                                    ",
                @"                                     ॥॥                                                    ",
                @"                   +-----------------------------------------------------------+           ",
                @"                   |                                                           |           ",
                @"                   |                     FRONT CORRIDOR                        |           ",
                @"                   |                                                           |           ",
                @"                   |                                                           |           ",
                @"                   +-----------------------------------------------------------+          ",
                @"                             ॥॥                   ॥॥                   ॥॥                  ",
                @"                   +----------+------+    +---------+---------+    +----+----------+       ",
                @"                   |                 |    |                   |    |               |       ",
                @"                   |     ENTRANCE    |    |                   |    |               |       ",
                @"                   |                 |    |                   |    |               |       ",
                @"                   +-----------------+    +-------------------+    +---------------+       "
            };

            foreach (var line in lockerRoom)
            {
                Console.WriteLine(line);
            }
        }
    }
}
