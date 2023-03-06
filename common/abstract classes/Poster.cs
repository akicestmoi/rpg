public abstract class Poster {

    public int InputChecker(int numberOfChoices) {
        
        bool notValid = true;
        int userInput = 0;

        while (notValid) {

            try {
                userInput = Convert.ToInt16(Console.ReadLine());
                while (userInput < 1 || userInput > numberOfChoices) {
                    Console.WriteLine($"Please choose from 1 to {numberOfChoices}");
                    userInput = Convert.ToInt16(Console.ReadLine());
                }
                notValid = false;
            }
            catch {
                Console.WriteLine($"Please choose from 1 to {numberOfChoices}");
            }
        }

        return userInput;
    }


    /* Battle */
    public virtual int onUserBattleChoiceRequest() {return 0;}
    public virtual int onUserTargetRequest(List<IEnemy> enemies) {return 0;}
    public virtual int onUserItemRequest(IPlayer player) {return 0;}
}