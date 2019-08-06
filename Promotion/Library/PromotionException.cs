using System;
using System.Runtime.Serialization;

namespace Promotion.Library
{
    [Serializable]
    public class PromotionException : Exception
    {
        public PromotionException() { }

        public PromotionException(string message) : base(message) { }

        public PromotionException(string message, Exception innerException)
            : base(message, innerException) { }

        protected PromotionException(SerializationInfo info, in StreamingContext context)
            : base(info, context) { }
    }
}
