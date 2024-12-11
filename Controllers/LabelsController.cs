using AmetekLabelAPI.Models;
using AmetekLabelAPI.Resources;
using AmetekLabelAPI.Resources.Configurations;
using AmetekLabelAPI.Resources.Exceptions;
using AmetekLabelAPI.Resources.Factories;
using AmetekLabelAPI.Resources.Logging;
using AmetekLabelAPI.Resources.Templates;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmetekLabelAPI.Controllers
{
    /// <summary>
    /// Controller object for all Label endpoints.
    /// </summary>
    //[Route("ametekapi/[controller]/")]
    [Authorize]
    [ApiController]
    public class LabelsController : Controller
    {
        #region Declarations
        private readonly ILoggingBroker _logger;
        private readonly IConfiguration _configuration;
        private readonly ILabelFactory _labelFactory;
        private readonly ITemplateFactory _templateFactory;
        #endregion Declarations
        #region Properties

        #endregion Properties
        #region Constructors
        /// <summary>
        /// Default constructor with injection dependency
        /// </summary>
        /// <param name="Logger">Logging object</param>
        /// <param name="Configuration">Configuration object</param>
        /// <param name="LabelFactory">Label Factory object</param>
        /// <param name="templateFactory">Template Factory object</param>
        public LabelsController(ILoggingBroker Logger, IConfiguration Configuration, ILabelFactory LabelFactory, ITemplateFactory templateFactory)
        {
            _logger = Logger;
            _configuration = Configuration;
            _labelFactory = LabelFactory;
            _templateFactory = templateFactory;
        }
        #endregion Constructors
        #region Public Methods

        /// <summary>
        /// This gets the data for a ViPAK label
        /// </summary>
        /// <param name="TemplateNameForSQL"></param>        
        /// <returns></returns>
        [HttpGet("/ametekapi/labels/{TemplateNameForSQL}", Name = "GetViPAKLabelData")]
        public ValueTask<List<SchedViPAKModel>> GetViPAKLabelData(string TemplateNameForSQL = "C:\\LableTemplates\\ViPAKLabels.tmplt")
        {

            string templateName = ValidTemplateFilePath(TemplateNameForSQL.BlockSQLInjection());

            string sqlScript = _templateFactory.GetSQLScript(templateName);

            return _labelFactory.GetViPAKLabelDataAsync(sqlScript);
        }

        /// <summary>
        /// This method inserts the provided data into a LabelTemplate object
        /// </summary>
        /// <param name="dataToInsert">list of selected data objects to be inserted into the template</param>
        /// <param name="templateName">Name and full path of template for data to be inserted</param>
        /// <returns></returns>
        [HttpPost("/ametekapi/labels/{templateName}")]
        public async Task<List<LabelTemplate>> InsertDataForPrintAsync([FromBody] SelectedData[] dataToInsert, string templateName)
        {

            return await _labelFactory.InsertDataForPrintAsync(dataToInsert.ToList<SelectedData>(), templateName.BlockSQLInjection());
        }

        #endregion Public Methods
        #region Private Methods

        /// <summary>
        /// This helper method returns a fully qualified file path when application is correctly configured and input is a valid (File Name)/(Path+FileName)
        /// </summary>
        /// <param name="fileName">a string that contains at leas a valid File Name</param>
        /// <returns>Fully qualified file path and name</returns>
        /// <exception cref="BadFilePathException">This is thrown when there is an unexpected string input.</exception>
        private string ValidTemplateFilePath(string fileName)
        {
            try
            {
                fileName.BlockSQLInjection();
                string? configuredFilePath = string.Empty;
                string? extension = string.Empty;
                LocalConfigurations? localConfigurations = _configuration.Get<LocalConfigurations>();
                if (localConfigurations != null)
                {
                    configuredFilePath = localConfigurations.templateFilePath.DefaultPath;
                    extension = localConfigurations.templateFilePath.DefaultExtension;
                }
                if (string.IsNullOrEmpty(extension))
                {
                    extension = ".";
                }



                if ((fileName.Contains(":\\") && fileName.Contains(extension)) && !string.IsNullOrEmpty(configuredFilePath))
                {
                    if (!System.IO.File.Exists(fileName) && !fileName.StartsWith(configuredFilePath))
                    {
                        fileName = Path.Combine(configuredFilePath, fileName.Substring(fileName.LastIndexOf("\\") + 1));
                    }
                }
                else if (fileName.Contains(":\\") && !fileName.Contains(extension) && fileName.LastIndexOf("\\") != fileName.Length)
                {
                    fileName += extension;
                }
                else if (!fileName.Contains(":\\") && !fileName.Contains("\\") && fileName.Contains(extension) && !string.IsNullOrEmpty(configuredFilePath))
                {
                    fileName = Path.Combine(configuredFilePath, fileName);
                }
                else if (!(fileName.Contains(":\\") && fileName.Contains(extension)) && !string.IsNullOrEmpty(configuredFilePath))
                {
                    fileName = Path.Combine(configuredFilePath, fileName, extension);
                }


            }
            catch
            {
                throw new BadFilePathException($"The file: {fileName} was not found");
            }

            return fileName;
        }
        #endregion Private Methods
    }
}
