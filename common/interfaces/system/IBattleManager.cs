public interface IBattleManager {
    public IPlayer Player {get;}
    public List<ICharacter> BattleAllies {get; set;}
    public List<IEnemy> BattleEnemies {get; set;}
    public IEnumerable<object> moveOrder {get; set;}
    public bool IsBattle {get; set;}
    public bool HasEscaped {get; set;}
    public int GainedXP {get; set;}
    public int GainedGold {get; set;}
    public Settings settings {get;}
    public Notifier gameStatusNotifier {get;}
    public Notifier playerStatusNotifier {get;}
    public Notifier battleNotifier {get;}
    public Getter getter {get;}
    

    public void UpdatePlayerInfo(IPlayer player);
    public void Battle(List<ICharacter> allies, List<IEnemy> enemies);
    public void OneTurn();
    public List<BattleChoices> SetBattleChoices();
    public (BattleChoices, int) GetAllUserInput();
    public void SetMoveOrder(BattleChoices userAction);
    public void AttackEvent(ICharacter attacker, int userChoice);
    public void ItemUseEvent(int userChoice);
    public void EscapeEvent();
}