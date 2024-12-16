public class LogginBroker
{
    public void LogInfo(string message)
    {
        System.Console.WriteLine($"INFO:{message}");
    }

    public void LogWarning(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"WARNING: {message}");
        Console.ResetColor();
    }

    public void LogError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine($"ERROR: {message}");
        Console.ResetColor();
    }

    public void LogException(Exception exception)
    {
        System.Console.WriteLine($"EXCEPTION: {exception}");
    }
}