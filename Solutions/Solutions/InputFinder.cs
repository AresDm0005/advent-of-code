namespace Solutions;

public static class InputFinder
{
    public static readonly string InputFolder = "Inputs";

    public static string GetInputPath(string fileName) =>
        Path.Combine(InputFolder, fileName);
}
