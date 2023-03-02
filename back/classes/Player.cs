public class Player: Character, ICharacter, IPlayer {

    public int XP {get; private set;}
    public int Level {get; private set;}
    
    
    private static Dictionary<int, int> LevelUpTable = Enumerable.Range(0, 99).ToDictionary(x => x, x => (int)Math.Pow(x,2) + 10*x);


    public Player(string playerName) {

        this.Name = playerName;
        Status = CharacterStatus.Alive;

        Level = 1;
        XP = 0;

        Random rnd = new Random();
        this.MaxHP = rnd.Next(10, 30);
        this.HP = this.MaxHP;
        this.ATK = rnd.Next(1, 5);
        this.DEF = rnd.Next(1, 5);
        this.SPD = rnd.Next(1, 5);
    }

    public void GainXP(int xp, Notifier playerStatusNotifier) {
                
        int xpNeeded = LevelUpTable[Level];

        playerStatusNotifier.NotifyXPGain(xp);
        XP += xp;

        if (XP >= xpNeeded ) {
            this.LevelUp(playerStatusNotifier);
        }
    }


    public void LevelUp(Notifier playerStatusNotifier) {

        Random rnd = new Random();

        this.Level ++;
        this.MaxHP += rnd.Next(3, 15);
        this.HP = this.MaxHP;
        this.ATK += rnd.Next(1, 3);
        this.DEF += rnd.Next(1, 3);
        this.SPD += rnd.Next(1, 3);

        playerStatusNotifier.NotifyLevelUp(this.Level, this.MaxHP, this.ATK, this.DEF, this.SPD);
    }
}