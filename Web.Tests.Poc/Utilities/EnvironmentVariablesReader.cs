namespace Web.Tests.Poc.Utilities;
public class EnvironmentVariablesReader
{
    public static string GetEnvironmentVariable(string variable)
    {
        var data = Environment.GetEnvironmentVariable(variable,EnvironmentVariableTarget.User);
        
        return data ?? throw new InvalidOperationException("The variable was not found");
    }
}