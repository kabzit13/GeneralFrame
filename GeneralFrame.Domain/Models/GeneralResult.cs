using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;

namespace GeneralFrame.Model.Models
{
    /// <summary>
    /// Class GeneralResult.
    /// </summary>
    [DataContract]
    public class GeneralResult
    {
        /// <summary>
        /// The time stamp format
        /// </summary>
        public string timeStampFormat = "ddMMyyyyHH:mm:ss.ffffff";

        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralResult"/> class.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="bigNumber1">The big number1.</param>
        /// <param name="bigNumber2">The big number2.</param>
        /// <param name="timestamps">The timestamps.</param>
        /// <exception cref="System.ArgumentException">One of arguments is null</exception>
        public GeneralResult(BigNumber result, BigNumber bigNumber1, BigNumber bigNumber2, DateTime? timestamps = null)
        {
            if (result == null || bigNumber1 == null || bigNumber2 == null)
                throw new ArgumentException("One of arguments is null");

            this.Result = result;
            this.BigNumber1 = bigNumber1;
            this.BigNumber2 = bigNumber2;
            
            this.TimeStamp = timestamps?
                .ToString(this.timeStampFormat, CultureInfo.InvariantCulture) 
                ?? DateTime.Now.ToString(this.timeStampFormat, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets or sets the time stamp.
        /// </summary>
        /// <value>The time stamp.</value>
        [DataMember]
        public string TimeStamp { get; private set; }

        /// <summary>
        /// Gets the big number1.
        /// </summary>
        /// <value>The big number1.</value>
        [DataMember]
        public BigNumber BigNumber1 { get; private set; }

        /// <summary>
        /// Gets the big number2.
        /// </summary>
        /// <value>The big number2.</value>
        [DataMember]
        public BigNumber BigNumber2 { get; private set; }

        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <value>The result.</value>
        [DataMember]
        public BigNumber Result { get; private set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(this.TimeStamp)
                .Append(" ")
                .Append(this.BigNumber1)
                .Append(" ")
                .Append(this.BigNumber2)
                .Append(" ")
                .Append(this.Result)
                .Append(" ");

            return stringBuilder.ToString();
        }
    }
}
