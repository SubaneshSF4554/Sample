using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCard
{
    public enum Gender{Select,Male,Female,Transgender}
    public class PersonalDetails
    {
        public string Name{get;set;}
        public string FatherName{get;set;}
        public Gender Gender{get;set;}
        public string MobNo{get;set;}
        public string MailID{get;set;}
        public PersonalDetails(string name,string fatherName,Gender gender,string mobNo,string mailID)
        {
            Name=name;
            FatherName=fatherName;
            Gender=gender;
            MobNo=mobNo;
            MailID=mailID;

        }
        public PersonalDetails()
        {
            
        }

    }
}