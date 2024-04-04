using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCard
{
    public interface IBalance
    {
        //public int _walletBalance{get;}
        public void WalletRecharge(double amount);
        public void DeductAmount(double amount);
    }
}