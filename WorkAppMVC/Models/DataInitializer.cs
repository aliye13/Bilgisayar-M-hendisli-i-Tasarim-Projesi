using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WorkAppMVC.Models
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var sehir = new List<Sehir>()
            {
                new Sehir() {SehirAd="İSTANBUL"},
                new Sehir() {SehirAd="ANKARA"},
                new Sehir() {SehirAd="İZMİR"}
            };
            foreach (var item in sehir)
            {
                context.Sehirs.Add(item);
            }
            context.SaveChanges();
            var ilçe = new List<Ilce>()
            {
                new Ilce() {IlceAd="KAĞITHANE", SehirId=1},
                new Ilce() {IlceAd="KEÇİÖREN", SehirId=2},
                new Ilce() {IlceAd="BORNOVA", SehirId=3}
            };
            foreach (var item in ilçe)
            {
                context.Ilces.Add(item);
            }
            context.SaveChanges();
            var mahalle = new List<Mahalle>()
            {
                new Mahalle() {MahalleAd="ÇAĞLAYAN", IlceId=1},
                new Mahalle() {MahalleAd="İZZETPAŞA", IlceId=2},
                new Mahalle() {MahalleAd="TALATPAŞA", IlceId=3},

            };
            foreach (var item in mahalle)
            {
                context.Mahalles.Add(item);
            }
            context.SaveChanges();

            var durum = new List<Durum>()
            {
                new Durum() {DurumAd="GÜNLÜK"},
                new Durum() {DurumAd="HAFTALIK"}
            };
            foreach(var item in durum)
            {
                context.Durums.Add(item);
            }
            context.SaveChanges();

            var mekan = new List<Mekan>()
            {
                new Mekan() {MekanAd="RESTORAN", DurumId=1},
                 new Mekan() {MekanAd="BAHÇE", DurumId=2},
                  new Mekan() {MekanAd="OFİS", DurumId=1},
                 new Mekan() {MekanAd="TARLA", DurumId=2}
            };
            foreach (var item in mekan)
            {
                context.Mekans.Add(item);
            }
            context.SaveChanges();

            

            var ilan = new List<Ilan>()
            {
                new Ilan() {Açıklama="Restoranımızda Çalışacak Günlük Garson Aranmaktadır",Adres="Şan Sokak", MesaiSüresi=8, MolaSüresi=1, Bahşiş=true, Ücret=25, MahalleId=1, IlceId=1, SehirId=1, DurumId=1, MekanId=1, Telefon="2121043584", Görev="Garson", UserName="aliye13"},

                new Ilan() {Açıklama="Bahçemizde 1 hafta Çalışacak Yardımcı Aranmaktadır",Adres="Çiçek Sokak", MesaiSüresi=8, MolaSüresi=1, Bahşiş=true, Ücret=30, MahalleId=2, IlceId=2, SehirId=2, DurumId=2, MekanId=2, Telefon="2159634251", Görev="Yardımcı", UserName="ecex"},
            };
            foreach (var item in ilan)
            {
                context.Ilans.Add(item);
            }
            context.SaveChanges();

            var resim = new List<Resim>()
            {
                new Resim() {ResimAd="restaurant.jpg", IlanId=1},
                new Resim() {ResimAd="restaurant.jpg", IlanId=1},
                new Resim() {ResimAd="Tarla.jpg", IlanId=2},
            };
            foreach (var item in resim)
            {
                context.Resims.Add(item);
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}