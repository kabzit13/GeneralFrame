using System;

namespace GeneralFrame.Core.Wcf
{
    /// <summary>
    /// Mechanism for sending request to service
    /// </summary>
    /// <typeparam name="TService">Service contract</typeparam>
    public interface IServiceProxy<out TService>
        where TService : class
    {
        /// <summary>
        ///  Invoke without getting results
        /// </summary>
        /// <param name="action">Request</param>
        void Invoke(Action<TService> action);

        /// <summary>
        ///  Invoke with getting results
        /// </summary>
        /// <typeparam name="TResult">Result</typeparam>
        /// <param name="func">Request</param>
        /// <returns></returns>
        TResult Invoke<TResult>(Func<TService, TResult> func);
    }
}
