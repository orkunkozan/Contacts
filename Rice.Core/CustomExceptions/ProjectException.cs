using Rice.Core.CustomExceptions.Base;
using System.Runtime.Serialization;

namespace Rice.Core.CustomExceptions
{
    [Serializable]
    public sealed class ProjectException : CustomException
    {
        public ProjectException()
        {

        }
        public ProjectException(string message)
      : base(message)
        {
        }

        public ProjectException(string message, Exception inner)
            : base(message, inner)
        {
        }

        private ProjectException(SerializationInfo info, StreamingContext context)
  : base(info, context)
        {
        } 
    }
}
