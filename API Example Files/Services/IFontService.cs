// -------------------------------------------------------------------------------
// Copyright ©Ametek 2023 
// For company use only. Author: Michael Kalkas
// -------------------------------------------------------------------------------


namespace AmetekLabelAPI.Resources.Services
{
    /// <summary>
    /// Interface for the font service.
    /// </summary>
    public interface IFontService
    {
        /// <summary>
        /// Gets and returns all available fonts on server.
        /// </summary>
        /// <returns>List of font names</returns>
        List<string> GetFonts();
    }
}