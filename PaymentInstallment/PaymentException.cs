using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PaymentInstallment
{
    internal class PaymentException : Exception
    {
        public PaymentException()
        {
        }

        public PaymentException(string? message) : base(message)
        {
        }

        public PaymentException(string? message, Exception? innerException) : base(message, innerException)
        {
        }


    }
}
