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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
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
                adp.Fill(ds);

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
        //public string GetData(int value, string hmm)
        //{



        //    return string.Format("You entered: {0}", Convert.ToString("" + value + " " + hmm + ""));
        //}

        //public CompositeType GetDataUsingDataContract(CompositeType composite)

        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}

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
                    AllInfo.Info = "Zapisano dane";
                    return AllInfo;
                }
                catch (Exception ex)
                {
                    string command = "INSERT INTO [dbo].[HistoryOfAccidents] ([vin], [descriptionofthedamage], [carname], [personal_identity_number], [penalty], [date]) VALUES ('" + AllInfo.Vin+ "', '" + AllInfo.DescriptionOfTheDamage+ "', '" + AllInfo.CarName+ "', '" + AllInfo.PersonalIdentityNumber+ "', " + AllInfo.Penalty+", '"+AllInfo.Date.ToString()+"')";
                    sqlcommand(command);
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
                    string command = "INSERT INTO [dbo].[BasicInformation] ([personal_identity_number], [identity_card_number], [address], [name_surname], [discounts], [phone_number], [birthday]) VALUES ('"+AllInfo.Personal_identity_number+ "', '" + AllInfo.Identity_card_number + "', '" + AllInfo.Address + "', '" + AllInfo.Name_surname + "', " + AllInfo.Discounts + ", '" + AllInfo.Phone_number + "', '" + AllInfo.Birthday.ToString() + "')";
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
                    string command = "INSERT INTO [dbo].[PurchaseHistory] ([personal_identity_number], [vin], [begindate], [enddate], [price], [descriptionpackage], [descriptioncar], [active], [nameinsurer], [savedate]) VALUES ('" + AllInfo.Personal_identity_number+ "', '" + AllInfo.Vin+"', '" + AllInfo.Begindate+ "', '" + AllInfo.Enddate+ "', " + AllInfo.Price+ ", '" + AllInfo.Descriptionpackage+ "', '" + AllInfo.Descriptioncar+"', "+AllInfo.Active+", '"+AllInfo.Nameinsurer+"', '"+AllInfo.Savedate.ToString()+"')";
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
            DataSet ds = sqldata("SELECT [Id],[personal_identity_number],[identity_card_number],[address],[name_surname],[discounts],[phone_number],[birthday] FROM[dbo].[BasicInformation] where [personal_identity_number] = "+ personal_identity_number + "");
            return ds;
        }

       
        public DataSet ReadPurchaseHistory(string personal_identity_number)
        {
            DataSet ds = sqldata("SELECT [Id] ,[personal_identity_number] ,[vin] ,[begindate] ,[enddate] ,[price] ,[descriptionpackage] ,[descriptioncar] ,[active] ,[nameinsurer] ,[savedate] FROM [dbo].[PurchaseHistory] where [personal_identity_number] = " + personal_identity_number + "");

            return ds;
        }

       
        public DataSet ReadHistoryOfAccidents(string personal_identity_number)
        {
            DataSet ds = sqldata("SELECT [Id] ,[vin] ,[descriptionofthedamage] ,[carname] ,[personal_identity_number] ,[penalty] ,[date] FROM [dbo].[HistoryOfAccidents] where [personal_identity_number] =" + personal_identity_number +"");

            return ds;
        }

    }
}