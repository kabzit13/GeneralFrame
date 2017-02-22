using System;
using System.Collections.Generic;
using System.Globalization;
using GeneralFrame.Core;
using GeneralFrame.Model.Models;

namespace GeneralFrame.Data.Repositories
{
    /// <summary>
    /// Class SpecificRepository.
    /// </summary>
    /// <seealso cref="RepositoryBase{T}.Calculator.Domain.Models.ComputationResult}" />
    public class SpecificRepository : RepositoryBase<GeneralResult>, ISpecificRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpecificRepository"/> class.
        /// </summary>
        /// <param name="dbContextUnitOfWork">The database context unit of work.</param>
        public SpecificRepository(IDbContextUnitOfWork dbContextUnitOfWork) : base(dbContextUnitOfWork)
        {
            //TODO: Implement custom queries.
        }

    }
}
