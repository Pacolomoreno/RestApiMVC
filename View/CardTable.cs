namespace RestApiMVC.View;

public static class CardTable
{
    public static void Clean() { Console.Clear(); }
    public static void Banner(string bannerText)
    {
        string BigBanner = string.Join(" ", bannerText.ToCharArray());
        Console.WriteLine("###############################################");
        Console.WriteLine($"            {BigBanner}");
        Console.WriteLine("###############################################");
    }


    public static void ShowWallet(int budget, int bet)
    {
        Console.WriteLine($"             {budget} $      Bet {bet} $");
    }
}