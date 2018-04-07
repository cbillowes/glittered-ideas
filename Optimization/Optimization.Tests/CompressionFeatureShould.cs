using System;
using NUnit.Framework;

namespace Optimization.Tests
{
    [TestFixture]
    public class CompressionFeatureShould
    {
        private Compressor _compressor;

        [SetUp]
        public void SetUp()
        {
            _compressor = new Compressor();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Break_when_the_input_does_not_exist()
        {
            string input = null;
            _compressor.Compress(input);
        }

        [Test]
        public void Give_back_an_empty_string_when_that_is_passed_in()
        {
            var input = string.Empty;
            var actual = _compressor.Compress(input);
            Assert.That(actual, Is.Empty);
        }

        [Test]
        public void Give_back_the_first_character_and_its_number_when_only_one_character_is_supplied()
        {
            const string input = "a";
            var actual = _compressor.Compress(input);
            Assert.That(actual, Is.EqualTo("a1"));
        }

        [Test]
        public void Give_back_a_compressed_string_when_the_input_is_valid()
        {
            const string input = "aabbbcccccaa";
            var actual = _compressor.Compress(input);
            Assert.That(actual, Is.EqualTo("a2b3c5a2"));
        }
    }
}
