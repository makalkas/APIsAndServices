using AmetekLabelAPI.Resources.Templates;

namespace AmetekLabelAPI.Resources.Services
{
    /// <summary>
    /// Interface for Template service.
    /// </summary>
    public interface ITemplateService
    {
        /// <summary>
        /// This method adds a new line object in the template.
        /// </summary>
        /// <param name="SectionID">Header, body, or footer name</param>
        /// <param name="FontFamily">Line font family to be used</param>
        /// <param name="FontSize">Line font size to be used</param>
        /// <param name="FonrWeight">Line font weight</param>
        /// <param name="FontStyle">Font style to use</param>
        /// <param name="NewParagraph">Includes a new paragraph character at end of line</param>
        /// <param name="Text">Text of the line</param>
        /// <returns></returns>
        bool AddNewLine(int SectionID, string FontFamily, int FontSize, string FonrWeight, Label.StandardFontStyle FontStyle, bool NewParagraph, string Text);

        /// <summary>
        /// Creates a new Label template file in default configured location.
        /// </summary>
        /// <param name="Template">Label Template to be created.</param>
        void createNewLabelTemplate(LabelTemplate Template);

        /// <summary>
        /// Creates a new Label template file from parameters.
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
        void createNewLabelTemplate(string TemplateName, float LabelScale, string TemplateDir, string Description, int LinesPerPage, int SpaceBetweenLines, int TemplateHeight, int TemplatWidth, float Scale, float LeftMargin, float TopMargin, string DefaultFont, string SQLQuery);

        /// <summary>
        /// Creates a new label section object.
        /// </summary>
        /// <param name="labelSection"></param>
        /// <returns></returns>
        bool CreateNewSection(LabelSection labelSection);

        /// <summary>
        /// Creates a new section object from parameters
        /// </summary>
        /// <param name="SectionType">"Header", "Body", or "Footer" section names</param>
        /// <param name="textLocation">Indicates if text should appear above image or below it. Not applicable to sections without an image.</param>
        /// <param name="leftMagin">Left margin space in pixels</param>
        /// <param name="rightMargin">Right margin space in pixels. Not applicable for sections without text.</param>
        /// <param name="topMargin">Top margin space in pixels</param>
        /// <param name="bottomMargin">Bottom margin space in pixels</param>
        /// <param name="imageFullPath">Full path to section image file.</param>
        /// <returns></returns>
        bool CreateNewSection(string SectionType, LabelSection.TextLocation textLocation, int leftMagin, int rightMargin, int topMargin, int bottomMargin, string imageFullPath);

        /// <summary>
        /// Creates a new section object from parameters
        /// </summary>
        /// <param name="SectionType">"Header", "Body", or "Footer" section names</param>
        /// <param name="textLocation">Indicates if text should appear above image or below it. Not applicable to sections without an image.</param>
        /// <param name="leftMagin">Left margin space in pixels</param>
        /// <param name="rightMargin">Right margin space in pixels. Not applicable for sections without text.</param>
        /// <param name="topMargin">Top margin space in pixels</param>
        /// <param name="bottomMargin">Bottom margin space in pixels</param>
        /// <param name="imageFullPath">Full path to section image file.</param>
        /// <param name="lines">List of line objects to be included in the section object</param>
        /// <returns></returns>
        bool CreateNewSection(string SectionType, LabelSection.TextLocation textLocation, int leftMagin, int rightMargin, int topMargin, int bottomMargin, string imageFullPath, List<Line> lines);
    }
}