using static AmetekLabelAPI.Models.LabelModel;

namespace AmetekLabelAPI.Models
{
    /// <summary>
    /// Data model for each line label of each line text.
    /// </summary>
    public partial class LabelLineLableModel
    {
        /// <summary>
        /// Label property: Text
        /// </summary>        
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// Label property: FontSize (e.g. 14.25f)
        /// </summary>       
        public float FontSizeEM { get; set; } = 14.25f;

        /// <summary>
        /// Label property: Font (e.g. "Currier New", FontSize(em) "14.25f", FontStyle "FontStyle.Regular")
        /// </summary>        
        public string FontFamily { get; set; } = "Courier New";

        /// <summary>
        /// Label property: FontStyle (e.g. Regular, Bold, Italic, Underlined, Strikeout)
        /// </summary>        
        public ModelStandardFontStyle fontStyle
        {
            get;
            set;
        } = ModelStandardFontStyle.Regular;
    }
}
