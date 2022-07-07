using AutoMapper;
using EmployeeCrud.RepositoryPattern.RepositoryBase;
using Microsoft.EntityFrameworkCore;
using staticclassmodel.DataAccess.Model.Master;
using VHotel.DataAccess;

namespace VHotel.RepositoryPattern
{
    public class StateRepository : Repository<State>, IStateRepository
    {
        private readonly VhotelsSQLContex db;
        private readonly IMapper mapper;

        public StateRepository(VhotelsSQLContex db, IMapper mapper) : base(db, mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<List<State>> GetStateByCont(int contid)
        {
            var  states = await base.DbSet.Where(x => x.CountryrefID == contid).ToListAsync();
            return states;
        }
    }
}
