using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCard
{
    public enum OrderStatus{Defalut,Initiated,Ordered,Cancelled}
    public class OrderDetails
    {
        public static int s_orderID=1000;
        public string OrderID;
        public string UserID{get;set;}
        public DateTime OrderDate{get;set;}
        public int TotalPrice{get;set;}
        public OrderStatus Status{get;set;}
        public OrderDetails(string userID,DateTime orderDate,int totalPrice,OrderStatus status)
        {
            s_orderID++;
            OrderID="OID"+s_orderID;
            UserID=userID;
            OrderDate=orderDate;
            TotalPrice=totalPrice;
            Status=status;
            
        }
         public OrderDetails(string order)
        {
            string[] val=order.Split(",");
            s_orderID=int.Parse(val[0].Remove(0,3));
            OrderID=val[0];
            UserID=val[1];
            OrderDate=DateTime.Parse(val[2],null);
            TotalPrice=int.Parse(val[3]);
            Status=Enum.Parse<OrderStatus>(val[4],true);
            
        }
    }
}