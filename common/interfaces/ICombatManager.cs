public interface ICombatManager {
    public ICharacter FirstAttacker {get;}
    public ICharacter SecondAttacker {get;}

    public void OneTurnCombat(Notifier combatNotifier, Notifier playerStatusNotifier);
}