public class GameStatusNotifier: Notifier {

    public GameStatusNotifier(List<string> eventList) : base(eventList) {}


    public override void NotifyGameEnd() {
        foreach (Listener listener in this.Listeners["System_GameEnd"]) {
            listener.onGameEnd();
        }
    }
}