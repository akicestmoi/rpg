public interface IPlayer: ICharacter {

    public int XP {get;}
    public int Level {get;}

    public void GainXP(int xp, Notifier playerStatusNotifier);
    public void LevelUp(Notifier playerStatusNotifier);
}