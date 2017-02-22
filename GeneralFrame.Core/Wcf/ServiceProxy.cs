using System;
using System.ServiceModel;

namespace GeneralFrame.Core.Wcf
{
    /// <summary>
    /// Represents the helper class that invokes remote service's methods.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    public class ServiceProxy<TService> : IServiceProxy<TService>
        where TService : class
    {

        private class ServiceClient : ClientBase<TService>
        {
            public TService InnerChannel
            {
                get { return this.Channel; }
            }
        }
        
        public void Invoke(Action<TService> action)
        {
            var proxy = new ServiceClient();
            try
            {
                proxy.Open();
                action(proxy.InnerChannel);
            }
            catch (Exception ex)
            {
                //TODO:Implement logging 
                throw;
            }
            finally
            {
                this.Dispose(proxy);
            }
        }

        public TResult Invoke<TResult>(Func<TService, TResult> func)
        {
            var proxy = new ServiceClient();
            try
            {
                proxy.Open();
                return func(proxy.InnerChannel);
            }
            catch (Exception ex)
            {
                //TODO:Implement logging 
                throw;
            }
            finally
            {
                this.Dispose(proxy);
            }
        }

        /// <summary>
        /// Disposes the specified proxy.
        /// </summary>
        /// <param name="proxy">The proxy.</param>
        private void Dispose(ICommunicationObject proxy)
        {
            try
            {
                if (proxy.State != CommunicationState.Faulted)
                {
                    proxy.Close();
                }
                else
                {
                    proxy.Abort();
                }
            }
            catch (Exception ex)
            {
                //TODO:Implement logging 
            }
        }
    }
}
