public abstract class Notifier {

    public Dictionary<string, List<Listener>> Listeners {get; set;}


    public Notifier(List<string> eventList) {
        
        this.Listeners = new Dictionary<string, List<Listener>>();
        
        foreach (string eventType in eventList) {
            List<Listener> eventListeners = new List<Listener>();
            Listeners.Add(eventType, eventListeners);
        }
    }

    public void Subscribe(string eventType, Listener listener) {
        Listeners[eventType].Add(listener);
    }


    public void Unsubscribe(string eventType, Listener listener) {
        Listeners[eventType].Remove(listener);
    }



    /* Game Status */
    public virtual void NotifyGameEnd() {}


    /* Player */
    public virtual void NotifyPropertyChange(string property, string value) {}
    public virtual void NotifyLevelUp(int level, int maxHp, int atk, int def, int spd) {}
    public virtual void NotifyXPGain(int xp) {}
    public virtual void NotifyPlayerDeath() {}


    /* Combat */
    public virtual void NotifyNewTurn(ICharacter firstCharacter, ICharacter secondCharacter) {}
    public virtual void NotifyAttackDamage(string attackerName, string damage) {}
    public virtual void NotifyCombatEnd(CharacterStatus currentStatus, string enemyName) {}
}