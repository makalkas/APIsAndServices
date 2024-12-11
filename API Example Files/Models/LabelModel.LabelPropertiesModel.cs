using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AmetekLabelAPI.Models
{
    /// <summary>
    /// Properties class used to ensure proper values are returned.
    /// </summary>

    public partial class LabelPropertiesModel
    {
        /// <summary>
        /// The default font the label should use when printing and a line doesn't have a font listed.
        /// </summary>
        [JsonPropertyName("defaultFont")]
        public string defaultFont { get; set; } = string.Empty;

        /// <summary>
        /// Value indicating there is a section called "Body"
        /// </summary>
        [JsonPropertyName("hasBody")]
        [Required]
        public bool hasBody { get; set; }

        /// <summary>
        /// Value indicating there is a section called "Footer"
        /// </summary>
        [JsonPropertyName("hasFooter")]
        [Required]
        public bool hasFooter { get; set; }

        /// <summary>
        /// Value indicating there is a section called "Header"
        /// </summary>
        [JsonPropertyName("hasHeader")]
        [Required]
        public bool hasHeader { get; set; }

        /// <summary>
        /// This is the over all scale of the entire label includeing images and text.
        /// </summary>
        [JsonPropertyName("labelScale")]
        [Required]
        public float labelScale { get; set; }

        /// <summary>
        /// Distance from left side of label
        /// </summary>
        [JsonPropertyName("leftMargin")]
        [Required]
        public float leftMargin { get; set; }

        /// <summary>
        /// Distance between lines.
        /// </summary>
        [JsonPropertyName("lineBorder")]
        public string lineBorder { get; set; } = string.Empty;

        /// <summary>
        /// Number of lines per page (Calculated value)
        /// </summary>
        [JsonPropertyName("linesPerPage")]
        public float linesPerPage { get; set; }

        /// <summary>
        /// This is the scale of the image.
        /// </summary>
        [JsonPropertyName("scale")]
        [Required]
        public float scale { get; set; }

        /// <summary>
        /// The number of sections included in template
        /// </summary>
        [JsonPropertyName("sectionCount")]
        [Required]
        public int sectionCount { get; set; }

        /// <summary>
        /// The query used to get the data from the database.
        /// </summary>
        [JsonPropertyName("sQLQuery")]
        public string sQLQuery { get; set; } = string.Empty;

        /// <summary>
        /// Description of the template
        /// </summary>
        [JsonPropertyName("template_Description")]
        public string template_Description { get; set; } = string.Empty;

        /// <summary>
        /// Identity of the template
        /// </summary>
        [JsonPropertyName("template_Name")]
        public string template_Name { get; set; } = string.Empty;

        /// <summary>
        /// File location on the server where the template is located.
        /// </summary>
        [JsonPropertyName("templateDirectory")]
        public string templateDirectory { get; set; } = string.Empty;

        /// <summary>
        /// Height of the template.
        /// </summary>
        [JsonPropertyName("templateHeight")]
        [Required]
        public int templateHeight { get; set; }

        /// <summary>
        /// Withd of the template.
        /// </summary>
        [JsonPropertyName("templateWidth")]
        [Required]
        public int templateWidth { get; set; }

        /// <summary>
        /// Distance from top where the labe begines to print.
        /// </summary>
        [JsonPropertyName("topMargin")]
        [Required]
        public float topMargin { get; set; }
    }
}