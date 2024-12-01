namespace AoC2024;

public class InputHelper
{
    public static async Task<string> GetInput(string name)
    {
        var filePath = Path.Combine(AppContext.BaseDirectory, "Inputs", name);
        return await File.ReadAllTextAsync(filePath);
    }
}
