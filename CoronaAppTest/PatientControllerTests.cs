using Microsoft.AspNetCore.Mvc.Testing;
using System;
using Xunit;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using CoronaApp.Services;
using PatientProject1.Controllers;

namespace CoronaApp.Test
{
    public class PatientControllerTests

    {
       readonly  Mock<ILocationService> _CoronaAppServiceMock = new();
        public PatientControllerTests()
        {
        }
        [Fact]

        public async void AddPatient_Success()//GetPatient_All_ReturnPatient
        {
        var locationToAdd = new Location() { PatientId = 1, City = "x", TheLocation = "y", StartDate = DateTime.Now, EndDate = DateTime.Now };

            _CoronaAppServiceMock.Setup(x => x.PostAsync(locationToAdd));
         
            LocationController location = new LocationController(_CoronaAppServiceMock.Object);
            var result = location.PostAsync(locationToAdd);
            Assert.True(true);
            _CoronaAppServiceMock.Verify(x => x.PostAsync(It.IsAny<Location>()), Times.Once);
        }

        [Fact]

        public async void AddPatient_Failed_NullObject()//GetPatient_All_ReturnPatient
        {

            _CoronaAppServiceMock.Setup(x => x.PostAsync(null));

            LocationController location = new LocationController(_CoronaAppServiceMock.Object);           
                var result = location.PostAsync(null);
            if(result.Exception!=null)
                Assert.False(false);
            
            _CoronaAppServiceMock.Verify(x => x.PostAsync(It.IsAny<Location>()), Times.Never);
        }





        //test without mock
        [Fact]
        public async void GetLocations_ByCity_ReturnLocations()
        {
            WebApplicationFactory<Program> application = new WebApplicationFactory<Program>();

            var client = application.CreateClient();
            var response = await client.GetAsync("/api/Location/city/Jerusalem");
            response.EnsureSuccessStatusCode();
        }


}
}