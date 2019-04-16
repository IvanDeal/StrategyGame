using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame
{
    class Game
    {

        public Game()
        {
            PlayerCharacter player = new PlayerCharacter();
            player.CalculatePlayerBaseStats();
        }

        public void GameLoop()
        {
            while (true)
            {
                Console.ReadLine();
                
            }
        }


    }
}
