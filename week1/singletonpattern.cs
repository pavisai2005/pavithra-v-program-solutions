using System;

public sealed class Logger
{
    // Private static variable to hold the single instance
    private static readonly Lazy<Logger> instance = new Lazy<Logger>(() => new Logger());

    // Private constructor to prevent external instantiation
    private Logger()
    {
        Console.WriteLine("Logger Initialized.");
    }

    // Public static method to provide global access point
    public static Logger Instance
    {
        get
        {
            return instance.Value;
        }
    }

    // Sample method
    public void Log(string message)
    {
        Console.WriteLine($"Log: {message}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Logger logger1 = Logger.Instance;
        Logger logger2 = Logger.Instance;

        logger1.Log("Singleton pattern in C#");

        if (logger1 == logger2)
        {
            Console.WriteLine("Both logger instances are the same.");
        }
        else
        {
            Console.WriteLine("Logger instances are different.");
        }
    }
}