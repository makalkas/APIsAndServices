using AmetekLabelAPI.Resources.Logging;
using AmetekLabelAPI.Resources.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmetekLabelAPI.Controllers
{
    /// <summary>
    /// Service endpoint class for file operations.
    /// </summary>
    //[Route("ametekapi/fileoperations/")]
    [Authorize]
    [ApiController]
    public class FileOperationsController : Controller
    {
        #region Enums

        #endregion Enums
        #region Declarations
        private readonly ILoggingBroker _logger;
        private readonly IConfiguration _configuration;
        private readonly IFileService _fileService;
        #endregion Declarations
        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="configuration"></param>
        /// <param name="fileService"></param>
        public FileOperationsController(ILoggingBroker logger, IConfiguration configuration, IFileService fileService)
        {
            _logger = logger;
            _configuration = configuration;
            _fileService = fileService;
        }
        #endregion Constructors
        #region Properties

        #endregion Properties
        #region Public Endpoints
        /// <summary>
        /// Gets the names of all available label templates in directory
        /// </summary>
        /// <returns>List of template file names</returns>
        [HttpGet("ametekapi/fileoperations/{filePath}", Name = "GetLableTemplateNames")]
        public async ValueTask<List<string>> GetLableTemplateNames(string filePath)
        {
            //Todo: remove the need for the file path. this should be set up in the configuration.

            return await _fileService.GetLabelTemplateFileNames(filePath);

        }

        /// <summary>
        /// (Delete) This method deletes a file. 
        /// </summary>
        /// <param name="fullpath">Windows folder path to file to be deleted</param>
        /// <param name="name">Exact name of file to be deleted.</param>
        /// <returns></returns>
        [HttpDelete("ametekapi/fileoperations/{fullpath}/{name}")]
        public bool DeleteTemplate(string fullpath, string name)
        {

            return _fileService.DeleteTemplate(fullpath, name);
        }


        /// <summary>
        /// This method renames a file or moves it to a new directory.
        /// </summary>
        /// <param name="CurrentFileName">The current file name including the full path.</param>
        /// <param name="NewFileName">The new file name with the current full file path.</param>
        /// <returns>Boolean value of true if operation was successful.</returns>
        [HttpPost("ametekapi/fileoperations/{CurrentFileName}/{NewFileName}")]
        public bool UpdateTemplateName(string CurrentFileName, string NewFileName)
        {
            return _fileService.UpdateTemplateName(CurrentFileName, NewFileName);

        }
        #endregion Public Endpoints
        #region Private Methods

        #endregion Private Methods


    }
}
