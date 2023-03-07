using System.Text.Json;


public class EventManager: IEventManager {
    
    public IPlayer Player {get; private set;}
    public List<IEnemy> EnemiesTemplate {get;}
    public List<IItem> ItemsTemplate {get;}
    public Settings settings {get;}
    public IBattleManager battleManager {get;}
    public Notifier gameStatusNotifier {get;}
    public Notifier playerStatusNotifier {get;}
    public Notifier battleNotifier {get;}


    public EventManager(IPlayer player, List<IEnemy> enemiesTemplate, List<IItem> itemsTemplate, Settings settings, IBattleManager battleManager, Notifier gameStatusNotifier, Notifier playerStatusNotifier, Notifier battleNotifier) {
        this.Player = player;
        this.EnemiesTemplate = enemiesTemplate;
        this.ItemsTemplate = itemsTemplate;
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

        var battleAllies = new List<ICharacter> {
            this.Player
        };

        Dictionary<int, int> encounteredEnemies = this.DefineEncounteredEnemies();
        var battleEnemies = new List<IEnemy>();
        foreach (var (enemyID, numberOfThisEnemyType) in encounteredEnemies.Select(x => (x.Key, x.Value))) {
            for (int i = 0; i < numberOfThisEnemyType; i++) {
                var newEnemy = this.GenerateEnemyFromTemplate(enemyID);
                if (numberOfThisEnemyType > 1) { newEnemy.Name = string.Format("{0} {1}", newEnemy.Name, (char)(i+65)); }
                battleEnemies.Add(newEnemy);
            }
        }

        battleManager.Battle(battleAllies, battleEnemies);
    }


    public Dictionary<int, int> DefineEncounteredEnemies() {

        var filteredEnemyIDList = new List<int>();

        foreach (var potentialEnemy in this.EnemiesTemplate.Select((value, index) => (value, index))) {
            if (potentialEnemy.value.LevelThreshold <= this.Player.Level) {
                filteredEnemyIDList.Add(potentialEnemy.index);
            }
        }

        var rnd = new Random();

        int potentialDifferentEnemy = rnd.Next(1, (int)this.settings.MechanicsParameters["Max_Different_Enemy_Type_in_One_Encounter"]); 
        var encounteredEnemies = new Dictionary<int, int>();
        for (int i = 0; i < potentialDifferentEnemy; i++) {

            int potentialEnemyID = rnd.Next(0, filteredEnemyIDList.Count);
            int enemyID = filteredEnemyIDList[potentialEnemyID];

            int numberOfThisEnemyType = rnd.Next(1, this.EnemiesTemplate[enemyID].SimultaneousApperance + 1); 

            encounteredEnemies.Add(enemyID, numberOfThisEnemyType);
        }

        return encounteredEnemies;
    }


    public IEnemy GenerateEnemyFromTemplate(int enemyID) {

        var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        string enemyJson = File.ReadAllText(this.settings.JsonLocation["EnemyList"]);
        var enemyList = JsonSerializer.Deserialize<EnemyList>(enemyJson, jsonOptions)!;

        Enemy generatedEnemy = enemyList.Enemy[enemyID];
        generatedEnemy.setStatus();

        return generatedEnemy;
    }


    /* Treasure */
    public void TreasureEvent() {
        IItem itemFound = DefineTreasureContent();
        this.Player.GainItem(this.settings, itemFound, this.playerStatusNotifier);
    }

    public IItem DefineTreasureContent() {
        var rnd = new Random();
        int itemID = rnd.Next(0, this.ItemsTemplate.Count);

        return this.ItemsTemplate[itemID];
    }


    /* Merchant */
    public void MerchantEvent() {
        /* */
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