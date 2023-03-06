public class BattleManager: IBattleManager {

    public IPlayer Player {get; private set;}
    public List<ICharacter> BattleAllies {get; set;}
    public List<IEnemy> BattleEnemies {get; set;}
    public IEnumerable<object> moveOrder {get; set;}
    public bool IsBattle {get; set;}
    public bool HasEscaped {get; set;}
    public int GainedXP {get; set;}
    public int GainedGold {get; set;}
    public Settings settings {get;}
    public Notifier gameStatusNotifier {get;}
    public Notifier playerStatusNotifier {get;}
    public Notifier battleNotifier {get;}
    public Getter getter {get;}


    public BattleManager(IPlayer player, Settings settings, Notifier gameStatusNotifier, Notifier playerStatusNotifier, Notifier battleNotifier, Poster poster) {
        this.Player = player;
        this.BattleAllies = new List<ICharacter>();
        this.BattleEnemies = new List<IEnemy>();
        this.moveOrder = new List<object>();
        this.IsBattle = false;
        this.HasEscaped = false;
        this.GainedXP = 0;
        this.GainedGold = 0;

        this.settings = settings;
        this.gameStatusNotifier = gameStatusNotifier;
        this.playerStatusNotifier = playerStatusNotifier;
        this.battleNotifier = battleNotifier;
        this.getter = new BattleGetter(poster);
    }


    public void UpdatePlayerInfo(IPlayer player) {
        this.Player = player;
    }


    public void Battle(List<ICharacter> allies, List<IEnemy> enemies) {

        this.BattleAllies = allies;
        this.BattleEnemies = enemies;
        this.IsBattle = true;

        while (this.IsBattle) {
            this.OneTurn();
        }
        
        if (this.Player.Status == CharacterStatus.Alive) {
            this.battleNotifier.NotifyBattleEnd(this.HasEscaped);
            this.Player.GainXP(this.GainedXP, this.playerStatusNotifier);
            this.Player.GainGold(this.GainedGold, this.playerStatusNotifier);
        } else {
            this.playerStatusNotifier.NotifyPlayerDeath();
            this.gameStatusNotifier.NotifyGameEnd();
        }
    }
    


    public void OneTurn() {

        this.battleNotifier.NotifyNewTurn(this.BattleAllies, this.BattleEnemies);
        int userBattleChoice = this.getter.getUserBattleChoice();
        this.SetMoveOrder();

        foreach (ICharacter participant in this.moveOrder) {
            
            BattleChoices turnAction = participant.CharacterType == CharacterType.Player ? (BattleChoices)userBattleChoice : BattleChoices.Attack;
            
            if (turnAction == BattleChoices.Attack) {
                this.AttackEvent(participant);
            } else if (turnAction == BattleChoices.Item) {
                this.ItemUseEvent();
            } else if (turnAction == BattleChoices.Run) {
                this.EscapeEvent();
            }

            if (!this.IsBattle) {break;}
        }
    }


    public void SetMoveOrder() {
        this.moveOrder = this.BattleAllies.Concat(this.BattleEnemies).OrderByDescending(x => x.SPD).ThenBy(x => x.CharacterType);
    }


    public void AttackEvent(ICharacter attacker) {

        dynamic target = this.Player;

        if (attacker.CharacterType == CharacterType.Player) {
            int userTarget = this.getter.getUserTarget(this.BattleEnemies);
            target = this.BattleEnemies[userTarget];
        }
        

        int attackerDamage = attacker.Attack(target);
        target.TakeHit(attackerDamage);
        this.battleNotifier.NotifyAttackDamage(attacker.Name, attackerDamage.ToString());

        if (target.Status == CharacterStatus.Dead) {
            if (target.CharacterType == CharacterType.Player) {
                this.IsBattle = false;
            } else if (target.CharacterType == CharacterType.Enemy) {
                this.battleNotifier.NotifiyEnemyDefeat(target.Name);
                this.BattleEnemies.Remove(target);
                this.GainedXP += target.GivableXP;
                this.GainedGold += target.GivableGold;
                this.IsBattle = this.BattleEnemies.Count == 0 ? false : true;
            }
        }
    }


    public void ItemUseEvent() {
        
        int userItem = this.getter.getUserItem(this.Player);
        var itemToUse = this.Player.Inventory[userItem];

        this.playerStatusNotifier.NotifyItemUse(itemToUse.Name);

        itemToUse.UseItem(this.settings, this.Player, this.playerStatusNotifier);
        this.Player.RemoveItem(itemToUse);
    }


    public void EscapeEvent() {
        
        var rnd = new Random();
        double escapeProb = rnd.NextDouble();
                
        if (escapeProb >= 0.5) {
            this.IsBattle = false;
            this.HasEscaped = true;
        } else {
            this.battleNotifier.NotifyEscapeFail();
        }
    }
}