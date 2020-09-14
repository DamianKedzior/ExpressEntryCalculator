using ExpressEntryCalculator.Api.Services;
using System;

namespace ExpressEntryCalculator.AcceptanceTests
{
    public class TestSystemTime : ISystemTime
    {
        private readonly DateTime _utcNow;

        public TestSystemTime(DateTime utcNow)
        {
            _utcNow = utcNow;
        }

        public DateTime UtcNow => _utcNow;
    }
}
