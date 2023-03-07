public interface ICharacter {
    public string Name {get; set;}
    public CharacterType CharacterType {get; set;}
    public CharacterStatus Status {get; set;}
    public int MaxHP {get; set;}
    public int HP {get; set;}
    public int ATK {get; set;}
    public int DEF {get; set;}
    public int SPD {get; set;}

    public int Attack(ICharacter opponent);
    public void TakeHit(int damage);
    public void Heal(ICharacter character, int healingAmount);
}