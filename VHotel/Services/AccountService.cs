using AutoMapper;
using MakeMuTrip.DataAccess.DTo;
using MakeMuTrip.DataAccess.Model.Master;
using MakeMuTrip.RepositoryPattern.Interface;

namespace MakeMuTrip.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepositery _accountRepository;
        private readonly IMapper _mapper;

        public AccountService(
            IAccountRepositery accountRepository,
            IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(AccountDTO accountDTO)
        {
            try
            {
                var account = _mapper.Map<Account>(accountDTO);
                await _accountRepository.CreateAsync(account);
            }
            catch (Exception ex)
            {

            }


        }

        public async Task<List<AccountDTO>> GetAllAsync()
        {
            var account = await _accountRepository.GetAllAsync<AccountDTO>();

            var accounts = account
                .Select(d => _mapper.Map<AccountDTO>(d))
                .ToList();

            return accounts;
        }

        public async Task<int> getidBYname(string userID)
        {
            var id = await _accountRepository.getIdbyname(userID);
            return id;
        }

        public async Task<AccountDTO> getidBYname(int userID)
        {
            return await _accountRepository.GetByIdAsync<AccountDTO>(userID);
        }

        public async Task<int> login(string userID, string Password)
        {
            var login = await _accountRepository.loginAsync(userID, Password);

            return login;
        }
    }
}
