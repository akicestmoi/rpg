public class Enemy: Character, IEnemy{

    public int ID {get; set;}
    public int GivableXP {get; set;}

    public void setStatus() {
        this.Status = CharacterStatus.Alive;
        this.MaxHP = this.HP;
    }
}