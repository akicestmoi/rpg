public class Settings {
    public Dictionary<string, string>? JsonLocation {get;}

    public Settings() {

        string rootPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\"));
        string filePath = rootPath + @"common\data\";

        JsonLocation = new Dictionary<string, string>();
        JsonLocation.Add("EnemyList", filePath + "Enemies.json");
        JsonLocation.Add("EventList", filePath + "Events.json");
    }

}