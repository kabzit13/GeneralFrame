using System.Runtime.Serialization;

namespace GeneralFrame.Model.Models
{
    [DataContract]
    public class CustomError
    {
        /// <summary>
        /// The message
        /// </summary>
        private string message;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomError"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public CustomError(string message)
        {
            this.message = message;
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        [DataMember]
        public string Message
        {
            get { return this.message; }
            set { this.message = value; }
        }
    }
}
