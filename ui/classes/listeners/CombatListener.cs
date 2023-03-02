public class CombatListener: Listener {


    public CombatListener(Notifier notifier, List<string> eventList) : base (notifier, eventList) {}


    public override void onNewTurn(ICharacter firstCharacter, ICharacter secondCharacter) {

        /* This line is made for the user to follow the automatic combat */
        Console.ReadLine();
        Console.WriteLine("New combat turn:");
        Console.WriteLine($"{firstCharacter.Name} HP:{firstCharacter.HP}");
        Console.WriteLine($"{secondCharacter.Name} HP:{secondCharacter.HP}");
    }


    public override void onAttack(string attacker, string damage) {
        Console.WriteLine($"{attacker} attacks and inflicts {damage} damages");
    }


    public override bool onCombatEnd(CharacterStatus currentStatus, string enemyName) {

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