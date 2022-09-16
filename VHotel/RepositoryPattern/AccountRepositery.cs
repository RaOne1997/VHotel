 using AutoMapper;
using EmployeeCrud.RepositoryPattern.RepositoryBase;
using Microsoft.EntityFrameworkCore;
using MakeMuTrip.DataAccess;
using MakeMuTrip.DataAccess.Model.Master;
using MakeMuTrip.RepositoryPattern.Interface;
using staticclassmodel.DataAccess.Model.Masters;
using MakeMuTrip.DataAccess.DTo;

namespace MakeMuTrip.RepositoryPattern
{
    public class AccountRepositery : Repository<Account>, IAccountRepositery
    {
        private readonly VhotelsSQLContex _db;
        private readonly IMapper _mapper;

        public AccountRepositery(VhotelsSQLContex db, IMapper mapper) : base(db, mapper)
        {
            _db = db;
            _mapper = mapper;
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

        public async Task<int> loginAsync(string userID, string Password)
        {
            var result = await (from a in DbSet
                                where a.Email.Equals(userID) | a.UserName.Equals(userID)
                                | a.Phone.Equals(userID) && a.Password.Equals(Password)
                                select a.ID).SingleOrDefaultAsync();

            //var accountdetails = await _mapper
            //.ProjectTo<CustomersDTO>(_db.customers)
            //    .Where(m => m.AccountRefID == result).SingleOrDefaultAsync();



            if (result != null)
            {
                return result;
            }
            else
                return 0;
        }
    }
}
