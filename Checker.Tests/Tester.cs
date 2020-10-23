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

        [Test]
        public void Should_succeed_with_tricky_fiscalcode_PAUFNC62D15M030X()
        {
            Assert.That(Checker.IsFormallyValid("PAUFNC62D15M030X"), Is.False);
        }

        [Test]
        public void Should_succeed_with_tricky_fiscalcode_MRGRRT65D30F050H()
        {
            Assert.That(Checker.IsFormallyValid("MRGRRT65D30F050H"), Is.False);
        }

        [Test]
        public void Should_succeed_with_tricky_fiscalcode_FRASRA77A20F050T()
        {
            Assert.That(Checker.IsFormallyValid("FRASRA77A20F050T"), Is.False);
        }
    }
}