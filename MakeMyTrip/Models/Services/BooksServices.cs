using AutoMapper;
using MakeMyTrip.Data;
using MakeMyTrip.Data.DTO;
using MakeMyTrip.VIewModel.Static_data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace MakeMyTrip.Models.Services
{
    public class BooksServices : IBooksServices
    {
        private readonly Context _context = new Context();


        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper
            ;

        static int _id = 0;
        public BooksServices(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }
        public async Task<string> inserttodpAsync(string SubjectName, int pagenumber)
        {
            var books = await GetallAsyncbooks(SubjectName, pagenumber);
            foreach (var a in books)
            {

                await _context.AddAsync(a);
                await _context.SaveChangesAsync();
                _id++;
            }
            return "Done : " + _id;
        }


        public List<Dropdown> dropdown()
        {
            var dropdowns = new List<Dropdown>();

            foreach (var lie in Static_value.cat)
            {
                var drop = new Dropdown
                {

                    key = lie,
                    value = lie
                };
                dropdowns.Add(drop);

            }
            return dropdowns;

        }

        public async Task staticcatAsync()
        {

            var cats = dropdown();
            foreach (var item in cats)
            {
                var cat = new Categories
                {
                    category = item.value

                };
                await _context.categories.AddAsync(cat);
                await _context.SaveChangesAsync();
            }
        }

        public async Task addauther(string authername)
        {

            var addauther = new Authors
            {
                AutherName = authername
            };
            await _context.authors.AddAsync(addauther);
            await _context.SaveChangesAsync();
        }


        public async Task insertDetailsAsync()
        {

            //staticcatAsync();

            var list = await _context.books.ToListAsync();
            var bookdetails = new BookDetailsDTO();
            foreach (var isbn13 in list)
            {
                var uriDeparture1 = $"https://api.itbook.store/1.0/books/{isbn13.isbn13}";
                var responseTextDeparture1 = await _httpClient.GetStringAsync(uriDeparture1);
                bookdetails = JsonConvert.DeserializeObject<BookDetailsDTO>(responseTextDeparture1);
                //addauther(bookdetails.authors);
                var auth = await _context.authors.ToListAsync();

                var dd = new Bookdetals();
                foreach (var author in auth)
                {
                    if (bookdetails.authors == author.AutherName)
                    {
                        dd = _mapper.Map<Bookdetals>(bookdetails);
                        dd.AuthorsRefID = author.ID;
                        dd.Bookrefid = isbn13.ID;
                        dd.CategoriesRefid = 1;

                        await _context.bookdetals.AddAsync(dd);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        continue;

                    }
                }




            }

        }
        public async Task<List<Books>> GetallAsyncbooks(string a, int page)
        {
            try
            {

                var uriDeparture = $"https://api.itbook.store/1.0/search/{a}/{page}";
                var responseTextDeparture = await _httpClient.GetStringAsync(uriDeparture);
                Pagination Test = JsonConvert.DeserializeObject<Pagination>(responseTextDeparture);

                var map = Test.books.Select(x => _mapper.Map<Books>(x)).ToList();
                return map;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<List<BookDetailsDTO>> GetallAsync()
        {
            var book = await _context.bookdetals.Include("Books")
                .Include("authorss")
                .ToListAsync();

            var result = book
                .Select(s => _mapper.Map<BookDetailsDTO>(s)).ToList();
            return result;
        }

        public async Task<BookDetailsDTO> getbyid(int id)
        {
            var book = await _context.bookdetals
                .Include("Books")
                .Include("categories")
                .Include("authorss")
                .SingleAsync(x => x.ID == id);

            var result = _mapper.Map<BookDetailsDTO>(book);

            return result;


        }
    }
}
