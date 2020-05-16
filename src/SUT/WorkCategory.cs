using System;

namespace SUT
{
    class WorkCategory
    {
        public string Id { get; }
        public string Timezone { get; }
        public DateTime FirstServiceUnitOfTheDay { get; set; }
        public DateTime LastRecordedServiceUnitOfTheDay { get; set; }
#if DEBUG
        public double OneServiceUnitInMinutes { get; set; } = 2;
#else
        public double OneServiceUnitInMinutes { get; set; } = 15;
#endif
        public string Name { get; set; }
        public int TotalServiceUnits { get; set; }

        public WorkCategory()
        {
            Id = DateTime.Now.ToString("yyyyMMdd");
            Timezone = TimeZone.CurrentTimeZone.StandardName;
            if (FirstServiceUnitOfTheDay == DateTime.MinValue)
                FirstServiceUnitOfTheDay = DateTime.Now;
        }

        public void AddServiceUnit()
        {
            if (LastRecordedServiceUnitOfTheDay.AddMinutes(OneServiceUnitInMinutes) < DateTime.Now)
            {
                TotalServiceUnits++;
                LastRecordedServiceUnitOfTheDay = DateTime.Now;
            }
        }
    }
}