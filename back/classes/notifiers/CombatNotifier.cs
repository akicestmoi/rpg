public class CombatNotifier: ICombatNotifier {

    public List<ICombatListener> Listeners {get; set;}


    /* Constructor */
     public CombatNotifier() {
        this.Listeners = new List<ICombatListener>();
    } 


    public void RegisterListener(ICombatListener listener) {
        Listeners.Add(listener);
    }


    public void UnregisterListener(ICombatListener listener) {
        Listeners.Remove(listener);
    }


    public void NotifyAttackDamage(string attackerName, string damage) {
        foreach (ICombatListener listener in this.Listeners) {
            listener.onAttack(attackerName, damage);
        }
    }

    public void NotifyCombatEnd(CharacterStatus currentStatus, string enemyName) {
        foreach (ICombatListener listener in this.Listeners) {
            listener.onCombatEnd(currentStatus, enemyName);
        }
    }
}