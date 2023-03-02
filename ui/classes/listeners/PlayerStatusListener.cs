public class PlayerStatusListener: IPlayerStatusListener {

    public PlayerStatusListener(IPlayerStatusNotifier notifier) {
        notifier.RegisterListener(this);
    }


    public void onPlayerCreation(GameManager gameManager, string playerName) {

        /* POST */
        gameManager.RegisterPlayer(playerName);

        Console.WriteLine(Environment.NewLine + "Character created!");

        /* GET */
        Player player = gameManager.Players[0];

        Console.WriteLine(Environment.NewLine + "Player characteristics:");
        Console.WriteLine($"Player Name: " + player.Name);
        Console.WriteLine($"Player Level: " + player.Level);
        Console.WriteLine($"Player HP: " + player.MaxHP);
        Console.WriteLine($"Player ATK: " + player.ATK);
        Console.WriteLine($"Player DEF: " + player.DEF);
        Console.WriteLine($"Player SPD: " + player.SPD);

    }


    public void onPropertyChange(string property, string value) {

        /* This is a GET, but currently the Backend is directly calling it from the notifier */
        Console.WriteLine($"Your {property} is now at: {value}");
    }


    public void onLevelUp(int level, int maxHp, int atk, int def, int spd) {

        /* This is a GET, but currently the Backend is directly calling it from the notifier */
        Console.WriteLine(Environment.NewLine + $"You reached level: {level.ToString()}!");
        Console.WriteLine("New Player characteristics:");
        Console.WriteLine($"Player HP: {maxHp.ToString()}");
        Console.WriteLine($"Player ATK: {atk.ToString()}");
        Console.WriteLine($"Player DEF: {def.ToString()}");
        Console.WriteLine($"Player SPD: {spd.ToString()}");

    }

    public void onXPGain(int xp) {

        /* This is a GET, but currently the Backend is directly calling it from the notifier */
        Console.WriteLine($"You Gain {xp.ToString()}XP");
    }

    public void onDeath() {

        /* This is a GET, but currently the Backend is directly calling it from the notifier */
        Console.WriteLine("You are dead. Game over");
    }

}
