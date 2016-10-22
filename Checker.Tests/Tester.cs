using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalCodeChecker.Tests
{
    [TestFixture]
	public class Tester
    {
		[Test]
		public void Should_succeed_with_author_fiscal_code()
		{
			Assert.That(Checker.IsFormallyValid("SPSMCL73T16L259D"), Is.True);
		}

		[Test]
		public void Should_succeed_with_invalid_author_fiscal_code()
		{
			Assert.That(Checker.IsFormallyValid("SPSMCL73T16L259E"), Is.False);
		}
    }
}
