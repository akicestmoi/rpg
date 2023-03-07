public class BattlePoster: Poster {

    public override int onUserBattleChoiceRequest(List<BattleChoices> availableChoices) {

        Console.WriteLine(Environment.NewLine + "Choose your action for this turn:");
        
        foreach (var choice in availableChoices.Select((value, index) => (value, index))) {
            Console.WriteLine($"{choice.index + 1}. {choice.value.ToDescriptionString()}");
        }

        int userInput = this.InputChecker(availableChoices.Count) - 1;

        return userInput;
    }


    public override int onUserTargetRequest(List<IEnemy> enemies) {
        
        Console.WriteLine(Environment.NewLine + "Choose your target:");

        foreach (var enemy in enemies.Select((value, index) => (value, index))) {
            Console.WriteLine($"{enemy.index + 1}. {enemy.value.Name}");
        }

        int userInput = this.InputChecker(enemies.Count) - 1;

        return userInput;
    }


    public override int onUserItemRequest(IPlayer player) {

        Console.WriteLine(Environment.NewLine + "Choose the item you want to use:");

        foreach (var availableItem in player.Inventory.Select((value, index) => (value, index))) {
            Console.WriteLine($"{availableItem.index + 1}. {availableItem.value.Name}");
        }

        int userInput = this.InputChecker(player.Inventory.Count) - 1;

        return userInput;
    }

}