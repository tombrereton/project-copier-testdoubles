﻿using CopierProject;
using CopierProject.Interfaces;
using Moq;
using NUnit.Framework;

// ReSharper disable InconsistentNaming

namespace CopierTests
{
    // The character copier is a simple class that reads characters from a source and copies them to a destination one character at a time.

    // When the method Copy is called on the copier then it should read characters from the source and copy them to the 
    // destination until the source returns a newline (‘\n’). The exercise is to implement the character copier using
    // test doubles for the source and the destination try using mocks written
    // with a mocking framework. 

    public class CopierShould
    {
        private Mock<ISource> _source;
        private Mock<IDestination> _destination;
        private Copier _copier;

        [SetUp]
        public void Setup()
        {
            _destination = new Mock<IDestination>();
            _source = new Mock<ISource>();
            _copier = new Copier(_destination.Object, _source.Object);
        }

        [Test]
        public void CopiesCharacterFromSourceToDestination()
        {
            // This is creating a stub as it returns something
            _source.SetupSequence(m => m.GetChar())
                .Returns('a')
                .Returns('\n');

            _copier.Copy();

            // This is a mock as it is verifying a side effect
            _destination.Verify(m => m.SetChar('a'));
        }

        [Test]
        public void CopiesTwoCharactersFromSourceToDestination()
        {
            _source.SetupSequence(m => m.GetChar())
                .Returns('a')
                .Returns('b')
                .Returns('\n');

            _copier.Copy();

            _destination.Verify(m => m.SetChar('a'));
            _destination.Verify(m => m.SetChar('b'));
        }

        [Test]
        public void CopiesThreeCharactersFromSourceToDestination()
        {
            _source.SetupSequence(m => m.GetChar())
                .Returns('a')
                .Returns('b')
                .Returns('c')
                .Returns('\n');

            _copier.Copy();

            _destination.Verify(m => m.SetChar('a'));
            _destination.Verify(m => m.SetChar('b'));
            _destination.Verify(m => m.SetChar('c'));
        }

        [Test]
        public void CopiesThreeCharactersFromSourceToDestinationButTerminatesAtNewlineCharacter()
        {
            _source.SetupSequence(m => m.GetChar())
                .Returns('a')
                .Returns('b')
                .Returns('\n');

            _copier.Copy();

            _destination.Verify(m => m.SetChar('a'));
            _destination.Verify(m => m.SetChar('b'));
            _destination.Verify(m => m.SetChar('\n'), Times.Never);
        }
    }
}
