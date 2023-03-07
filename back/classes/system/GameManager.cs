using System.Text.Json;


public class GameManager: IGameManager {

    public IPlayer Player {get; private set;}
    public List<IEnemy> EnemiesTemplate {get;}
    public List<IItem> ItemsTemplate {get;}
    public Settings settings {get;}
    public IBattleManager battleManager {get;}
    public IEventManager eventManager {get;}
    public Notifier gameStatusNotifier {get;}
    public Notifier playerStatusNotifier {get;}
    public Notifier battleNotifier {get;}


    /* Constructor */
    public GameManager(Poster battlePoster) {

        this.settings = new Settings();

        /* Initialize all Notifiers */
        this.gameStatusNotifier = new GameStatusNotifier(settings.AllGameEvents["gameEventList"]);
        this.playerStatusNotifier = new PlayerStatusNotifier(settings.AllGameEvents["playerEventList"]);
        this.battleNotifier = new BattleNotifier(settings.AllGameEvents["battleEventList"]);


        /* Initialize Items Data */
        this.ItemsTemplate = new List<IItem>();
        this.GenerateItems(settings);

        /* Initialize Enemies Data */
        this.EnemiesTemplate = new List<IEnemy>();
        this.GenerateEnemies(settings);

        /* Initialize Player Data */
        this.Player = new Player("default", settings);

        /* Initialize all Managers */
        this.battleManager = new BattleManager(this.Player, this.settings, this.gameStatusNotifier, this.playerStatusNotifier, this.battleNotifier, battlePoster);
        this.eventManager = new EventManager(this.Player, this.EnemiesTemplate, this.ItemsTemplate, this.settings, this.battleManager, this.gameStatusNotifier, this.playerStatusNotifier, this.battleNotifier);
    }


    public void GenerateEnemies(Settings settings) {

        var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        string enemyJson = File.ReadAllText(settings.JsonLocation["EnemyList"]);
        var enemyList = JsonSerializer.Deserialize<EnemyList>(enemyJson, jsonOptions)!;

        foreach (Enemy enemy in enemyList.Enemy) {
            enemy.setStatus();
            this.EnemiesTemplate.Add(enemy);
        }
    }


    public void GenerateItems(Settings settings) {

        var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        string itemJson = File.ReadAllText(settings.JsonLocation["ItemList"]);
        var itemList = JsonSerializer.Deserialize<ItemList>(itemJson, jsonOptions)!;

        foreach (Item item in itemList.Item) {
            this.ItemsTemplate.Add(item);
        }
    }

    public void RegisterPlayer(string playerName) {
        this.Player = new Player(playerName, this.settings);
        this.battleManager.UpdatePlayerInfo(this.Player);
        this.eventManager.UpdatePlayerInfo(this.Player);
    }


    public void gameEventController() {
        
        var rnd = new Random();

        double probEventTrigger = rnd.NextDouble();

        switch (probEventTrigger)
        {
            /* Combat */
            case >= 0 and < 0.25:
                this.gameStatusNotifier.NotifyEnemyEncounter();
                this.eventManager.BattleEvent();
                break;

            /* Treasure */
            case >= 0.25 and < 0.50:
                this.gameStatusNotifier.NotifyChestFound();
                this.eventManager.TreasureEvent();
                break;

            /* Merchant */
            case >= 0.50 and < 0.55:
                this.gameStatusNotifier.NotifyMerchantEncounter();
                this.eventManager.MerchantEvent();
                break;

            /* Healing Fountain */
            case >= 0.55 and < 0.75:
                this.gameStatusNotifier.NotifyFountainFound();
                this.eventManager.HealingFountainEvent();
                break;

            /* No Event */
            case >= 0.75:
                this.gameStatusNotifier.NotifyNoEvent();
                break;

            default:
                this.gameStatusNotifier.NotifyNoEvent();
                break;
        }
    }     
}