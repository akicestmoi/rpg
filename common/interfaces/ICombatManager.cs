public interface ICombatManager {
    public ICharacter FirstAttacker {get;}
    public ICharacter SecondAttacker {get;}

    public void OneTurnCombat(ICombatNotifier combatNotifier, IPlayerStatusNotifier playerStatusNotifier);
}