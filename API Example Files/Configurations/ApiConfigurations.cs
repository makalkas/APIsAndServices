// -------------------------------------------------------------------------------
// Copyright ©Ametek 2023 
// For company use only. Author: Michael Kalkas
// -------------------------------------------------------------------------------

namespace AmetekLabelAPI.Resources.Configurations
{
    /// <summary>
    /// Class for getting the application API configuration Information from the appsettings.json file.
    /// </summary>
    public class ApiConfigurations
    {
        /// <summary>
        /// Blank constructor
        /// </summary>
        public ApiConfigurations() { }

        /// <summary>
        /// Constructor that takes in a URL
        /// </summary>
        /// <param name="url">API Url</param>
        public ApiConfigurations(string url)
        {
            this.Url = url;
        }

        /// <summary>
        /// Main Web service URL.
        /// </summary>
        public string Url { get; set; } = string.Empty;
    }
}
