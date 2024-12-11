using AmetekLabelAPI.Models;
using AmetekLabelAPI.Resources.Logging;
using AmetekLabelAPI.Resources.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Versioning;

namespace AmetekLabelAPI.Controllers
{
    //Standard controlers can only contain one httpget(retrieves data), post(sends dat to server),
    //put(replaces or creates new), Patch (partial updat),Put(full update), Delete(Remove):
    //[HttpDelete], [HttpGet],[HttpPatch],[HttpPost], [HttpPut]

    /// <summary>
    /// This controler contains the endpoints for printing the label.
    /// </summary>
    [SupportedOSPlatform("windows")]
    [Authorize]
    [ApiController]
    //[Route("ametekapi/[controller]")]
    public class PrintersController : Controller
    {
        #region Declarations
        IPrinterService _printer;
        private readonly ILoggingBroker _logger;

        #endregion Declarations

        #region Constructors
        /// <summary>
        /// Blank Constructor.
        /// </summary>
        /// <param name="logger">Microsoft Logger object for logging errors.</param>
        /// <param name="printerClass"></param>
        public PrintersController(ILoggingBroker logger, IPrinterService printerClass)
        {
            _logger = logger;
            _printer = printerClass;
        }
        #endregion Constructors

        #region Public Endpoints
        /// <summary>
        /// This method gets the names of all available printers on the main server.
        /// </summary>
        /// <returns>List of available printers</returns>
        [HttpGet("/ametekapi/printers", Name = "GetServerPrinters")]
        public List<string> GetServerPrinterNames()
        {
            List<string> PrinterNames = new List<string>();
            try
            {
                return _printer.GetPrinters();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                PrinterNames.Add(ex.Message);
                return PrinterNames;
            }

        }

        /// <summary>
        /// This public endpoint allows the label to be printed to the thermal printer.
        /// </summary>
        /// <param name="labelToPrint">Object representing all label properties for printing</param>
        /// <param name="Printer">The name of the selected printer.</param>
        /// <returns></returns>
        [HttpPost("/ametekapi/printers/{Printer}")]
        public LabelModel PrintDocument(string Printer, [FromBody] LabelModel labelToPrint)
        {


            if (string.IsNullOrEmpty(Printer)) { Printer = "Adobe PDF"; }

            try
            {
                //_printer.PrintDoc(ConvertToTemplate(labelToPrint), Printer, false); //original print method used for testing purposes.
                _printer.PrintLabel(labelToPrint, Printer, false); //latest print method for printing from service endpoint.
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);

            }
            return labelToPrint;
        }
        #endregion Public Endpoints

        #region Private Methods

        #endregion Private Methods
    }
}
