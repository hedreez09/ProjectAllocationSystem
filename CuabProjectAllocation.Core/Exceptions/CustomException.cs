// Last Modified On 04-05-2022
// ***********************************************************
// <copyright file="CustomException.cs" company="Sheriff Olamilekan">
//  Copyright (c) Advansio Interactive. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuabProjectAllocation.Core.Exceptions
{
    /// <summary>
    /// CustomException Class.
    /// Implements the <see cref="System.Exception"/>
    /// </summary>
    public class CustomException: Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomExceptionHandler"/> class
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/></see> that holds the serialized object data about the exception been thrown</param>
        
        protected CustomException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context): 
            base(info, context)
        {
        }
            
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomExceptionHandler"/> class
        /// </summary>
        /// <param name="message">The message that describes the error. </param>
        public CustomException(string message): base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomExceptionHandler"/> class
        /// <param name="message">The error message that explains the reason for the exception</param>
        /// <param name="message">The exception that is the cause of the current exception, or a null reference, if no inner exception is specified</param>
        /// </summary>
        public CustomException(string message, Exception innerException): base(message, innerException)
        {
        }

    }
}
