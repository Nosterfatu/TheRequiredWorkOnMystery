using System.Collections.Generic;

namespace Source
{
    // Hardcode data for Levels
    public static class LevelsDict
    {
        public static List<string> Levels { get; } = new()
        {
            "a|c|n\nc|d|n\na| |d",
            "a|c|n\nc|d|n\nw|d|a\nr|w|r",
            "a|c|n|d\nc|d|n|r\na|r|d|d",
            "a|c|n|d\nc|d|n|s\na|r|t|d\ns|r|t|d",
        };
    }
}