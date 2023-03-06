public class BattlePoster: Poster {

    public override int onUserBattleChoiceRequest() {

        Console.WriteLine(Environment.NewLine + "Choose your action for this turn:");
        Console.WriteLine("1. Attack Enemy");
        Console.WriteLine("2. Use Item");
        Console.WriteLine("3. Run away");
        
        int userInput = this.InputChecker(3);

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