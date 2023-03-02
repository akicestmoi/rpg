public class PlayerStatusNotifier: IPlayerStatusNotifier {

    public List<IPlayerStatusListener> Listeners {get; set;}


    /* Constructor */
     public PlayerStatusNotifier() {
        this.Listeners = new List<IPlayerStatusListener>();
    } 


    public void RegisterListener(IPlayerStatusListener listener) {
        Listeners.Add(listener);
    }


    public void UnregisterListener(IPlayerStatusListener listener) {
        Listeners.Remove(listener);
    }


    public void NotifyPropertyChange(string property, string value) {
        foreach (IPlayerStatusListener listener in this.Listeners) {
            listener.onPropertyChange(property, value);
        }
    }

    public void NotifyLevelUp(int level, int maxHp, int atk, int def, int spd) {
        foreach (IPlayerStatusListener listener in this.Listeners) {
            listener.onLevelUp(level, maxHp, atk, def, spd);
        }
    }

    public void NotifyXPGain(int xp) {
        foreach (IPlayerStatusListener listener in this.Listeners) {
            listener.onXPGain(xp);
        }
    }

    public void NotifyDeath() {
        foreach (IPlayerStatusListener listener in this.Listeners) {
            listener.onDeath();
        }
    }
}