namespace AmetekLabelAPI.Resources.Exceptions
{
    /// <summary>
    /// Custom Exception for File path operations.
    /// </summary>
    [Serializable]
    public class BadFilePathException : Exception
    {
        /// <summary>
        /// File path exception that is thrown if file path is incorrect of doesn't exist.
        /// </summary>
        public BadFilePathException()
            : base("The file path provided does not exist or there are no Template files at that location.") { }

        /// <summary>
        /// File path exception that is thrown if file path is incorrect of doesn't exist. Accepts a message input parameter
        /// </summary>
        /// <param name="message">string with message to be displayed in exception</param>
        public BadFilePathException(string message) : base(message) { }

        /// <summary>
        /// File path exception that is thrown if file path is incorrect of doesn't exist. Accepts a message input parameter and inner exception object
        /// </summary>
        /// <param name="message">string with message to be displayed in exception</param>
        /// <param name="innerException">Inner Exception object to be included with this exception</param>
        public BadFilePathException(string message, Exception innerException) : base(message, innerException) { }
    }
}
