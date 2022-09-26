using TimeZones.Helpers;
using System;
using NUnit.Framework;
using System.Collections;

namespace TimeZones.Tests
{
	[TestFixture]
	public class TimeZoneHelperTests
	{
		[TestCaseSource("GetDataFromCSVTimeZonesAEST")]
		public DateTime Should_Convert_From_AEST_To_OtherTimeZones(string timeZoneId, DateTime localAEST)
		{
			// Act
			var foreignDateTime = TimeZoneHelper.DateFromAEST(localAEST, TimeZoneInfo.FindSystemTimeZoneById(timeZoneId));

			//Assert
			return foreignDateTime;
		}

		private static IEnumerable GetDataFromCSVTimeZonesAEST()
		{
			CsvReader reader = new CsvReader("TestData\\TimeZones.csv");
			bool firstLineHeader = true;
			while (reader.Next())
			{
				if (firstLineHeader)
				{ 
					firstLineHeader = false;
					continue;
				}
				string regionTimeZoneId = reader[1].ToString();
				DateTime BaseAEST = DateTime.Parse(reader[2]);
				DateTime foreignDateTime = DateTime.Parse(reader[3]);
				yield return new TestCaseData(regionTimeZoneId, BaseAEST).Returns(foreignDateTime);
			}
		}


		//Vice Versa - the other direction...

		[TestCaseSource("GetDataFromCSVTimeZonesForeign")]
		public DateTime Should_Convert_From_OtherTimeZones_To_AEST(string timeZoneId, DateTime foreignDateTime)
		{
			// Act
			var localAEST = TimeZoneHelper.DateToAEST(foreignDateTime, TimeZoneInfo.FindSystemTimeZoneById(timeZoneId));

			//Assert
			return localAEST;
		}

		private static IEnumerable GetDataFromCSVTimeZonesForeign()
		{
			CsvReader reader = new CsvReader("TestData\\TimeZones.csv");
			bool firstLineHeader = true; 
			while (reader.Next())
			{
				if (firstLineHeader)
				{
					firstLineHeader = false;
					continue;
				}
				string regionTimeZoneId = reader[1].ToString();
				DateTime BaseAEST = DateTime.Parse(reader[2]);
				DateTime foreignDateTime = DateTime.Parse(reader[3]);
				yield return new TestCaseData(regionTimeZoneId, foreignDateTime).Returns(BaseAEST);
			}
		}
	}
}
