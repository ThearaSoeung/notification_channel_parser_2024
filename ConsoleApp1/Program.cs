using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    private static readonly string[] ValidChannels = { "BE", "FE", "QA", "Urgent" };
    private static readonly Regex TagRegex = new Regex(@"\[(.*?)\]", RegexOptions.Compiled);

    private static void Main(string[] args)
    {
        const string message = "[BE][QA][HAHA][Urgent] there is error";
        HashSet<string> parsedChannels = ParseNotificationChannels(message);
        Console.WriteLine(string.Join(", ", parsedChannels));
    }

    private static HashSet<string> ParseNotificationChannels(string message)
    {
        var channels = new HashSet<string>();

        foreach (Match match in TagRegex.Matches(message))
        {
            string tag = match.Groups[1].Value;
            if (Array.Exists(ValidChannels, channel => channel == tag))
            {
                channels.Add(tag);
            }
        }

        return channels;
    }
}