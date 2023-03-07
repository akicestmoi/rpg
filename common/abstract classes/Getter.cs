public abstract class Getter {

    public Poster poster {get; set;}

    public Getter(Poster poster) {
        this.poster = poster;
    }

    /* Battle */
    public virtual int getUserBattleChoice(List<BattleChoices> availableChoices) {return 0;}
    public virtual int getUserTarget(List<IEnemy> enemies) {return 0;}
    public virtual int getUserItem(IPlayer player) {return 0;}
}