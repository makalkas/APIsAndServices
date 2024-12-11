namespace AmetekLabelAPI.Resources.Exceptions
{
    /// <summary>
    /// Custom Connection string exception.
    /// </summary>
    public class ConnectionStringException : Exception
    {
        /// <summary>
        /// General Connection string exception.
        /// </summary> 
        /// <param name="message">string indicating what the error was.</param>
        public ConnectionStringException(string message) : base(message) { }
        /// <summary>
        /// General Connection string exception.
        /// </summary>
        /// <param name="innerException">Exception that contains more information on exception details.</param>
        public ConnectionStringException(Exception innerException)
            : base("A Connection string error occured. Please see the inner exception for more details.", innerException) { }

        /// <summary>
        /// General Connection string exception.
        /// </summary>
        /// <param name="message">string indicating what the error was.</param>
        /// <param name="innerException">Exception that contains more information on exception details.</param>
        public ConnectionStringException(string message, Exception innerException) : base(message, innerException) { }

    }
}
