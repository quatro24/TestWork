using System.Configuration;

namespace TestApplication.Common
{
    public static class ConfigurationProvider
    {
        public static string GetDictionaryPath()
        {
            return ConfigurationManager.AppSettings["DictionaryPath"];
        }

        public static string GetInputFilePath()
        {
            return ConfigurationManager.AppSettings["InputFilePath"];
        }

        public static string GetOutputPath()
        {
            return ConfigurationManager.AppSettings["OutputFilePath"];
        }
    }
}
