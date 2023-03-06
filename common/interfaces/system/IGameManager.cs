public interface IGameManager {
    public IPlayer Player {get;}
    public List<IEnemy> Enemies {get;}
    public List<IItem> Items {get;}
    public Settings settings {get;}
    public IBattleManager battleManager {get;}
    public IEventManager eventManager {get;}
    public Notifier gameStatusNotifier {get;}
    public Notifier playerStatusNotifier {get;}
    public Notifier battleNotifier {get;}


    public void GenerateEnemies(Settings settings);
    public void GenerateItems(Settings settings);
    public void RegisterPlayer(string playerName);
    public void gameEventController();
}