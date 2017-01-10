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

        DataSet sqldata(string cmd)
        {
            string sqlconnectionstring = WCF_generowanie.Properties.Settings.Default.connectionstring;

            using (SqlConnection connection = new SqlConnection(sqlconnectionstring))
            {
                connection.Open();

                SqlDataAdapter adp = new SqlDataAdapter(cmd,connection);
              
                DataSet ds = new DataSet();
                adp.Fill(ds);

                return ds;
                // Do work here; connection closed on following line.
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
            DataSet ds = sqldata("ss");
            return ds;
        }

       
        public DataSet ReadPurchaseHistory(string personal_identity_number)
        {
            DataSet ds = sqldata("ss");
            return ds;
        }

       
        public DataSet ReadHistoryOfAccidents(string personal_identity_number)
        {
            DataSet ds = sqldata("ss");
            return ds;
        }

    }
}