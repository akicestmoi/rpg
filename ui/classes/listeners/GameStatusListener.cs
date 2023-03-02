public class GameStatusListener: Listener {

    public bool isGameOver {get; set;}

    public GameStatusListener(Notifier notifier, List<string> eventList) : base (notifier, eventList) { isGameOver = false; }


    public override void onGameStart() {

        Console.WriteLine("Welcome to Aki's RPG!");
        Console.WriteLine("Please enter your character name:");
        
    }

    public override void onPlayerTurn() {

        Console.WriteLine(Environment.NewLine + "Your Move!");
        Console.WriteLine("Which way do you want to go?");
        Console.WriteLine("1. Up");
        Console.WriteLine("2. Bottom");
        Console.WriteLine("3. Left");
        Console.WriteLine("4. Right");

    }

    public override void onPlayerMove(IGameManager gameManager) {
        
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

    public override void onEnemyEncounter(IGameManager gameManager) {

        IPlayer player = gameManager.Players[0];
        gameManager.EngageCombat(player, gameManager.DefineEncounteredEnemy());

    }

    public override void onGameEnd() {

        /* This is a GET, but currently the Backend is directly calling it from the notifier */
        this.isGameOver = true;

        Console.WriteLine(Environment.NewLine);
        Console.WriteLine("Thanks for playing the game!");
    }
}