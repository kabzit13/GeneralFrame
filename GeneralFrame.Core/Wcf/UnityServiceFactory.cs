using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Microsoft.Practices.Unity;

namespace GeneralFrame.Core.Wcf
{
    /// <summary>
    /// Represents the custom factory to create service host instance.
    /// </summary>
    public abstract class UnityServiceHostFactory : ServiceHostFactory
    {
        private static UnityContainer container;
        private readonly object containerLock = new object();

        /// <summary>
        /// Configures the container.
        /// </summary>
        /// <param name="container">The container.</param>
        protected abstract void ConfigureContainer(IUnityContainer container);

        /// <summary>
        /// Creates a <see cref="T:System.ServiceModel.ServiceHost" /> for a specified type of service with a specific base address.
        /// </summary>
        /// <param name="serviceType">Specifies the type of service to host.</param>
        /// <param name="baseAddresses">The <see cref="T:System.Array" /> of type <see cref="T:System.Uri" /> that contains the base addresses for the service hosted.</param>
        /// <returns>
        /// A <see cref="T:System.ServiceModel.ServiceHost" /> for the type of service specified with a specific base address.
        /// </returns>
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            lock (this.containerLock)
            {
                if (container == null)
                {
                    container = new UnityContainer();
                    this.ConfigureContainer(container);
                }
            }

            return new UnityServiceHost(container, serviceType, baseAddresses);
        }
    }
}
