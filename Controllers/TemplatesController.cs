using AmetekLabelAPI.Models;
using AmetekLabelAPI.Resources.Factories;
using AmetekLabelAPI.Resources.Logging;
using AmetekLabelAPI.Resources.Services;
using AmetekLabelAPI.Resources.Templates;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Versioning;

namespace AmetekLabelAPI.Controllers
{
    /// <summary>
    /// This class controls the update, deletion, modification, and creation of a label template file.
    /// </summary>
    [SupportedOSPlatform("windows")]
    [Route("ametekapi/[controller]")]
    [Authorize]
    [ApiController]
    public class TemplatesController : Controller
    {
        #region Declarations
        private readonly ILoggingBroker _logger;
        private readonly IConfiguration _configuration;
        private readonly ITemplateService _templateService;
        private readonly ILabelFactory _labelFactory;
        #endregion Declarations
        #region Properties
        #endregion Properties
        #region Constructors
        /// <summary>
        /// Default constructor with necessary injected objects.
        /// </summary>
        /// <param name="Logger">Application logger</param>
        /// <param name="Configuration">Application configuration</param>
        /// <param name="TemplateService">Application Template Service</param>
        /// <param name="labelFactory">Factory class for dealing with labels</param>
        public TemplatesController(ILoggingBroker Logger, IConfiguration Configuration, ITemplateService TemplateService, ILabelFactory labelFactory)
        {
            _logger = Logger;
            _configuration = Configuration;
            _templateService = TemplateService;
            _labelFactory = labelFactory;
        }
        #endregion Constructors
        #region Public Methods
        /// <summary>
        /// (Save) This method accepts a label template object and saves it in the correct location as passed in to the fullpath string.
        /// </summary>
        /// <returns>true/fals depending on success or failure of saving process.</returns>
        //[HttpPost(Name = "Save")]
        [HttpPost("labeltemplates/{fullpath}")]
        public bool SaveTemplate(string fullpath, [FromBody] LabelModel lableTemplate)
        {
            try
            {
                if (string.IsNullOrEmpty(fullpath)) { return false; }
                if (!IsValidFullPathAndName(fullpath)) { return false; }

                LabelTemplate template = _labelFactory.ConvertLabelModelToLabelTemplate(lableTemplate);

                template.SaveTemplate(fullpath, template);
            }
            catch
            {
                return false;
            }

            return true;
        }



        /// <summary>
        /// (Get Template) This gets a template by the name and the full path to the template file (*.tmplt).
        /// </summary>
        /// <param name="name">Name of the template file to return</param>
        /// <param name="FullPath">Full path of the folder location of the template file.</param>
        /// <returns>(LabelTemplate)Object representing the Label template XML file</returns>
        [HttpGet("{name}/{FullPath}")]
        public LabelTemplate GetTemplate(string name, string FullPath)
        {
            LabelTemplate labelTemplate;
            try
            {
                labelTemplate = new LabelTemplate(name, FullPath);
                string fullpath;
                if (FullPath.EndsWith('\\'))
                {
                    fullpath = FullPath + name;
                }
                else
                {
                    fullpath = FullPath + '\\' + name;
                }
                labelTemplate = AmetekLabelAPI.Resources.Helpers.TemplateHelper.OpenLabelTemplateFromFile(fullpath);
                labelTemplate.Properties.SQLQuery = string.Empty;
                labelTemplate.Properties.TemplateDirectory = string.Empty;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                labelTemplate = new LabelTemplate();
            }

            return labelTemplate;
        }

        /// <summary>
        /// (Update) This method updates a template.
        /// </summary>
        /// <param name="name">Name of the template file to return</param>
        /// <param name="FullPath">Full path of the folder location of the template file.</param>
        /// <param name="labelTemplate">Object, contains all information for updating a template file.</param>
        /// <returns>(Bool) indicating success or failure.</returns>
        [HttpPatch("{name}/{fullPath}")]
        public bool UpdateTemplate(string name, string FullPath, LabelTemplate labelTemplate)
        {
            LabelTemplate origLabelTemplate = new LabelTemplate(name, FullPath);
            try
            {
                foreach (LabelSection section in labelTemplate.Sections)
                {
                    // ToDo: Compare each section and its corresponding properties object values of the opened object with the input label template object. 
                    //       Where there are diffferences, make changes to the opened object and at the endd save the new template as the new xml file.

                    // Compare the properties objects between the two Label template objects
                    if (labelTemplate.Properties.Template_Name != "-NA-")
                    {
                        origLabelTemplate.Properties.Template_Name = labelTemplate.Properties.Template_Name;
                    }
                    if (labelTemplate.Properties.LabelScale != 0)
                    {
                        origLabelTemplate.Properties.LabelScale = labelTemplate.Properties.LabelScale;
                    }
                    if (labelTemplate.Properties.TemplateDirectory != "-NA-")
                    {
                        origLabelTemplate.Properties.TemplateDirectory = labelTemplate.Properties.TemplateDirectory;
                    }
                    if (labelTemplate.Properties.Template_Description != "-NA-")
                    {
                        origLabelTemplate.Properties.Template_Description = labelTemplate.Properties.Template_Description;
                    }
                    if (labelTemplate.Properties.LinesPerPage != 0)
                    {
                        origLabelTemplate.Properties.LinesPerPage = labelTemplate.Properties.LinesPerPage;
                    }
                    if (labelTemplate.Properties.LineBorder != "0")
                    {
                        origLabelTemplate.Properties.LineBorder = labelTemplate.Properties.LineBorder;
                    }
                    if (labelTemplate.Properties.SectionCount != 0)
                    {
                        origLabelTemplate.Properties.SectionCount = labelTemplate.Properties.SectionCount;
                    }
                    if (labelTemplate.Properties.HasHeader != false)
                    {
                        origLabelTemplate.Properties.HasHeader = labelTemplate.Properties.HasHeader;
                    }
                    if (labelTemplate.Properties.HasBody != false)
                    {
                        origLabelTemplate.Properties.HasBody = labelTemplate.Properties.HasBody;
                    }
                    if (labelTemplate.Properties.HasFooter != false)
                    {
                        origLabelTemplate.Properties.HasFooter = labelTemplate.Properties.HasFooter;
                    }
                    if (labelTemplate.Properties.TemplateHeight != 0)
                    {
                        origLabelTemplate.Properties.TemplateHeight = labelTemplate.Properties.TemplateHeight;
                    }
                    if (labelTemplate.Properties.TemplateWidth != 0)
                    {
                        origLabelTemplate.Properties.TemplateWidth = labelTemplate.Properties.TemplateWidth;
                    }
                    if (labelTemplate.Properties.Scale != 0)
                    {
                        origLabelTemplate.Properties.Scale = labelTemplate.Properties.Scale;
                    }
                    if (labelTemplate.Properties.LeftMargin != 0)
                    {
                        origLabelTemplate.Properties.LeftMargin = labelTemplate.Properties.LeftMargin;
                    }
                    if (labelTemplate.Properties.TopMargin != 0)
                    {
                        origLabelTemplate.Properties.TopMargin = labelTemplate.Properties.TopMargin;
                    }
                    if (labelTemplate.Properties.DefaultFont != "-NA-")
                    {
                        origLabelTemplate.Properties.DefaultFont = labelTemplate.Properties.DefaultFont;
                    }
                    if (labelTemplate.Properties.SQLQuery != "-NA-")
                    {
                        origLabelTemplate.Properties.SQLQuery = labelTemplate.Properties.SQLQuery;
                    }


                    LabelSection sec = new LabelSection();
                    foreach (LabelSection s in origLabelTemplate.Sections)
                    {
                        if (s.Name == section.Name)
                        {
                            sec = s;
                        }
                    }
                    int i = 0;
                    //Compare/overwrite the line values between the two objects.
                    foreach (Line l in section.Lines)
                    {

                        if (l.FontFamily != "-NA-")
                        {
                            sec.Lines[i].FontFamily = l.FontFamily;
                        }
                        i++;
                    }
                }

                string P = Path.Combine(name, FullPath);

                origLabelTemplate.SaveTemplate(P, origLabelTemplate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
            }

            return true;
        }

        #endregion Public Methods
        #region Private Methods
        private bool IsValidFullPathAndName(string stringToCheck)
        {
            if (stringToCheck.Contains('.') && stringToCheck.Contains('\\') && stringToCheck.StartsWith("C:"))
            {
                string dir = stringToCheck.Substring(0, stringToCheck.LastIndexOf('\\'));
                if (Directory.Exists(dir))
                {
                    return true;
                }
            }

            return false;
        }
        #endregion Private Methods
    }
}
