using System;
using System.IO;


namespace CafeteriaCard
{
    public class FileHandling
    {
        public static void Create()
        {
            if(!Directory.Exists("FoodFolder"))
            {
                Console.Write("FOlder is created");
                Directory.CreateDirectory("FoodFOlder");
            }
            else{
                Console.WriteLine("Folder Exits");
            }
            if(!File.Exists("FoodFolder/userInfo.csv"))
            {
                Console.WriteLine("UserInfo File is created");
                File.Create("FoodFolder/UserInfo.csv").Close();
            }
            else{
                Console.WriteLine("User File Exists");
            }
            if(!File.Exists("FoodFolder/FoodInfo.csv"))
            {
                Console.WriteLine("FoodInfo File is created");
                File.Create("FoodFolder/FoodInfo.csv").Close();
            }
            else{
                Console.WriteLine("Food file is exits");
            }
            if(!File.Exists("FoodFolder/CartInfo.csv"))
            {
                Console.WriteLine("CartInfo File is created");
                File.Create("FoodFolder/CartInfo.csv").Close();
            }
            else{
                Console.WriteLine("Cart File is exists");
            }
            if(!File.Exists("FoodFolder/OrderInfo.csv"))
            {
                Console.WriteLine("OrderInfo File is created");
                File.Create("FoodFolder/OrderInfo.csv").Close();
            }
            else{
                Console.WriteLine("Order file is exists");
            }
        }
        public static void Writecsv()
        {
            string[] s1=new string[Operations.userList.Count];
            for(int i=0;i<Operations.userList.Count;i++)
            {
                s1[i]=Operations.userList[i].UserID+","+Operations.userList[i].Name+","+Operations.userList[i].FatherName+","+Operations.userList[i].Gender+","+Operations.userList[i].MobNo+","+Operations.userList[i].MailID+","+Operations.userList[i].WorkStationNumber+","+Operations.userList[i].Balance;
            }
            File.WriteAllLines("FoodFolder/userInfo.csv",s1);

            string[] s2=new string[Operations.foodList.Count];
            for(int i=0;i<Operations.foodList.Count;i++)
            {
                s2[i]=Operations.foodList[i].FoodID+","+Operations.foodList[i].FoodName+","+Operations.foodList[i].FoodPrice+","+Operations.foodList[i].AvailableQuantity;
            }
            File.WriteAllLines("FoodFolder/FoodInfo.csv",s2);

            string[] s3=new string[Operations.cartList.Count];
            for(int i=0;i<Operations.cartList.Count;i++)
            {
                s3[i]=Operations.cartList[i].ItemID+","+Operations.cartList[i].OrderID+","+Operations.cartList[i].FoodID+","+Operations.cartList[i].OrderPrice+","+Operations.cartList[i].OrderQuantity;
            }
            File.WriteAllLines("FoodFolder/CartInfo.csv",s3);

            string[] s4=new string[Operations.orderList.Count];
            for(int i=0;i<Operations.orderList.Count;i++)
            {
                s4[i]=Operations.orderList[i].OrderID+","+Operations.orderList[i].UserID+","+Operations.orderList[i].OrderDate.ToString("dd/MM/yyyy")+","+Operations.orderList[i].TotalPrice+","+Operations.orderList[i].Status;
            }
            File.WriteAllLines("FoodFolder/OrderInfo.csv",s4);
        }
        public static void Readcsv()
        {
            string[] str1=File.ReadAllLines("FoodFolder/userInfo.csv");
            foreach(string user in str1)
            {
                UserDetails userObj=new UserDetails(user);
                Operations.userList.Add(userObj);
            }
            string[] str2=File.ReadAllLines("FoodFolder/FoodInfo.csv");
            foreach(string food in str2)
            {
                FoodDetails foodObj=new FoodDetails(food);
                Operations.foodList.Add(foodObj);
            }
            string[] str3=File.ReadAllLines("FoodFolder/CartInfo.csv");
            foreach(string cart in str3)
            {
                CartItem cartObj=new CartItem(cart);
                Operations.cartList.Add(cartObj);

            }
            string[] str4=File.ReadAllLines("FoodFolder/OrderInfo.csv");
            foreach(string order in str4)
            {
                OrderDetails orderObj=new OrderDetails(order);
                Operations.orderList.Add(orderObj);
            }
        }
    }
}