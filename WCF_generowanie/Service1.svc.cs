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
           
            return AllInfo;
        }

        public BasicInformation SaveBasicInformation(BasicInformation AllInfo)
        {
            return AllInfo;
        }

        public BasicInformation SavePurchaseHistory(BasicInformation AllInfo)
        {
            return AllInfo;
        }

        public DataSet ReadBasicInformation(string personal_identity_number)
        {
            DataSet ds = sqldata("SELECT [Id],[personal_identity_number],[identity_card_number],[address],[name_surname],[discounts],[phone_number],[birthday] FROM[dbo].[BasicInformation] where [personal_identity_number] = "+ personal_identity_number + "");
            return ds;
        }

       
        public DataSet ReadPurchaseHistory(string personal_identity_number)
        {
            DataSet ds = sqldata("SELECT TOP 1000 [Id] ,[personal_identity_number] ,[vin] ,[begindate] ,[enddate] ,[price] ,[descriptionpackage] ,[descriptioncar] ,[active] ,[nameinsurer] ,[savedate] FROM [dbo].[PurchaseHistory] where [personal_identity_number] = " + personal_identity_number + "");

            return ds;
        }

       
        public DataSet ReadHistoryOfAccidents(string personal_identity_number)
        {
            DataSet ds = sqldata("SELECT [Id] ,[vin] ,[descriptionofthedamage] ,[carname] ,[personal_identity_number] ,[penalty] ,[date] FROM [dbo].[HistoryOfAccidents] where [personal_identity_number] =" + personal_identity_number +"");

            return ds;
        }

    }
}