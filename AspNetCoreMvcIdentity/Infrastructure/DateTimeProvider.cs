using System;
using AspNetCoreMvcIdentity.Application.Common.Interfaces;

namespace AspNetCoreMvcIdentity.Infrastructure
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.Now;
    }
}
