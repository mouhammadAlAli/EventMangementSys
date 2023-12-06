﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class ApplicationException : Exception
    {
        public ApplicationException():base("Application exception")
        {

        }
        public ApplicationException(string message) : base(message)
        {
        }
    }
}
