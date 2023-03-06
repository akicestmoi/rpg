public class Player: Character, ICharacter, IPlayer {

    public Dictionary<int, int> LevelUpTable {get;}
    public int XP {get; private set;}
    public int Level {get; private set;}
    public int Gold {get; private set;}
    public Dictionary<string, IEquipmentItem> Equipment {get; private set;}
    public List<IItem> Inventory {get; private set;}
    

    public Player(string playerName, Settings settings) {

        this.Name = playerName;
        this.CharacterType = CharacterType.Player;
        this.Status = CharacterStatus.Alive;

        this.LevelUpTable = settings.LevelUpTable;
        this.Level = 1;
        this.XP = 0;
        this.Gold = 0;

        this.Equipment = new Dictionary<string, IEquipmentItem>() {
            { "Head", new EquipmentItem("Head") },
            { "Body", new EquipmentItem("Body") },
            { "Legs", new EquipmentItem("Legs") },
            { "Hands", new EquipmentItem("Hands") },
            { "Foot", new EquipmentItem("Foot") },
        };

        this.Inventory = new List<IItem>();

        Random rnd = new Random();
        this.MaxHP = rnd.Next(10, 30);
        this.HP = this.MaxHP;
        this.ATK = rnd.Next(1, 5);
        this.DEF = rnd.Next(1, 5);
        this.SPD = rnd.Next(1, 5);
    }

    public void GainXP(int xp, Notifier playerStatusNotifier) {
                
        int xpNeeded = this.LevelUpTable[this.Level];

        playerStatusNotifier.NotifyXPGain(xp);
        this.XP += xp;

        if (this.XP >= xpNeeded ) {
            this.LevelUp(playerStatusNotifier);
        }
    }


    public void LevelUp(Notifier playerStatusNotifier) {

        Random rnd = new Random();

        this.Level ++;
        this.MaxHP += rnd.Next(3, 15);
        this.HP = this.MaxHP;
        this.ATK += rnd.Next(1, 3);
        this.DEF += rnd.Next(1, 3);
        this.SPD += rnd.Next(1, 3);

        playerStatusNotifier.NotifyLevelUp(this.Level, this.MaxHP, this.ATK, this.DEF, this.SPD);
    }

    
    public void GainGold(int gold, Notifier playerStatusNotifier) {
        this.Gold += gold;
        playerStatusNotifier.NotifyGoldGain(gold);
    }


    public void SpendGold(int gold, Notifier playerStatusNotifier) {
        this.Gold -= gold;
        playerStatusNotifier.NotifyGoldUsage(gold);
    }


    public void GainItem(Settings settings, IItem item, Notifier playerStatusNotifier) {

        if (this.Inventory.Count < settings.MechanicsParameters["Inventory_Capacity"]) {
            this.Inventory.Add(item);
            playerStatusNotifier.NotifyItemPickup(item.Name);
        } else {
            playerStatusNotifier.NotifyInventoryFull();
        }

    }


    public void RemoveItem(IItem item) {

        foreach (var inventoryItem in this.Inventory.Select((value, index) => (value, index))) {
            if (inventoryItem.value.Name == item.Name) {
                this.Inventory.RemoveAt(inventoryItem.index);
                break;
            }
        }
    }


    public void EquipItem() {
        /* Place Item in respective equipment slot */
        /* If something already on equipment slot, ask player to replace */
        /* Apply stat change */
        /* Remove equipment from inventory with this.RemoveItem */
    }


    public void UnequipItem() {
        /* Remove Item from respective equipment slot */
        /* If something already on equipment slot, ask player to replace */
        /* Apply stat change */
        /* Remove equipment from inventory with this.RemoveItem */
    }
}