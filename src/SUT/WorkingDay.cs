using System;

namespace SUT
{
    class WorkingDay
    {        
        readonly int maximumNumberOfServiceUnits = 96; // One Service Unit == 15 minutes making one 24 hours period concist of a maximum of 96.

        TimeSpan timeSpanMorningStart = new TimeSpan(06, 0, 0);
        TimeSpan timeSpanMorningEnd = new TimeSpan(12, 0, 0);
        TimeSpan timeSpanAfternoonStart = new TimeSpan(12, 0, 0);
        TimeSpan timeSpanAfternoonEnd = new TimeSpan(18, 0, 0);
        TimeSpan timeSpanEveningStart = new TimeSpan(18, 0, 0);
        TimeSpan timeSpanEveningEnd = new TimeSpan(23, 0, 0);
        TimeSpan timeSpanNightStart = new TimeSpan(23, 0, 0);
        TimeSpan timeSpanNightEnd = new TimeSpan(06, 0, 0);

        public string Id { get; }
        public string Timezone { get; }
        public DateTime FirstServiceUnitOfTheDay { get; set; }
        public DateTime LastRecordedServiceUnitOfTheDay { get; set; }
#if DEBUG
        public double OneServiceUnitInMinutes { get; set; } = 2;
#else
        public double OneServiceUnitInMinutes { get; set; } = 15;
#endif
        public int TotalServiceUnitsMorning { get; set; }
        public int TotalServiceUnitsAfternoon { get; set; }
        public int TotalServiceUnitsEvening { get; set; }
        public int TotalServiceUnitsNight { get; set; }

        public WorkingDay()
        {
            Id = DateTime.Now.ToString("yyyyMMdd");
            Timezone = TimeZone.CurrentTimeZone.StandardName;
            if (FirstServiceUnitOfTheDay == DateTime.MinValue)
                FirstServiceUnitOfTheDay = DateTime.Now;
            //AddServiceUnit();
        }

        public int TotalServiceUnits()
        {
            return TotalServiceUnitsMorning + TotalServiceUnitsAfternoon + TotalServiceUnitsEvening + TotalServiceUnitsNight;
        }

        public TimeSpan TotalTime()
        {
            var duration = TimeSpan.Zero;
            duration = TimeSpan.FromMinutes(OneServiceUnitInMinutes);
            duration = TimeSpan.FromTicks(duration.Ticks * TotalServiceUnits());
            return duration;
        }

        public void AddServiceUnit()
        {
            if (maximumNumberOfServiceUnits > TotalServiceUnits() && LastRecordedServiceUnitOfTheDay.AddMinutes(OneServiceUnitInMinutes) < DateTime.Now)
            {
                var now = DateTime.Now.TimeOfDay;
                if ((now > timeSpanMorningStart) && (now < timeSpanMorningEnd))
                    TotalServiceUnitsMorning++;

                if ((now > timeSpanAfternoonStart) && (now < timeSpanAfternoonEnd))
                    TotalServiceUnitsAfternoon++;

                if ((now > timeSpanEveningStart) && (now < timeSpanEveningEnd))
                    TotalServiceUnitsEvening++;

                if ((now > timeSpanNightStart) || (now < timeSpanNightEnd))
                    TotalServiceUnitsNight++;

                LastRecordedServiceUnitOfTheDay = DateTime.Now;
            }
        }
    }
}