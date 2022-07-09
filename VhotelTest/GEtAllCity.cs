using AutoMapper;
using NSubstitute;
using staticclassmodel.DataAccess.Model.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHotel.DataAccess.DTo;
using VHotel.RepositoryPattern.Interface;
using VHotel.Services;
using VHotel.Services.Interface;

namespace VhotelTest
{
    public class GEtAllCity
    {
        public readonly ICityServices _cityServices;
        private readonly ICityRepository _CityRepository;
        private readonly IStateRepository _StateRepository;
        private readonly IMapper _mapper;

        public GEtAllCity()
        {
            _CityRepository = Substitute.For<ICityRepository>();
            _StateRepository = Substitute.For<IStateRepository>();
            _mapper = Substitute.For<IMapper>();

            _cityServices = new CityServices(_CityRepository, _StateRepository, _mapper);
        }

        [Fact]
        public async Task getallCityAsync()
        {
            
            var expectedCitys = new List<CityMasterdto>
            {
                new () {ID=1,CityName ="Pune", stateRefID = 1, stateName = "Maharashtra"},
                new () {ID=2,CityName ="Mumbai", stateRefID = 1, stateName = "Maharashtra"},
                new () {ID=5,CityName ="Banglore", stateRefID = 2, stateName = "Karnataka"},
            };
            var cityMasterdtos = expectedCitys
               .Select(d => _mapper.Map<CityMaster>(d))
               .ToList();
            //var city = _mapper.Map<CityMaster>(expectedCitys);
            _CityRepository.GetAllAsync<CityMasterdto>().Returns(expectedCitys);

            var Citys = await _cityServices.GetAllAsync();

            for (int i = 0; i < expectedCitys.Count; i++)
            {
                Assert.Equal(Citys[i].CityName, expectedCitys[i].CityName);
                Assert.Equal(Citys[i].stateRefID, expectedCitys[i].stateRefID);
                Assert.Equal(Citys[i].stateName, expectedCitys[i].stateName);
            }
        }
    }
}
