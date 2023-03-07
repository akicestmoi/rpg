public abstract class Notifier {

    public Dictionary<string, List<Listener>> Listeners {get; set;}


    public Notifier(List<string> eventList) {
        
        this.Listeners = new Dictionary<string, List<Listener>>();
        
        foreach (string eventType in eventList) {
            List<Listener> eventListeners = new List<Listener>();
            this.Listeners.Add(eventType, eventListeners);
        }
    }

    public void Subscribe(string eventType, Listener listener) {
        this.Listeners[eventType].Add(listener);
    }


    public void Unsubscribe(string eventType, Listener listener) {
        this.Listeners[eventType].Remove(listener);
    }



    /* Game Status */
    public virtual void NotifyNoEvent() {}
    public virtual void NotifyEnemyEncounter() {}
    public virtual void NotifyChestFound() {}
    public virtual void NotifyMerchantEncounter() {}
    public virtual void NotifyFountainFound() {}
    public virtual void NotifyGameEnd() {}


    /* Player */
    public virtual void NotifyPropertyChange(string property, string value) {}
    public virtual void NotifyLevelUp(int level, int maxHp, int atk, int def, int spd) {}
    public virtual void NotifyXPGain(int xp) {}
    public virtual void NotifyHeal(int healingAmount) {}
    public virtual void NotifyGoldGain(int gold) {}
    public virtual void NotifyGoldUsage(int gold) {}
    public virtual void NotifyItemPickup(string itemName) {}
    public virtual void NotifyInventoryFull() {}
    public virtual void NotifyItemUse(string itemName) {}
    public virtual void NotifyPlayerDeath() {}


    /* Battle */
    public virtual void NotifyNewTurn(List<ICharacter> allies, List<IEnemy> enemies) {}
    public virtual void NotifyAttackDamage(string attackerName, int damage, string targetName) {}
    public virtual void NotifiyEnemyDefeat(string enemyName) {}
    public virtual void NotifyEscapeFail() {}
    public virtual void NotifyBattleEnd(bool hasEscaped) {}
}