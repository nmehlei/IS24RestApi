﻿using IS24;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace IS24RestApi
{
    /// <summary>
    /// Represents error that occur during interaction with the IS24 REST API.
    /// </summary>
    [Serializable]
    public class IS24Exception : Exception
    {
        /// <summary>
        /// Gets or sets the detailed error messages. See http://developerwiki.immobilienscout24.de/wiki/Status_codes for more.
        /// </summary>
        public messages Messages { get; set; }
        /// <summary>
        /// Initializes a new instance of the IS24Exception class.
        /// </summary>
        public IS24Exception() { }
        /// <summary>
        /// Initializes a new instance of the IS24Exception class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public IS24Exception(string message) : base(message) { }
        /// <summary>
        /// Initializes a new instance of the IS24Exception class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public IS24Exception(string message, Exception inner) : base(message, inner) { }
        /// <summary>
        /// Initializes a new instance of the Exception class with serialized data.
        /// </summary>
        /// <param name="info">The SerializationInfo that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The StreamingContext that contains contextual information about the source or destination.</param>
        protected IS24Exception(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
            Messages = (messages)info.GetValue("Messages", typeof(messages));
        }

        // see http://stackoverflow.com/a/100369

        /// <summary>
        /// Sets the SerializationInfo with information about the exception.
        /// </summary>
        /// <param name="info">The SerializationInfo that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The StreamingContext that contains contextual information about the source or destination.</param>
        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            info.AddValue("Messages", Messages, typeof(messages));

            // MUST call through to the base class to let it save its own state
            base.GetObjectData(info, context);
        }
    }
}
