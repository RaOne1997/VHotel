using System.ComponentModel.DataAnnotations.Schema;

namespace MakeMyTrip.Data
{
    public class Bookdetals : ViewDataModel
    {
        public int Bookrefid { get; set; }
        [ForeignKey(nameof(Bookrefid))]
        public Books Books { get; set; }
        public int AuthorsRefID { get; set; }
        [ForeignKey(nameof(Bookrefid))]
        public Authors authorss { get; set; }
        public string publisher { get; set; }
        public string isbn10 { get; set; }
        public string pages { get; set; }
        public string year { get; set; }
        public string rating { get; set; }
        public string desc { get; set; }
        public string url { get; set; }
        public int CategoriesRefid { get; set; }
        [ForeignKey(nameof(CategoriesRefid))]
        public Categories categories { get; set; }
    }



    public class BookDetailsDTO
    {
        public int ID { get; set; }
        public string title { get; set; }
        public string subtitle { get; set; }
        public string authors { get; set; }
        public string publisher { get; set; }
        public string isbn10 { get; set; }
        public string isbn13 { get; set; }
        public string pages { get; set; }
        public string year { get; set; }
        public string rating { get; set; }
        public string desc { get; set; }
        public string price { get; set; }
        public string image { get; set; }
        public string url { get; set; }

    }

}