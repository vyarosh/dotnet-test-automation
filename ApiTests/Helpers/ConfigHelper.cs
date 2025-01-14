using Newtonsoft.Json.Linq;

namespace ApiTests.Helpers;

/// <summary>
/// Encapsulates configuration initialization and serves as parameters collection
/// </summary>
public static class ConfigHelper
{
    private const string CONFIG_FILE_PATH = "config.json";
        
    /// <summary>
    /// Retrieves a configuration value by key from a JSON file.
    /// </summary>
    /// TODO: change type to enum to avoid typos
    /// <param name="key">The key of the configuration setting.</param>
    /// <returns>The configuration value as a string.</returns>
    public static string ReadConfigFile(string key)
    {
        var json = File.ReadAllText(CONFIG_FILE_PATH);
        var settings = JObject.Parse(json);
        //TODO: implement null check with proper message 
        return settings[key]?.ToString();
    }
}