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

        #region MockObjects
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
        Post testPost = new Post
        {
            Type = "TestType",
            Content = "post.Content - Test",
            Author = "John Doe"
        };

        #endregion
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
        dBContext.Machines.Add(testMachine);
        dBContext.Machines.Add(testMachine2);
        dBContext.SaveChanges();
        //When
        var result = controller.GetMachinePosts(1);
        //Then
        Assert.Equal(null, result.Value);
        }
        
        [Fact]
        public void PostMachine_MachineCountUps_WhenValidObj()
        {
        //Given
        var oldCount = dBContext.Machines.Count();
        //When
        var result = controller.PostNewMachine(testMachine);
        
        //Then
        Assert.Equal(++oldCount, dBContext.Machines.Count());
        }

        [Fact]
        public void PostNewMachine_Return201_WhenCreatingObj()
        {
        //Given
        
        //When
        var result = controller.PostNewMachine(testMachine);
        //Then
        Assert.IsType<CreatedAtActionResult>(result.Result);
        }
        #endregion
        [Fact]
        public void PostNextPost_PostCountUps_WhenValidObj()
        {
        //Given

        dBContext.Machines.Add(testMachine);
        dBContext.SaveChanges();
        
        var oldCount = dBContext.Posts.Count();
        //When
        var result = controller.PostNextPost(testPost, testMachine.MachineId);
        
        //Then
        Assert.Equal(++oldCount, dBContext.Posts.Count());
        }

        [Fact]
        public void PostNextPost_Return201_WhenCreatingObj()
        {
        //Given
        dBContext.Add(testMachine);
                
        //When
        var result = controller.PostNextPost(testPost, testMachine.MachineId);
        //Then
        Assert.IsType<CreatedAtActionResult>(result.Result);
        }
        
        #region TDD-PutCommand

        // Tests to do
        // - valid object submitted = attribute updated
        // - valid object submitted = 204
        // - invalid object submitted = 400 Bad Request
        // - invalid object submitted = Object not changed

        [Fact]
        public void PutMachine_ValidObj_UpdatedOK()
        {
        //Given
        dBContext.Machines.Add(testMachine);
        dBContext.SaveChanges();

        var machId = testMachine.MachineId;
        testMachine.Description = "UPDATED";

        //When
        controller.PutMachine(machId, testMachine);
        var result = dBContext.Machines.Find(machId);
        //Then
        Assert.Equal(testMachine.Description, result.Description);

        }

        [Fact]
        public void PutMachine_ValidObj_204()
        {
        //Given
        dBContext.Machines.Add(testMachine);
        dBContext.SaveChanges();

        var machId = testMachine.MachineId;
        testMachine.Description = "UPDATED";

        //When
        var result = controller.PutMachine(machId, testMachine);
        
        //Then
        Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void PutMachine_InvObj_400()
        {
        //Given
        dBContext.Machines.Add(testMachine);
        dBContext.SaveChanges();

        var mId = testMachine.MachineId;

        testMachine.Description = "UPDATED";

        //When
        var result = controller.PutMachine(++mId, testMachine);
        //Then
        Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void PutMachine_InvObj_NoChange()
        {
        //Given
        dBContext.Machines.Add(testMachine);
        dBContext.SaveChanges();

        var mId = testMachine.MachineId;

        testMachine.Description = "UPDATED";

        //When
        controller.PutMachine(++mId, testMachine);
        var result = dBContext.Machines.Find(testMachine.MachineId);
        //Then
        Assert.Equal(testMachine.Description, result.Description);
        }
        #endregion

        #region TDD-DELETE

        // Tests to do
        // - valid id submitted = count decrements by 1
        // - valid id submitted = 200
        // - invalid id submitted = 400 Bad Request
        // - invalid id submitted = Object not changed
        
        [Fact]
        public void DeleteMachine_ValidId_CountDecrem()
        {
        //Given
        dBContext.Machines.Add(testMachine);
        dBContext.Machines.Add(testMachine2);
        dBContext.SaveChanges();
        var machineCount = dBContext.Machines.Count();
        //When
        var result = controller.DeleteMachineById(testMachine.MachineId);
        //Then
        Assert.Equal(machineCount - 1, dBContext.Machines.Count());
        }

        [Fact]
        public void DeleteMachine_ValidId_200()
        {
        //Given
        dBContext.Machines.Add(testMachine);
        dBContext.Machines.Add(testMachine2);
        dBContext.SaveChanges();
        //When
        var result = controller.DeleteMachineById(testMachine.MachineId);
        //Then
        Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void DeleteMachine_InvId_400()
        {
        //Given

        //When
        var result = controller.DeleteMachineById(1);
        //Then
        Assert.IsType<BadRequestResult>(result);
        }
        [Fact]
        public void DeleteMachine_InvId_ObjCountNotChanged()
        {
        //Given
        dBContext.Machines.Add(testMachine);
        dBContext.Machines.Add(testMachine2);
        dBContext.SaveChanges();
        var objCount = dBContext.Machines.Count();
        //When
        var result = controller.DeleteMachineById(17);
        //Then
        Assert.Equal(objCount, dBContext.Machines.Count());
        }

        #endregion
    }
}