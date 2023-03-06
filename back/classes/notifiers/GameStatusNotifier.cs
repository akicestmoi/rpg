public class GameStatusNotifier: Notifier {

    public GameStatusNotifier(List<string> eventList) : base(eventList) {}


    public override void NotifyNoEvent() {
        foreach (Listener listener in this.Listeners["System_NoEvent"]) {
            listener.onNoEvent();
        }
    }

    public override void NotifyEnemyEncounter() {
        foreach (Listener listener in this.Listeners["System_EnemyEncounter"]) {
            listener.onEnemyEncounter();
        }
    }

    public override void NotifyChestFound() {
        foreach (Listener listener in this.Listeners["System_ChestFound"]) {
            listener.onChestFound();
        }
    }

    public override void NotifyMerchantEncounter() {
        foreach (Listener listener in this.Listeners["System_MerchantEncounter"]) {
            listener.onMerchantEncounter();
        }
    }

    public override void NotifyFountainFound() {
        foreach (Listener listener in this.Listeners["System_FountainFound"]) {
            listener.onHealingFountain();
        }
    }

    public override void NotifyGameEnd() {
        foreach (Listener listener in this.Listeners["System_GameEnd"]) {
            listener.onGameEnd();
        }
    }
}