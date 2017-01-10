using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF_generowanie
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        //[OperationContract]
        //string GetData(int value, string hmm);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        HistoryOfAccidents SaveAccidents(HistoryOfAccidents AllInfo);

        [OperationContract]
        BasicInformation SaveBasicInformation(BasicInformation AllInfo);

        [OperationContract]
        PurchaseHistory SavePurchaseHistory(PurchaseHistory AllInfo);

        [OperationContract]
        DataSet ReadBasicInformation(string personal_identity_number);

        [OperationContract]
        DataSet ReadPurchaseHistory(string personal_identity_number);

        [OperationContract]
        DataSet ReadHistoryOfAccidents(string personal_identity_number);
        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }

    }


    [DataContract]
    public class BasicInformation
    {
        string personal_identity_number;
        string identity_card_number;
        string address;
        string name_surname;
        float discounts;
        string phone_number;
        DateTime birthday;
        string info;

        [DataMember]
        public string Personal_identity_number
        {
            get { return personal_identity_number; }
            set { personal_identity_number = value; }
        }
        [DataMember]
        public string Identity_card_number
        {
            get { return identity_card_number; }
            set { identity_card_number = value; }
        }

        [DataMember]
        public string Name_surname
        {
            get { return name_surname; }
            set { name_surname = value; }
        }

        [DataMember]
        public float Discounts
        {
            get { return discounts; }
            set { discounts = value; }
        }

        [DataMember]
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        [DataMember]
        public string Phone_number
        {
            get { return phone_number; }
            set { phone_number = value; }
        }

        [DataMember]
        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }
        [DataMember]
        public string Info
        {
            get { return info; }
            set { info = value; }
        }
    }

    [DataContract]
    public class HistoryOfAccidents
    {
        string vin;
        string descriptionofthedamage;
        string carname;
        string personal_identity_number;
        float penalty;
        DateTime date;
        string info;

        [DataMember]
        public string Vin
        {
            get { return vin; }
            set { vin = value; }
        }
        [DataMember]
        public string DescriptionOfTheDamage
        {
            get { return descriptionofthedamage; }
            set { descriptionofthedamage = value; }
        }
        [DataMember]
        public string CarName
        {
            get { return carname; }
            set { carname = value; }
        }
        [DataMember]
        public string PersonalIdentityNumber
        {
            get { return personal_identity_number; }
            set { personal_identity_number = value; }
        }
        [DataMember]
        public float Penalty
        {
            get { return penalty; }
            set { penalty = value; }
        }
        [DataMember]
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        [DataMember]
        public string Info
        {
            get { return info; }
            set { info = value; }
        }
    }

    [DataContract]
    public class PurchaseHistory
    {
        string personal_identity_number;
        string vin;
        DateTime begindate;
        DateTime enddate;
        float price;
        string descriptionpackage;
        string descriptioncar;
        bool active;
        string nameinsurer;
        DateTime savedate;
        string info;

        [DataMember]
        public string Personal_identity_number
        {
            get { return personal_identity_number; }
            set { personal_identity_number = value; }
        }

        [DataMember]
        public string Vin
        {
            get { return vin; }
            set { vin = value; }
        }
        [DataMember]
      public  DateTime Begindate
        {
            get { return begindate; }
            set { begindate = value; }
        }
        [DataMember]
        public DateTime Enddate
        {
            get { return enddate; }
            set { enddate = value; }
        }
             [DataMember]
     public float Price
        {
            get { return price; }
            set { price = value; }
        }
             [DataMember]
     public string Descriptionpackage
        {
            get { return descriptionpackage; }
            set { descriptionpackage = value; }
        }
             [DataMember]
      public string Descriptioncar
        {
            get { return descriptioncar; }
            set { descriptioncar = value; }
        }
             [DataMember]
     public bool Active
        {
            get { return active; }
            set { active = value; }
        }
             [DataMember]
      public string Nameinsurer
        {
            get { return nameinsurer; }
            set { nameinsurer = value; }
        }
        [DataMember]
        public DateTime Savedate
        {
            get { return savedate; }
            set { savedate = value; }
        }
        [DataMember]
        public string Info
        {
            get { return info; }
            set { info = value; }
        }
    }
}

