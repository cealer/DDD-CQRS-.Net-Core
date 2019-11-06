using System;

namespace EVALUACION.DOMAIN.Exceptions
{
    public class OCDomainException : Exception
    {
        public OCDomainException()
        { }

        public OCDomainException(string mensaje) : base(mensaje)
        { }

        public OCDomainException(string mensaje,
            Exception innerException) : base(mensaje, innerException)
        { }
    }
}
