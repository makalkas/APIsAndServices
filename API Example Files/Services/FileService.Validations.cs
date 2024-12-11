using AmetekLabelAPI.Resources.Exceptions;

namespace AmetekLabelAPI.Resources.Services
{
    public partial class FileService
    {
        private bool ValidateFilePath(string filePath)
        {
            bool filePathIsDirectory = false;

            if (!filePath.Contains('.'))
            {
                filePathIsDirectory = true;
            }

            if (filePathIsDirectory == false)
            {
                if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
                {
                    throw new BadFilePathException($"The file does not exist at:{filePath}.");
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(filePath) || !Directory.Exists(filePath))
                {
                    throw new BadFilePathException($"The directory does not exist at:{filePath}.");
                }
            }
            return true;
        }
    }
}
