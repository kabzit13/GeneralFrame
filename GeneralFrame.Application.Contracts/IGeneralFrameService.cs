using System.ServiceModel;
using GeneralFrame.Model.Models;

namespace GeneralFrame.Application.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    [ServiceContract]
    public interface IGeneralFrameService
    {
        /// <summary>
        /// 
        /// </summary>
        [OperationContract]
        [FaultContract(typeof(CustomError))]
        void GetData();
    }
}
