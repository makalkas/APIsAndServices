namespace AmetekLabelAPI.Resources.Configurations
{
    /// <summary>
    /// Class for getting Application configuration data.
    /// </summary>
    public class ConnectionStrings
    {
        /// <summary>
        /// Blank constructor
        /// </summary>
        public ConnectionStrings() { }

        /// <summary>
        /// constructor that takes in a default connection string
        /// </summary>
        /// <param name="_default"></param>
        public ConnectionStrings(string _default)
        {
            this.Default = _default;
        }
        /// <summary>
        /// Default connection string value
        /// </summary>
        public string Default { get; set; } = string.Empty;
    }
}
