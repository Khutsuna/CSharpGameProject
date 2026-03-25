using System;
using GameProject.Map;
using GameProject.Models.Characters;
using GameProject.Models.Items.Base;

namespace GameProject.Core
{
    public class Game
    {
        Location currentLocation;
        Player player;

        //HEYHEYHEEEY

        public void Start()
        {
            GameStart();
            GameLoop();
        }

        private void GameStart()
        {
            player = new Player("Survivor", 100, 10, 0);

            currentLocation = new Location(
                "Police Station Entrance",
                "You stand outside the police station. The building looms above you.",
                false,
                LocationType.Entrance
            );
        }

        private void GameLoop()
        {
            while (true)
            {

                currentLocation.ShowMap();
                currentLocation.ShowOptions();

                string input = Console.ReadLine();

                GameInput(input);
            }
        }

        private void GameInput(string input)
        {
            switch (currentLocation.Type)
            {
                case LocationType.Entrance:
                    GameInputEntrance(input);
                    break;

                case LocationType.Corridor:
                    GameInputCorridor(input);
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
        }
    }
}