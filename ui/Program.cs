namespace UI {
    class Program
    {
        static void Main(string[] args)
        {

            /* Instanciation of the Backend Game Manager*/
            GameManager gameManager = new GameManager();

            /* Instanciation of Communicator to Backend */
            FrontCommunicator communicator = new FrontCommunicator();

            /* Instanciation of all Listeners and Registering */
            GameStatusListener gameStatusListener = new GameStatusListener();
            PlayerStatusListener playerStatusListener = new PlayerStatusListener(gameManager.playerStatusNotifier);
            CombatListener combatListener = new CombatListener(gameManager.combatNotifier);
            

            gameStatusListener.onGameStart();
            

            string? playerName = Console.ReadLine();
            playerStatusListener.onPlayerCreation(gameManager, playerName);


            bool endGame = false;

            while (endGame == false) {

                string? direction = "";
                while (direction != "1" && direction != "2" && direction != "3" && direction != "4") {
                    
                    gameStatusListener.onPlayerTurn();
                    direction = Console.ReadLine();
                }
                

                gameStatusListener.onPlayerMove(gameManager);

                string? playerAnswer = "";
                while (playerAnswer != "y" & playerAnswer != "n") {
                    Console.WriteLine("Continue? (y/n)");
                    playerAnswer = Console.ReadLine();
                }
                
                if (playerAnswer == "n") {
                    endGame = true;
                }
            }
        }
    }
}