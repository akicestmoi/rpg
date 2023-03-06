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

    public override void NotifyHeal(int healingAmount) {
        foreach (Listener listener in this.Listeners["Player_Heal"]) {
            listener.onHeal(healingAmount);
        }
    }

    public override void NotifyGoldGain(int gold) {
        foreach (Listener listener in this.Listeners["Player_GoldGain"]) {
            listener.onGoldGain(gold);
        }
    }

    public override void NotifyGoldUsage(int gold) {
        foreach (Listener listener in this.Listeners["Player_GoldSpend"]) {
            listener.onGoldUsage(gold);
        }
    }

    public override void NotifyItemPickup(string itemName) {
        foreach (Listener listener in this.Listeners["Player_ItemPick"]) {
            listener.onItemPickup(itemName);
        }
    }

    public override void NotifyInventoryFull() {
        foreach (Listener listener in this.Listeners["Player_FullInventory"]) {
            listener.onInventoryFull();
        }
    }

    public override void NotifyItemUse(string itemName) {
        foreach (Listener listener in this.Listeners["Player_ItemUse"]) {
            listener.onItemUse(itemName);
        }
    }

    public override void NotifyPlayerDeath() {
        foreach (Listener listener in this.Listeners["Player_PlayerDeath"]) {
            listener.onPlayerDeath();
        }
    }
}