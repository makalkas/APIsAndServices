using System.ComponentModel;

namespace AmetekLabelAPI.Models
{
    /// <summary>
    /// This class is the data model for SchedViPAK data.
    /// </summary>
    public class SchedViPAKModel
    {
        /// <summary>
        /// Sales Order Number
        /// </summary>
        [DisplayName("sono")]
        public string sono { get; set; } = string.Empty;

        /// <summary>
        /// Sales Order Line number
        /// </summary>
        [DisplayName("lineno")]
        public int Linenum { get; set; }


        /// <summary>
        /// Item identification string
        /// </summary>
        public string Item { get; set; } = string.Empty;

        /// <summary>
        /// Item Description
        /// </summary>
        [DisplayName("descrip")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// PO Line ID number
        /// </summary>
        public string plinid { get; set; } = string.Empty;

        /// <summary>
        /// PO Line Text information
        /// </summary>
        [DisplayName("custmemo")]
        public string LineText { get; set; } = string.Empty;

        /// <summary>
        /// Po Number
        /// </summary>
        [DisplayName("ponum")]
        public string ExternalDocumentNo { get; set; } = string.Empty;

        /// <summary>
        /// Customer number.
        /// </summary>
        [DisplayName("custno")]
        public string SellToCustomerNo { get; set; } = string.Empty;
    }
}
