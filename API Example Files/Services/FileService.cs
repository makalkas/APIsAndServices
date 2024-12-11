using AmetekLabelAPI.Resources.Logging;

namespace AmetekLabelAPI.Resources.Services
{
    /// <summary>
    /// Class for obtaining Template File information
    /// </summary>
    public partial class FileService : IFileService
    {

        #region Enums

        #endregion Enums
        #region Declarations
        private readonly ILoggingBroker _logger;
        #endregion Declarations
        #region Constructors
        /// <summary>
        /// Default constructor that requires ILogger injection.
        /// </summary>
        /// <param name="logger">ILogger Object for logging application information</param>
        public FileService(ILoggingBroker logger)
        {
            _logger = logger;
        }
        #endregion Constructors
        #region Properties

        #endregion Properties
        #region Public Methods
        /// <summary>
        /// This gets the template file names and extracts out the try-catch using a try-catch method and deligate.
        /// </summary>
        /// <param name="filepath">Path to template files.</param>
        /// <returns></returns>
        public async ValueTask<List<string>> GetLabelTemplateFileNames(string filepath)
        {
            //await CheckFilePath(filepath);


            return await Task.Run(() =>
            GetAllTemplateFilePathsAndNames(filepath));
        }

        /// <summary>
        /// (Delete) This method deletes a file. 
        /// </summary>
        /// <param name="fullpath">Windows folder path to file to be deleted</param>
        /// <param name="name">Exact name of file to be deleted.</param>
        /// <returns></returns>

        public bool DeleteTemplate(string fullpath, string name)
        {

            string fileToDelete = Path.Combine(fullpath, name);
            CheckFilePath(fileToDelete);

            System.IO.File.Delete(fileToDelete);
            return true;

        }

        /// <summary>
        /// This method renames a file or moves it to a new directory.
        /// </summary>
        /// <param name="CurrentFileName">The current file name including the full path.</param>
        /// <param name="NewFileName">The new file name with the current full file path.</param>
        /// <returns>Boolean value of true if operation was successful.</returns>

        public bool UpdateTemplateName(string CurrentFileName, string NewFileName)
        {
            CheckFilePath(CurrentFileName);


            System.IO.File.Move(CurrentFileName, NewFileName);
            return true;

        }
        #endregion Public Methods
        #region Private Methods
        private ValueTask<bool> CheckFilePath(string filepath) =>
        TryCatch(() =>
        {
            bool result = false;
            if (ValidateFilePath(filepath) == true)
            {
                result = true;

            }

            return ValueTask.FromResult(result);
        });

        private List<string> GetAllTemplateFilePathsAndNames(string filepath)
        {
            List<string> filenames = new List<string>();
            if (CheckFilePath(filepath).Result)
            {
                DirectoryInfo dir = new DirectoryInfo(filepath);
                FileInfo[] files = dir.GetFiles("*.tmplt");

                foreach (FileInfo file in files)
                {
                    filenames.Add(file.FullName);
                }

                return filenames;
            };
            return filenames;
        }
        #endregion Private Methods
    }
}
