using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Restaurants.Exceptions
{
    public class NotFoundCustomException : Exception
    {
        public NotFoundCustomException(): base() { }

        public NotFoundCustomException(string message) : base(message) { }

        public NotFoundCustomException(string message, Exception innerException) : base(message, innerException) { }

        public NotFoundCustomException(string resourceType, string resourceIdentifier) : base($"{resourceType} with {resourceIdentifier} doesn't exist") { }
    }
}
