namespace AmetekLabelAPI.Resources.Configurations
{
    /// <summary>
    /// This is the configuration File path class.
    /// </summary>
    public class TemplateFilePath
    {
        /// <summary>
        /// Constructor for object
        /// </summary>
        public TemplateFilePath() { }

        /// <summary>
        /// Constructor that accepts a default string value.
        /// </summary>
        /// <param name="_default">Default path of files</param>
        public TemplateFilePath(string _default)
        {
            this.DefaultPath = _default;
        }

        /// <summary>
        /// Default path of files property.
        /// </summary>
        public string? DefaultPath { get; set; }

        /// <summary>
        /// Default Template File Extension
        /// </summary>
        public string? DefaultExtension { get; set; }
    }
}
