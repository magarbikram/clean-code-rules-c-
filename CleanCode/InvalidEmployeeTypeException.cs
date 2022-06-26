using System.Runtime.Serialization;

namespace CleanCode
{
    [Serializable]
    internal class InvalidEmployeeTypeException : Exception
    {
        private EmployeeType type;

        public InvalidEmployeeTypeException()
        {
        }

        public InvalidEmployeeTypeException(EmployeeType type)
        {
            this.type = type;
        }

        public InvalidEmployeeTypeException(string? message) : base(message)
        {
        }

        public InvalidEmployeeTypeException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidEmployeeTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}