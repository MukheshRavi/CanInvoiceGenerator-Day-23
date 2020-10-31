using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoice
{
    /// <summary>
    /// This class contain various Custom exceptions
    /// </summary>
        [Serializable]
        public class CabInvoiceException : Exception
        {
            public ExceptionType exceptionType;
            public enum ExceptionType
            {
                INVALID_RIDE_TYPE,
                INVALID_DISTANCE,
                INVALID_TIME,
                NULL_RIDES
            }
            public CabInvoiceException(ExceptionType exception, string message) : base(message)
            {
                this.exceptionType = exception;
            }
        }
}
