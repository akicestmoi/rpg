using System.Text.Json;


public class GameManager: IGameManager {

    public List<IPlayer> Players {get; set;}
    public List<IEnemy> Enemies {get; set;}
    public IPlayerStatusNotifier playerStatusNotifier {get;set;}
    public ICombatNotifier combatNotifier {get;set;}

    /* Constructor */
    public GameManager() {

        Settings settings = new Settings();

        /* Initialize all Notifiers */
        this.playerStatusNotifier = new PlayerStatusNotifier();
        this.combatNotifier = new CombatNotifier();

        /* Initialize Enemies Data */
        this.GenerateEnemies(settings);

        /* Initialize Player Data */
        this.Players = new List<IPlayer>();
    }


    public void GenerateEnemies(Settings settings) {

        var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        string enemyJson = File.ReadAllText(settings.JsonLocation["EnemyList"]);
        EnemyList enemyList = JsonSerializer.Deserialize<EnemyList>(enemyJson, jsonOptions)!;

        foreach (Enemy enemy in enemyList.Enemy) {
            enemy.setStatus();
            this.Enemies.Add(enemy);
        }
    }


    public void RegisterPlayer(string playerName) {
                
        Player player = new Player(playerName);
        Players.Add(player);

    }


    public int eventTrigger() {
        
        Random rnd = new Random();

        int diceRollRange = 100;
        double diceRoll = rnd.Next(1, diceRollRange);
        double probEventTrigger = diceRoll / diceRollRange;

        int gameEvent = 0;

        switch (probEventTrigger)
        {
            case >= 0 and < 0.33:
                if (this.IsEventHappening(0.9)) {
                    gameEvent = 1 ;
                } else { 
                    gameEvent = 3;
                };
                break;

            case >= 0.33 and < 0.66:
                if (this.IsEventHappening(0.5)) {
                    gameEvent = 2 ;
                } else { 
                    gameEvent = 3;
                };
                break;

            case >= 0.66:
                gameEvent = 3;
                break;

            default:
                gameEvent = 3;
                break;
        }

        return gameEvent;
    }


    public bool IsEventHappening(double threshold) {

        Random rnd = new Random();

        int diceRollRange = 100;
        double diceRoll = rnd.Next(1, diceRollRange);
        double probHappening = diceRoll / diceRollRange;

        return probHappening >= threshold;
    }


    public IEnemy DefineEncounteredEnemy() {
        
        Random rnd = new Random();
        int enemyID = rnd.Next(0, Enemies.Count);

        return Enemies[0];
    }


    public void EngageCombat(Player player, Enemy enemy) {
        
        CombatManager CurrentCombat = new CombatManager(player, enemy);

        while (player.Status == CharacterStatus.Alive & enemy.Status == CharacterStatus.Alive) {
            CurrentCombat.OneTurnCombat(this.combatNotifier, this.playerStatusNotifier);
        }

        this.combatNotifier.NotifyCombatEnd(player.Status, enemy.Name);
        
        if (player.Status == CharacterStatus.Alive) {
            player.GainXP(enemy.GivableXP, this.playerStatusNotifier);
        }
    }
}