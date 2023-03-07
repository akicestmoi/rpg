using System.ComponentModel;

public enum BattleChoices {
    [Description("Attack Target")]
    Attack = 0,
    [Description("Use Item")]
    Item = 1,
    [Description("Run Away")]
    Run = 2
}


public static class BattleChoicesExtensions
{
    public static string ToDescriptionString(this BattleChoices val)
    {
        DescriptionAttribute[] attributes = (DescriptionAttribute[])val
           .GetType()
           .GetField(val.ToString())
           .GetCustomAttributes(typeof(DescriptionAttribute), false);
        return attributes.Length > 0 ? attributes[0].Description : string.Empty;
    }
} 