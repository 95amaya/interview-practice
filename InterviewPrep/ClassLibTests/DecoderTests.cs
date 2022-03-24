using ClassLib;
using FluentAssertions;
using System;
using Xunit;

namespace ClassLibTests
{
    public class DecoderTests
    {
        private readonly IDecoder _Decoder;
        
        public DecoderTests()
        {
            _Decoder = new Decoder();
        }

        [Theory]
        [InlineData("a", "a")]
        [InlineData("2[a]", "aa")]
        public void Decoder_Decodes_Successfully(string encodedStr, string expectedDecodedStr)
        {
            // Arrange

            // Act
            var decodedStr = _Decoder.Decode(encodedStr);

            // Assert
            decodedStr.Should().BeEquivalentTo(expectedDecodedStr);
        }
    }
}
