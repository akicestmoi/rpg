using System.Reflection;

public class Item: IItem {
    public int ID {get; set;}
    public string? Name {get; set;}
    public List<string>? Effect {get; set;}


    public void TriggerItemEffect(Settings settings, IPlayer player, Notifier notifier) {
        foreach (string effect in this.Effect) {
            MethodInfo effectFunc = this.GetType().GetMethod(effect);
            effectFunc.Invoke(this, new object[] {settings, player, notifier});
        }
    }

    public void UseItem(Settings settings, IPlayer player, Notifier notifier) {
        this.TriggerItemEffect(settings, player, notifier);
    }

    public void RestoreHP(Settings settings, IPlayer player, Notifier notifier) {
        int healingAmount = (int)Math.Ceiling(player.MaxHP * settings.MechanicsParameters["Item_Healing_Effect"]);
        notifier.NotifyHeal(healingAmount);
        player.Heal(player, healingAmount);
    }
}