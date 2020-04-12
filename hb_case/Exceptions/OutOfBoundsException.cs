using System;
using System.Runtime.Serialization;

namespace hb_case.Exceptions
{
    [Serializable]
    public class OutOfBoundsException : Exception
    {
        public OutOfBoundsException() : base()
        {
        }
        public OutOfBoundsException(string message) : base(message)
        {
        }

        public OutOfBoundsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OutOfBoundsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
