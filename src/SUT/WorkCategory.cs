using System;

namespace SUT
{
    public class WorkCategory
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

        public WorkCategory(string name)
        {
            Id = GetCleanedStringForId(DateTime.Now, name);
            Timezone = TimeZone.CurrentTimeZone.StandardName;
            if (FirstServiceUnitOfTheDay == DateTime.MinValue)
                FirstServiceUnitOfTheDay = DateTime.Now;
            Name = name;
        }

        public void AddServiceUnit()
        {
            if (LastRecordedServiceUnitOfTheDay.AddMinutes(OneServiceUnitInMinutes) < DateTime.Now)
            {
                TotalServiceUnits++;
                LastRecordedServiceUnitOfTheDay = DateTime.Now;
            }
        }

        private string GetCleanedStringForId(DateTime dateTime, string name)
        {
            return string.Format("{0}-{1}", dateTime.ToString("yyyyMMdd"), name.ToUpper().Replace(" ","-")); 
        }
    }
}