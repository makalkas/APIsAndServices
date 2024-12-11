// -------------------------------------------------------------------------------
// Copyright ©Ametek 2023 
// For company use only. Author: Michael Kalkas
// -------------------------------------------------------------------------------

using AmetekLabelAPI.Resources.Logging;
using System.Drawing;
using System.Runtime.Versioning;

namespace AmetekLabelAPI.Resources.Services
{
    /// <summary>
    /// Class necessary for obtaining fonts
    /// </summary>
    [SupportedOSPlatform("windows")]
    public class FontService : IFontService
    {
        #region Declarations
        private readonly ILoggingBroker _logger;
        #endregion Declarations
        #region Constructors
        /// <summary>
        /// Default constructor with ILogger injection required.
        /// </summary>
        /// <param name="logger">ILogger object</param>
        public FontService(ILoggingBroker logger)
        {
            _logger = logger;
        }
        #endregion Constructors
        #region Public Methods
        /// <summary>
        /// Method that returns fonts available on the server.
        /// </summary>
        /// <returns>Font names</returns>
        public List<string> GetFonts()
        {
            return FontFamily.Families.FFToList();
        }
        #endregion Public Methods
        #region Private Methods

        #endregion Private Methods
    }
}
