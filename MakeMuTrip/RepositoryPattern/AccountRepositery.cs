 using AutoMapper;
using EmployeeCrud.RepositoryPattern.RepositoryBase;
using Microsoft.EntityFrameworkCore;
using MakeMuTrip.DataAccess;
using MakeMuTrip.DataAccess.Model.Master;
using MakeMuTrip.RepositoryPattern.Interface;

namespace MakeMuTrip.RepositoryPattern
{
    public class AccountRepositery : Repository<Account>, IAccountRepositery
    {
        private readonly VhotelsSQLContex db;
        private readonly IMapper mapper;

        public AccountRepositery(VhotelsSQLContex db, IMapper mapper) : base(db, mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }


        public async Task<int> getIdbyname(string userID)
        {
            var result = await (from a in DbSet
                                where a.Email.Equals(userID) 
                               
                                select a.ID).SingleOrDefaultAsync();

            if (result != null)
            {
                return result;
            }
            else
                return result;
        }

        public async Task<Account> loginAsync(string userID, string Password)
        {
            var result = await (from a in DbSet
                                where a.Email.Equals(userID) | a.UserName.Equals(userID)
                                | a.Phone.Equals(userID) && a.Password.Equals(Password)
                                select a).SingleOrDefaultAsync();

            if (result != null)
            {
                return result;
            }
            else
                return result;
        }
    }
}
