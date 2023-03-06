public class PlayerStatusListener: Listener {

    public PlayerStatusListener(Notifier notifier, List<string> eventList) : base (notifier, eventList) {}


    public override void onPlayerCreation(IGameManager gameManager, string playerName) {

        /* POST */
        gameManager.RegisterPlayer(playerName);

        Console.WriteLine(Environment.NewLine + "Character created!");

        /* GET */
        IPlayer player = gameManager.Player;

        Console.WriteLine(Environment.NewLine + "Player characteristics:");
        Console.WriteLine($"Player Name: " + player.Name);
        Console.WriteLine($"Player Level: " + player.Level);
        Console.WriteLine($"Player HP: " + player.MaxHP);
        Console.WriteLine($"Player ATK: " + player.ATK);
        Console.WriteLine($"Player DEF: " + player.DEF);
        Console.WriteLine($"Player SPD: " + player.SPD);

    }


    public override void onPropertyChange(string property, string value) {

        /* This is a GET, but currently the Backend is directly calling it from the notifier */
        Console.WriteLine($"Your {property} is now at: {value}");
    }


    public override void onLevelUp(int level, int maxHp, int atk, int def, int spd) {

        /* This is a GET, but currently the Backend is directly calling it from the notifier */
        Console.WriteLine(Environment.NewLine + $"Congratulation! You reached level: {level.ToString()}!");
        Console.WriteLine("New Player characteristics:");
        Console.WriteLine($"Player HP: {maxHp.ToString()}");
        Console.WriteLine($"Player ATK: {atk.ToString()}");
        Console.WriteLine($"Player DEF: {def.ToString()}");
        Console.WriteLine($"Player SPD: {spd.ToString()}");

    }

    public override void onXPGain(int xp) {

        /* This is a GET, but currently the Backend is directly calling it from the notifier */
        Console.WriteLine($"You gain {xp.ToString()} XP");
    }

    public override void onHeal(int healingAmount) {

        /* This is a GET, but currently the Backend is directly calling it from the notifier */
        Console.WriteLine($"You healed {healingAmount.ToString()} HP");
    }

    public override void onGoldGain(int gold) {
        Console.WriteLine($"You found {gold.ToString()} G");
    }

    public override void onGoldUsage(int gold) {
        Console.WriteLine($"You spent {gold.ToString()} G");
    }

    public override void onItemPickup(string itemName) {
        Console.WriteLine($"You picked up a {itemName} and you put it in your inventory");
    }

    public override void onInventoryFull() {
        Console.WriteLine("Your inventory is full! You should either use, sell or drop an item!");
    }

    public override void onItemUse(string itemName) {
        Console.WriteLine($"You used {itemName}");
    }

    public override void onPlayerDeath() {

        /* This is a GET, but currently the Backend is directly calling it from the notifier */
        Console.WriteLine("You are dead. Game over");
    }

}
