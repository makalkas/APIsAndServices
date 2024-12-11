using AmetekLabelAPI.Resources.Logging;
using AmetekLabelAPI.Resources.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Versioning;

namespace AmetekLabelAPI.Controllers
{
    /// <summary>
    /// This controller is for handling server font information.
    /// </summary>
    [SupportedOSPlatform("windows")]
    [Authorize]
    [ApiController]
    //[Route("ametekapi/[controller]")]
    public class FontsController : Controller
    {
        #region Declarations
        IFontService? _fontService = null;
        private readonly ILoggingBroker _logger;
        private readonly IConfiguration _configuration;

        #endregion Declarations

        #region Constructors
        /// <summary>
        /// Blank constructor for class object.
        /// </summary>
        /// <param name="logger">Application logger object</param>
        /// <param name="configuration">Application configuration object</param>
        /// <param name="fontService"></param>
        public FontsController(ILoggingBroker logger, IConfiguration configuration, IFontService fontService)
        {
            _logger = logger;
            _configuration = configuration;
            _fontService = fontService;
        }
        #endregion Constructors

        #region Public Endpoints
        /// <summary>
        /// Gets all fonts available on server.
        /// </summary>
        /// <returns></returns>
        [HttpGet("/ametekapi/fonts", Name = "GetServerFonts")]
        public List<string> GetServerFonts()
        {
            return _fontService!.GetFonts();
        }
        #endregion Public Endpoints
    }
}
