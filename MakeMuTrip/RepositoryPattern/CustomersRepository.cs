using AutoMapper;
using EmployeeCrud.RepositoryPattern.RepositoryBase;

using Microsoft.EntityFrameworkCore;
using staticclassmodel.DataAccess.Model.Masters;
using MakeMuTrip.DataAccess;
using MakeMuTrip.RepositoryPattern.Interface;

namespace MakeMuTrip.RepositoryPattern
{
    public class CustomersRepository : Repository<Customer>, ICustomersRepository
    {
        private readonly VhotelsSQLContex db;
        private readonly IMapper mapper;

        public CustomersRepository(VhotelsSQLContex db, IMapper mapper) : base(db, mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public Task<Customer> GetbyrefID(int id)
        {
            var a = DbSet.Where(x => x.AccountRefID.Equals(id)).SingleOrDefaultAsync();

            return a;
        }
    }
}
