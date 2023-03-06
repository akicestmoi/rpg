public class BattleListener: Listener {

    public BattleListener(Notifier notifier, List<string> eventList) : base (notifier, eventList) {}


    public override void onNewTurn(List<ICharacter> allies, List<IEnemy> enemies) {

        Console.WriteLine(Environment.NewLine + "New battle turn:");
        Console.WriteLine("______ Allies ______");
        foreach (ICharacter ally in allies) {
            Console.WriteLine($"{ally.Name} HP:{ally.HP}");
        }
        Console.WriteLine("______ Enemies ______");
        foreach (ICharacter enemy in enemies) {
            Console.WriteLine($"{enemy.Name} HP:{enemy.HP}");
        }
    }


    public override void onAttack(string attacker, string damage) {
        Console.WriteLine($"{attacker} attacks and inflicts {damage} damages");
    }


    public override void onEnemyDefeat(string enemyName) {
        Console.WriteLine($"You have beaten {enemyName}");
    }


    public override void onEscapeFail() {
        Console.WriteLine("You failed to escape from the Battle");
    }


    public override void onBattleEnd(bool hasEscaped) {
        if (hasEscaped) {
            Console.WriteLine("You escaped from the Battle");
        } else {
            Console.WriteLine("You have beaten all of your enemies!");
        }
    }
}