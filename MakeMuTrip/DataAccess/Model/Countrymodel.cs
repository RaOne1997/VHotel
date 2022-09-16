using staticclassmodel.DataAccess.Model.Masters;

namespace staticclassmodel.DataAccess.Model
{
    public class Countrymodel
    {
        ///</summary>
        public List<Country> country { get; set; } = null!;
        public int CurrentPageIndex { get; set; }


        public int PageCount { get; set; }
    }
}
