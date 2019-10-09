﻿// ***********************************************************************
// Assembly         : dotNetTips.Utility.Standard
// Author           : David McCarter
// Created          : 06-06-2018
//
// Last Modified By : David McCarter
// Last Modified On : 10-04-2019
// ***********************************************************************
// <copyright file="LoggableException.cs" company="dotNetTips.com - David McCarter">
//     McCarter Consulting (David McCarter)
// </copyright>
// <summary></summary>
// ***********************************************************************
using dotNetTips.Utility.Standard.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Permissions;
using System.Text;

namespace dotNetTips.Utility.Standard
{
    /// <summary>
    /// Class LoggableException.
    /// </summary>
    /// <seealso cref="System.Exception" />
    /// <seealso cref="System.Xml.Serialization.IXmlSerializable" />
    [Serializable]
    public class LoggableException : Exception
    {
        /// <summary>
        /// The exception has been logged
        /// </summary>
        private bool _hasBeenLogged;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggableException" /> class.
        /// </summary>
        public LoggableException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggableException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public LoggableException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggableException" /> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public LoggableException(string message, Exception innerException) : base(message, innerException)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="LoggableException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="ex">The ex.</param>
        /// <param name="userMessage">The user message.</param>

        public LoggableException(string message, Exception ex, string userMessage) : base(message, ex)
        {
            this.UserMessage = userMessage;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggableException" /> class.
        /// </summary>
        /// <param name="serializationInfo">The serialization information.</param>
        /// <param name="streamingContext">The streaming context.</param>
        /// <exception cref="System.NotImplementedException">The exception.</exception>
        /// <exception cref="NotImplementedException">The exception.</exception>
        protected LoggableException(SerializationInfo serializationInfo, StreamingContext streamingContext)
         : base(serializationInfo, streamingContext)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has been logged.
        /// </summary>
        /// <value><c>true</c> if this instance has been logged; otherwise, <c>false</c>.</value>
        public bool HasBeenLogged
        {
            get
            {
                return this._hasBeenLogged;
            }

            set
            {
                // Prevent from being set (from code) to false.
                if (value == true)
                {
                    this._hasBeenLogged = value;
                }
            }
        }

        /// <summary>
        /// Gets Excpetion message, including inner Exceptions.
        /// </summary>
        /// <value>The messages.</value>
        public virtual IEnumerable<string> Messages
        {
            get
            {
                var exceptions = LoggingHelper.RetrieveAllExceptions(this);
                var errorMessages = new List<string>();

                exceptions.ForEach(current =>
                {
                    errorMessages.Add(current.GetType().FullName);
                    errorMessages.Add(ReflectException(current));

                    if (current.StackTrace != null)
                    {
                        errorMessages.Add(current.StackTrace);
                    }
                });

                return errorMessages;
            }
        }

        /// <summary>
        /// Gets or sets the user message.
        /// </summary>
        /// <value>The user message.</value>
        /// <returns>string.</returns>
        public virtual string UserMessage { get; private set; }

        /// <summary>
        /// When overridden in a derived class, sets the <see cref="T:System.Runtime.Serialization.SerializationInfo" /> with information about the exception.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue(nameof(this.UserMessage), this.UserMessage);
        }

        /// <summary>
        /// Returnes a list of properties and their value.
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <returns>System.String.</returns>
        private static string ReflectException(Exception ex)
        {
            var sb = new StringBuilder();

            var properties = ex.GetType().GetRuntimeProperties().ToList();

            properties.ForEach(current =>
            {
                object objectValue = null;

                try
                {
                    objectValue = RuntimeHelpers.GetObjectValue(current.GetValue(ex, null));
                }
                catch (SecurityException securityEx)
                {
                    Trace.WriteLine(securityEx);
                }

                if ((objectValue != null) && (objectValue.ToString() != objectValue.GetType().FullName))
                {
                    sb.AppendLine(string.Format(CultureInfo.CurrentCulture, "{0}: {1}", new object[] { current.Name, RuntimeHelpers.GetObjectValue(current) }));
                }
            });

            return sb.ToString();
        }
    }
}
