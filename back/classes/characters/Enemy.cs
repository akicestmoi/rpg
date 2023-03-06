public class Enemy: Character, ICharacter, IEnemy{

    public int ID {get; set;}
    public int LevelThreshold {get; set;}
    public int GivableXP {get; set;}
    public int GivableGold {get; set;}


    public void setStatus() {
        this.CharacterType = CharacterType.Enemy;
        this.Status = CharacterStatus.Alive;
        this.MaxHP = this.HP;
    }
}