using System.Text.Json.Serialization;
using static AmetekLabelAPI.Models.LabelModel;

namespace AmetekLabelAPI.Models
{
    /// <summary>
    /// Input Line Model class.
    /// </summary>

    public partial class LineModel
    {
        #region Declarations

        #endregion Declarations
        #region Constructors
        /// <summary>
        /// Constructor for a Line that allows the simultanious input of all necessary values.
        /// </summary>
        /// <param name="FontFamily">Text line font family. This has no effect if the section only contains an image.</param>
        /// <param name="FontSize">Text line Font size (e.g. 12, 18, 24)</param>
        /// <param name="FontWeight">Text line font weight (normal, Bold)</param>
        /// <param name="Text">Text characters of the line.</param>
        /// <param name="FontStyle">Text line font style (e.g. normal(default), Underlined)</param>
        /// <param name="NewParagraph"></param>
        /// <param name="LineLabel"></param>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [JsonConstructor]
        public LineModel(string FontFamily, string FontSize, string FontWeight, string Text, ModelStandardFontStyle FontStyle, string NewParagraph = "", LabelLineLableModel? LineLabel = null)

        {
            this.FontFamily = FontFamily;
            this.FontSize = FontSize;
            this.FontWeight = FontWeight;
            this.FontStyle = FontStyle;
            this.Text = Text;
            this.NewParagraph = NewParagraph;
            if (LineLabel != null)
            {
                this.LineLabel = LineLabel;
            }
        }
        /// <summary>
        /// Constructor for a Line that allows the input of just the text value.
        /// </summary>
        /// <param name="Text">Text characters of the line.</param>

        public LineModel(string Text)
        {
            this.Text = Text;
        }

        /// <summary>
        /// Constroctor for a Line that allows creation of the line object without any values set. This requireds manually setting all values.
        /// </summary>
        public LineModel()
        {

        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        #endregion Constructors
        #region Properties

        /// <summary>
        /// Label object containing information about the lable that goes with the line item.
        /// </summary>
        [JsonPropertyName("lineLabel")]
        public LabelLineLableModel LineLabel { get; set; } = new LabelLineLableModel();
        /// <summary>
        /// This is the Name of the Font to be used for this line.
        /// </summary>
        [JsonPropertyName("fontFamily")]
        public string FontFamily { get; set; } = "Currier New";

        /// <summary>
        /// This is the size of each character in the line.
        /// </summary>
        [JsonPropertyName("fontSize")]
        public string FontSize { get; set; } = "12";

        /// <summary>
        /// This is the weight of the font. E.g. In HTML: normal, bold, lighter, bolder.
        /// </summary>
        [JsonPropertyName("fontWeight")]
        public string FontWeight { get; set; } = "Normal";

        /// <summary>
        /// Actual string characters to be displayed.
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; set; } = "Sample Line Text";

        /// <summary>
        /// The style of the font: normal, underlined, subscript, Superrscript, etc.
        /// </summary>
        [JsonPropertyName("fontStyle")]
        public ModelStandardFontStyle FontStyle { get; set; } = ModelStandardFontStyle.Regular;

        /// <summary>
        /// Indicates if the next line should be spaced vertically as the beginning of a new paragraph.
        /// </summary>
        [JsonPropertyName("newParagraph")]
        public string NewParagraph { get; set; } = "false";

        /// <summary>
        /// Column Name text maps to.
        /// </summary>
        [JsonPropertyName("mapsTo")]
        public string MapsTo { get; set; } = "-SALESORDER-";
        #endregion Properties
    }
}
