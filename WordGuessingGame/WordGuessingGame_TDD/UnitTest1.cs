using System;
using Xunit;
using static WordGuessingGame.Program;

namespace WordGuessingGame_TDD
{
    public class UnitTest1
    {
        [Fact]
        public void TestWithTwoOutOfFourLettersGuessed()
        {
            // Arrange
            char[] letters = { 'w', 'o', 'r', 'd' };
            char[] guessLetters = { 'w', '_', 'r', '_' };

            // Act
            int check = CheckForWin(letters, guessLetters);
            // Assert
            Assert.Equal(2, check);
        }

        [Fact]
        public void TestWithThreeOutOfFourLettersGuessed()
        {
            // Arrange
            char[] letters = { 'w', 'o', 'r', 'd' };
            char[] guessLetters = { 'w', '_', 'r', 'd' };

            // Act
            int check = CheckForWin(letters, guessLetters);
            // Assert
            Assert.Equal(3, check);
        }

        [Fact]
        public void TestWithZeroOutOfFourLettersGuessed()
        {
            // Arrange
            char[] letters = { 'w', 'o', 'r', 'd' };
            char[] guessLetters = { '_', '_', '_', '_' };

            // Act
            int check = CheckForWin(letters, guessLetters);
            // Assert
            Assert.Equal(0, check);
        }

        [Fact]
        public void TestWithOneOutOfFourLettersGuessed()
        {
            // Arrange
            char[] letters = { 'w', 'o', 'r', 'd' };
            char[] guessLetters = { '_', 'o', '_', '_' };

            // Act
            int check = CheckForWin(letters, guessLetters);
            // Assert
            Assert.Equal(1, check);
        }

        [Fact]
        public void TestWithFourOutOfFourLettersGuessed()
        {
            // Arrange
            char[] letters = { 'w', 'o', 'r', 'd' };
            char[] guessLetters = { 'w', 'o', 'r', 'd' };

            // Act
            int check = CheckForWin(letters, guessLetters);
            // Assert
            Assert.Equal(4, check);
        }

        [Fact]
        public void ReadWordsInList()
        {
            // Arrange
            string path = "../../../../WordGuessingGame_TDD/word.txt";

            // Act
            string[] word = ReadWordList(path);

            // Assert
            Assert.Equal("auto" , word[0]);

        }

        [Fact]
        public void AddWordsToList()
        {
            // Arrange
            string path = "../../../../WordGuessingGame_TDD/word.txt";
            string addWord = "puppy";

            // Act
            AddWord(path, addWord);
            string[] word = ReadWordList(path);

            // Assert
            Assert.Equal("puppy", word[1]);

        }

        [Fact]
        public void RemoveWordsFromList()
        {
            // Arrange
            string path = "../../../../WordGuessingGame_TDD/word.txt";
            string removeWord = "puppy";

            // Act
            DeleteWord(path, removeWord);
            string[] word = ReadWordList(path);

            // Assert
            Assert.NotEqual("puppy", word[1]);

        }
    }
}
