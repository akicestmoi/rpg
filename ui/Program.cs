namespace UI {
    class Program
    {
        static void Main(string[] args)
        {
            /* Instanciation of the Poster*/
            var battlePoster = new BattlePoster();

            /* Instanciation of the Backend Game Manager*/
            var gameManager = new GameManager(battlePoster);

            /* Instanciation of Communicator to Backend */
            var communicator = new FrontCommunicator();

            /* Instanciation of all Listeners and Registering to repsective Notifiers */
            var gameStatusListener = new GameStatusListener(gameManager.gameStatusNotifier, gameManager.settings.AllGameEvents["gameEventList"]);
            var playerStatusListener = new PlayerStatusListener(gameManager.playerStatusNotifier, gameManager.settings.AllGameEvents["playerEventList"]);
            var battleListener = new BattleListener(gameManager.battleNotifier, gameManager.settings.AllGameEvents["battleEventList"]);
            

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