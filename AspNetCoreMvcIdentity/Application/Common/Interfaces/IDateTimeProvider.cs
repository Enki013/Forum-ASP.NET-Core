using System;

namespace AspNetCoreMvcIdentity.Application.Common.Interfaces
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}
