using AmetekLabelAPI.Resources.Exceptions;

namespace AmetekLabelAPI.Resources.Services
{
    public partial class SQLService
    {
        private delegate string ValidateConnectionStringFunction();

        private string TryCatch(ValidateConnectionStringFunction function)
        {
            try
            {
                return function();
            }
            catch (Exception ex)
            {
                throw CreateAndLogValidationException(ex);
            }
        }

        private ConnectionStringException CreateAndLogValidationException(Exception exception)
        {
            var ConnectionStringException = new ConnectionStringException(exception);
            this._logger.LogError(ConnectionStringException);

            return ConnectionStringException;
        }
    }
}
