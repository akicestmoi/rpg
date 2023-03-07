public interface IEnemy: ICharacter {
    public int ID {get; set;}
    public int LevelThreshold {get; set;}
    public int GivableXP {get; set;}
    public int GivableGold {get; set;}
    public int SimultaneousApperance {get; set;}
}