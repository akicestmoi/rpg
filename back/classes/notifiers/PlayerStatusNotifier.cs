public class PlayerStatusNotifier: Notifier {

    public PlayerStatusNotifier(List<string> eventList) : base(eventList) {}


    public override void NotifyPropertyChange(string property, string value) {
        foreach (Listener listener in this.Listeners["Player_PropertyChange"]) {
            listener.onPropertyChange(property, value);
        }
    }


    public override void NotifyLevelUp(int level, int maxHp, int atk, int def, int spd) {
        foreach (Listener listener in this.Listeners["Player_LevelUp"]) {
            listener.onLevelUp(level, maxHp, atk, def, spd);
        }
    }


    public override void NotifyXPGain(int xp) {
        foreach (Listener listener in this.Listeners["Player_XPGain"]) {
            listener.onXPGain(xp);
        }
    }


    public override void NotifyPlayerDeath() {
        foreach (Listener listener in this.Listeners["Player_PlayerDeath"]) {
            listener.onPlayerDeath();
        }
    }
}