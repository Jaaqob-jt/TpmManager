using System;
using Xunit;
using TpmManager.Models;

namespace TpmManager.Tests
{
    public class MachineTests : IDisposable
    {
        // Given
        public Machine _testMachine;
        public MachineTests()
        { 
            var testMachine = new Machine
            {
                Name = "xUnit",
                Location = "CLI",
                Description = "basic test of a model"
            };
            _testMachine = testMachine;
        }
        public void Dispose() => _testMachine = null;

        [Fact]
        public void CanChangeName()
        {
            //When
            _testMachine.Name = "Twoja stara";    
            //Then
            Assert.Equal("Twoja stara", _testMachine.Name);
        }

        [Fact]
        public void CanChangeLocation()
        {
            //When
            _testMachine.Location = "Narnia";
            //Then
            Assert.Equal("Narnia", _testMachine.Location);
        }

        [Fact]
        public void CanChangeDescription()
        {
            //When
            _testMachine.Description = "Non-descriptive";
            //Then
            Assert.Equal("Non-descriptive", _testMachine.Description);
        }
        
    }
}