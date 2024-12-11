using AmetekLabelAPI.Resources.Exceptions;

namespace AmetekLabelAPI.Resources.Services
{
    public partial class FileService
    {
        private delegate ValueTask<bool> ReturningFileNameFunction();
        private async ValueTask<bool> TryCatch(ReturningFileNameFunction returningFileNameFunction)
        {
            try
            {
                return await returningFileNameFunction();
            }
            catch (BadFilePathException badFilePathException)
            {

                throw CreatAndLogValidationException(badFilePathException);
            }
        }

        private FileAccessException CreatAndLogValidationException(Exception badFilePathException)
        {
            var fileAccessException = new FileAccessException(badFilePathException);
            this._logger.LogError(fileAccessException);

            return fileAccessException;
        }
    }
}
