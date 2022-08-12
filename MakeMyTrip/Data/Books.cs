using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MakeMyTrip.VIewModel.dataviewModel;

namespace MakeMyTrip.Data
{
    public class Books : ViewDataModel
    {

        public string title { get; set; }
        public string subtitle { get; set; }
        public string isbn13 { get; set; }
        public string price { get; set; }
        public string image { get; set; }
      


    }


}