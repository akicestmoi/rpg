namespace UI {
    class Program
    {
        static void Main(string[] args)
        {

            /* Instanciation of the Backend Game Manager*/
            GameManager gameManager = new GameManager();

            /* Instanciation of Communicator to Backend */
            FrontCommunicator communicator = new FrontCommunicator();

            /* Instanciation of all Listeners and Registering to repsective Notifiers */
            List<string> playerEventList = new List<string> { "Player_PropertyChange", "Player_LevelUp", "Player_XPGain", "Player_PlayerDeath" };
            List<string> combatEventList = new List<string> { "Combat_NewTurn", "Combat_AttackDamage", "Combat_CombatEnd" };
            List<string> gameEventList = new List<string> { "System_GameEnd" };
            GameStatusListener gameStatusListener = new GameStatusListener(gameManager.gameStatusNotifier, gameEventList);
            PlayerStatusListener playerStatusListener = new PlayerStatusListener(gameManager.playerStatusNotifier, playerEventList);
            CombatListener combatListener = new CombatListener(gameManager.combatNotifier, combatEventList);
            

            gameStatusListener.onGameStart();
            

            string? playerName = Console.ReadLine();
            playerStatusListener.onPlayerCreation(gameManager, playerName);


            while (gameStatusListener.isGameOver == false) {

                string? direction = "";
                while (direction != "1" && direction != "2" && direction != "3" && direction != "4") {
                    
                    gameStatusListener.onPlayerTurn();
                    direction = Console.ReadLine();
                }
                

                gameStatusListener.onPlayerMove(gameManager);


                if (gameStatusListener.isGameOver == true) { break;}

                string? playerAnswer = "";
                while (playerAnswer != "y" & playerAnswer != "n") {
                    Console.WriteLine(Environment.NewLine + "Continue? (y/n)");
                    playerAnswer = Console.ReadLine();
                }
                    
                if (playerAnswer == "n") {
                    gameStatusListener.isGameOver = true;
                    gameStatusListener.onGameEnd();
                }
            }
        }
    }
}