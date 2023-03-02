public interface IPlayerStatusNotifier {
    public List<IPlayerStatusListener> Listeners {get; set;}

    public void RegisterListener(IPlayerStatusListener listener);
    public void UnregisterListener(IPlayerStatusListener listener);
    public void NotifyPropertyChange(string property, string value);
    public void NotifyLevelUp(int level, int maxHp, int atk, int def, int spd);
    public void NotifyXPGain(int xp);
    public void NotifyDeath();
}