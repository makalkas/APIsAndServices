
namespace AmetekLabelAPI.Resources.Services
{
    /// <summary>
    /// Interface for the File Service.
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Removes a template file.
        /// </summary>
        /// <param name="fullpath">Path of the file to be removed</param>
        /// <param name="name">Name of the file to be removed</param>
        /// <returns></returns>
        bool DeleteTemplate(string fullpath, string name);

        /// <summary>
        /// Returnes a list of file names in the specified directory.
        /// </summary>
        /// <param name="filepath">Directory to look for file names</param>
        /// <returns>List of all available files in directory and their full path.</returns>
        ValueTask<List<string>> GetLabelTemplateFileNames(string filepath);

        /// <summary>
        /// Changes the current file name to a new file name or moves it.
        /// </summary>
        /// <param name="CurrentFileName">Current file name and directory of the file</param>
        /// <param name="NewFileName">New file name and directory for the file.</param>
        /// <returns>returns true on success</returns>
        bool UpdateTemplateName(string CurrentFileName, string NewFileName);
    }
}