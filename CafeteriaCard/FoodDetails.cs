using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCard
{
    public class FoodDetails
    {
        public static int s_foodID=100;
        public string FoodID;
        public string FoodName{get;set;}
        public int FoodPrice{get;set;}
        public int AvailableQuantity{get;set;}
        public FoodDetails(string foodName,int foodPrice,int availableQuantity)
        {
            s_foodID++;
            FoodID="FID"+s_foodID;
            FoodName=foodName;
            FoodPrice=foodPrice;
            AvailableQuantity=availableQuantity;
        }
         public FoodDetails(string food)
        {
            string[] val=food.Split(",");
            s_foodID=int.Parse(val[0].Remove(0,3));
            FoodID=val[0];
            FoodName=val[1];
            FoodPrice=int.Parse(val[2]);
            AvailableQuantity=int.Parse(val[3]);
        }
    }
}