public interface IPlayerStatusListener {

    public void onPlayerCreation(IGameManager gameManager, string playerName);
    public void onPropertyChange(string property, string value);
    public void onLevelUp(int level, int maxHp, int atk, int def, int spd);
    public void onXPGain(int xp);
    public void onDeath();
}