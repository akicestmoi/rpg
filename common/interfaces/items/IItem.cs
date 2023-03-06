public interface IItem {
    public int ID {get; set;}
    public string? Name {get; set;}
    public List<string>? Effect {get; set;}

    public void TriggerItemEffect(Settings settings, IPlayer player, Notifier notifier);
    public void UseItem(Settings settings, IPlayer player, Notifier notifier);
    public void RestoreHP(Settings settings, IPlayer player, Notifier notifier);
}