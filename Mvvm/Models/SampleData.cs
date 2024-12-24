﻿using System.Collections.ObjectModel;

namespace ECOllect.Models
{
    public static class SampleData
    {
        public static ObservableCollection<CommunityAction> GetSampleActions()
        {
            return new ObservableCollection<CommunityAction>
            {
                new CommunityAction
                {
                    Id = "1",
                    Title = "Očistimo Kamberovica Polje",
                    Description = "Kamberovica polje, kao glavno okupljalište mladih, zahtijeva našu pažnju. Pridružite nam se u akciji čišćenja!",
                    Date = new DateTime(2024, 1, 26,16,30,0),
                    Location = "Kamberovica Polje",
                    Latitude = 44.201749,
                    Longitude = 17.910467,
                    ParticipantCount = 35,
                    Prize = 25,
                    Image = "salcinovic.png",
                    HasJoined = false
                },
                new CommunityAction
                {
                    Id = "2",
                    Title = "Sadnja drveća u naselju",
                    Description = "Zelena akcija za ljepši grad. Svako novo drvo čini razliku!",
                    Date = new DateTime(2024, 1, 5,12,0,0),
                    Location = "Novo Selo",
                    Latitude = 44.204858,
                    Longitude = 17.915544,
                    ParticipantCount = 30,
                    Prize = 15,
                    Image = "logo.png",
                    HasJoined = false
                },
                new CommunityAction
                {
                    Id = "3",
                    Title = "Reciklaža elektronskog otpada",
                    Description = "Organizovano prikupljanje i reciklaža elektronskog otpada",
                    Date = new DateTime(2024, 2, 10,15,10,0),
                    Location = "Gradski park",
                    Latitude = 44.203731,
                    Longitude = 17.904071,
                    ParticipantCount = 20,
                    Prize = 10,
                    Image = "graycoin.png",
                    HasJoined = false
                },
                new CommunityAction
                {
                    Id = "4",
                    Title = "Smetovi",
                    Description = "Zelena akcija za ljepši grad. Svako novo drvo čini razliku!",
                    Date = new DateTime(2025, 1, 15,9,30,0),
                    Location = "Smetovi",
                    Latitude = 44.245417,
                    Longitude = 17.962172,
                    ParticipantCount = 30,
                    Prize = 15,
                    Image = "logo.png",
                    HasJoined = false
                },
                new CommunityAction
                {
                    Id = "4",
                    Title = "Smetovi",
                    Description = "Zelena akcija za ljepši grad. Svako novo drvo čini razliku!",
                    Date = new DateTime(2025, 1, 15,9,30,0),
                    Location = "Smetovi",
                    Latitude = 44.245417,
                    Longitude = 17.962172,
                    ParticipantCount = 30,
                    Prize = 15,
                    Image = "logo.png",
                    HasJoined = false
                },
                new CommunityAction
                {
                    Id = "4",
                    Title = "Smetovi",
                    Description = "Zelena akcija za ljepši grad. Svako novo drvo čini razliku!",
                    Date = new DateTime(2025, 1, 15,9,30,0),
                    Location = "Smetovi",
                    Latitude = 44.245417,
                    Longitude = 17.962172,
                    ParticipantCount = 30,
                    Prize = 15,
                    Image = "logo.png",
                    HasJoined = false
                },new CommunityAction
                {
                    Id = "4",
                    Title = "Smetovi",
                    Description = "Zelena akcija za ljepši grad. Svako novo drvo čini razliku!",
                    Date = new DateTime(2025, 1, 15,9,30,0),
                    Location = "Smetovi",
                    Latitude = 44.245417,
                    Longitude = 17.962172,
                    ParticipantCount = 30,
                    Prize = 15,
                    Image = "logo.png",
                    HasJoined = false
                },
            };
        }

        public static ObservableCollection<Sponsor> GetSampleSponsors()
        {
            return new ObservableCollection<Sponsor>
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
                        Title = "SIM2GO 10GB",
                        ImageUrl = "bhtelecom.png",
                        PointsCost = 100,
                        Description = "10GB mobilnog interneta",
                        ValidUntil = DateTime.Now.AddMonths(1)
                    },
                    new Promotion
                    {
                        Id = "2",
                        Title = "BH Telecom internet",
                        ImageUrl = "bhtelecom.png",
                        PointsCost = 80,
                        Description = "Kupon za besplatnih 7GB 7 dana",
                        ValidUntil = DateTime.Now.AddMonths(1)
                    },
                    new Promotion
                    {
                        Id = "2",
                        Title = "BH Telecom internet",
                        ImageUrl = "bhtelecom.png",
                        PointsCost = 80,
                        Description = "Kupon za besplatnih 7GB 7 dana",
                        ValidUntil = DateTime.Now.AddMonths(1)
                    },
                    new Promotion
                    {
                        Id = "2",
                        Title = "BH Telecom internet",
                        ImageUrl = "bhtelecom.png",
                        PointsCost = 80,
                        Description = "Kupon za besplatnih 7GB 7 dana",
                        ValidUntil = DateTime.Now.AddMonths(1)
                    },
                    new Promotion
                    {
                        Id = "2",
                        Title = "BH Telecom internet",
                        ImageUrl = "bhtelecom.png",
                        PointsCost = 80,
                        Description = "Kupon za besplatnih 7GB 7 dana",
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
                        Id = "3",
                        Title = "Salčinović bon",
                        ImageUrl = "salcinovic.png",
                        PointsCost = 105,
                        Description = "7KM bon u svim Salčinović restoranima",
                        ValidUntil = DateTime.Now.AddMonths(1)
                    },
                    new Promotion
                    {
                        Id = "4",
                        Title = "Salčinović popust",
                        ImageUrl = "salcinovic.png",
                        PointsCost = 75,
                        Description = "20% popusta na sve menije",
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
                        Id = "5",
                        Title = "dm poklon bon",
                        ImageUrl = "dmlogo.png",
                        PointsCost = 150,
                        Description = "Poklon bon u vrijednosti 15 KM",
                        ValidUntil = DateTime.Now.AddMonths(1)
                    }
                }
            }
        };
        }
    }
}