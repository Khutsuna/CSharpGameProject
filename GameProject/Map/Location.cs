using GameProject.GameplaySystems;
using GameProject.Models.Enums;

namespace GameProject.Map
{
    public class Location
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public LocationType Type { get; set; }
        public bool IsLocked = false;
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

            switch(Type)
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
                    Console.WriteLine("Check the Window");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("  5. ");
                    Console.ResetColor();
                    Console.WriteLine("Use Typewriter");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("  6. ");
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

        public void Entrance()
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

        public void Corridor()
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

        public void MainLobby()
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
                @"|                 =>---|                                              =---=              |",
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

        public void InterrogationRoom()
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

            foreach (var line in mainLobby)
            {
                Console.WriteLine(line);
            }
        }

        public void LockerRoom()
        {
            string[] mainLobby =
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

            foreach (var line in mainLobby)
            {
                Console.WriteLine(line);
            }
        }
    }
}