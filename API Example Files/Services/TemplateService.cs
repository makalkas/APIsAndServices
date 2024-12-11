using AmetekLabelAPI.Resources.Templates;
using System.Runtime.Versioning;
using static AmetekLabelAPI.Resources.Templates.LabelSection;

namespace AmetekLabelAPI.Resources.Services
{
    /// <summary>
    /// This service builds new templates.
    /// </summary>
    [SupportedOSPlatform("windows")]
    public class TemplateService : ITemplateService
    {
        #region Declarations
        LabelTemplate labelTemplate;

        #endregion Declarations

        #region Constructors
        /// <summary>
        /// Non-parameteric constructor.
        /// </summary>
        public TemplateService()
        {
            labelTemplate = new LabelTemplate();
        }
        #endregion Constructors

        #region Public Methods


        /// <summary>
        /// Creates a new Label Template object for use in creating a new Label template from a passed in object.
        /// </summary>
        public void createNewLabelTemplate(LabelTemplate Template)
        {
            labelTemplate = Template;
        }

        /// <summary>
        /// Method for creating a new Label Template object
        /// </summary>
        /// <param name="TemplateName">Template File Name</param>
        /// <param name="LabelScale">Master Scale of Label during print</param>
        /// <param name="TemplateDir">Directory of Template File</param>
        /// <param name="Description">Text explaining Label purpose and data</param>
        /// <param name="LinesPerPage">Total number of lines per page</param>
        /// <param name="SpaceBetweenLines">integer giving space between lines in pixels</param>
        /// <param name="TemplateHeight">integer giving Label height during printing in pixels</param>
        /// <param name="TemplatWidth">integer giving Label witdth during printing in pixels</param>
        /// <param name="Scale">Image scale</param>
        /// <param name="LeftMargin">Left margin space in pixels</param>
        /// <param name="TopMargin">Top margin space in pixels</param>
        /// <param name="DefaultFont">Label default font</param>
        /// <param name="SQLQuery">SQL Script for returning data for label.</param>       
        public void createNewLabelTemplate(string TemplateName, float LabelScale, string TemplateDir, string Description, int LinesPerPage, int SpaceBetweenLines, int TemplateHeight, int TemplatWidth, float Scale, float LeftMargin, float TopMargin, string DefaultFont, string SQLQuery)
        {
            labelTemplate = new LabelTemplate(TemplateName, LabelScale, TemplateDir, Description, LinesPerPage, SpaceBetweenLines, TemplateHeight, TemplatWidth, Scale, LeftMargin, TopMargin, DefaultFont, SQLQuery);
        }

        /// <summary>
        /// Method for creating/adding a new label section from a label section object.
        /// </summary>
        /// <param name="labelSection">Label Section to creat/add to a label Template.</param>
        /// <returns></returns>        
        public bool CreateNewSection(LabelSection labelSection)
        {
            labelTemplate.Sections.Add(labelSection);

            return false;
        }

        /// <summary>
        /// Method for creating/adding a new label section from properties
        /// </summary>
        /// <param name="SectionType">Header, body, or footer section type</param>
        /// <param name="textLocation">Above or below image.</param>
        /// <param name="leftMagin">Integer indication how many points from edge</param>
        /// <param name="rightMargin">Integer indication how many points from edge</param>
        /// <param name="topMargin">Integer indication how many points from edge</param>
        /// <param name="bottomMargin">Integer indication how many points from edge</param>
        /// <param name="imageFullPath">Full file path to section image.</param>
        /// <param name="lines">Array of text lines to be included in section.</param>
        /// <returns>bool indicating success (true) or failure (false)</returns>         
        public bool CreateNewSection(string SectionType, TextLocation textLocation, int leftMagin, int rightMargin, int topMargin, int bottomMargin, string imageFullPath, List<Line> lines)
        {
            if (labelTemplate == null)
            {
                labelTemplate = new LabelTemplate();
            }
            LabelSection section = new LabelSection();
            section.Name = SectionType;
            section.LayoutOptions = textLocation;
            section.LeftMargin = leftMagin;
            section.RightMargin = rightMargin;
            section.TopMargin = topMargin;
            section.BottomMargin = bottomMargin;
            section.ImageLocation = imageFullPath;
            section.Lines = lines;

            labelTemplate.AddSection(section);
            return false;
        }

        /// <summary>
        /// Method for creating/adding a new label section from properties
        /// </summary>
        /// <param name="SectionType">Header, body, or footer section type</param>
        /// <param name="textLocation">Above or below image.</param>
        /// <param name="leftMagin">Integer indication how many points from edge</param>
        /// <param name="rightMargin">Integer indication how many points from edge</param>
        /// <param name="topMargin">Integer indication how many points from edge</param>
        /// <param name="bottomMargin">Integer indication how many points from edge</param>
        /// <param name="imageFullPath">Full file path to section image.</param>        
        /// <returns>bool indicating success (true) or failure (false)</returns>         
        public bool CreateNewSection(string SectionType, TextLocation textLocation, int leftMagin, int rightMargin, int topMargin, int bottomMargin, string imageFullPath)
        {
            if (labelTemplate == null)
            {
                labelTemplate = new LabelTemplate();
            }
            LabelSection section = new LabelSection();
            section.Name = SectionType;
            section.LayoutOptions = textLocation;
            section.LeftMargin = leftMagin;
            section.RightMargin = rightMargin;
            section.TopMargin = topMargin;
            section.BottomMargin = bottomMargin;
            section.ImageLocation = imageFullPath;


            labelTemplate.AddSection(section);
            return false;
        }

        /// <summary>
        /// ToDo: Update XML Comments
        /// </summary>
        /// <param name="SectionID"></param>
        /// <param name="FontFamily"></param>
        /// <param name="FontSize"></param>
        /// <param name="FonrWeight"></param>
        /// <param name="FontStyle"></param>
        /// <param name="NewParagraph"></param>
        /// <param name="Text"></param>
        /// <returns></returns>        
        public bool AddNewLine(int SectionID, string FontFamily, int FontSize, string FonrWeight, Label.StandardFontStyle FontStyle, bool NewParagraph, string Text)
        {
            try
            {
                Line line = new Line();
                line.FontFamily = FontFamily;
                line.FontSize = FontSize.ToString();
                line.FontWeight = FonrWeight;
                line.FontStyle = FontStyle;
                line.NewParagraph = NewParagraph.ToString();
                line.Text = Text;

                //labelTemplate.Sections[SectionID].AddLines(FontFamily, FontSize.ToString(),FonrWeight,Text,FontStyle,NewParagraph);
                labelTemplate.Sections[SectionID].AddLines(line);

                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion Public Methods

        #region Private Methods

        #endregion Private Methods
    }
}
