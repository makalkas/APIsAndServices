namespace AmetekLabelAPI.Resources.Exceptions
{
    /// <summary>
    /// Custom exception that is thrown if the connection string is Null or empty.
    /// </summary>
    public class NullOrEmptyConnectionStringException : Exception
    {
        /// <summary>
        /// Null or empty connection string exception.
        /// </summary>
        public NullOrEmptyConnectionStringException()
            : base("The Connection string was null or empty.") { }

        /// <summary>
        /// Null or empty connection string exception.
        /// </summary>
        /// <param name="message">String indicating issue that caused exception</param>
        public NullOrEmptyConnectionStringException(string message) : base(message) { }

        /// <summary>
        /// Null or empty connection string exception.
        /// </summary>
        /// <param name="message">String indicating issue that caused exception</param>
        /// <param name="innerException">More specific exception with additional information on issue that caused exception.</param>
        public NullOrEmptyConnectionStringException(string message, Exception innerException) : base(message, innerException) { }
    }
}
