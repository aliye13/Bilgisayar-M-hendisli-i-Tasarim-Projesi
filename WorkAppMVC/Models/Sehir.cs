using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkAppMVC.Models
{
    public class Sehir
    {
        public int SehirId { get; set; }
        public string SehirAd { get; set; }
        public List<Ilce> Ilce { get; set; }
    }
}