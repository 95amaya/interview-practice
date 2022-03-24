using System;
using System.Collections.Generic;

namespace ClassLib
{
    public interface IDecoder
    {
        string Decode(string encodedStr);
    }

    public class Decoder : IDecoder
    {
        public string Decode(string encodedStr)
        {
            var decodedStr = string.Empty;
            int charIndex = 0;
            var numStack = new Stack<int>();

            var firstEncodedExpressionIndx = encodedStr.IndexOf('[');

            while (firstEncodedExpressionIndx > 0)
            {
                var decodeNumAsStr = string.Empty;

                while (charIndex < firstEncodedExpressionIndx)
                {
                    var character = encodedStr[charIndex];

                    if (char.IsDigit(character))
                    {
                        decodeNumAsStr += character;
                    }
                    else
                    {
                        decodedStr += character;
                    }
                    charIndex++;
                }

                if (int.TryParse(decodeNumAsStr, out var decodeNum))
                {
                    numStack.Push(decodeNum);
                }
                else
                {
                    throw new InvalidOperationException($"Cannot parse integer:{decodeNumAsStr}");
                }

                firstEncodedExpressionIndx = encodedStr.IndexOf('[', charIndex);
            }

            if (charIndex >= 0 && charIndex < encodedStr.Length)
            {
                while(charIndex < encodedStr.Length)
                {
                    decodedStr += encodedStr[charIndex];
                    charIndex++;
                }
            }

            return decodedStr;
        }
    }
}
