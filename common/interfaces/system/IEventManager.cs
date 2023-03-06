public interface IEventManager {
    public IPlayer Player {get;}
    public List<IEnemy> Enemies {get;}
    public List<IItem> Items {get;}
    public Settings settings {get;}
    public IBattleManager battleManager {get;}
    public Notifier gameStatusNotifier {get;}
    public Notifier playerStatusNotifier {get;}
    public Notifier battleNotifier {get;}

    public void UpdatePlayerInfo(IPlayer player);
    public void BattleEvent();
    public IEnemy DefineEncounteredEnemy();
    public void TreasureEvent();
    public IItem DefineTreasureContent();
    public void MerchantEvent();
    public void HealingFountainEvent();
    public void HealingFountainEffect();

}