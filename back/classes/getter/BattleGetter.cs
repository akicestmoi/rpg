public class BattleGetter: Getter {

    public BattleGetter(Poster poster) : base(poster) {
        this.poster = poster;
    }

    public override int getUserBattleChoice(List<BattleChoices> availableChoices) {
        int userInput = this.poster.onUserBattleChoiceRequest(availableChoices);
        return userInput;
    }

    public override int getUserTarget(List<IEnemy> enemies) {
        /* Need input potentialTargetList */
        int userInput = this.poster.onUserTargetRequest(enemies);
        return userInput;
    }

    public override int getUserItem(IPlayer player) {
        int userInput = this.poster.onUserItemRequest(player);
        return userInput;
    }

}