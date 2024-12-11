namespace AmetekLabelAPI.Models
{
    /// <summary>
    /// Data to be mapped into Label for printing
    /// </summary>
    [Serializable()]
    public class SelectedData
    {
        #region Declarations
        #endregion Declarations
        #region Properties
        /// <summary>
        /// Name used in mapping data placement in Label Template data for printing.
        /// </summary>
        public string ColumnName { get; set; } = string.Empty;

        /// <summary>
        /// Actual values to be inserted into Label Template data for printing.
        /// </summary>
        public string Data { get; set; } = string.Empty;

        #endregion Properties
        #region Constructors

        #endregion Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public SelectedData() { }

        /// <summary>
        /// Constructor used when values are supplied at instantiation.
        /// </summary>
        /// <param name="ColumnName"></param>
        /// <param name="Data"></param>
        public SelectedData(string ColumnName, string Data)
        {
            this.ColumnName = ColumnName;
            this.Data = Data;
        }
        #region Public Methods

        #endregion Public Methods
    }
}
