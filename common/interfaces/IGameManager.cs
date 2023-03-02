public interface IGameManager {
    public List<IPlayer> Players {get; set;}
    public List<IEnemy> Enemies {get; set;}
    public Notifier gameStatusNotifier {get;set;}
    public Notifier playerStatusNotifier {get;set;}
    public Notifier combatNotifier {get;set;}

    public void GenerateEnemies(Settings settings);
    public void RegisterPlayer(string playerName);
    public int eventTrigger();
    public bool IsEventHappening(double threshold);
    public IEnemy DefineEncounteredEnemy();
    public void ResetEnemy(IEnemy enemy);
    public void EngageCombat(IPlayer player, IEnemy enemy);
}