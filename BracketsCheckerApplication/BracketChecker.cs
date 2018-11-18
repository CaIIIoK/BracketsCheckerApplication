using System;

namespace BracketsCheckerApplication
{
    class RoundBracketsChecker
    {
        private const char leftRoundBracketCharacter = '(';
        private const char rightRoundBracketCharacter = ')';
        private const char caretCharacter = '^';
        private const char spaceCharacter = ' ';
        private const string emptyValue = "";

        private string input;
        // Boolean variable select incorrect formula and print it to output.txt
        private bool needToPrint = false;

        public RoundBracketsChecker(string inputValue)
        {
            input = inputValue;
        }

        public string Check()
        {
            int maxStackSize = input.Length;
            Stack theStack = new Stack(maxStackSize);
            // An array with spaces and mistakes highlightes by '^' character.
            char[] mistakesArray = new char[input.Length];
            FillSpaces(mistakesArray);

            // Get characters from string
            for (int charsCounter = 0; charsCounter < input.Length; charsCounter++)
            {
                char characterFromTheString = input[charsCounter];
                switch (characterFromTheString)
                {
                    // Opening symbols
                    case leftRoundBracketCharacter:
                        theStack.Push(characterFromTheString);
                        break;
                    // Closing symbols
                    case rightRoundBracketCharacter:
                        if (!theStack.IsEmpty())
                        {
                            // Pop and check
                            char characterFromTheTopOfStack = theStack.Pop();
                            if ((characterFromTheString == rightRoundBracketCharacter 
                                && characterFromTheTopOfStack != leftRoundBracketCharacter))
                                mistakesArray[charsCounter] = caretCharacter;
                        }
                        // prematurely empty
                        else
                        {
                            mistakesArray[charsCounter] = caretCharacter;
                            needToPrint = true;
                        }
                        break;
                    default:
                        break;

                }
            }

            // If stack is not empty, we will begin to check closing brackets with opening ones
            // This time we will begin from end of the formula
            if (!theStack.IsEmpty())
            {
                theStack = new Stack(maxStackSize);
                for (int charsCounter = input.Length - 1; charsCounter >= 0; charsCounter--)
                {

                    char characterFromTheString = input[charsCounter];
                    switch (characterFromTheString)
                    {
                        // Closing symbols
                        case rightRoundBracketCharacter:
                            theStack.Push(characterFromTheString);
                            break;
                        // Opening symbols
                        case leftRoundBracketCharacter:
                            // If stack not empty,
                            if (!theStack.IsEmpty())
                            {
                                // Pop and check
                                char characterFromTheTopOfStack = theStack.Pop();
                                if ((characterFromTheString == leftRoundBracketCharacter 
                                    && characterFromTheTopOfStack != rightRoundBracketCharacter))
                                    mistakesArray[charsCounter] = caretCharacter;
                            }
                            else 
                                mistakesArray[charsCounter] = caretCharacter;
                                needToPrint = true;
                            break;
                        default:
                            break;
                    }
                }
            }

            if (needToPrint)
                return input + Environment.NewLine + CreateStringWithHighlightsOfMistakes(mistakesArray);
            else
                return emptyValue;
        }

        // Method that returns string with highlihts of the mistakes
        public string CreateStringWithHighlightsOfMistakes(char[] inputMistakesArray)
        {
            string resultString = emptyValue;
            foreach (char singleCharInMistakesArray in inputMistakesArray)
            {
                resultString += singleCharInMistakesArray;
            }
            return resultString;
        }

        // Method fills an array of chars with spaces
        public char[] FillSpaces(char[] inputArrayOfChars)
        {
            for (int counter = 0; counter < inputArrayOfChars.Length; counter++)
            {
                inputArrayOfChars[counter] = spaceCharacter;
            }
            return inputArrayOfChars;
        }
    }
}
