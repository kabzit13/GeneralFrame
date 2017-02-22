using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using Microsoft.Practices.Unity;

namespace GeneralFrame.Core.Wcf
{
    /// <summary>
    /// Represents the custom service host with Unity integration.
    /// </summary>
    public sealed class UnityServiceHost : ServiceHost
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnityServiceHost"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="baseAddresses">The base addresses.</param>
        /// <exception cref="System.ArgumentNullException">container</exception>
        public UnityServiceHost(IUnityContainer container, Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            if (container == null)
                throw new ArgumentNullException("container");
        
            this.ApplyServiceBehaviors(container);

            this.ApplyContractBehaviors(container);

            foreach (var contractDescription in this.ImplementedContracts.Values)
            {
                var contractBehavior =
                    new UnityContractBehavior(new UnityInstanceProvider(container, contractDescription.ContractType));

                contractDescription.Behaviors.Add(contractBehavior);
            }
        }

        /// <summary>
        /// Applies the contract behaviors.
        /// </summary>
        /// <param name="container">The container.</param>
        private void ApplyContractBehaviors(IUnityContainer container)
        {
            var registeredContractBehaviors = container.ResolveAll<IContractBehavior>();

            foreach (var contractBehavior in registeredContractBehaviors)
            {
                foreach (var contractDescription in this.ImplementedContracts.Values)
                    contractDescription.Behaviors.Add(contractBehavior);
            }
        }

        /// <summary>
        /// Applies the service behaviors.
        /// </summary>
        /// <param name="container">The container.</param>
        private void ApplyServiceBehaviors(IUnityContainer container)
        {
            var registeredServiceBehaviors = container.ResolveAll<IServiceBehavior>();

            foreach (var serviceBehavior in registeredServiceBehaviors)
                this.Description.Behaviors.Add(serviceBehavior);
        }
    }
}
