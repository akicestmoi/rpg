public interface ICombatListener {
    public void onCombatStart();
    public void onAttack(string attacker, string damage);
    public bool onCombatEnd(CharacterStatus currentStatus, string enemyName);
}