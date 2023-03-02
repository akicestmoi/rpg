public class CombatManager: ICombatManager {
    public ICharacter FirstAttacker {get;}
    public ICharacter SecondAttacker {get;}


    public CombatManager(IPlayer player, IEnemy enemy) {

        if (player.SPD >= enemy.SPD) {
            this.FirstAttacker = player;
            this.SecondAttacker = enemy;
        } else {
            this.FirstAttacker = enemy;
            this.SecondAttacker = player;
        }
    }


    public void OneTurnCombat(Notifier combatNotifier, Notifier playerStatusNotifier) {

        combatNotifier.NotifyNewTurn(this.FirstAttacker, this.SecondAttacker);

        int firstAttackerDamage = this.FirstAttacker.Attack(SecondAttacker);
        combatNotifier.NotifyAttackDamage(this.FirstAttacker.Name, firstAttackerDamage.ToString());

        this.SecondAttacker.TakeHit(firstAttackerDamage);
        
        if (this.SecondAttacker.Status == CharacterStatus.Alive) {
            
            int secondAttackerDamage = this.SecondAttacker.Attack(FirstAttacker);
            combatNotifier.NotifyAttackDamage(this.SecondAttacker.Name, secondAttackerDamage.ToString());

            this.FirstAttacker.TakeHit(secondAttackerDamage);
        }
    }
}