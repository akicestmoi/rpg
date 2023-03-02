public class GameStatusListener: IGameStatusListener {

    public GameStatusListener() {
    }

    public void onGameStart() {

        Console.WriteLine("Welcome to Aki's RPG!");
        Console.WriteLine("Please enter your character name:");
        
    }

    public void onPlayerTurn() {

        Console.WriteLine(Environment.NewLine + "Your Move!");
        Console.WriteLine("Which way do you want to go?");
        Console.WriteLine("1. Up");
        Console.WriteLine("2. Bottom");
        Console.WriteLine("3. Left");
        Console.WriteLine("4. Right");

    }

    public void onPlayerMove(GameManager gameManager) {
        
        int gameEventID = gameManager.eventTrigger();
        switch (gameEventID)
        {
            case 1:
                Console.WriteLine(Environment.NewLine + "You encountered an enemy!");
                this.onEnemyEncounter(gameManager);
                break;
            case 2:
                Console.WriteLine(Environment.NewLine + "You found a treasure!");
                break;
            case 3:
                Console.WriteLine(Environment.NewLine + "There was nothing here");
                break;
            default:
                Console.WriteLine(Environment.NewLine + "There was nothing here");
                break;
        }
    }

    public void onEnemyEncounter(GameManager gameManager) {

        Player player = gameManager.Players[0];
        gameManager.EngageCombat(player, gameManager.DefineEncounteredEnemy());

    }

    public void onGameEnd() {
        Console.WriteLine(Environment.NewLine);
        Console.WriteLine("Thanks for playing the game!");
    }
}