public class CombatManager: ICombatManager {
    public ICharacter FirstAttacker {get;}
    public ICharacter SecondAttacker {get;}


    public CombatManager(Player player, Enemy enemy) {

        if (player.SPD >= enemy.SPD) {
            this.FirstAttacker = player;
            this.SecondAttacker = enemy;
        } else {
            this.FirstAttacker = enemy;
            this.SecondAttacker = player;
        }
    }


    public void OneTurnCombat(ICombatNotifier combatNotifier, IPlayerStatusNotifier playerStatusNotifier) {

        int firstAttackerDamage = this.FirstAttacker.Attack();
        combatNotifier.NotifyAttackDamage(this.FirstAttacker.Name, firstAttackerDamage.ToString());

        this.SecondAttacker.TakeHit(firstAttackerDamage);
        
        if (this.SecondAttacker.Status == CharacterStatus.Alive) {
            
            int secondAttackerDamage = this.SecondAttacker.Attack();
            combatNotifier.NotifyAttackDamage(this.SecondAttacker.Name, secondAttackerDamage.ToString());

            this.FirstAttacker.TakeHit(firstAttackerDamage);

            if (this.FirstAttacker.Status == CharacterStatus.Dead) {
                playerStatusNotifier.NotifyDeath();
            }

        }
    }
}