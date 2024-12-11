using AmetekLabelAPI.Models;

namespace AmetekLabelAPI.Resources.Services
{
    /// <summary>
    /// Public printer class interface
    /// </summary>
    public interface IPrinterService
    {
        /// <summary>
        /// This method returns a list of all available printers on the server.
        /// </summary>
        /// <returns>List of "Printer Names"</returns>
        List<string> GetPrinters();

        /// <summary>
        /// Loads Template data to be worked with.
        /// </summary>
        /// <param name="TemplateName"></param>
        void LoadLabelTemplate(string TemplateName);

        /// <summary>
        /// This method sends the modified (Data from Database) Label Template to the printer.
        /// </summary>
        /// <param name="labelToPrint">Endpoint model for receiving data from UI.</param>
        /// <param name="printerName">string indicating which printer to send the document to.</param>
        /// <param name="cancel">Not used yet.</param>
        void PrintDoc(LabelModel labelToPrint, string printerName, bool cancel = false);

        /// <summary>
        /// This method sends the incoming Label Template data to the printer.
        /// </summary>
        /// <param name="labelToPrint">Endpoint model for receiving data from UI.</param>
        /// <param name="printerName">String indicating which printer to send the document to.</param>
        /// <param name="cancel">Not used yet.</param>
        void PrintLabel(LabelModel labelToPrint, string printerName, bool cancel = false);
    }
}