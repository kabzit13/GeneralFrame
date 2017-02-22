using System;
using GeneralFrame.Data.Repositories;

namespace GeneralFrame.Application
{
    /// <summary>
    /// Class CalculatorAppService.
    /// </summary>
    /// <seealso cref="IGeneraFrameService" />
    public class GeneralFrameAppService : IGeneralFrameAppService
    {
        /// <summary>
        /// The computation result repository
        /// </summary>
        private readonly ISpecificRepository specificRepository;
        /// <summary>
        /// Initializes a new instance of the <see cref="GeneraFrameService"/> class.
        /// </summary>
        /// <param name="specificRepository">The computation result repository.</param>
        public GeneralFrameAppService(ISpecificRepository specificRepository)
        {
            this.specificRepository = specificRepository;
        }

       

        public void GetData()
        {
            throw new NotImplementedException();
        }
    }
}
