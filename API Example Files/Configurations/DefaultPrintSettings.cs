namespace AmetekLabelAPI.Resources.Configurations
{
    /// <summary>
    /// Settings class that contains default printer settings.
    /// </summary>
    public class DefaultPrintSettings
    {
        /// <summary>
        /// Blank Constructor
        /// </summary>
        public DefaultPrintSettings()
        {

        }

        /// <summary>
        /// Constructor with setting.
        /// </summary>
        /// <param name="_paperSize"></param>
        public DefaultPrintSettings(string _paperSize)
        {
            this.PaperSize = _paperSize;
        }

        /// <summary>
        /// Default paper size from configuration file.
        /// </summary>
        public string PaperSize { get; set; } = string.Empty;
    }
}
