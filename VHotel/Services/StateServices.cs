using AutoMapper;
using staticclassmodel.DataAccess.Model.Master;
using VHotel.DataAccess.DTo;
using VHotel.RepositoryPattern;

namespace VHotel.Services
{
    public class StateServices : IStateServices
    {
        private readonly IStateRepository _StateRepository;
        private readonly IMapper _mapper;

        public StateServices(
            IStateRepository StateRepository,
            IMapper mapper)
        {
            _StateRepository = StateRepository;
            _mapper = mapper;
        }
        public async Task CreateAsync(StateDTO stateDTO)
        {
            var state = _mapper.Map<State>(stateDTO);
            await _StateRepository.CreateAsync(state);
        }

        public async Task DeleteAsync(int id)
        {
            await _StateRepository.DeleteAsync(id);
        }

        public async Task<bool> Exists(int id)
        {
            return await _StateRepository.Exists(id);
        }

        public async Task<List<StateDTO>> GetAllAsync()
        {
            var state = await _StateRepository.GetAllAsync<StateDTO>();

            var stateDTO = state
                .Select(d => _mapper.Map<StateDTO>(d))
                .ToList();

            return stateDTO;
        }

        public async Task<StateDTO?> GetByIdAsync(int id)
        {
            var state = await _StateRepository.GetByIdAsync<StateDTO>(id);


            var stateDTO = _mapper.Map<StateDTO>(state);

            return stateDTO;
        }

        public async Task<List<StateDTO>> stateBYcont(int id)
        {
            var states = await _StateRepository.GetStateByCont(id);

            var stateDTO = states
                .Select(d => _mapper.Map<StateDTO>(d))
                .ToList();
            return stateDTO;
        }

        public async Task UpdateAsync(StateDTO stateDTO)
        {
            try
            {

                if (await _StateRepository.Exists((int)stateDTO.ID))
                {
                    var state = _mapper.Map<State>(stateDTO);
                    await _StateRepository.UpdateAsync(state);

                }
            }
            catch (Exception)
            {

            }

        }
    }
}
