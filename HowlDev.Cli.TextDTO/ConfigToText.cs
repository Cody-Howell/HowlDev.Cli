using HowlDev.IO.Text.ConfigFile;
using HowlDev.IO.Text.ConfigFile.Enums;

namespace HowlDev.Cli.TextDTO;

/// <summary>
/// Provides methods for turning an IBaseConfigOption to a given filetype. 
/// </summary>
public static class ConfigToText {
    /// <summary>
    /// To a standard C# DTO file.
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    public static string ToCSharpFile(TextConfigFile file) {
        if (file.Type != ConfigOptionType.Object) {
            throw new InvalidOperationException("Configuration must be of type Object.");
        }

        string output = "";

        bool ignoreWarnings = file.Contains("ignoreWarnings") && file["ignoreWarnings"].ToBoolean(null);
        if (ignoreWarnings) {
            output += "#pragma warning disable\n";
        }

        if (file.Contains("namespace"))
            output += "namespace " + file["namespace"] + ";\n\n";

        output += "public class " + file["name"] + " {\n";
        foreach (var option in file["properties"].Items) {
            string name = option["name"].ToString()!;
            string type = option["type"].ToString()!;

            string d = "\n";
            if (option.Contains("default")) {
                if (type == "string") {
                    d = '"' + option["default"].ToString() + '"';
                } else {
                    d = option["default"].ToString()!;
                }
                d = $"= {d};\n";
            }

            if (option.Contains("nullable") && option["nullable"].ToBoolean(null)) {
                type += "?";
            }

            output += $"  public {type} {name} {"{ get; set; }"} {d}";

        }
        output += "}\n";
        return output;
    }

    /// <summary>
    /// Returns a JS Type file with full exports. 
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    public static string ToTSFile(TextConfigFile file) {
        if (file.Type != ConfigOptionType.Object) {
            throw new InvalidOperationException("Configuration must be of type Object.");
        }

        return "";
    }

    private static string ConvertCSharpToJS(string val) => switch (val) {
        
    }
}