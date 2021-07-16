// <copyright file="Logic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Borton.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Xml.Linq;
    using Borton.Data;
    using Borton.Repository;

    /// <summary>
    /// Navigates the methods and variables to the Repository class
    /// </summary>
    public class Logic : ILogic
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Logic"/> class.
        /// </summary>
        public Logic()
        {
            this.Entity = new BortonEntities();
            this.Fegyenc = new FegyencRepository();
            this.Bortonor = new BortonorRepository();
            this.Itelet = new IteletRepository();
            this.Elhelyezes = new ElhelyezesRepository();
            this.Buntett = new BuntettRepository();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Logic"/> class.
        /// Constructor needed for the testing with mocked objects
        /// </summary>
        /// <param name="entity">A BortonEntities instance</param>
        /// <param name="fegyenc">A set up instance for the operations on the FEGYENC entities</param>
        /// <param name="bortonor">A set up instance for the operations on the BORTONOR entities</param>
        /// <param name="itelet">A set up instance for the operations on the ITELET entities</param>
        /// <param name="elhelyezes">A set up instance for the operations on the ELHELYEZES entities</param>
        /// <param name="buntett">A set up instance for the operations on the BUNTETT entities</param>
        public Logic(BortonEntities entity, IRepository<FEGYENC> fegyenc, IRepository<BORTONOR> bortonor, IRepository<ITELET> itelet, IRepository<ELHELYEZES> elhelyezes, IRepository<BUNTETT> buntett)
        {
            this.Entity = entity;
            this.Fegyenc = fegyenc;
            this.Bortonor = bortonor;
            this.Itelet = itelet;
            this.Elhelyezes = elhelyezes;
            this.Buntett = buntett;
        }

        /// <summary>
        /// Gets or sets an instance of an IRepository for the operations on the FEGYENC entity
        /// </summary>
        public IRepository<FEGYENC> Fegyenc { get; set; }

        /// <summary>
        /// Gets or sets an instance of an IRepository for the operations on the BORTONOR entity
        /// </summary>
        public IRepository<BORTONOR> Bortonor { get; set; }

        /// <summary>
        /// Gets or sets an instance of an IRepository for the operations on the BUNTETT entity
        /// </summary>
        public IRepository<BUNTETT> Buntett { get; set; }

        /// <summary>
        /// Gets or sets an instance of an IRepository for the operations on the ITELET entity
        /// </summary>
        public IRepository<ITELET> Itelet { get; set; }

        /// <summary>
        /// Gets or sets an instance of an IRepository for the operations on the ELHELYEZES entity
        /// </summary>
        public IRepository<ELHELYEZES> Elhelyezes { get; set; }

        /// <summary>
        /// Gets or sets an instance of BortonEntities entity model
        /// </summary>
        public BortonEntities Entity { get; set; }

        /// <summary>
        /// Deleting entities and navigating them to Repository
        /// </summary>
        /// <param name="melyiktabla">The identifier of the table</param>
        /// <param name="azonosito">The identifier of the instance to delete</param>
        public void Delete(int melyiktabla, params string[] azonosito)
        {
            if (melyiktabla != 5)
            {
                if (azonosito[0].All(char.IsDigit))
                {
                    if (melyiktabla == 1)
                    {
                        this.Fegyenc.Delete(this.Entity, int.Parse(azonosito[0]));
                    }
                    else if (melyiktabla == 2)
                    {
                        this.Bortonor.Delete(this.Entity, int.Parse(azonosito[0]));
                    }
                    else if (melyiktabla == 3)
                    {
                        this.Itelet.Delete(this.Entity, int.Parse(azonosito[0]));
                    }
                    else if (melyiktabla == 4)
                    {
                        this.Buntett.Delete(this.Entity, int.Parse(azonosito[0]));
                    }
                }
                else
                {
                    throw new InvalidCastException();
                }
            }
            else
            {
                if (azonosito[0].All(char.IsDigit) && azonosito[1].All(char.IsDigit))
                {
                    this.Elhelyezes.Delete(this.Entity, int.Parse(azonosito[0]), int.Parse(azonosito[1]));
                }
                else
                {
                    throw new InvalidCastException();
                }
            }
        }

        /// <summary>
        /// Updating an entity and navigating them to the Repository
        /// </summary>
        /// <param name="melyiktabla">The identifier of the table</param>
        /// <param name="filteringValue">the value by which we want to filter</param>
        /// <param name="modifiedValue">the value to which we want to modify the current one</param>
        /// <param name="propertyNameForModifying">the property we want to modify</param>
        /// <param name="propertyNameForFiltering">the property by which we filter</param>
        public void Update(int melyiktabla, object filteringValue, object modifiedValue, string propertyNameForModifying, string propertyNameForFiltering)
        {
            if (melyiktabla == 1)
            {
                this.Fegyenc.Update(this.Entity, filteringValue, modifiedValue, propertyNameForFiltering, propertyNameForModifying);
            }
            else if (melyiktabla == 2)
            {
                this.Bortonor.Update(this.Entity, filteringValue, modifiedValue, propertyNameForFiltering, propertyNameForModifying);
            }
            else if (melyiktabla == 3)
            {
                this.Itelet.Update(this.Entity, filteringValue, modifiedValue, propertyNameForFiltering, propertyNameForModifying);
            }
            else if (melyiktabla == 4)
            {
                this.Buntett.Update(this.Entity, filteringValue, modifiedValue, propertyNameForFiltering, propertyNameForModifying);
            }
            else
            {
                this.Elhelyezes.Update(this.Entity, filteringValue, modifiedValue, propertyNameForFiltering, propertyNameForModifying);
            }
        }

        /// <summary>
        /// Returns which convict commited which crime, how many years of jail time it got.
        /// </summary>
        /// <param name="entity">BortonEntities instance for the Listing operation</param>
        /// <returns>Returns the result as IEnumerable</returns>
        public IEnumerable<BuntettekEsFegyencek> BuntettekEsFegyencekListazasa(BortonEntities entity)
        {
            var q = (from x1 in this.Fegyenc.Listing(entity)
                     join x2 in this.Itelet.Listing(entity) on x1.itelet_ID equals x2.itelet_ID
                     join x3 in this.Buntett.Listing(entity) on x2.buntett_ID equals x3.buntett_ID
                     select new BuntettekEsFegyencek()
                     {
                         Nev = x1.nev,
                         LetoltendoIdo = (int)x2.letoltendo_ido,
                         BuntettLeiras = x3.buntett_leiras
                     }).OrderBy(x => -x.LetoltendoIdo);

            return q;
        }

        /// <summary>
        /// Returns the result of the BuntettekEsFegyencekListaza method
        /// </summary>
        /// <returns>Returns the result as string</returns>
        public string BuntettekEsFegyencekToString()
        {
            string returnol = string.Empty;
            foreach (var item in this.BuntettekEsFegyencekListazasa(this.Entity))
            {
                returnol += string.Format("NÉV:  {0}, LETÖLTENDŐ IDŐ:  {1}, BUNTETT LEÍRÁSA:  {2}\n", item.Nev, item.LetoltendoIdo, item.BuntettLeiras);
            }

            return returnol;
        }

        /// <summary>
        /// Returns the name of the convict, the section and the cellnumber
        /// </summary>
        /// <param name="entity">BortonEntities instance for the Listing operation</param>
        /// <returns>Returns the result as IEnumerable</returns>
        public IEnumerable<FegyencElhelyezesek> FegyencEsElhelyezesListazas(BortonEntities entity)
        {
            var q = (from x1 in this.Fegyenc.Listing(entity)
                     join x2 in this.Elhelyezes.Listing(entity) on x1.cellaszam equals x2.cellaszam
                     where x1.agy == x2.agy
                     select new FegyencElhelyezesek()
                     {
                         Nev = x1.nev,
                         Emelet = (int)x2.emelet,
                         Reszleg = x2.reszleg,
                         Cellaszam = (int)x1.cellaszam
                     }).OrderBy(x => x.Emelet);
            return q;
        }

        /// <summary>
        /// Returns the result of the FegyencEsElhelyezesListazas method
        /// </summary>
        /// <returns>Returns the result as string</returns>
        public string FegyencEsElhelyezesKiiras()
        {
            string returnol = null;
            foreach (var item in this.FegyencEsElhelyezesListazas(this.Entity))
            {
                returnol += string.Format("NÉV:  {0}, EMELET:  {1}, RÉSZLEG:  {2}, CELLASZÁM:  {3}\n", item.Nev, item.Emelet, item.Reszleg, item.Cellaszam);
            }

            return returnol;
        }

        /// <summary>
        /// One of the non-CRUD methods, returns what kind of crimes have the convicts committed, the average jailtime and the number of convicts in for the crime.
        /// </summary>
        /// <param name="entity">BortonEntities instance for the Listing operation</param>
        /// <returns>Returns the result as IEnumerable</returns>
        public IEnumerable<Buntettek> HanyfeleBuntettListazas(BortonEntities entity)
        {
            var q = (from x1 in this.Buntett.Listing(entity)
                     join x2 in this.Itelet.Listing(entity) on x1.buntett_ID equals x2.buntett_ID
                     join x3 in this.Fegyenc.Listing(entity) on x2.itelet_ID equals x3.itelet_ID
                     group x2 by x1.buntett_leiras into g
                     select new Buntettek()
                     {
                         BuntettLeiras = g.Key,
                         AtlagosLetoltendoIdo = Math.Round((double)g.Average(x => x.letoltendo_ido), 2),
                         FegyencekSzama = g.Count()
                     }).OrderBy(x => -x.FegyencekSzama);
            return q;
        }

        /// <summary>
        /// Returns the result of the HanyfeleBuntettListazas method
        /// </summary>
        /// <returns>Returns the result as string</returns>
        public string HanyfeleBuntettToString()
        {
            string returnol = null;
            foreach (var item in this.HanyfeleBuntettListazas(this.Entity))
            {
                returnol += string.Format("BŰNTETT LEÍRÁS:  {0}, ÁTLAGOS LETÖLTENDŐ IDŐ:  {1}, FEGYENCEK SZÁMA:  {2}\n", item.BuntettLeiras, item.AtlagosLetoltendoIdo, item.FegyencekSzama);
            }

            return returnol;
        }

        /// <summary>
        /// Loads and processes the xml file generated by the Java project.
        /// It passes three parameters with GET: fegyencnev, fegyenc_ID, letoltendo_ido.
        /// </summary>
        /// <param name="letoltendo_ido">The jailtime of the convict which is passed to another method</param>
        /// <param name="fegyencnev">The name of the convict which is passed to another method</param>
        /// <param name="fegyenc_id">The identifier of the convict which is passed to another method</param>
        /// <returns>returns the generated data in string format</returns>
        public string Java(string letoltendo_ido, string fegyencnev, string fegyenc_id)
        {
            if (!letoltendo_ido.All(char.IsDigit))
            {
                throw new InvalidCastException();
            }
            else
            {
                XDocument xd = XDocument.Load("http://localhost:8080/Borton/Generalas?fegyenc=" + fegyencnev + "&fegyenc_id=" + fegyenc_id + "&letoltendo_ido=" + letoltendo_ido);
                var tablazatba = from x in xd.Descendants("fegyenc")
                                 select new
                                 {
                                     Nev = x.Element("nev").Value,
                                     Azonosito = x.Element("azonosito").Value,
                                     Ev = x.Element("ev").Value,
                                     Letoltendo_ido = x.Element("letoltendo_ido").Value
                                 };
                StringBuilder builder = new StringBuilder();
                builder.Append("\nLetöltendő idők alakulása az évek során \"" + tablazatba.First().Azonosito + "\" azonosítójú fegyenc esetén (neve: " + tablazatba.First().Nev + "): \n");
                foreach (var s in tablazatba)
                {
                    builder.Append("Év: " + s.Ev + ", hátralevő letöltendő idő " + s.Letoltendo_ido + " év\n");
                }

                return builder.ToString();
            }
        }

        /// <summary>
        /// Navigates inseritng the entity to the Repository
        /// </summary>
        /// <param name="melyiktabla">Identifies the type of the table</param>
        /// <param name="values">The values which are inserted</param>
        public void Insert(int melyiktabla, string[] values)
        {
            object obj;
            Type type;
            if (melyiktabla == 1)
            {
                obj = new FEGYENC();
                type = typeof(FEGYENC);
                obj = this.InsertSeged(type, obj, values);
                this.Fegyenc.Insert(this.Entity, obj as FEGYENC);
            }
            else if (melyiktabla == 2)
            {
                obj = new BORTONOR();
                type = typeof(BORTONOR);
                obj = this.InsertSeged(type, obj, values);
                this.Bortonor.Insert(this.Entity, obj as BORTONOR);
            }
            else if (melyiktabla == 3)
            {
                obj = new ITELET();
                type = typeof(ITELET);
                obj = this.InsertSeged(type, obj, values);
                this.Itelet.Insert(this.Entity, obj as ITELET);
            }
            else if (melyiktabla == 4)
            {
                obj = new BUNTETT();
                type = typeof(BUNTETT);
                obj = this.InsertSeged(type, obj, values);
                this.Buntett.Insert(this.Entity, obj as BUNTETT);
            }
            else
            {
                obj = new ELHELYEZES();
                type = typeof(ELHELYEZES);
                obj = this.InsertSeged(type, obj, values);
                this.Elhelyezes.Insert(this.Entity, obj as ELHELYEZES);
            }
        }

        /// <summary>
        /// This method inserts the parameters given by the users to the instance
        /// </summary>
        /// <param name="type">Identifies the type of the entity</param>
        /// <param name="obj">The instance of the object</param>
        /// <param name="values">The values which are inserted</param>
        /// <returns>Returns the object set</returns>
        public object InsertSeged(Type type, object obj, string[] values)
        {
            int cv = 0;
            foreach (var i in type.GetProperties())
            {
                if (!i.GetGetMethod().IsVirtual)
                {
                    object x2 = values[cv];
                    if (i != null)
                    {
                        Type t = Nullable.GetUnderlyingType(i.PropertyType) ?? i.PropertyType;

                        object safeValue = (i == null) ? null : Convert.ChangeType(x2, t);

                        i.SetValue(obj, safeValue, null);
                    }
                }

                cv++;
            }

            return obj;
        }

        /// <summary>
        /// Returns the names of non-virtual properties as string
        /// </summary>
        /// <param name="melyiktabla">Identifier of the table</param>
        /// <returns>Returns the result as string</returns>
        public string[] PropertyNamesToString(string melyiktabla)
        {
            Type type = this.TableidToType(melyiktabla);
            var properties = type.GetProperties().Where(x => !x.GetGetMethod().IsVirtual).ToArray();
            string[] names = new string[properties.Length];
            for (int i = 0; i < names.Length; i++)
            {
                names[i] = properties[i].Name;
            }

            return names;
        }

        /// <summary>
        /// Returns the result of the Listing methods
        /// </summary>
        /// <param name="melyiktabla">The identifier of the table</param>
        /// <returns>Returns the result as string</returns>
        public string Listing(int melyiktabla)
        {
            string returnol = null;
            if (melyiktabla == 1)
            {
                foreach (var item in this.Fegyenc.Listing(this.Entity))
                {
                    returnol += string.Format("NÉV: {0}, ID: {1}, NEM: {2}, ITELET ID: {3}, SZÜLETÉSI DÁTUM: {4}, SZÜLETÉSI HELY: {5}, LETÖLTÉSI IDŐ KEZDETE: {6}, CELLA: {7}, ÁGY :{8}\n", item.nev, item.fegyenc_ID, item.nem, item.itelet_ID, item.szuletesi_datum, item.szuletesi_hely, item.letoltesi_ido_kezdete, item.cellaszam, item.agy);
                }
            }
            else if (melyiktabla == 2)
            {
                foreach (var item in this.Bortonor.Listing(this.Entity))
                {
                    returnol += string.Format("NÉV: {0}, ID: {1}, JELVÉNYSZÁM: {2}, SZÜLETÉSI DÁTUM: {3}, SZÜLETÉSI HELY: {4}, MUNKA KEZDETE: {5}\n", item.nev, item.bortonor_ID, item.jelveny_szam, item.szuletesi_datum, item.szuletesi_hely, item.munka_kezdete);
                }
            }
            else if (melyiktabla == 3)
            {
                ITELET obj = new ITELET();
                foreach (var item in this.Itelet.Listing(this.Entity))
                {
                    returnol += string.Format("ID: {0}, ÍTÉLET DÁTUMA: {1}, LETÖLTENDO IDŐ: {2}, BÍRÓ: {3}, ÜGYVÉD: {4}, BŰNTETT ID: {5}\n", item.itelet_ID, item.itelet_datuma, item.letoltendo_ido, item.biro, item.ugyved, item.buntett_ID);
                }
            }
            else if (melyiktabla == 4)
            {
                BUNTETT obj = new BUNTETT();
                foreach (var item in this.Buntett.Listing(this.Entity))
                {
                    returnol += string.Format("ID: {0}, LETARTÓZTATÓ SZEMÉLY: {1}, BŰNTETT LEÍRÁS: {2}, ÁLDOZAT: {3}, ELKÖVETÉS HELYE: {4}\n", item.buntett_ID, item.letartoztato_szemely, item.buntett_leiras, item.aldozat, item.elkovetes_helye);
                }
            }
            else
            {
                foreach (var item in this.Elhelyezes.Listing(this.Entity))
                {
                    returnol += string.Format("CELLA: {0}, ÁGY {1}, EMELET: {2}, RÉSZLEG: {3}\n", item.cellaszam, item.agy, item.emelet, item.reszleg);
                }
            }

            return returnol;
        }

        /// <summary>
        /// Returns a Type from an int which identifies the table
        /// </summary>
        /// <param name="melyiktabla">The identifier of the table</param>
        /// <returns>Type instance</returns>
        private Type TableidToType(string melyiktabla)
        {
            Type type = null;
            if (melyiktabla == "1")
            {
                type = typeof(FEGYENC);
            }
            else if (melyiktabla == "2")
            {
                type = typeof(BORTONOR);
            }
            else if (melyiktabla == "3")
            {
                type = typeof(ITELET);
            }
            else if (melyiktabla == "4")
            {
                type = typeof(BUNTETT);
            }
            else
            {
                type = typeof(ELHELYEZES);
            }

            return type;
        }
    }
}