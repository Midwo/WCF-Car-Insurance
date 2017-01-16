using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF_generowanie
{
    public class Service1 : IService1
    {

        string sqlconnectionstring = WCF_generowanie.Properties.Settings.Default.connectionstring;

        DataSet sqldata(string cmd)
        {
            
            using (SqlConnection connection = new SqlConnection(sqlconnectionstring))
            {
                connection.Open();

                SqlDataAdapter adp = new SqlDataAdapter(cmd,connection);
             


                DataSet ds = new DataSet();
                try
                {

                    adp.Fill(ds);
                }
                catch
                {
                    return ds;
                }
                return ds;
            }
        }

        void sqlcommand(string cmd)
        {
            using (SqlConnection connection = new SqlConnection(sqlconnectionstring))
            {
                SqlCommand command = new SqlCommand(cmd, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public string UpdateBasicInformation(int ID, string personal_identity_number, string identity_card_number, string address, string name_surname, float discounts, string phone_number, DateTime birthday)
        {
            try
            {
                string date = birthday.ToUniversalTime().ToString("u");
                string command = "UPDATE[dbo].[BasicInformation] SET [personal_identity_number] = '"+personal_identity_number+"',  [identity_card_number] = '"+identity_card_number+"', [address] = '"+address+"',  [name_surname] = '"+name_surname+"', [phone_number] = '"+phone_number+"', [birthday] = '"+date+"', [discounts] = '"+discounts.ToString().Replace(',','.')+"' Where ID = "+ID+"";
                sqlcommand(command);
                return "Zaktualizowano  dane";
            }
            catch
            {
                return "Nie zaktualizowano danych.";
            }

        }

        public HistoryOfAccidents SaveAccidents(HistoryOfAccidents AllInfo)
        {
            if (AllInfo.Vin == null || AllInfo.CarName == null || AllInfo.Date == null || AllInfo.DescriptionOfTheDamage == null || AllInfo.Vin == null )
            {
                AllInfo.Info = "Nie zapisano danych";
                return AllInfo;
            }


            else
            {
                try
                {
                 
                    string command = "INSERT INTO [dbo].[HistoryOfAccidents] ([vin], [descriptionofthedamage], [carname], [personal_identity_number], [penalty], [date]) VALUES ('" + AllInfo.Vin + "', '" + AllInfo.DescriptionOfTheDamage + "', '" + AllInfo.CarName + "', '" + AllInfo.PersonalIdentityNumber + "', " + AllInfo.Penalty.ToString().Replace(',','.') + ", '" + AllInfo.Date.ToString("yyyy.MM.dd hh:mm:ss") + "')";
                    sqlcommand(command);
                    AllInfo.Info = "Zapisano dane";

                    return AllInfo;
                }
                catch (Exception ex)
                {
          
                    AllInfo.Info = "Nie zapisano danych, błąd: " + ex.ToString() + "";
                    return AllInfo;
                }

            }


        }

        public BasicInformation SaveBasicInformation(BasicInformation AllInfo)
        {
            if (AllInfo.Address == null || AllInfo.Birthday == null || AllInfo.Identity_card_number == null || AllInfo.Name_surname == null || AllInfo.Personal_identity_number == null || AllInfo.Phone_number == null)
            {
                AllInfo.Info = "Nie zapisano danych";
                return AllInfo;
            }


            else
            {
                try
                {
  
                    string command = "INSERT INTO [dbo].[BasicInformation] ([personal_identity_number], [identity_card_number], [address], [name_surname], [discounts], [phone_number], [birthday]) VALUES ('"+AllInfo.Personal_identity_number+ "', '" + AllInfo.Identity_card_number + "', '" + AllInfo.Address + "', '" + AllInfo.Name_surname + "', '" + AllInfo.Discounts.ToString().Replace(',', '.') + "', '" + AllInfo.Phone_number + "', '" + AllInfo.Birthday.ToString("yyyy.MM.dd hh:mm:ss") + "')";
                    sqlcommand(command);
                    
                    AllInfo.Info = "Zapisano dane";
                    return AllInfo;
                }
                catch (Exception ex)
                {
                    AllInfo.Info = "Nie zapisano danych, błąd: " + ex.ToString() + "";
                    return AllInfo;
                }

            }
        }

        public PurchaseHistory SavePurchaseHistory(PurchaseHistory AllInfo)
        {

            if (AllInfo.Begindate == null || AllInfo.Begindate == null || AllInfo.Descriptioncar == null || AllInfo.Descriptionpackage == null || AllInfo.Enddate == null || AllInfo.Nameinsurer == null || AllInfo.Personal_identity_number == null || AllInfo.Savedate == null || AllInfo.Vin == null)
            {
                AllInfo.Info = "Nie zapisano danych";
                return AllInfo;
            }

            else
            {
                try
                {
                   

                    string command = "INSERT INTO [dbo].[PurchaseHistory] ([personal_identity_number], [vin], [begindate], [enddate], [price], [descriptionpackage], [descriptioncar], [active], [nameinsurer], [savedate]) VALUES ('" + AllInfo.Personal_identity_number+ "', '" + AllInfo.Vin+"', '" + AllInfo.Begindate.ToString("yyyy.MM.dd hh:mm:ss") + "', '" + AllInfo.Enddate.ToString("yyyy.MM.dd hh:mm:ss") + "', " + AllInfo.Price.ToString().Replace(',', '.') + ", '" + AllInfo.Descriptionpackage+ "', '" + AllInfo.Descriptioncar+"', "+ Convert.ToByte(AllInfo.Active) + ", '"+AllInfo.Nameinsurer+"', '"+AllInfo.Savedate.ToString("yyyy.MM.dd hh:mm:ss") + "')";
                    sqlcommand(command);
                    AllInfo.Info = "Zapisano dane";
                    return AllInfo;
                }
                catch (Exception ex)
                {
                    AllInfo.Info = "Nie zapisano danych, błąd: "+ex.ToString()+"";
                    return AllInfo;
                }
        
            }
        }

        public DataSet ReadBasicInformation(string personal_identity_number)
        {
            DataSet ds = sqldata("SELECT [Id],[personal_identity_number] as 'Personal Identity Number',[identity_card_number],[address],[name_surname],[discounts],[phone_number],[birthday] FROM[dbo].[BasicInformation] where [personal_identity_number] = '"+ personal_identity_number + "'");
            return ds;
        }

       
        public DataSet ReadPurchaseHistory(string personal_identity_number)
        {
            DataSet ds = sqldata("SELECT [Id] ,[personal_identity_number] as 'Personal Identity Number',[vin] as 'Number Vin',[begindate] as 'Start date' ,[enddate] as 'End date',[price] as 'Price',[descriptionpackage] as 'Description package',[descriptioncar] as 'Desctription car',[active] as 'Active',[nameinsurer] as 'Name Insurer' ,[savedate] as 'Save date' FROM [dbo].[PurchaseHistory] where [personal_identity_number] = '" + personal_identity_number + "'");

            return ds;
        }

       
        public DataSet ReadHistoryOfAccidents(string personal_identity_number)
        {
            DataSet ds = sqldata("SELECT [Id] ,[vin] as 'Vin' ,[descriptionofthedamage] as 'Description of the damage',[carname] as 'Car name' ,[personal_identity_number] as 'Personal identity number',[penalty] as 'Penalty',[date]  as 'Date' FROM [dbo].[HistoryOfAccidents] where [personal_identity_number] ='" + personal_identity_number +"'");

            return ds;
        }

    }
}