using System;

namespace ExpressEntryCalculator.Api.Services
{
    public interface ISystemTime
    {
        DateTime UtcNow { get; }
    }

    public class SystemTime : ISystemTime
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
