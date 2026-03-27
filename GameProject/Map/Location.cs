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
            }
        }

        public void ShowOptions()
        {
            Console.WriteLine("\nWhat do you want to do?");

            switch(Type)
            {
                case LocationType.Entrance:
                    Console.WriteLine("1. Enter the Police Department");
                    Console.WriteLine("2. Look around");
                    break;
                case LocationType.Corridor:
                    Console.WriteLine("1. Enter Main Lobby");
                    Console.WriteLine("2. Check Desk");
                    Console.WriteLine("3. Check Body");
                    Console.WriteLine("4. Go Back");
                    break;
                case LocationType.MainLobby:
                    Console.WriteLine("1. Interact with Body");
                    Console.WriteLine("2. Search Area");
                    Console.WriteLine("3. Use Typewriter");
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
                @"|       EVIDENCE ROOM       |      |    BREAK ROOM    |      |          ARMORY           | ",
                @"|                           |      |                  |      |                           | ",
                @"|                           |      |                  |      |                           | ",
                @"|                           |      |                  |      |                           | ",
                @"+-----------------॥॥--------+      +-------॥॥---------+      +--------॥॥-----------------+ ",
                @"                   |                       ॥॥                         ॥॥                   ",
                @"                   |   |-----------------------------------------------|                   ",
                @"                   |   |                                               |                   ",
                @"+------------------+   |                                               |   +--------------+",
                @"|                  =---<                                               >---=              |",
                @"|  CHIEF'S OFFICE  |   |                                               |   |   RECORDS    |",
                @"|                  |   -------------                      --------------   |              |",
                @"|                 =>---<=                                              =---=              |",
                @"+------------------+   |                                               |   +--------------+",
                @"                   |   |                  MAIN LOBBY                   |                   ",
                @"+------------------+   |                                               |   +--------------+",
                @"|                  >---<                                               >---=              |",
                @"|  INTERROGATION   |   |                                               |   |   HOLDING    |",
                @"|                  |   |                                               |   |    CELLS     |",
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
                @"                   |     ENTRANCE    |    |    RECEPTION      |    |  WAITING AREA |       ",
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
                @"|       EVIDENCE ROOM       |      |    BREAK ROOM    |      |          ARMORY           | ",
                @"|                           |      |                  |      |                           | ",
                @"|                           |      |                  |      |                           | ",
                @"|                           |      |                  |      |                           | ",
                @"+-----------------॥॥--------+      +-------॥॥---------+      +--------॥॥-----------------+ ",
                @"                   |                       ॥॥                         ॥॥                   ",
                @"                   |   |###############################################|                   ",
                @"                   |   |                                               |                   ",
                @"+------------------+   |                                               |   +--------------+",
                @"|                  =---=                                               =---=              |",
                @"|  CHIEF'S OFFICE  |   |                                               |   |   RECORDS    |",
                @"|                  |   -############                      ##############   |              |",
                @"|                 =>---<=                                              =---=              |",
                @"+------------------+   |                                               |   +--------------+",
                @"                   |   |[BODY]            MAIN LOBBY                   |                   ",
                @"+------------------+   |                                               |   +--------------+",
                @"|                  >---<[DOOR]                                   [DOOR]>---=              |",
                @"|  INTERROGATION   |   |                                               |   |   HOLDING    |",
                @"|                  |   |                                               |   |    CELLS     |",
                @"|                  |   |                                [TYPEWRITER]   |   |              |",
                @"|[BODY]            +---+###########[DOOR]##############################+   +--------------+",
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
                @"                   |     ENTRANCE    |    |    RECEPTION      |    |  WAITING AREA |       ",
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