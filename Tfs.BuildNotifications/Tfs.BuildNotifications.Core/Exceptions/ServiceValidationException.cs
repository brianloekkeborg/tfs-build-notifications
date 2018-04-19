﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tfs.BuildNotifications.Core.Exceptions
{
    public class ServiceValidationException : Exception
    {
        public List<string> ServiceErrors { get; set; }
        public Exception OriginalException { get; set; }

        public ServiceValidationException(string error, Exception originalException = null)
            : base(originalException != null ? originalException.Message : null)
        {
            ServiceErrors = new List<string> { error };
            OriginalException = originalException;
        }

        public ServiceValidationException(List<string> errors)
        {
            ServiceErrors = errors;
        }

        public ServiceValidationException(Exception e)
        {
            OriginalException = e;
        }

		public override string Message => ToString();

		public override string ToString()
		{
			var s = new StringBuilder("ServiceValidationException: ");

			foreach (var error in ServiceErrors)
			{
				s.Append($"Error: {error}. ");
			}

			s.Append($"Original exception: {OriginalException?.ToString() ?? "<null>"}");

			return s.ToString();
		}
	}
}
