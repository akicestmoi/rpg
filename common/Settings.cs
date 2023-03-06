public class Settings {
    public Dictionary<string, string>? JsonLocation {get;}
    public Dictionary<string, List<string>> AllGameEvents {get;}
    public Dictionary<int, int> LevelUpTable {get;}
    public Dictionary<string, double> MechanicsParameters {get;}
    

    public Settings() {
        
        /* JsonLocation Path */
        string rootPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\"));
        string filePath = rootPath + @"common\data\";

        this.JsonLocation = new Dictionary<string, string>();
        this.JsonLocation.Add("EnemyList", filePath + "Enemies.json");
        this.JsonLocation.Add("ItemList", filePath + "Items.json");


        /* Dictionary containing Game Event Lists */
        this.AllGameEvents = new Dictionary<string, List<string>>() {
            { "playerEventList", new List<string> { "Player_PropertyChange", "Player_LevelUp", "Player_XPGain", "Player_Heal", "Player_GoldGain", "Player_GoldSpend", "Player_ItemPick", "Player_FullInventory", "Player_ItemUse", "Player_PlayerDeath"} },
            { "battleEventList", new List<string> { "Battle_NewTurn", "Battle_AttackDamage", "Battle_EnemyDefeat", "Battle_EscapeFail", "Battle_BattleEnd" } },
            { "gameEventList", new List<string> { "System_NoEvent", "System_EnemyEncounter", "System_ChestFound", "System_MerchantEncounter", "System_FountainFound", "System_GameEnd" } }
        };


        /* Define Level up table */
        this.LevelUpTable = Enumerable.Range(0, 99).ToDictionary(x => x, x => (int)Math.Pow(x,2) + 10*x);


        /* Deictionary containing Game mechanics parameters */
        this.MechanicsParameters = new Dictionary<string, double> {
            { "Healing_Fountain_Effect", 0.1 },
            { "Item_Healing_Effect", 0.05 },
            { "Inventory_Capacity", 16 }
        };

    }

}