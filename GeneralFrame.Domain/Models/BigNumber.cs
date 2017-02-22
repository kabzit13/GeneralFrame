using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using GeneralFrame.Model.Constants;

namespace GeneralFrame.Model.Models
{
    /// <summary>
    /// Represent big number that not fits to any .Net type
    /// </summary>
    [DataContract]
    public class BigNumber
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BigNumber"/> struct.
        /// </summary>
        /// <param name="sourceNumber">The source number.</param>
        public BigNumber(string sourceNumber)
        {
            if (string.IsNullOrEmpty(sourceNumber))
                throw new ArgumentNullException(nameof(sourceNumber), Errors.ParamIsNullOrEmpty);
            if (!IsDigitsOnly(sourceNumber))
                throw new ArgumentException(Errors.OnlyNumeric);
            this.SourceString = sourceNumber;
        }

        /// <summary>
        /// Gets or sets the source string.
        /// </summary>
        /// <value>The source string.</value>
        [DataMember]
        public string SourceString { get; private set; }


        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return this.SourceString;
        }

        /// <summary>
        /// To the int list.
        /// </summary>
        /// <returns>IEnumerable&lt;System.Int32&gt;.</returns>
        public IEnumerable<int> ToIntList()
        {
            var array = this.SourceString.ToCharArray();
            return array.Select(t => int.Parse(t.ToString()));
        }

        /// <summary>
        /// Determines whether [is digits only] [the specified source].
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>System.Boolean.</returns>
        private static bool IsDigitsOnly(string source)
        {
            //Add check for negative numbers.
            return source.All(character => character >= '0' && character <= '9');
        }
    }
}
