namespace Web.Tests.Poc.Utilities;
public static  class TestParameter
{
    public static string Username => EnvironmentVariablesReader.GetEnvironmentVariable("TEST_USERNAME");
    public static string Password => EnvironmentVariablesReader.GetEnvironmentVariable("TEST_PASSWORD");
    public static string IncorrectUsername => EnvironmentVariablesReader.GetEnvironmentVariable("INCORRECT_USERNAME");
    public static string IncorrectPassword => EnvironmentVariablesReader.GetEnvironmentVariable("INCORRECT_PASSWORD");
}