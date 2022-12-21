using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkAppMVC.Models
{
    public class Mekan
    {
        public int MekanId { get; set; }
        public string MekanAd { get; set; }
        public int DurumId { get; set; }
        public virtual Durum Durum { get; set; }
    }
}