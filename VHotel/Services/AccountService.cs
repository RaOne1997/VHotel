using AutoMapper;
using VHotel.DataAccess.DTo;
using VHotel.RepositoryPattern.Interface;

namespace VHotel.Services
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



        public async Task<List<AccountDTO>> GetAllAsync()
        {
            var account = await _accountRepository.GetAllAsync<AccountDTO>();

            var accounts = account
                .Select(d => _mapper.Map<AccountDTO>(d))
                .ToList();

            return accounts;
        }

        public async Task<AccountDTO> login(string userID, string Password)
        {
           var  login = await _accountRepository.loginAsync(userID, Password);
            var logins = _mapper.Map<AccountDTO>(login);
              
            return logins;
        }
    }
}
