using DBHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace ServerProject.Models.DAL
{
    public class BandRepository
    {
        public static ObservableCollection<Band> Bands()
        {


            ObservableCollection<Band> lijst = new ObservableCollection<Band>();
            string sql = "SELECT * FROM Bands";
            DbDataReader Reader = Database.GetData(sql);
            while (Reader.Read())
            {
                Band temp = new Band();
                temp.ID = Reader["ID"].ToString();
                temp.Name = Reader["Name"].ToString();
                temp.Description = Reader["Description"].ToString();
                temp.Facebook = Reader["Facebook"].ToString();
                temp.Picture = Reader["Picture"].ToString();
                temp.Twitter = Reader["Twitter"].ToString();
                lijst.Add(temp);
            }

            AddGenres(lijst);
            return lijst;

        }
        public static Band BandByID(DbTransaction tran , int id)
        {

           Band temp = new Band();
            string sql = "SELECT * FROM Bands WHERE ID = @ID";
            DbParameter par = Database.AddParameter("@ID", id);
            DbDataReader Reader = Database.GetData(sql);
            while (Reader.Read())
            {
            
                temp.ID = Reader["ID"].ToString();
                temp.Name = Reader["Name"].ToString();
                temp.Description = Reader["Description"].ToString();
                temp.Facebook = Reader["Facebook"].ToString();
                temp.Picture = Reader["Picture"].ToString();
                temp.Twitter = Reader["Twitter"].ToString();
               
            }

            AddGenre(temp);
            return temp;

        }
        public static void AddGenres(ObservableCollection<Band> lijst)
        {

            foreach (Band item in lijst)
            {
                AddGenre(item);


            }


        }

        private static void AddGenre(Band item)
        {
            ObservableCollection<Genre> tempLijst = new ObservableCollection<Genre>();
            string sql = "SELECT bands_genres.*,genres.ID as GenreID,genres.name as GenreName FROM festival.bands_genres INNER JOIN festival.genres ON bands_genres.GenreID = genres.ID WHERE BandID = @BandID ";
            DbParameter par = Database.AddParameter("@BandID", item.ID);
            DbDataReader reader = Database.GetData(sql, par);
            if (reader != null)
            {

                while (reader.Read())
                {


                    Genre temp = new Genre();
                    temp.ID = reader["GenreID"].ToString();
                    temp.Name = reader["GenreName"].ToString();
                    tempLijst.Add(temp);

                }
                item.Genres = tempLijst;

            }
        }
        

        private static void ParamsMaken(string name, string pic, string descrp, string facebook, string twitter, string sql, string BandID = null)
        {
            DbParameter parName = Database.AddParameter("@Name", name);
            DbParameter parPic = Database.AddParameter("@Picture", pic);
            DbParameter parDescrp = Database.AddParameter("@Description", descrp);
            DbParameter parFacebook = Database.AddParameter("@Facebook", facebook);
            DbParameter parTwitter = Database.AddParameter("@Twitter", twitter);
            DbParameter parBandID = Database.AddParameter("@BandID", BandID);
            Database.ModifyData(sql, parName, parPic, parDescrp, parFacebook, parTwitter, parBandID);
        }

       
    }
}