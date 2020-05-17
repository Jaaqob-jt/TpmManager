using System;
using Xunit;
using TpmManager.Controllers;
using TpmManager.Models;
using Microsoft.EntityFrameworkCore;


namespace TpmManager.Tests
{
    public class MachineControllerTests
    {

        [Fact]
        public void GetMachines_ReturnZeroItems_WhenDBIsEmpty()
        {
            //Arrange
            //DBContext
            var optionsBuilder = new DbContextOptionsBuilder<TpmContext>();
            optionsBuilder.UseInMemoryDatabase("UnitTestInMemDB");
            var DBContext = new TpmContext(optionsBuilder.Options);

            //Controller
            var controller = new MachinesController(DBContext);

            //ACT
            var result = controller.GetMachines();

            //ASSERT
            Assert.Equal(null, result.Value);
        }

        // strona 135
        
    }
}