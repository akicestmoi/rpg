public interface IGameManager {
    public List<IPlayer> Players {get; set;}
    public List<IEnemy> Enemies {get; set;}
    public IPlayerStatusNotifier playerStatusNotifier {get;set;}
    public ICombatNotifier combatNotifier {get;set;}

    public void GenerateEnemies(Settings settings);
    public void RegisterPlayer(string playerName);
    public int eventTrigger();
    public bool IsEventHappening(double threshold);
    public IEnemy DefineEncounteredEnemy();
    public void EngageCombat(IPlayer player, IEnemy enemy);
}