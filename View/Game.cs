namespace RestApiMVC.View;

public static class Game
{
    public static void ShowInstuctions(string instructionsTxtFile)
    {
        do
        {
            CardTable.Clean();
            try
            {
                // Check if the file exists
                if (!File.Exists(instructionsTxtFile))
                {
                    Console.WriteLine("Instructions file not found.");
                }

                // Read all text from the file and display it
                string instructions = File.ReadAllText(instructionsTxtFile);
                Console.WriteLine(instructions);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading instructions: {ex.Message}");
            }
        } while (!UserInput.userChooseYN("Should we start ?\n"));
    }
}