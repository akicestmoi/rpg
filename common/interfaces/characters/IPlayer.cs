public interface IPlayer: ICharacter {

    public Dictionary<int, int> LevelUpTable {get;}
    public int Level {get;}
    public int XP {get;}
    public int Gold {get;}
    public Dictionary<string, IEquipmentItem> Equipment {get;}
    public List<IItem> Inventory {get;}


    public void GainXP(int xp, Notifier playerStatusNotifier);
    public void LevelUp(Notifier playerStatusNotifier);
    public void GainGold(int gold, Notifier playerStatusNotifier);
    public void SpendGold(int gold, Notifier playerStatusNotifier);
    public void GainItem(Settings settings, IItem item, Notifier playerStatusNotifier);
    public void RemoveItem(IItem item);
    public void EquipItem();
    public void UnequipItem();
}