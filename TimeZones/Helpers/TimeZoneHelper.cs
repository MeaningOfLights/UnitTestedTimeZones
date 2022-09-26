using System;
using System.Reflection;
using System.Resources;

namespace TimeZones.Helpers
{
    public static class TimeZoneHelper
    {
        public static DateTime DateFromAEST(DateTime AESTDateTime, TimeZoneInfo targetTimeZoneInfo)
        {
            // Convert AEST DateTime to UTC - TODO remove hardcoded AEST timezone
            var utcOfAEST = TimeZoneInfo.ConvertTimeToUtc(AESTDateTime, TimeZoneInfo.FindSystemTimeZoneById("AUS Eastern Standard Time"));

            // Convert UTC DateTime to Target TimeZone
            var dateTimeInTargetTimeZone = TimeZoneInfo.ConvertTimeFromUtc(utcOfAEST, targetTimeZoneInfo);

            return dateTimeInTargetTimeZone;
        }

        public static DateTime DateToAEST(DateTime foreignDateTime, TimeZoneInfo sourceTimeZoneInfo)
        {
            // Convert source DateTime to UTC
            var utcOfSource = TimeZoneInfo.ConvertTimeToUtc(foreignDateTime, sourceTimeZoneInfo);

            // Convert UTC DateTime to AEST TimeZone - TODO remove hardcoded AEST timezone
            var dateTimeInSourceTimeZone = TimeZoneInfo.ConvertTimeFromUtc(utcOfSource, TimeZoneInfo.FindSystemTimeZoneById("AUS Eastern Standard Time"));

            return dateTimeInSourceTimeZone;
        }
    }
}

