// <copyright file="LogicTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Borton.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Borton.Data;
    using Borton.Repository;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// The test class for the Logic and Repository classes
    /// </summary>
    [TestFixture]
    public class LogicTest
    {
        private Logic logic;
        private BortonEntities entity;
        private Mock<IRepository<FEGYENC>> fegyenc;
        private Mock<IRepository<BORTONOR>> bortonor;
        private Mock<IRepository<ITELET>> itelet;
        private Mock<IRepository<BUNTETT>> buntett;
        private Mock<IRepository<ELHELYEZES>> elhelyezes;

        /// <summary>
        /// Sets the return value of the Listing objects and the Mock object
        /// </summary>
        [SetUp]
        public void Setup()
        {
            List<BUNTETT> buntettek = new List<BUNTETT>()
            {
                new BUNTETT() { buntett_ID = 1, buntett_leiras = "Adócsalás" },
                new BUNTETT() { buntett_ID = 2, buntett_leiras = "Nemi erőszak" },
                new BUNTETT() { buntett_ID = 3, buntett_leiras = "Öngyilkosságban közreműködés" },
                new BUNTETT() { buntett_ID = 4, buntett_leiras = "Nemi erőszak" }
            };
            List<ELHELYEZES> elhelyezesek = new List<ELHELYEZES>()
            {
                new ELHELYEZES() { cellaszam = 1, agy = 1, reszleg = "A", emelet = 1 },
                new ELHELYEZES() { cellaszam = 1, agy = 2, reszleg = "A", emelet = 1 },
                new ELHELYEZES() { cellaszam = 2, agy = 1, reszleg = "B", emelet = 3 },
                new ELHELYEZES() { cellaszam = 3, agy = 2, reszleg = "C", emelet = 2 }
            };
            List<ITELET> iteletek = new List<ITELET>()
            {
                new ITELET() { itelet_ID = 1, letoltendo_ido = 7, buntett_ID = 1 },
                new ITELET() { itelet_ID = 2, letoltendo_ido = 8, buntett_ID = 2 },
                new ITELET() { itelet_ID = 3, letoltendo_ido = 9, buntett_ID = 3 },
                new ITELET() { itelet_ID = 4, letoltendo_ido = 10, buntett_ID = 4 }
            };
            List<FEGYENC> fegyencek = new List<FEGYENC>()
            {
                new FEGYENC() { fegyenc_ID = 1, nev = "Luis Garavito", itelet_ID = 1, agy = 1, cellaszam = 1 },
                new FEGYENC() { fegyenc_ID = 2, nev = "Gary Ridgway", itelet_ID = 2, agy = 2, cellaszam = 1 },
                new FEGYENC() { fegyenc_ID = 3, nev = "Ted Bundy", itelet_ID = 3, agy = 1, cellaszam = 2 },
                new FEGYENC() { fegyenc_ID = 4, nev = "John Wayne Gacy", itelet_ID = 4, agy = 2, cellaszam = 3 }
            };

            this.fegyenc = new Mock<IRepository<FEGYENC>>();
            this.bortonor = new Mock<IRepository<BORTONOR>>();
            this.itelet = new Mock<IRepository<ITELET>>();
            this.buntett = new Mock<IRepository<BUNTETT>>();
            this.elhelyezes = new Mock<IRepository<ELHELYEZES>>();
            this.entity = new BortonEntities();
            this.fegyenc.Setup(x => x.Listing(this.entity)).Returns(fegyencek.AsQueryable);
            this.itelet.Setup(x => x.Listing(this.entity)).Returns(iteletek.AsQueryable);
            this.buntett.Setup(x => x.Listing(this.entity)).Returns(buntettek.AsQueryable);
            this.elhelyezes.Setup(x => x.Listing(this.entity)).Returns(elhelyezesek.AsQueryable);
            this.logic = new Logic(this.entity, this.fegyenc.Object, this.bortonor.Object, this.itelet.Object, this.elhelyezes.Object, this.buntett.Object);
        }

        /// <summary>
        /// Test the Insert method for the ELHELYEZES instance
        /// </summary>
        [Test]
        public void HaInsert_ELHELYEZESAkkorHozzaAdja()
        {
            Mock<Logic> m = new Mock<Logic>();
            ELHELYEZES l = new ELHELYEZES()
            {
                agy = 1,
                cellaszam = 15,
                reszleg = "A",
                emelet = 4
            };
            m.Object.Elhelyezes.Insert(m.Object.Entity, l);
            Assert.That(m.Object.Elhelyezes.Listing(m.Object.Entity).Count(), Is.EqualTo(11));
            Assert.That(m.Object.Elhelyezes.Listing(m.Object.Entity).Where(x => x.cellaszam == 15).Select(x => x.agy).Contains(1), Is.EqualTo(true));
        }

        /// <summary>
        /// Test the Insert method for the BORTONOR instance
        /// </summary>
        [Test]
        public void HaInsert_BORTONORAkkorHozzaAdja()
        {
            Mock<Logic> m = new Mock<Logic>();
            BORTONOR l = new BORTONOR()
            {
                bortonor_ID = 6,
                nev = "Thomas Edison"
            };
            m.Object.Bortonor.Insert(m.Object.Entity, l);
            Assert.That(m.Object.Bortonor.Listing(m.Object.Entity).Count(), Is.EqualTo(6));
            Assert.That(m.Object.Bortonor.Listing(m.Object.Entity).Where(x => x.bortonor_ID == 6).Select(x => x.nev).Contains("Thomas Edison"), Is.EqualTo(true));
        }

        /// <summary>
        /// Test the Insert method for the BUNTETT instance
        /// </summary>
        [Test]
        public void HaInsert_BUNTETTAkkorHozzaadja()
        {
            Mock<Logic> m = new Mock<Logic>();
            BUNTETT l = new BUNTETT()
            {
                buntett_ID = 11,
                aldozat = "Marika"
            };
            m.Object.Buntett.Insert(m.Object.Entity, l);
            Assert.That(m.Object.Buntett.Listing(m.Object.Entity).Count(), Is.EqualTo(11));
            Assert.That(m.Object.Buntett.Listing(m.Object.Entity).Where(x => x.buntett_ID == 11).Select(x => x.aldozat).Contains("Marika"), Is.EqualTo(true));
        }

        /// <summary>
        /// Test the Insert method for the ITELET instance
        /// </summary>
        [Test]
        public void HaInsert_ITELETAkkorHozzaadja()
        {
            Mock<Logic> m = new Mock<Logic>();
            ITELET l = new ITELET()
            {
                itelet_ID = 11,
                buntett_ID = 11,
                biro = "Thomas"
            };
            m.Object.Itelet.Insert(m.Object.Entity, l);
            Assert.That(m.Object.Itelet.Listing(m.Object.Entity).Count(), Is.EqualTo(11));
            Assert.That(m.Object.Itelet.Listing(m.Object.Entity).Where(x => x.itelet_ID == 11).Select(x => x.buntett_ID).Contains(11), Is.EqualTo(true));
        }

        /// <summary>
        /// Test the Insert method for the FEGYENC instance
        /// </summary>
        [Test]
        public void HaInsert_FEGYENCAkkorHozzaadja()
        {
            Mock<Logic> m = new Mock<Logic>();
            FEGYENC l = new FEGYENC()
            {
                fegyenc_ID = 11,
                itelet_ID = 10,
                bortonor_ID = 6,
                cellaszam = 15,
                agy = 1,
                nev = "Dereck Morgan"
            };
            m.Object.Fegyenc.Insert(m.Object.Entity, l);
            Assert.That(m.Object.Fegyenc.Listing(m.Object.Entity).Count(), Is.EqualTo(11));
            Assert.That(m.Object.Fegyenc.Listing(m.Object.Entity).Where(x => x.itelet_ID == 10).Select(x => x.bortonor_ID).Contains(6), Is.EqualTo(true));
            Assert.That(m.Object.Fegyenc.Listing(m.Object.Entity).Where(x => x.cellaszam == 15).Select(x => x.agy).Contains(1), Is.EqualTo(true));
        }

        /// <summary>
        /// Test if the instance gets deleted from the FEGYENC table
        /// </summary>
        [Test]
        public void HaDelete_FEGYENCAkkorTorli()
        {
            Mock<Logic> m = new Mock<Logic>();
            m.Object.Fegyenc.Insert(m.Object.Entity, new FEGYENC() { fegyenc_ID = 16, itelet_ID = 10, agy = 1, cellaszam = 1, bortonor_ID = 5, nev = " " });
            m.Object.Fegyenc.Delete(m.Object.Entity, new int[] { 16 });
            Assert.That(m.Object.Fegyenc.Listing(m.Object.Entity).Select(x => x.fegyenc_ID).Contains(15), Is.EqualTo(false));
        }

        /// <summary>
        /// Test if the instance gets deleted from the BUNTETT table
        /// </summary>
        [Test]
        public void HaDelete_BUNTETTAkkorTorli()
        {
            Mock<Logic> m = new Mock<Logic>();
            m.Object.Buntett.Insert(m.Object.Entity, new BUNTETT() { buntett_ID = 15 });
            m.Object.Buntett.Delete(m.Object.Entity, new int[] { 15 });
            Assert.That(m.Object.Buntett.Listing(m.Object.Entity).Select(x => x.buntett_ID).Contains(15), Is.EqualTo(false));
        }

        /// <summary>
        /// Test if the instance gets deleted from the ITELET table
        /// </summary>
        [Test]
        public void HaDelete_ITELETAkkorTorli()
        {
            Mock<Logic> m = new Mock<Logic>();
            m.Object.Itelet.Insert(m.Object.Entity, new ITELET() { itelet_ID = 19, buntett_ID = 1, biro = "Valaki" });
            m.Object.Itelet.Delete(m.Object.Entity, new int[] { 19 });
            Assert.That(m.Object.Itelet.Listing(m.Object.Entity).SingleOrDefault(x => x.itelet_ID == 19), Is.EqualTo(null));
        }

        /// <summary>
        /// Test if the instance gets deleted from the ELHELYEZES table
        /// </summary>
        [Test]
        public void HaDelete_ELHELYEZESAkkorTorli()
        {
            Mock<Logic> m = new Mock<Logic>();
            m.Object.Elhelyezes.Insert(m.Object.Entity, new ELHELYEZES() { cellaszam = 100, agy = 1 });
            m.Object.Elhelyezes.Delete(m.Object.Entity, new int[] { 100, 1 });
            Assert.That(m.Object.Elhelyezes.Listing(m.Object.Entity).SingleOrDefault(x => x.cellaszam == 100 && x.agy == 1), Is.EqualTo(null));
        }

        /// <summary>
        /// Test if the instance gets deleted from the BORTONOR table
        /// </summary>
        [Test]
        public void HaDelete_BORTONORAkkorTorli()
        {
            Random rand = new Random();
            int k = rand.Next(999);
            Mock<Logic> m = new Mock<Logic>();
            m.Object.Bortonor.Insert(m.Object.Entity, new BORTONOR() { bortonor_ID = 20, jelveny_szam = k });
            m.Object.Bortonor.Delete(m.Object.Entity, new int[] { 20 });
            Assert.That(m.Object.Bortonor.Listing(m.Object.Entity).SingleOrDefault(x => x.bortonor_ID == 20), Is.EqualTo(null));
        }

        /// <summary>
        /// Test if the instance gets updated after calling the Update method on the FEGYENC table
        /// </summary>
        [Test]
        public void Update_FEGYENC()
        {
            Mock<Logic> m = new Mock<Logic>();
            m.Object.Fegyenc.Update(m.Object.Entity, "Luis Garavito", "TESZT", "nev", "nev");
            Assert.That(m.Object.Fegyenc.Listing(m.Object.Entity).Where(x => x.nev == "TESZT").Count(), Is.EqualTo(1));
        }

        /// <summary>
        /// Test if the instance gets updated after calling the Update method on the BUNTETT table
        /// </summary>
        [Test]
        public void Update_BUNTETT()
        {
            Mock<Logic> m = new Mock<Logic>();
            m.Object.Buntett.Insert(m.Object.Entity, new BUNTETT() { buntett_ID = 15, aldozat = "Valaki" });
            m.Object.Buntett.Update(m.Object.Entity, 15, "TESZT", "buntett_ID", "aldozat");
            Assert.That(m.Object.Buntett.Listing(m.Object.Entity).ToList().FindAll(x => x.aldozat == "TESZT").Count(), Is.EqualTo(1));
        }

        /// <summary>
        /// Test if the instance gets updated after calling the Update method on the ITELET table
        /// </summary>
        [Test]
        public void Update_ITELET()
        {
            Mock<Logic> m = new Mock<Logic>();
            m.Object.Itelet.Insert(m.Object.Entity, new ITELET() { itelet_ID = 20, buntett_ID = 1, biro = "Valaki" });
            m.Object.Itelet.Update(m.Object.Entity, 20, "TESZT", "itelet_ID", "biro");
            Assert.That(m.Object.Itelet.Listing(m.Object.Entity).Where(x => x.biro == "TESZT")?.Count(), Is.EqualTo(1));
        }

        /// <summary>
        /// Test if the instance gets updated after calling the Update method on the ELHELYEZES table
        /// </summary>
        [Test]
        public void Update_ELHELYEZES()
        {
            Mock<Logic> m = new Mock<Logic>();
            m.Object.Elhelyezes.Insert(m.Object.Entity, new ELHELYEZES() { cellaszam = 101, reszleg = "B", agy = 1 });
            m.Object.Elhelyezes.Update(m.Object.Entity, 101, "A", "cellaszam", "reszleg");
            Assert.That(m.Object.Elhelyezes.Listing(m.Object.Entity).Where(x => x.cellaszam == 101).Select(x => x.reszleg).SingleOrDefault(), Is.EqualTo("A"));
        }

        /// <summary>
        /// Test if the instance gets updated after calling the Update method on the BORTONOR table
        /// </summary>
        [Test]
        public void Update_BORTONOR()
        {
            Random rand = new Random();
            int r = rand.Next(999);
            Mock<Logic> m = new Mock<Logic>();
            m.Object.Bortonor.Insert(m.Object.Entity, new BORTONOR() { bortonor_ID = 20, nev = "Kis Pista", jelveny_szam = r });
            m.Object.Bortonor.Update(m.Object.Entity, 20, "TESZT", "bortonor_ID", "nev");
            Assert.That(m.Object.Bortonor.Listing(m.Object.Entity).ToList().FindAll(x => x.nev == "TESZT").Count(), Is.EqualTo(1));
        }

        /// <summary>
        /// Test if the Listing method returns the correct value for the FEGYENC instance
        /// </summary>
        [Test]
        public void Listing_FEGYENC()
        {
            Mock<Logic> m = new Mock<Logic>();
            Assert.That(m.Object.Fegyenc.Listing(m.Object.Entity).Count(), Is.EqualTo(m.Object.Entity.FEGYENC.Count()));
        }

        /// <summary>
        /// Test if the Listing method returns the correct value for the ELHELYEZES instance
        /// </summary>
        [Test]
        public void Listing_ELHELYEZES()
        {
            Mock<Logic> m = new Mock<Logic>();
            Assert.That(m.Object.Elhelyezes.Listing(m.Object.Entity).Count(), Is.EqualTo(m.Object.Entity.ELHELYEZES.Count()));
        }

        /// <summary>
        /// Test if the Listing method returns the correct value for the BUNTETT instance
        /// </summary>
        [Test]
        public void Listing_BUNTETT()
        {
            Mock<Logic> m = new Mock<Logic>();
            Assert.That(m.Object.Buntett.Listing(m.Object.Entity).Count(), Is.EqualTo(m.Object.Entity.BUNTETT.Count()));
        }

        /// <summary>
        /// Test if the Listing method returns the correct value for the ITELETT instance
        /// </summary>
        [Test]
        public void Listing_ITELET()
        {
            Mock<Logic> m = new Mock<Logic>();
            Assert.That(m.Object.Itelet.Listing(m.Object.Entity).Count(), Is.EqualTo(m.Object.Entity.ITELET.Count()));
        }

        /// <summary>
        /// Test if the Listing method returns the correct value for the BORTONOR instance
        /// </summary>
        [Test]
        public void Listing_BORTONOR()
        {
            Mock<Logic> m = new Mock<Logic>();
            Assert.That(m.Object.Bortonor.Listing(m.Object.Entity).Count(), Is.EqualTo(m.Object.Entity.BORTONOR.Count()));
        }

        /// <summary>
        /// Tests, if the BuntettekEsFegyencekListazasa method returns a value which has 2 instances where Buntett_leiras is "Nemi erőszak" is 2
        /// </summary>
        [Test]
        public void BuntettekEsFegyencekListazasaTest_1()
        {
            var q = this.logic.BuntettekEsFegyencekListazasa(this.logic.Entity);
            Assert.That(this.logic.BuntettekEsFegyencekListazasa(this.logic.Entity).Where(x => x.BuntettLeiras == "Nemi erőszak").Select(x => x.BuntettLeiras).Count(), Is.EqualTo(2));
        }

        /// <summary>
        /// Test if the BuntettekEsFegyencekListazasa method (on the mock repository) return value contains an instance where the summary of the jail time is 34.
        /// </summary>
        [Test]
        public void BuntettekEsFegyencekListazasaTest_2()
        {
            Assert.That(this.logic.BuntettekEsFegyencekListazasa(this.logic.Entity).Select(x => x.LetoltendoIdo).Sum(), Is.EqualTo(7 + 8 + 9 + 10));
        }

        /// <summary>
        /// Test if the BuntettekEsFegyencekListazasa method return value on the mocked repository has the count of 4
        /// </summary>
        [Test]
        public void BuntettekEsFegyencekListazasaTest_3()
        {
            Assert.That(this.logic.BuntettekEsFegyencekListazasa(this.logic.Entity).Count(), Is.EqualTo(4));
        }

        /// <summary>
        /// Test, if the return value of the FegyencEsElhelyezesListazas method on the mocked repository contains an instance where fegyenc_nev= "Luis Garavito"
        /// , lives on "A" section and on the 1. floor
        /// </summary>
        [Test]
        public void FegyencEsElhelyezesListazasTest_1()
        {
            Assert.That(this.logic.FegyencEsElhelyezesListazas(this.logic.Entity).Where(x => x.Nev == "Luis Garavito").Select(x => x.Reszleg).First(), Is.EqualTo("A"));
            Assert.That(this.logic.FegyencEsElhelyezesListazas(this.logic.Entity).Where(x => x.Nev == "Luis Garavito").Select(x => x.Emelet).First(), Is.EqualTo(1));
        }

        /// <summary>
        /// Tests, if the return value of the FegyencEsElhelyezesListazas method on mocked repository's count has the count of 4
        /// </summary>
        [Test]
        public void FegyencEsElhelyezesListazasTest_2()
        {
            Assert.That(this.logic.FegyencEsElhelyezesListazas(this.logic.Entity).Count(), Is.EqualTo(4));
        }

        /// <summary>
        /// Tests, if the return value of the FegyencEsElhelyezesekListazasa method on mocked repository contains an instance where the ID is 3, the name is John Wayne Gacy
        /// and the floor is 2.
        /// </summary>
        [Test]
        public void FegyencEsElhelyezesListazasTest_3()
        {
            Assert.That(this.logic.FegyencEsElhelyezesListazas(this.logic.Entity).Where(x => x.Cellaszam == 3).Select(x => x.Nev).First(), Is.EqualTo("John Wayne Gacy"));
            Assert.That(this.logic.FegyencEsElhelyezesListazas(this.logic.Entity).Where(x => x.Cellaszam == 3).Select(x => x.Emelet).First(), Is.EqualTo(2));
        }

        /// <summary>
        /// Tests, if the count of the return value of the HanyfeleBuntettListazas method has the count of 3
        /// </summary>
        [Test]
        public void HanyfeleBuntettListazasTest_1()
        {
            Assert.That(this.logic.HanyfeleBuntettListazas(this.logic.Entity).Count(), Is.EqualTo(3));
        }

        /// <summary>
        /// Tests, if the return value of the HanyfeleBuntettListazas method on mocked repository contains a value where Buntett leiras is nemi erőszak
        /// and the convicts number is 2 and the average jail time is 9 years
        /// </summary>
        [Test]
        public void HanyfeleBuntettListazasTest_2()
        {
            Assert.That(this.logic.HanyfeleBuntettListazas(this.logic.Entity).Where(x => x.BuntettLeiras == "Nemi erőszak").Select(x => x.FegyencekSzama).First(), Is.EqualTo(2));
            Assert.That(this.logic.HanyfeleBuntettListazas(this.logic.Entity).Where(x => x.BuntettLeiras == "Nemi erőszak").Select(x => x.AtlagosLetoltendoIdo).First(), Is.EqualTo(9));
        }

        /// <summary>
        ///  Tests, if the return value of the HanyfeleBuntettListazas method on mocked repository where the commited crime is adócsalás count is 1
        /// </summary>
        [Test]
        public void HanyfeleBuntettListazasTest_3()
        {
            Assert.That(this.logic.HanyfeleBuntettListazas(this.logic.Entity).Where(x => x.BuntettLeiras == "Adócsalás").Select(x => x.FegyencekSzama).First(), Is.EqualTo(1));
        }

        /// <summary>
        /// Tests if the return value fo the HanyfeleBuntettListazas method on mocked repository where the number of once committed buntett leiras is 2ú
        /// </summary>
        [Test]
        public void HanyfeleBuntettListazasTest_4()
        {
            Assert.That(this.logic.HanyfeleBuntettListazas(this.logic.Entity).Where(x => x.FegyencekSzama == 1).Count(), Is.EqualTo(2));
        }
    }
}
