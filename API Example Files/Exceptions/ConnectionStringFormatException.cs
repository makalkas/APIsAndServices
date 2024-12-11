namespace AmetekLabelAPI.Resources.Exceptions
{
    /// <summary>
    /// Custom exception
    /// </summary>
    public class ConnectionStringFormatException : Exception
    {
        /// <summary>
        /// Exception thrown if key parameters like "Data Source", "Catalog", or "Security" are missing.
        /// </summary>
        public ConnectionStringFormatException()
            : base("The SQL Connection string is missing necessary parameters.") { }

        /// <summary>
        /// Constructor that accepts a message.
        /// </summary>
        /// <param name="message">String information for exception.</param>
        public ConnectionStringFormatException(string message) : base(message) { }

        /// <summary>
        /// Constructor that accepts a message and an inner exception object.
        /// </summary>
        /// <param name="message">String information for exception.</param>
        /// <param name="innerException">Exception Object for more detailed information</param>
        public ConnectionStringFormatException(string message, Exception innerException) : base(message, innerException) { }

    }
}
