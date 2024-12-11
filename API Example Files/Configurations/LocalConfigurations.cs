// -------------------------------------------------------------------------------
// Copyright ©Ametek 2023 
// For company use only. Author: Michael Kalkas
// -------------------------------------------------------------------------------

namespace AmetekLabelAPI.Resources.Configurations
{
    /// <summary>
    /// Object for getting all the local settings for the application from the appsettings.json file.
    /// </summary>
    public class LocalConfigurations
    {
        /// <summary>
        /// List of all API configuration settings.
        /// </summary>
        public ApiConfigurations apiConfigurations { get; set; } = new ApiConfigurations(url: @"https://localhost:7272");

        /// <summary>
        /// List of Connection strings
        /// </summary>
        public ConnectionStrings connectionStrings { get; set; } = new ConnectionStrings("C:\\Users\\Michael Kalkas\\Pictures\\OBRIAN AMETEK.jpg");

        /// <summary>
        /// Location where Templates are stored.
        /// </summary>
        public TemplateFilePath templateFilePath { get; set; } = new TemplateFilePath();

        /// <summary>
        /// Contains information about the logo used in labels.
        /// </summary>
        public Logo logo { get; set; } = new Logo();


        /// <summary>
        /// Thermal printer print settings: default
        /// </summary>
        public DefaultPrintSettings? defaultPrintSettings { get; set; } = new DefaultPrintSettings();
    }
}
