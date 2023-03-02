public interface IPlayer {

    public int XP {get;}
    public int Level {get;}

    public void GainXP(int xp, IPlayerStatusNotifier playerStatusNotifier);
    public void LevelUp(IPlayerStatusNotifier playerStatusNotifier);
}