using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCard
{
    public class Operations
    {
        public static CustomList<UserDetails> userList = new CustomList<UserDetails>();
        static UserDetails currentUser;
        public static CustomList<FoodDetails> foodList = new CustomList<FoodDetails>();
        public static CustomList<CartItem> cartList = new CustomList<CartItem>();
        public static CustomList<OrderDetails> orderList = new CustomList<OrderDetails>();
        public static void Defalut()
        {
            userList.Add(new UserDetails("Ravichandran", "Ettaparajan", Gender.Male, "885777575", "ravi@gmail.com", "WS101", 400.00));
            userList.Add(new UserDetails("Baskaran", "Sethurajan", Gender.Male, "9090909090", "baskaran@gmail.com", "WS105", 500.00));

            foodList.Add(new FoodDetails("Coffee", 20, 100));
            foodList.Add(new FoodDetails("Tea", 15, 100));
            foodList.Add(new FoodDetails("Biscuit", 10, 100));
            foodList.Add(new FoodDetails("Juice", 50, 100));
            foodList.Add(new FoodDetails("Puff", 40, 100));
            foodList.Add(new FoodDetails("Milk", 10, 100));
            foodList.Add(new FoodDetails("popcorn", 20, 20));

            orderList.Add(new OrderDetails("SF1001", new DateTime(2022, 06, 15), 70, OrderStatus.Ordered));
            orderList.Add(new OrderDetails("SF1002", new DateTime(2022, 06, 15), 100, OrderStatus.Ordered));

            cartList.Add(new CartItem("OID1001", "FID101", 20, 1));
            cartList.Add(new CartItem("OID1001", "FID103", 10, 1));
            cartList.Add(new CartItem("OID1001", "FID105", 40, 1));
            cartList.Add(new CartItem("OID1002", "FID103", 10, 1));
            cartList.Add(new CartItem("OID1002", "FID104", 50, 1));
            cartList.Add(new CartItem("OID1002", "FID105", 40, 1));
        }
        public static void Display()
        {
            //for user List
            foreach (UserDetails user in userList)
            {
                Console.WriteLine($"UserID : {user.UserID}||UserNAme : {user.Name}||FatherName : {user.FatherName}||MobileNumber : {user.MobNo}||MailID : {user.MailID}||Gender : {user.Gender}||WorkStationNumber : {user.WorkStationNumber}||Balance : {user.Balance}");
            }
            Console.WriteLine();
            //for food list 
            foreach (FoodDetails food in foodList)
            {
                Console.WriteLine($"FoodID : {food.FoodID}||FoodNAme : {food.FoodName}||Price : {food.FoodPrice}||AvailableQuantity : {food.AvailableQuantity}");
            }
            Console.WriteLine();
            //for order list 
            foreach (OrderDetails order in orderList)
            {
                Console.WriteLine($"OrderID : {order.OrderID}||UserID : {order.UserID}||OrderDate : {order.OrderDate}||TotalPrice : {order.TotalPrice}||OrderStatus : {order.Status}");
            }
            Console.WriteLine();
            //for cart 
            foreach (CartItem cart in cartList)
            {
                Console.WriteLine($"ItemID : {cart.ItemID}||OrderID : {cart.OrderID}||FoodID : {cart.FoodID}||orderPrice : {cart.OrderPrice}||OrderQuantity : {cart.OrderQuantity}");
            }
            Console.WriteLine();
        }
        public static void MainMenu()
        {
            Console.WriteLine("-----------------------MainMenu-----------------------");
            string flag = "yes";
            do
            {
                Console.WriteLine("Choose any one option : \n1)UserRegistration \n2)UserLogin \n3)Exit");
                int options = int.Parse(Console.ReadLine());
                switch (options)
                {
                    case 1:
                        UserRegistration();
                        break;
                    case 2:
                        LogIn();
                        break;
                    case 3:
                        Console.WriteLine("Exit");
                        flag = "no";
                        break;
                    default:
                        Console.WriteLine("Enter a valid input");
                        break;
                }

            } while (flag == "yes");
        }
        public static void UserRegistration()
        {
            Console.Write("Enter the user Name : ");
            string userName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Enter the father name : ");
            string fatherName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Enter the mobilenumber : ");
            string mobNo = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Enter the mail id : ");
            string mailID = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Enter the gender of the user : ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            Console.WriteLine();

            Console.Write("Enter the Wrokstation number : ");
            string workStationNumber = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Enter the balance : ");
            double balance = double.Parse(Console.ReadLine());
            Console.WriteLine();

            UserDetails user = new UserDetails(userName, fatherName, gender, mobNo, mailID, workStationNumber, balance);
            userList.Add(user);

            Console.WriteLine($"UserId : {user.UserID}");


        }
        public static void LogIn()
        {
            Console.WriteLine("Enter the user id for the validation : ");
            string searchID = Console.ReadLine();
            bool temp = false;
            UserDetails user=BinarySearch.Binary(userList,searchID);
                if (user!=null)
                {
                    temp = true;
                    currentUser = user;
                    SubMenu();
                }
            
            if (!temp)
            {
                Console.WriteLine("Enter the valid ID");
            }

        }
        public static void SubMenu()
        {
            string opinion = "yes";
            do
            {
                Console.WriteLine("Choose any option from the below list : \na)show my profile \nb)Food order \nc)Modify order \nd)Cancel Order \ne)Order History \nf)Wallet recharge \ng)Show WalletBalance \nh)Exit");
                char selectCharacter = Convert.ToChar(Console.ReadLine());
                switch (selectCharacter)
                {
                    case 'a':
                        ShowMyProfile();
                        break;
                    case 'b':
                        FoodOrder();
                        break;
                    case 'c':
                        ModifyOrder();
                        break;
                    case 'd':
                        CancelOrder();
                        break;
                    case 'e':
                        OrderHistory();
                        break;
                    case 'f':
                        Console.WriteLine("How much of amount you want to recharge : ");
                        double amount = double.Parse(Console.ReadLine());
                        currentUser.WalletRecharge(amount);
                        break;
                    case 'g':
                        Console.WriteLine(currentUser.Balance);
                        break;
                    case 'h':
                        Console.WriteLine("Exit");
                        opinion = "no";
                        break;
                    default:
                        Console.WriteLine("Enter a valid input");
                        break;
                }
            } while (opinion == "yes");
        }
        public static void ShowMyProfile()
        {
            foreach (UserDetails user in userList)
            {
                if (currentUser.UserID.Equals(user.UserID))
                {
                    Console.WriteLine($"userID : {user.UserID}||UserNAme : {user.Name}||FatherName : {user.FatherName}||MobileNumber : {user.MobNo}||MailID : {user.MailID}||Gender : {user.Gender}||WorkStationNumber : {user.WorkStationNumber}||Balance : {user.Balance}");
                }
            }
        }
        public static void FoodOrder()
        {
            Console.WriteLine("Choose the below items to order : ");
            foreach (FoodDetails food in foodList)
            {
                Console.WriteLine($"FoodID : {food.FoodID}||FoodNAme : {food.FoodName}||Price : {food.FoodPrice}||AvailableQuantity : {food.AvailableQuantity}");
            }
            int totalPrice = 0;
            List<CartItem> cartItemList = new List<CartItem>();
            OrderDetails orderobj = new OrderDetails(currentUser.UserID, DateTime.Now, totalPrice, OrderStatus.Initiated);
            Console.WriteLine("Enter the food ID you want to order : ");
            string searchID1 = Console.ReadLine();
            Console.WriteLine("Quantity of the food : ");
            int selectQuantity = int.Parse(Console.ReadLine());
            bool temp2 = false;
            foreach (FoodDetails foods in foodList)
            {
                if (searchID1.Equals(foods.FoodID))
                {
                    temp2 = true;
                    double tot = selectQuantity * foods.FoodPrice;
                    currentUser.DeductAmount(tot);
                    if (foods.AvailableQuantity >= selectQuantity)
                    {
                        Console.WriteLine("Food Quantity is available ");
                        foods.AvailableQuantity -= selectQuantity;
                        CartItem cartObj = new CartItem(foods.FoodID, foods.FoodPrice, selectQuantity);
                        cartItemList.Add(cartObj);
                        string option;
                        bool answer=false;
                        do
                        {
                            answer=true;
                            Console.WriteLine("You want wish to pruchase another : ");
                            option = Console.ReadLine();
                            Console.WriteLine("Enter the food ID you want to order : ");
                            string searchID12 = Console.ReadLine();
                            Console.WriteLine("Quantity of the food : ");
                            int selectQuantity1 = int.Parse(Console.ReadLine());
                            bool temp21 = false;
                            foreach (FoodDetails foods1 in foodList)
                            {
                                if (searchID1.Equals(foods1.FoodID))
                                {
                                    temp21 = true;
                                    double tot1 = selectQuantity * foods1.FoodPrice;
                                    currentUser.DeductAmount(tot1);
                                    if (foods.AvailableQuantity >= selectQuantity1)
                                    {
                                        Console.WriteLine("Food Quantity is available ");
                                        foods1.AvailableQuantity -= selectQuantity1;
                                        CartItem cartObj1 = new CartItem(foods.FoodID, foods.FoodPrice, selectQuantity1);
                                        cartItemList.Add(cartObj1);
                                    }


                                }
                            }
                            if(!temp21)
                            {
                                Console.WriteLine("invalid foodID");
                            }
                        } while (option == "yes");
                        if(!answer)
                        {
                           Console.WriteLine("Are you confrim the purchase : ");
                           string ans=Console.ReadLine();
                           if(ans=="no")
                           {
                            foreach(CartItem cart in cartItemList)
                            {
                                Console.WriteLine($"Food ID : {cart.FoodID}||Food price : {cart.OrderPrice}\n||Quantity : {cart.OrderQuantity}");

                            }
                           }
                            else
                            {
                                

                                
                            }
                           
                        }
                    }
                }

            }
            if (!temp2)
            {
                Console.WriteLine("Invalid food ID ");
            }
        }
        public static void ModifyOrder()
        {
            foreach(OrderDetails order in orderList)
            {
                if(currentUser.UserID.Equals(order.UserID)&&order.Status==OrderStatus.Ordered)
                {
                     Console.WriteLine($"OrderID : {order.OrderID}||UserID : {order.UserID}||OrderDate : {order.OrderDate}||TotalPrice : {order.TotalPrice}||OrderStatus : {order.Status}");
                    
                }
            }

        }
        public static void CancelOrder()
        {
            bool temp=false;
            foreach(OrderDetails order in orderList)
            {
                if(currentUser.UserID.Equals(order.UserID)&&order.Status==OrderStatus.Ordered)
                {
                    Console.WriteLine($"Order ID : {order.OrderID}||UserID : {order.UserID}||Orderdate : {order.OrderDate.ToString("dd/MM/yyyy")}||TotalPrice : {order.TotalPrice}||Orderstatus : {order.Status}");
                     Console.WriteLine("Pick the order ID for validation : ");
                     string pickID=Console.ReadLine();
                     if(pickID.Equals(order.OrderID))
                     {
                        Console.WriteLine("The order ID is valid");
                        temp=true;
                        double amount=order.TotalPrice;
                        currentUser.WalletRecharge(amount);
                        order.Status=OrderStatus.Cancelled;

                      //  double amount=
                      //  currentUser.WalletRecharge();
                      Console.WriteLine("Order cancelled successfully");

                     }
                }
               
                
            }
            if(!temp)
            {
                Console.WriteLine("Invalid ID");
            }
            
        }
        public static void OrderHistory()
        {
            foreach(OrderDetails order in orderList)
            {
                if(currentUser.UserID.Equals(order.UserID))
                {
                    Console.WriteLine($"Order ID : {order.OrderID}||UserID : {order.UserID}||Orderdate : {order.OrderDate.ToString("dd/MM/yyyy")}||TotalPrice : {order.TotalPrice}||Orderstatus : {order.Status}");
                }
            }
        }
    }
}