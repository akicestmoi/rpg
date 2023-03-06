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

        /* POST */
        gameManager.gameEventController();
    }

    public override void onNoEvent() {
        Console.WriteLine(Environment.NewLine + "There was nothing here");
    }

    public override void onEnemyEncounter() {
        Console.WriteLine(Environment.NewLine + "You encountered an enemy!");
    }

    public override void onChestFound() {
        Console.WriteLine(Environment.NewLine + "You found a treasure chest!");
    }

    public override void onMerchantEncounter() {
        Console.WriteLine(Environment.NewLine + "You found a wandering merchant!");
    }

    public override void onHealingFountain() {
        Console.WriteLine(Environment.NewLine + "You found a healing fountain!");
    }

    public override void onGameEnd() {

        /* This is a GET, but currently the Backend is directly calling it from the notifier */
        this.isGameOver = true;
        
        Console.WriteLine(Environment.NewLine);
        Console.WriteLine("Thanks for playing the game!");
    }
}