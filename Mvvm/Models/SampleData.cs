using System.Collections.ObjectModel;
using ECOllect.Database;

namespace ECOllect.Models
{
    public static class SampleData
    {
        public static ObservableCollection<CommunityAction> GetSampleActions()
        {
            using var connection = DatabaseService.GetConnection();
            var actions = connection.Table<CommunityAction>().ToList();

            return new ObservableCollection<CommunityAction>(actions);
        }

        public static ObservableCollection<Sponsor> GetSampleSponsors()
        {
            var sponsors =new ObservableCollection<Sponsor>
        {
            new Sponsor
            {
                Id = "1",
                Name = "BH Telecom",
                LogoUrl = "bhtelecom.png",
                Advertisement="Zgrabi svoju ULTRA slobodu!",
                Promotions = new List<Promotion>
                {
                    new Promotion
                    {
                        Id = "1",
                        Title = "7GB mobilnog interneta",
                        ImageUrl = "sedamgbinterneta.png",
                        PointsCost = 100,
                        ValidUntil = DateTime.Now.AddMonths(1)
                    },
                    new Promotion
                    {
                        Id = "2",
                        Title = "10% popusta na telefon",
                        ImageUrl = "popustnatelefon.png",
                        PointsCost = 200,
                        ValidUntil = DateTime.Now.AddMonths(1)
                    },
                    new Promotion
                    {
                        Id = "3",
                        Title = "1GB mobilnog interneta",
                        ImageUrl = "jedangbinterneta.png",
                        PointsCost = 30,
                        ValidUntil = DateTime.Now.AddMonths(1)
                    },
                    new Promotion
                    {
                        Id = "4",
                        Title = "50% popusta na studentski paket",
                        ImageUrl = "popustnastudentski.png",
                        PointsCost = 150,
                        ValidUntil = DateTime.Now.AddMonths(1)
                    },
                    new Promotion
                    {
                        Id = "5",
                        Title = "Besplatni pozivi mjesec dana",
                        ImageUrl = "besplatnipozivi.png",
                        PointsCost = 250,
                        ValidUntil = DateTime.Now.AddMonths(1)
                    }
                }
            },
            new Sponsor
            {
                Id = "2",
                Name = "Salčinović",
                LogoUrl = "salcinovic.png",
                Advertisement="Tradicionalna jela i specijaliteti sa roštilja",
                Promotions = new List<Promotion>
                {
                    new Promotion
                    {
                        Id = "1",
                        Title = "7KM bon",
                        ImageUrl = "sedamkmbon.png",
                        PointsCost = 105,
                        ValidUntil = DateTime.Now.AddMonths(1)
                    },
                    new Promotion
                    {
                        Id = "2",
                        Title = "20% popusta",
                        ImageUrl = "popustnasve.png",
                        PointsCost = 65,
                        ValidUntil = DateTime.Now.AddMonths(1)
                    },
                    new Promotion
                    {
                        Id = "3",
                        Title = "Besplatan sok",
                        ImageUrl = "besplatansok.png",
                        PointsCost = 35,
                        ValidUntil = DateTime.Now.AddMonths(1)
                    }
                }
            },
            new Sponsor
            {
                Id = "3",
                Name = "dm",
                LogoUrl = "dmlogo.png",
                Advertisement = "Tu sam čovjek, tu kupujem",
                Promotions = new List<Promotion>
                {
                    new Promotion
                    {
                        Id = "1",
                        Title = "dm poklon bon 15KM",
                        ImageUrl = "poklonbon.png",
                        PointsCost = 130,
                        ValidUntil = DateTime.Now.AddMonths(1)
                    },
                    new Promotion
                    {
                        Id = "2",
                        Title = "Poklon set",
                        ImageUrl = "poklonset.png",
                        PointsCost = 250,
                        ValidUntil = DateTime.Now.AddMonths(1)
                    },
                    new Promotion
                    {
                        Id = "3",
                        Title = "Mirisi za dom",
                        ImageUrl = "mirisizadom.png",
                        PointsCost = 100,
                        ValidUntil = DateTime.Now.AddMonths(1)
                    },
                    new Promotion
                    {
                        Id = "4",
                        Title = "30% popust na Balea proizvode",
                        ImageUrl = "popustnabalea.png",
                        PointsCost = 120,
                        ValidUntil = DateTime.Now.AddMonths(1)
                    }
                }
            },
            new Sponsor
            {
                Id = "4",
                Name = "Bingo",
                LogoUrl = "bingologo.png",
                Advertisement = "Kralj dobrih cijena!",
                Promotions = new List<Promotion>
                {
                    new Promotion
                    {
                        Id = "1",
                        Title = "20% popusta na kafu",
                        ImageUrl = "popustnakafu",
                        PointsCost = 60,
                        ValidUntil = DateTime.Now.AddMonths(1)
                    },
                    new Promotion
                    {
                        Id = "2",
                        Title = "Bluetooth slušalice",
                        ImageUrl = "bluetoothslusalice",
                        PointsCost = 270,
                        ValidUntil = DateTime.Now.AddMonths(1)
                    },
                    new Promotion
                    {
                        Id = "3",
                        Title = "40% popust na sokove",
                        ImageUrl = "popustnasokove",
                        PointsCost = 30,
                        ValidUntil = DateTime.Now.AddMonths(1)
                    },
                    new Promotion
                    {
                        Id = "4",
                        Title = "Majica po želji",
                        ImageUrl = "majicapozelji",
                        PointsCost = 230,
                        ValidUntil = DateTime.Now.AddMonths(1)
                    },
                    new Promotion
                    {
                        Id = "5",
                        Title = "Parfem u pola cijene",
                        ImageUrl = "parfemupola",
                        PointsCost = 100,
                        ValidUntil = DateTime.Now.AddMonths(1)
                    }
                }
            }
        };
            foreach (var sponsor in sponsors)
            {
                foreach (var promotion in sponsor.Promotions)
                {
                    promotion.Sponsor = sponsor;
                }
            }

            return sponsors;
        }
    }
}