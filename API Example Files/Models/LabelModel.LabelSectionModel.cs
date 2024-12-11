using System.Drawing;
using System.Runtime.Versioning;
using System.Text.Json.Serialization;
using static AmetekLabelAPI.Models.LabelModel;

namespace AmetekLabelAPI.Models
{
    /// <summary>
    /// Model for recieving information to print a label.
    /// </summary>
    [SupportedOSPlatform("windows")]

    public class LabelSectionModel
    {
        #region Declarations
        private bool _hasImage;
        private string _imagePath = string.Empty;
        private Image? _image;
        #endregion Declarations

        #region Enumerations
        /// <summary>
        /// This enumeration allows the text lines to appear above or below and image.
        /// </summary>
        public enum TextPosition
        {
            /// <summary>
            /// Set text lines above an image. Has no effect if there is no image.
            /// </summary>
            Above,
            /// <summary>
            /// Set text lines below an image. Has no effect if there is no image.
            /// </summary>
            Below
        }
        #endregion Enumerations

        #region Constructors
        /// <summary>
        /// Blank constructor.
        /// </summary>
        public LabelSectionModel()
        {
            _hasImage = false;
            _imagePath = string.Empty;
        }
        /// <summary>
        /// Constructor that initializes all properties.
        /// </summary>
        public LabelSectionModel(string Name, TextPosition LayoutOptions, float LeftMargin, float RightMargin, float TopMargin, float BottomMargin, string ImageLocation, bool HasImage, LineModel[] Lines)
        {
            this.Name = Name;
            this.LayoutOptions = LayoutOptions;
            this.LeftMargin = LeftMargin;
            this.RightMargin = RightMargin;
            this.TopMargin = TopMargin;
            this.BottomMargin = BottomMargin;
            this.ImageLocation = ImageLocation;
            this.HasImage = HasImage;
            this.Lines = Lines.ToList();
        }
        #endregion Constructors

        #region Properties
        /// <summary>
        /// Name of the section
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// (enum) Property that determines if the text should come before or after an image.
        /// </summary>
        [JsonPropertyName("layoutOptions")]
        public TextPosition LayoutOptions { get; set; } = TextPosition.Below;


        /// <summary>
        /// (float) Space between left side of paper and beginning of text or image.
        /// </summary>
        [JsonPropertyName("leftMargin")]
        public float LeftMargin { get; set; } = 0f;

        /// <summary>
        /// (float) Space between right side of paper and end of text or image. This may vary depending on dimensions of paper.
        /// </summary>
        [JsonPropertyName("rightMargin")]
        public float RightMargin { get; set; } = 0f;

        /// <summary>
        /// (float) Space between top of print start and text or image.
        /// </summary>
        [JsonPropertyName("topMargin")]
        public float TopMargin { get; set; } = 0f;

        /// <summary>
        /// (float) space between bottom of print end and text or image. This may vary depending on dimensions of paper.
        /// </summary>
        [JsonPropertyName("bottomMargin")]
        public float BottomMargin { get; set; } = 0f;

        /// <summary>
        /// Path to image for section
        /// </summary>
        [JsonPropertyName("imageLocation")]
        public string ImageLocation
        {
            get
            {
                return _imagePath;
            }
            set
            {
                _imagePath = value;
                this.HasImage = true;


            }
        }


        /// <summary>
        /// Used to determine if an immage has been provided for a section.
        /// </summary>
        [JsonPropertyName("hasImage")]
        public bool HasImage
        {
            get
            {
                return _hasImage;
            }
            set
            {
                _hasImage = value;

            }
        }


        /// <summary>
        /// (List of "Line" objects) A list of line objects that holds the text and settings that belongs in that line.
        /// </summary>        
        [JsonPropertyName("lines")]
        public List<LineModel> Lines { get; set; } = new List<LineModel>();

        /// <summary>
        /// Returns the number of lines currently in the section.
        /// </summary>
        [JsonIgnore]
        public int LineCount
        {
            get
            {
                if (Lines != null)
                {
                    return Lines.Count();
                }
                return 0;
            }
        }

        /// <summary>
        /// (Image) An image in a bitmap format. (E.g. jpg, bmp,gif) Property that holds the actual image.
        /// </summary>
        [JsonIgnore]
        public Image? SectionImage { get; set; }
        #endregion Properties

        #region Public Methods
        /// <summary>
        /// Returns the number of lines currently in the section.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public LineModel GetLine(int index)
        {
            if (Lines != null && Lines.Count<LineModel>() > index)
            {
                return Lines[index];
            }
            else
            {
                LineModel line = new LineModel(FontFamily: "Currier New", FontSize: "12", FontWeight: "Bold", Text: "No Lines currently included in this section.", ModelStandardFontStyle.Regular);
                return line;
            }
        }
        /// <summary>
        /// This method adds the text lines for the section using properties.
        /// </summary>
        /// <param name="FontFamily">Text line font family. This has no effect if the section only contains an image.</param>
        /// <param name="FontSize">Text line Font size (e.g. 12, 18, 24)</param>
        /// <param name="FontWeight">Text line font weight (normal, Bold)</param>
        /// <param name="Text">Text characters of the line.</param>
        /// <param name="FontStyle">Text line font style (e.g. normal(default), Underlined)</param>
        /// <param name="NewParagraph">Boolean value indicating if extra space should be included between lines.</param>
        public void AddLines(string FontFamily, string FontSize, string FontWeight, string Text, ModelStandardFontStyle FontStyle, bool NewParagraph)
        {

            LineModel line = new LineModel(FontFamily, FontSize, FontWeight, Text, FontStyle);
            this.Lines.Add(line);
        }

        /// <summary>
        /// This method adds the text lines for the section using a line object.
        /// </summary>
        /// <param name="line">Line object</param>
        public void AddLines(LineModel line)
        {
            if (Lines == null || Lines.Count == 0)
            {
                Lines = new List<LineModel>
                {
                    line
                };
            }
            else
            {
                Lines.Add(line);
            }

        }

        /// <summary>
        /// This method removes the actual image from the image property.
        /// </summary>
        public void ClearImage()
        {
            _image = null;
            this.HasImage = false;
        }

        /// <summary>
        /// Ensures image is loaded properly, othewise returns false.
        /// </summary>
        /// <returns>bool indicating image was reloaded</returns>
        public bool checkForImage()
        {
            if (_image != null & !string.IsNullOrEmpty(this._imagePath))
            {
                if (this._imagePath != @"C:\\")
                {
                    this.SectionImage = new Bitmap(this._imagePath);
                    this.HasImage = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion Public Methods

    }
}
