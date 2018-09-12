using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetAngularApplication.Models;

namespace DotNetAngularApplication.Data
{
    public class TransactionData
    {
        public static List<TransactionViewModel> GetTransaction()
        {
            return new List<TransactionViewModel>
            {
                new TransactionViewModel {StudentId=1, StudentFees=5000, Date=DateTime.Now},
                new TransactionViewModel {StudentId=2, StudentFees=2000, Date=DateTime.Now},
                new TransactionViewModel {StudentId=3, StudentFees=3000, Date=DateTime.Now},
                new TransactionViewModel {StudentId=4, StudentFees=7000, Date=DateTime.Now},
                new TransactionViewModel {StudentId=5, StudentFees=9000, Date=DateTime.Now},
                new TransactionViewModel {StudentId=6, StudentFees=8000, Date=DateTime.Now},
                new TransactionViewModel {StudentId=7, StudentFees=1000, Date=DateTime.Now}
            };
        }
    }
}
