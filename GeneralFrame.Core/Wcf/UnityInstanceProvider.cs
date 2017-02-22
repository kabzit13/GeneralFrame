using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using Microsoft.Practices.Unity;

namespace GeneralFrame.Core.Wcf
{
    /// <summary>
    /// Represents the WCF-extention that creates WCF services through Unity IoC-container.
    /// </summary>
    public sealed class UnityInstanceProvider : IInstanceProvider
    {
        private readonly Type serviceType;
        private readonly IUnityContainer rootContainer;
        private readonly Dictionary<object, IUnityContainer> instacesWithContainers = new Dictionary<object, IUnityContainer>();

        /// <summary>
        /// Initializes a new instance of the <see cref="UnityInstanceProvider" /> class.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="rootContainer">The root IoC container.</param>
        /// <exception cref="System.ArgumentNullException">serviceType</exception>
        public UnityInstanceProvider(IUnityContainer rootContainer, Type serviceType)
        {
            if (serviceType == null)
                throw new ArgumentNullException("serviceType");

            if (rootContainer == null)
                throw new ArgumentNullException("rootContainer");

            this.serviceType = serviceType;
            this.rootContainer = rootContainer;
        }

        #region Implementation of IInstanceProvider

        /// <summary>
        /// Returns a service object given the specified <see cref="InstanceContext" /> object.
        /// </summary>
        /// <param name="instanceContext">The current <see cref="InstanceContext" /> object.</param>
        /// <returns>
        /// A user-defined service object.
        /// </returns>
        public object GetInstance(InstanceContext instanceContext)
        {
            return this.GetInstance(instanceContext, null);
        }

        /// <summary>
        /// Returns a service object given the specified <see cref="InstanceContext" /> object.
        /// </summary>
        /// <param name="instanceContext">The current <see cref="InstanceContext" /> object.</param>
        /// <param name="message">The message that triggered the creation of a service object.</param>
        /// <returns>
        /// The service object.
        /// </returns>
        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            var sessionContainer = this.rootContainer.CreateChildContainer();
            var serviceInstance = sessionContainer.Resolve(this.serviceType);

            lock (this.instacesWithContainers)
            {
                this.instacesWithContainers.Add(serviceInstance, sessionContainer);
            }

            return serviceInstance;
        }

        /// <summary>
        /// Called when an <see cref="InstanceContext" /> object recycles a service object.
        /// </summary>
        /// <param name="instanceContext">The service's instance context.</param>
        /// <param name="instance">The service object to be recycled.</param>
        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            IUnityContainer containerToRelease = null;
            lock (this.instacesWithContainers)
            {
                if (this.instacesWithContainers.ContainsKey(instance))
                {
                    containerToRelease = this.instacesWithContainers[instance];
                    this.instacesWithContainers.Remove(instance);
                }
            }

            if (containerToRelease != null)
                containerToRelease.Dispose();
        }

        #endregion
    }
}
