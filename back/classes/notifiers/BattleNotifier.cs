public class BattleNotifier: Notifier {

    public BattleNotifier(List<string> eventList) : base(eventList) {}

    public override void NotifyNewTurn(List<ICharacter> allies, List<IEnemy> enemies) {
        foreach (Listener listener in this.Listeners["Battle_NewTurn"]) {
            listener.onNewTurn(allies, enemies);
        }
    }


    public override void NotifyAttackDamage(string attackerName, string damage) {
        foreach (Listener listener in this.Listeners["Battle_AttackDamage"]) {
            listener.onAttack(attackerName, damage);
        }
    }


    public override void NotifiyEnemyDefeat(string enemyName) {
        foreach (Listener listener in this.Listeners["Battle_EnemyDefeat"]) {
            listener.onEnemyDefeat(enemyName);
        }
    }


    public override void NotifyEscapeFail() {
        foreach (Listener listener in this.Listeners["Battle_EscapeFail"]) {
            listener.onEscapeFail();
        }
    }


    public override void NotifyBattleEnd(bool hasEscaped) {
        foreach (Listener listener in this.Listeners["Battle_BattleEnd"]) {
            listener.onBattleEnd(hasEscaped);
        }
    }
}