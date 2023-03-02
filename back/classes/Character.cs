public abstract class Character: ICharacter {
    
    public string Name {get; set;}
    public CharacterStatus Status {get; set;}
    public int MaxHP {get; set;}
    public int HP {get; set;}
    public int ATK {get; set;}
    public int DEF {get; set;}
    public int SPD {get; set;}


    public int Attack() {

        double preDamage = Math.Min(ATK * 1.5 - DEF, 1.0);
        int damage = (int)Math.Round(preDamage);

        return damage;
    }


    public void TakeHit(int damage) {
        this.HP = Math.Max(damage, 0);
        if (this.HP == 0) {this.Status = CharacterStatus.Dead;}
    }

}