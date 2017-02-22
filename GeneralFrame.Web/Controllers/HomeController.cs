using System;
using System.Web.Mvc;
using GeneralFrame.Application.Contracts;
using GeneralFrame.Core.Wcf;

namespace GeneralFrame.Web.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// The calculator service
        /// </summary>
        private readonly IServiceProxy<IGeneralFrameService> generalFrameSrv;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        protected HomeController() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="generalFrameSrv">The calculator service.</param>
        public HomeController(IServiceProxy<IGeneralFrameService> generalFrameSrv)
        {
            this.generalFrameSrv = generalFrameSrv;
        }

        /// <summary>
        /// Returns main view.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            return this.View("Index");
        }

        /// <summary>
        /// Adds the specified two numbers.
        /// </summary>
        /// <param name="number1">The number1.</param>
        /// <param name="number2">The number2.</param>
        /// <returns>ActionResult.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// Parameter is null or empty - number1
        /// or
        /// Parameter is null or empty - number2
        /// </exception>
        [HttpGet]
        public ActionResult GetData(string number1, string number2)
        {
            try
            {
                if (string.IsNullOrEmpty(number1))
                    throw new ArgumentNullException(nameof(number1), "Parameter is null or empty");
                if (string.IsNullOrEmpty(number2))
                    throw new ArgumentNullException(nameof(number2), "Parameter is null or empty");

                this.generalFrameSrv.Invoke(srv => srv.GetData());

            }
            //TODO: Implement more specific error handling
            catch (Exception error)
            {
                return this.View("ErrorView", error);
            }
            return null;
        }

        
    }
}