using AutoMapper;
using staticclassmodel.DataAccess.Model.Master;
using VHotel.DataAccess.DTo;
using VHotel.RepositoryPattern.Interface;
using VHotel.Services.Interface;

namespace VHotel.Services
{
    public class CustomersServices : ICrudeServices<CustomersDTO>
    {

        private readonly ICustomersRepository _customersRepository;
        private readonly IMapper _mapper;

        public CustomersServices(
            ICustomersRepository customersRepository,
            IMapper mapper)
        {
            _customersRepository = customersRepository;
            _mapper = mapper;
        }
        public async Task CreateAsync(CustomersDTO modelDTO)
        {
            await using var memorystring = new MemoryStream();
            await modelDTO.ProfilePhotoTouplode.CopyToAsync(memorystring);
            modelDTO.ProfilePhoto = memorystring.ToArray();

            var airport = _mapper.Map<Customer>(modelDTO);
            await _customersRepository.CreateAsync(airport);
        }

        public async Task DeleteAsync(int id)
        {
            await _customersRepository.DeleteAsync(id);
        }

        public async Task<bool> Exists(int id)
        {
            return await _customersRepository.Exists(id);
        }

        public async Task<List<CustomersDTO>> GetAllAsync()
        {
            var customer = await _customersRepository.GetAllAsync<CustomersDTO>();

            var customerdto = customer
                .Select(d => _mapper.Map<CustomersDTO>(d))
                .ToList();

            return customerdto;
        }

        public async Task<CustomersDTO> GetByIdAsync(int id)
        {
            var customer = await _customersRepository.GetByIdAsync<CustomersDTO>(id);


            var customerdto = _mapper.Map<CustomersDTO>(customer);

            return customerdto;
        }

        public async Task UpdateAsync(CustomersDTO modelDTO)
        {
            try
            {
                await using var memorystring = new MemoryStream();
                await modelDTO.ProfilePhotoTouplode.CopyToAsync(memorystring);
                modelDTO.ProfilePhoto = memorystring.ToArray();

                if (await _customersRepository.Exists((int)modelDTO.ID))
                {
                    var airlineDetails = _mapper.Map<Customer>(modelDTO);
                    await _customersRepository.UpdateAsync(airlineDetails);

                }
            }
            catch (Exception)
            {

            };
        }
    }
}
