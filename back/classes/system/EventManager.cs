public class EventManager: IEventManager {
    
    public IPlayer Player {get; private set;}
    public List<IEnemy> Enemies {get;}
    public List<IItem> Items {get;}
    public Settings settings {get;}
    public IBattleManager battleManager {get;}
    public Notifier gameStatusNotifier {get;}
    public Notifier playerStatusNotifier {get;}
    public Notifier battleNotifier {get;}


    /* Pour plus tard... */
/*     public bool IsEventHappening(double threshold) {
        var rnd = new Random();

        int diceRollRange = 100;
        double diceRoll = rnd.Next(1, diceRollRange);
        double probHappening = diceRoll / diceRollRange;

        return probHappening >= threshold;
    } */

    public EventManager(IPlayer player, List<IEnemy> enemies, List<IItem> items, Settings settings, IBattleManager battleManager, Notifier gameStatusNotifier, Notifier playerStatusNotifier, Notifier battleNotifier) {
        this.Player = player;
        this.Enemies = enemies;
        this.Items = items;
        this.settings = settings;
        this.battleManager = battleManager;
        this.gameStatusNotifier = gameStatusNotifier;
        this.playerStatusNotifier = playerStatusNotifier;
        this.battleNotifier = battleNotifier;
    }

    public void UpdatePlayerInfo(IPlayer player) {
        this.Player = player;
    }


    /* Enemy Encounter */
    public void BattleEvent() {
        IEnemy encounteredEnemy = this.DefineEncounteredEnemy();
        var battleAllies = new List<ICharacter> {
            this.Player
        };
        var battleEnemies = new List<IEnemy> {
            encounteredEnemy
        };
        battleManager.Battle(battleAllies, battleEnemies);
    }

    public IEnemy DefineEncounteredEnemy() {

        var filteredEnemyIDList = new List<int>();

        foreach (var potentialEnemy in this.Enemies.Select((value, index) => (value, index))) {
            if (potentialEnemy.value.LevelThreshold <= this.Player.Level) {
                filteredEnemyIDList.Add(potentialEnemy.index);
            }
        }

        var rnd = new Random();
        int potentialEnemyID = rnd.Next(0, filteredEnemyIDList.Count);
        int enemyID = filteredEnemyIDList[potentialEnemyID];

        return this.Enemies[enemyID];
    }


    /* Treasure */
    public void TreasureEvent() {
        IItem itemFound = DefineTreasureContent();
        this.Player.GainItem(this.settings, itemFound, this.playerStatusNotifier);
    }

    public IItem DefineTreasureContent() {
        var rnd = new Random();
        int itemID = rnd.Next(0, this.Items.Count);

        return this.Items[itemID];
    }


    /* Merchant */
    public void MerchantEvent() {
    }


    /* Healing Fountain */
    public void HealingFountainEvent() {
        this.HealingFountainEffect();
    }
    
    public void HealingFountainEffect() {
        int healingAmount = (int)Math.Ceiling(this.Player.MaxHP * this.settings.MechanicsParameters["Healing_Fountain_Effect"]);
        this.playerStatusNotifier.NotifyHeal(healingAmount);
        this.Player.Heal(this.Player, healingAmount);
    }
}