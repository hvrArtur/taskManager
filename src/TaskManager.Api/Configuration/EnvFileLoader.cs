namespace TaskManager.Api.Configuration;

public static class EnvFileLoader
{
    public static void LoadFromCurrentDirectoryTree(string fileName = ".env", int maxDepth = 6)
    {
        var directory = new DirectoryInfo(AppContext.BaseDirectory);

        for (var depth = 0; directory is not null && depth <= maxDepth; depth++)
        {
            var candidatePath = Path.Combine(directory.FullName, fileName);
            if (TryLoad(candidatePath))
                return;

            directory = directory.Parent;
        }
    }

    public static void Load(params string[] candidatePaths)
    {
        foreach (var path in candidatePaths)
        {
            if (TryLoad(path))
                return;
        }
    }

    private static bool TryLoad(string path)
    {
        if (!File.Exists(path))
            return false;

        var loadedVariablesCount = 0;

        foreach (var rawLine in File.ReadAllLines(path))
        {
            var line = rawLine.Trim();

            if (string.IsNullOrWhiteSpace(line) || line.StartsWith('#'))
                continue;

            var separatorIndex = line.IndexOf('=');
            if (separatorIndex <= 0)
                continue;

            var key = line[..separatorIndex].Trim();
            var value = line[(separatorIndex + 1)..].Trim().Trim('"');

            if (string.IsNullOrWhiteSpace(key))
                continue;

            Environment.SetEnvironmentVariable(key, value);
            loadedVariablesCount++;
        }

        return loadedVariablesCount > 0;
    }
}
