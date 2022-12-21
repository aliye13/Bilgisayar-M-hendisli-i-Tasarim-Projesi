using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkAppMVC.Models
{
    public class Ilan
    {
        public int IlanId { get; set; }
        public string Açıklama { get; set; }
        public double Ücret { get; set; }
        public int MesaiSüresi { get; set; }
        public int MolaSüresi { get; set; }
        public string ÇalışmaMekanı { get; set; }
        public string Görev { get; set; }
        public bool Bahşiş { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public string UserName { get; set; }
        public int SehirId { get; set; }
        public int IlceId { get; set; }
        public int DurumId { get; set; }
        public int MahalleId { get; set; }
        public Mahalle Mahalle { get; set; }
        public int MekanId { get; set; }
        public Mekan Mekan { get; set; }
        public List<Resim> Resims { get; set; }
    }
}