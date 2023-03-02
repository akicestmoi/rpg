using System.Text.Json;


public class GameManager: IGameManager {

    public List<IPlayer> Players {get; set;}
    public List<IEnemy> Enemies {get; set;}
    public Notifier gameStatusNotifier {get;set;}
    public Notifier playerStatusNotifier {get;set;}
    public Notifier combatNotifier {get;set;}


    /* Constructor */
    public GameManager() {

        Settings settings = new Settings();

        /* Initialize all Notifiers */
        List<string> playerEventList = new List<string> { "Player_PropertyChange", "Player_LevelUp", "Player_XPGain", "Player_PlayerDeath" };
        List<string> combatEventList = new List<string> { "Combat_NewTurn", "Combat_AttackDamage", "Combat_CombatEnd" };
        List<string> gameEventList = new List<string> { "System_GameEnd" };
        this.gameStatusNotifier = new GameStatusNotifier(gameEventList);
        this.playerStatusNotifier = new PlayerStatusNotifier(playerEventList);
        this.combatNotifier = new CombatNotifier(combatEventList);


        /* Initialize Enemies Data */
        this.Enemies = new List<IEnemy>();
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
            case >= 0 and < 0.7:
                if (this.IsEventHappening(0.9)) {
                    gameEvent = 1 ;
                } else { 
                    gameEvent = 1;
                };
                break;

            case >= 0.7 and < 0.8:
                if (this.IsEventHappening(0.5)) {
                    gameEvent = 2 ;
                } else { 
                    gameEvent = 1;
                };
                break;

            case >= 0.8:
                gameEvent = 1;
                break;

            default:
                gameEvent = 1;
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

        return Enemies[enemyID];
    }


    public void ResetEnemy(IEnemy enemy) {
        enemy.Status = CharacterStatus.Alive;
        enemy.HP = enemy.MaxHP;
    }


    public void EngageCombat(IPlayer player, IEnemy enemy) {

        CombatManager CurrentCombat = new CombatManager(player, enemy);

        while (player.Status == CharacterStatus.Alive & enemy.Status == CharacterStatus.Alive) {
            CurrentCombat.OneTurnCombat(this.combatNotifier, this.playerStatusNotifier);
        }

        this.combatNotifier.NotifyCombatEnd(player.Status, enemy.Name);
        this.ResetEnemy(enemy);
        
        if (player.Status == CharacterStatus.Alive) {
            player.GainXP(enemy.GivableXP, this.playerStatusNotifier);
        } else {
            this.playerStatusNotifier.NotifyPlayerDeath();
            this.gameStatusNotifier.NotifyGameEnd();
        }
    }
}