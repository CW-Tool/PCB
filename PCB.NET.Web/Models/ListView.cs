using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCB.NET.Web.Models
{
    public class ListView
    {
        public int TotalEntities { get; set; }
        public int EntitiesPerPages { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalEntities / EntitiesPerPages); }
        }
    }
}