using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCard
{
    public class BinarySearch
    {
        public static UserDetails Binary(CustomList<UserDetails> custom,string searchID)
        {
             int left=0;
             int right=Operations.userList.Count-1;
             while(left<=right)
             {
                int mid=left+(right-left)/2;
                if(Operations.userList[mid].UserID.CompareTo(searchID)==0)
                {
                    return Operations.userList[mid];
                }
                else if(Operations.userList[mid].UserID.CompareTo(searchID)==-1)
                {
                    left=mid+1;
                }
                else{
                    right=mid-1;
                }
             }
             return null;
        }
    }
}