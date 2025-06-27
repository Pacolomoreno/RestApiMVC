namespace RestApiMVC.View;

public class UserInput
{
    /// <summary>
    /// Prompts with message and options for console user input 
    /// </summary>
    /// <param name="message">Message to show</param>
    /// <param name="choices">Options delimited by ',' where first char should be different Ex.: "Ignore,Retry,Cancel"</param>
    /// <returns>The first char of the selected option </returns>
    public static char userChooseByInitial(string message, string choices)
    {
        Console.Write(message + "  ");
        if (choices == "") return ' ';
        List<string> options = choices.Split(',').ToList();
        List<char> optionKeys = new List<char>();
        foreach (string option in options)
        {
            char key = (char)option[0];
            optionKeys.Add(key);
            Console.Write($"[{key}] {option}   ");
        }
        char keyPressed = ' ';
        while (!optionKeys.Contains(keyPressed))
        {
            keyPressed = Console.ReadKey(intercept: true).KeyChar;
        }
        return keyPressed;
    }


    /// <summary>
    /// Prompts with message and options for console user Y/N input 
    /// </summary>
    /// <param name="message">Question message to confirm or deny </param>
    /// <returns>true if yes answered and false if no answered </returns>
    public static bool userChooseYN(string message)
    {
        Console.Write("\n" + message + "  [y] yes    [n] no  ");
        List<char> optionKeys = ['y', 'n'];
        char keyPressed = ' ';
        while (!optionKeys.Contains(keyPressed))
        {
            keyPressed = Console.ReadKey(intercept: true).KeyChar;
        }
        return (keyPressed == 'y');
    }



}