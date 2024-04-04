using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCard
{
   
    public class CartItem
    {
        public static int s_itemID=100;
        public string ItemID;
        public string OrderID{get;set;}
        public string FoodID{get;set;}
        public int OrderPrice{get;set;}
        public int OrderQuantity{get;set;}
        public CartItem(string orderID,string foodID,int orderPrice,int orderQuantity)
        {
            s_itemID++;
            ItemID="ITID"+s_itemID;
            OrderID=orderID;
            FoodID=foodID;
            OrderPrice=orderPrice;
            OrderQuantity=orderQuantity;
        }
        public CartItem(string order)
        {
            string[] val=order.Split(",");
            s_itemID=int.Parse(val[0].Remove(0,4));
            ItemID=val[0];
            OrderID=val[1];
            FoodID=val[2];
            OrderPrice=int.Parse(val[3]);
            OrderQuantity=int.Parse(val[4]);
        }
        public CartItem(string foodID,int orderPrice,int orderQuantity)
        {

        }

    }
}