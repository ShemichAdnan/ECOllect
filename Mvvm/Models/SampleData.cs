using System.Collections.ObjectModel;
using static Microsoft.Maui.ApplicationModel.Permissions;

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
                    Id = 1,
                    Title = "Očistimo Kamberovica Polje",
                    Description = "Kamberovica polje, kao glavno okupljalište mladih, zahtijeva našu pažnju. Pridružite nam se u akciji čišćenja!",
                    Date = new DateTime(2024, 1, 26,16,30,0),
                    Location = "Kamberovica Polje",
                    Latitude = 44.201749,
                    Longitude = 17.910467,
                    ParticipantCount = 35,
                    Prize = 25,
                    Image = "kamberovicapolje.png",
                    HasJoined = false
                },
                new CommunityAction
                {
                    Id = 2,
                    Title = "Zeleni Pojas uz Bosnu",
                    Description = "Akcija \"Zeleni Pojas uz Bosnu\" ima za cilj sadnju drveća duž obala rijeke Bosne kako bi se unaprijedio okoliš i smanjio utjecaj erozije tla. Volonteri će saditi autohtone vrste drveća koje će doprinijeti očuvanju biodiverziteta, poboljšanju kvaliteta zraka i stvaranju prirodnog hlada uz šetnice. Tokom akcije, učesnici će imati priliku naučiti više o značaju sadnje drveća za ekosistem i očuvanje rijeke. Ova inicijativa nije samo korak ka zelenijem prostoru, već i ka jačanju svijesti o važnosti brige za prirodu i našu zajedničku budućnost.",
                    Date = new DateTime(2024, 1, 5,12,0,0),
                    Location = "Obala rijeke Bosne",
                    Latitude = 44.206122,
                    Longitude = 17.9108,
                    ParticipantCount = 30,
                    Prize = 15,
                    Image = "sadnjadrveca.png",
                    HasJoined = false
                },
                new CommunityAction
                {
                    Id = 3,
                    Title = "Uredimo Naš Park",
                    Description="Akcija \"Uredimo Naš Park\" ima za cilj obnoviti i unaprijediti izgled gradskog parka kako bi postao ugodnije mjesto za odmor i druženje. Aktivnosti uključuju čišćenje smeća, sadnju cvijeća i drveća, obnavljanje klupa i igrališta te postavljanje novih kanti za otpatke. Također, volonteri će oslikavati edukativne murale s porukama o očuvanju prirode. Ova akcija doprinosi očuvanju okoliša, jačanju zajednice i stvaranju zelenog, zdravog prostora za sve građane. Nakon završetka, planirano je druženje uz osvježenje kako bi se obilježio uspješan zajednički trud.",
                    Date = new DateTime(2024, 2, 10,15,10,0),
                    Location = "Gradski park",
                    Latitude = 44.203731,
                    Longitude = 17.904071,
                    ParticipantCount = 20,
                    Prize = 10,
                    Image = "uredjenjegradskogparka.png",
                    HasJoined = false
                },
                new CommunityAction
                {
                    Id = 4,
                    Title = "Čisti Smetovi - Naša Priroda, Naša Odgovornost",
                    Description = "Akcija \"Čisti Smetovi\" okuplja volontere iz zajednice kako bi očistili smeće i unaprijedili prirodnu ljepotu ovog popularnog izletišta. Cilj je ukloniti otpad s planinarskih staza, livada i šuma, te podići svijest o važnosti očuvanja prirodnih prostora. Osim čišćenja, planirano je postavljanje dodatnih kanti za smeće i edukativnih tabli koje će posjetitelje podsjećati na odgovorno ponašanje prema prirodi. Nakon akcije, učesnici će se okupiti na zajedničkom druženju kao znak zahvalnosti za njihov trud i doprinos ljepšem i čistijem okolišu.",
                    Date = new DateTime(2025, 1, 15,9,30,0),
                    Location = "Smetovi",
                    Latitude = 44.245417,
                    Longitude = 17.962172,
                    ParticipantCount = 30,
                    Prize = 15,
                    Image = "ciscenjesmetova.png",
                    HasJoined = false
                },
                new CommunityAction
                {
                    Id = 5,
                    Title = "Uređenje staza na Smetovima",
                    Description = "Smetovi, popularno izletište u Zenici, zahtijevaju uređenje planinarskih staza kako bi posjetitelji mogli uživati u sigurnom i ugodnom okruženju. Akcija bi uključivala čišćenje staza od otpada, postavljanje oznaka i odmorišta, te sadnju drveća i cvijeća za dodatno uljepšavanje prostora. Cilj je poboljšati infrastrukturu, očuvati prirodu i potaknuti zajednicu na aktivno sudjelovanje u zaštiti okoliša. Na kraju akcije, planirano je druženje svih volontera kao znak zahvalnosti za njihov doprinos.",
                    Date = new DateTime(2025, 2, 25,12,00,0),
                    Location = "Smetovi",
                    Latitude = 44.242448,
                    Longitude = 17.973166,
                    ParticipantCount = 35,
                    Prize = 30,
                    Image = "smetovistaze.png",
                    HasJoined = false
                },
                new CommunityAction
                {
                    Id = 6,
                    Title = "Novo Lice Lisca",
                    Description="Akcija \"Novo Lice Lisca\" usmjerena je na obnovu planinarskog doma na Liscu, kako bi se ovaj omiljeni kutak planinara i prirodnjaka pretvorio u još ljepše i funkcionalnije mjesto za odmor. Aktivnosti uključuju čišćenje i farbanje unutrašnjih i vanjskih površina, popravku dotrajalih elemenata, postavljanje novih klupa i stolova, te uređenje okoliša doma. Cilj je stvoriti prijatan i siguran prostor za posjetitelje, ali i očuvati dom kao važan dio lokalne planinarske tradicije. Nakon završetka radova, planiran je zajednički ručak i druženje svih učesnika u znak zahvalnosti za njihov doprinos.",
                    Date = new DateTime(2025, 3, 05,9,30,0),
                    Location = "Lisac",
                    Latitude = 44.228334,
                    Longitude = 17.851218,
                    ParticipantCount = 10,
                    Prize = 50,
                    Image = "planinarskidom.png",
                    HasJoined = false
                },
                new CommunityAction
                {
                    Id = 7,
                    Title = "Cvjetna Šetnica",
                    Description="Akcija \"Cvjetna Šetnica – Uljepšajmo Obale Bosne\" ima za cilj sadnju raznobojnog cvijeća duž gradske šetnice uz rijeku Bosnu, stvarajući ljepši i prijatniji ambijent za sve posjetitelje. Volonteri će raditi na uređenju cvjetnih gredica uz staze, postavljanju ukrasnih biljaka i osvježavanju zelenih površina koje povezuju mostove i Kamberovića polje. Pored sadnje, planirano je postavljanje edukativnih tabli koje promovišu brigu o okolišu i važnost očuvanja prirodnih ljepota rijeke Bosne. Ova akcija će doprinijeti ne samo vizualnom uljepšavanju šetnice, već i jačanju svijesti građana o očuvanju urbanog zelenila. Nakon završetka aktivnosti, planirano je druženje uz rijeku kao zahvalnost svim učesnicima za njihov trud.",
                    Date = new DateTime(2025, 3, 20,11,30,0),
                    Location = "Šetnica",
                    Latitude = 44.199560,
                    Longitude = 17.915791,
                    ParticipantCount = 20,
                    Prize = 20,
                    Image = "sadnjacvjeca.png",
                    HasJoined = false
                },

            };
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