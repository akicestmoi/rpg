public class CombatNotifier: Notifier {

    public CombatNotifier(List<string> eventList) : base(eventList) {}

    public override void NotifyNewTurn(ICharacter firstCharacter, ICharacter secondCharacter) {
        foreach (Listener listener in this.Listeners["Combat_NewTurn"]) {
            listener.onNewTurn(firstCharacter, secondCharacter);
        }
    }


    public override void NotifyAttackDamage(string attackerName, string damage) {
        foreach (Listener listener in this.Listeners["Combat_AttackDamage"]) {
            listener.onAttack(attackerName, damage);
        }
    }


    public override void NotifyCombatEnd(CharacterStatus currentStatus, string enemyName) {
        foreach (Listener listener in this.Listeners["Combat_CombatEnd"]) {
            listener.onCombatEnd(currentStatus, enemyName);
        }
    }
}