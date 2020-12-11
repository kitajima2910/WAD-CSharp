using Lab03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab03.Services
{
    public interface IAccountService
    {
        bool CheckLogin(string accountNo, string pinCode);
        Account CheckLoginV2(string accountNo, string pinCode);

        List<Account> GetAccounts();
        Account FindByAccountNo(string accountNo);
        void Create(Account account);
        void Update(Account account);
        void Delete(string accountNo);
    }
}
