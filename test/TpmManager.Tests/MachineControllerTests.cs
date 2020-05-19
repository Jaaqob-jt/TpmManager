using System;
using Xunit;
using TpmManager.Controllers;
using TpmManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Collections.Generic;

namespace TpmManager.Tests
{
    public class MachineControllerTests : IDisposable
    {
        #region Setup
        DbContextOptionsBuilder<TpmContext> optionsBuilder;
        TpmContext dBContext;
        MachinesController controller;
        public MachineControllerTests()
        {         
            //Arrange
            //DBContext
            optionsBuilder = new DbContextOptionsBuilder<TpmContext>();
            optionsBuilder.UseInMemoryDatabase("UnitTestInMemDB");
            dBContext = new TpmContext(optionsBuilder.Options);

            //Controller
            controller = new MachinesController(dBContext);
   
        }
        public void Dispose()
        {
            optionsBuilder = null;
            foreach (var item in dBContext.Machines)
            {
                dBContext.Machines.Remove(item);
            }
            foreach (var post in dBContext.Posts)
            {
                dBContext.Posts.Remove(post);
            }
            foreach (var media in dBContext.Medias)
            {
                dBContext.Medias.Remove(media);
            }
            dBContext.SaveChanges();
            dBContext.Dispose();
            controller = null;
        }
        #endregion

        #region PassedTests
        [Fact]
        public void GetMachines_ReturnZeroItems_WhenDBIsEmpty()
        {
            //ACT
            var result = controller.GetMachines();

            //ASSERT
            Assert.Equal(null, result.Value);
        }
        [Fact]
        public void GetMachines_ReturnOneItem_DBHasOneObj()
        {
        //Given
        Machine testMachine = new Machine
        {
            Name = "xUnit",
            Location = "CLI",
            Description = "basic test of a model"
        };

        dBContext.Add(testMachine);
        dBContext.SaveChanges();
        
        //When
        var result = controller.GetMachines();
        //Then
        Assert.Single(result.Value);
        }
        [Fact]
        public void GetMachines_ReturnMultipleItems_DBHasMoreObj()
        {
        //Given
        Machine testMachine = new Machine
        {
            Name = "xUnit",
            Location = "CLI",
            Description = "basic test of a model"
        };
        Machine testMachine2 = new Machine
        {
            Name = "xUSnit",
            Location = "CLIS",
            Description = "basiSc test of a model"
        };
        dBContext.Add(testMachine);
        dBContext.Add(testMachine2);
        dBContext.SaveChanges();
        
        //When
        var result = controller.GetMachines();
        //Then
        Assert.True(result.Value.Count() > 1);
        }
        [Fact]
        public void GetMachines_ReturnMachineType()
        {
        //Given
        
        //When
        var result = controller.GetMachines();
        //Then
        Assert.IsType<ActionResult<IEnumerable<Machine>>>(result);
        }
        [Fact]
        public void GetMachines_ReturnNull_InvalidID()
        {
        //Given
        
        //When
        var result = controller.GetSingleMachine(0);
        //Then
        Assert.Null(result.Value);
        }
        [Fact]
        public void GetMachines_ReturnNotFound_InvalidID()
        {
        //Given
        
        //When
        var result = controller.GetSingleMachine(0);
        //Then
        Assert.IsType<NotFoundResult>(result.Result);
        }
        [Fact]
        public void GetMachinesPosts_ReturnListOfPostsType()
        {
        //Given
        
        //When
        var result = controller.GetMachinePosts(1);
        //Then
        Assert.IsType<ActionResult<IEnumerable<Post>>>(result);
        }
        [Fact]
        public void GetMachinePosts_ReturnNotFound_DBIsEmpty()
        {
        //Given
        Machine testMachine = new Machine
        {
            Name = "xUnit",
            Location = "CLI",
            Description = "basic test of a model"
        };
        Machine testMachine2 = new Machine
        {
            Name = "xUSnit",
            Location = "CLIS",
            Description = "basiSc test of a model"
        };
        dBContext.Add(testMachine);
        dBContext.Add(testMachine2);
        dBContext.SaveChanges();
        //When
        var result = controller.GetMachinePosts(1);
        //Then
        Assert.Equal(null, result.Value);
        }
        
        #endregion

        #region UpcomingTests
        // Strona 144

        #endregion
        
    }
}