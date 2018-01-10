using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

namespace Donger.BuckeyeEngine.UnitTests{
	[TestFixture]
	public class CalendarTests {

		[Test]
		[TestCase(2000, 10, 1, 11)]
		[TestCase(2000, 12, 1, 1)]
		[TestCase(2000, 1, 1, 2)]
		public void Date_ForwardMonth_ReturnsCorrectMonth(int year, int month, int day, int result)
		{
			var date = new Date(year, month, day);
			date.ForwardMonth();
			Assert.AreEqual(result, date.Month);
		}

		[Test]
		[TestCase(2000, 10, 1, 9)]
		[TestCase(2000, 12, 1, 11)]
		[TestCase(2000, 1, 1, 12)]
		public void Date_BackMonth_ReturnsCorrectMonth(int year, int month, int day, int result)
		{
			var date = new Date(year, month, day);
			date.BackMonth();
			Assert.AreEqual(result, date.Month);
		}
		
		[Test]
		[TestCase(2000, 10, 1, 2000)]
		[TestCase(2000, 12, 1, 2001)]
		[TestCase(2000, 1, 1, 2000)]
		public void Date_ForwardMonth_ReturnsCorrectYear(int year, int month, int day, int result)
		{
			var date = new Date(year, month, day);
			date.ForwardMonth();
			Assert.AreEqual(result, date.Year);
		}

		[Test]
		[TestCase(2000, 10, 1, 2000)]
		[TestCase(2000, 12, 1, 2000)]
		[TestCase(2000, 1, 1, 1999)]
		public void Date_BackMonth_ReturnsCorrectYear(int year, int month, int day, int result)
		{
			var date = new Date(year, month, day);
			date.BackMonth();
			Assert.AreEqual(result, date.Year);
		}
	}
}

