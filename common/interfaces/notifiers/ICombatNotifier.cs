public interface ICombatNotifier {
    public List<ICombatListener> Listeners {get; set;}

    public void RegisterListener(ICombatListener listener);
    public void UnregisterListener(ICombatListener listener);
    public void NotifyAttackDamage(string attackerName, string damage);
    public void NotifyCombatEnd(CharacterStatus currentStatus, string enemyName);
}