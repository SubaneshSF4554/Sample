using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCard
{
    public class UserDetails:PersonalDetails,IBalance
    {
        public static int s_userID=1000;
        public string UserID;
        public string WorkStationNumber{get;set;}
        private double _balance;
        public double Balance{get{return _balance;}}

        //public int _walletBalance => throw new NotImplementedException();
        

        public UserDetails(string name,string fatherName,Gender gender,string mobNo,string mailID,string workStationNumber,double balance):base(name,fatherName,gender,mobNo,mailID)
        {
            s_userID++;
            UserID="SF"+s_userID;
            WorkStationNumber=workStationNumber;
            _balance=balance;
        }
       

        public void WalletRecharge(double amount)
        {
            _balance+=amount;
            Console.WriteLine(_balance);
        }

        public void DeductAmount(double amount)
        {
            _balance-=amount;
            Console.WriteLine(_balance);
        }
        
        public UserDetails(string user)
        {
            string[] val=user.Split(",");
            s_userID=int.Parse(val[0].Remove(0,2));
            UserID=val[0];
            Name=val[1];
            FatherName=val[2];
            Gender=Enum.Parse<Gender>(val[3],true);
            MobNo=val[4];
            MailID=val[5];
            WorkStationNumber=val[6];
            _balance=double.Parse(val[7]);

        }
    }
}