namespace AmetekLabelAPI.Resources.Exceptions
{
    /// <summary>
    /// Main File access exception class
    /// </summary>
    public class FileAccessException : Exception
    {
        /// <summary>
        /// This exception is thrown when the file path doesn't exist, no files are present at the location or the file is not in the proper format.
        /// </summary>
        /// <param name="message"></param>
        public FileAccessException(string message) : base(message) { }

        /// <summary>
        /// This exception is thrown when the file path doesn't exist, no files are present at the location or the file is not in the proper format.
        /// </summary>
        /// <param name="innerException">Exception specific to the error</param>
        public FileAccessException(Exception innerException)
            : base("File Access error occurred, please try again.", innerException) { }

        /// <summary>
        /// Constructor that accepts a message and an inner exception object.
        /// </summary>
        /// <param name="message">String message information on the exception</param>
        /// <param name="innerException">Exception object that contains more information on exception</param>
        public FileAccessException(string message, Exception innerException) : base(message, innerException) { }
    }
}
