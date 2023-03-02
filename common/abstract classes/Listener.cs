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
    public virtual void onEnemyEncounter(IGameManager gameManager) {}
    public virtual void onGameEnd() {}

    /* Combat */
    public virtual void onNewTurn(ICharacter firstCharacter, ICharacter secondCharacter) {}
    public virtual void onAttack(string attacker, string damage) {}
    public virtual bool onCombatEnd(CharacterStatus currentStatus, string enemyName) { return false; }

    /* Player Status */
    public virtual void onPlayerCreation(IGameManager gameManager, string playerName) {}
    public virtual void onPropertyChange(string property, string value) {}
    public virtual void onLevelUp(int level, int maxHp, int atk, int def, int spd) {}
    public virtual void onXPGain(int xp) {}
    public virtual void onPlayerDeath() {}
}