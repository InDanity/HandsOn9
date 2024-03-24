
using System;
using System.Collections.Generic;
using System.Xml.Serialization;


public class ConsoleLogger
{
    static ConsoleLogger instance;

    protected ConsoleLogger()
    {
    }

    public static ConsoleLogger GetInstance()
    {
        if (instance == null)
        {
            instance = new ConsoleLogger();
        }
        return instance;
    }

    public void Log(String report, String message)
    {
        String reportUC = report.ToUpper();
        switch (reportUC)
        {
            case "ERROR":
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {message}");
            Console.ResetColor();
            Environment.Exit(0);
            break;

            case "WARNING":
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Warning: {message}");
            Console.ResetColor();
            break;

            case "COMMENT":
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Comment: {message}");
            Console.ResetColor();
            break;

        }
    }
}

public class HelloWorld
{
    public static void Main(string[] args)
    {
        ConsoleLogger cLogA = ConsoleLogger.GetInstance();
        ConsoleLogger cLogB = ConsoleLogger.GetInstance();

        if(cLogA == cLogB){
            Console.WriteLine("Same instance.");
        }

        cLogA.Log("Comment", "This is a comment.");
        cLogA.Log("Warning", "This is a warning.");
        cLogA.Log("Error", "Whoa, an error.");
        Console.ReadKey();
        
    }
}