using System.Runtime.Versioning;
using System.Text.Json.Serialization;

namespace AmetekLabelAPI.Models
{
    /// <summary>
    /// Used to hold information about line text Labels
    /// </summary>

    public partial class LabelModel
    {
        #region Enums
        /// <summary>
        /// Enumeration for font style.
        /// </summary>
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public enum ModelStandardFontStyle
        {
            Regular,
            Bold,
            Italic,
            Underlined,
            Strikeout
        }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        #endregion Enums
        #region Declarations
        private string _templateName = "ViPAKLabels.tmplt";
        private string _templateDirectory = @"C:\LableTemplates";
        private LabelPropertiesModel _properties = new LabelPropertiesModel();
        private List<LabelSectionModel> _sections = new List<LabelSectionModel>();
        #endregion Declarations
        #region Constructors
        /// <summary>
        /// A constructor that requires both a template name and a template directory at instantiation.
        /// </summary>
        /// <param name="TemplateName"></param>
        /// <param name="TemplateDirectory"></param>
        public LabelModel(string TemplateName, string TemplateDirectory)
        {
            _templateName = TemplateName;
            _templateDirectory = TemplateDirectory;
            _properties = new LabelPropertiesModel();
        }

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public LabelModel()
        {
            _properties = new LabelPropertiesModel();
        }

        /// <summary>
        /// Constructor that accepts template properties on initilization.
        /// </summary>
        /// <param name="TemplateName"></param>
        /// <param name="LabelScale"></param>
        /// <param name="TemplateDir"></param>
        /// <param name="Description"></param>
        /// <param name="LinesPerPage"></param>
        /// <param name="SpaceBetweenLines"></param>
        /// <param name="TemplateHeight"></param>
        /// <param name="TemplatWidth"></param>
        /// <param name="Scale"></param>
        /// <param name="LeftMargin"></param>
        /// <param name="TopMargin"></param>
        /// <param name="DefaultFont"></param>
        /// <param name="SQLQuery"></param>
        [SupportedOSPlatform("Windows")]
        public LabelModel(string TemplateName, float LabelScale, string TemplateDir, string Description, int LinesPerPage, int SpaceBetweenLines, int TemplateHeight, int TemplatWidth, float Scale, float LeftMargin, float TopMargin, string DefaultFont, string SQLQuery)
        {
            LabelPropertiesModel properties = new LabelPropertiesModel();
            _templateName = TemplateName;
            _templateDirectory = TemplateDir;
            properties.template_Name = TemplateName;
            properties.labelScale = LabelScale;
            properties.templateDirectory = TemplateDir;
            properties.template_Description = Description;
            properties.linesPerPage = LinesPerPage;
            properties.lineBorder = SpaceBetweenLines.ToString();
            properties.templateHeight = TemplateHeight;
            properties.templateWidth = TemplatWidth;
            properties.scale = Scale;
            properties.leftMargin = LeftMargin;
            properties.topMargin = TopMargin;
            properties.defaultFont = DefaultFont;
            properties.sQLQuery = SQLQuery;
            this._properties = properties;
        }
        #endregion Constructors
        #region Properties
        /// <summary>
        /// This is the version of the template.
        /// </summary>
        [JsonPropertyName("version")]
        public double Version { get; set; }

        /// <summary>
        /// Label setup properties.
        /// </summary>        
        [JsonPropertyName("properties")]
        public LabelPropertiesModel Properties { get; set; } = new LabelPropertiesModel();

        /// <summary>
        /// List of sections that hold main label data.
        /// </summary>        
        [JsonPropertyName("sections")]
        public List<LabelSectionModel> Sections { get; set; } = new List<LabelSectionModel>();


        #endregion Properties
        #region Public Methods

        #endregion Public Methods
        #region Private Methods

        #endregion Private Methods
    }

}
