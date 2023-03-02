public class CombatListener: ICombatListener {

    public CombatListener(ICombatNotifier notifier) {
        notifier.RegisterListener(this);
    }


    public void onCombatStart() {
    }

    public void onAttack(string attacker, string damage) {
        Console.WriteLine($"{attacker} attacks and inflicts {damage} damages");
    }

    public bool onCombatEnd(CharacterStatus currentStatus, string enemyName) {

        bool endGame = false;

        if (currentStatus == CharacterStatus.Alive) {
            Console.WriteLine($"You have beaten {enemyName}");
            endGame = false;
        } else {
            endGame = true;
        }
        return endGame;
    }
}