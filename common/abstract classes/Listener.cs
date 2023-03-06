public abstract class Listener {

    /* Constructor */
    public Listener(Notifier notifier, List<string> eventList) {
        foreach(string eventType in eventList) {
            notifier.Subscribe(eventType, this);
        }
    }

    /* Game Status */
    public virtual void onGameStart() {}
    public virtual void onPlayerTurn() {}
    public virtual void onPlayerMove(IGameManager gameManager) {}
    public virtual void onNoEvent() {}
    public virtual void onEnemyEncounter() {}
    public virtual void onChestFound() {}
    public virtual void onMerchantEncounter() {}
    public virtual void onHealingFountain() {}
    public virtual void onGameEnd() {}

    /* Battle */
    public virtual void onNewTurn(List<ICharacter> allies, List<IEnemy> enemies) {}
    public virtual void onAttack(string attacker, string damage) {}
    public virtual void onEnemyDefeat(string enemyName) {}
    public virtual void onEscapeFail() {}
    public virtual void onBattleEnd(bool hasEscaped) {}

    /* Player Status */
    public virtual void onPlayerCreation(IGameManager gameManager, string playerName) {}
    public virtual void onPropertyChange(string property, string value) {}
    public virtual void onLevelUp(int level, int maxHp, int atk, int def, int spd) {}
    public virtual void onXPGain(int xp) {}
    public virtual void onHeal(int healingAmount) {}
    public virtual void onGoldGain(int gold) {}
    public virtual void onGoldUsage(int gold) {}
    public virtual void onItemPickup(string itemName) {}
    public virtual void onInventoryFull() {}
    public virtual void onItemUse(string itemName) {}
    public virtual void onPlayerDeath() {}
}