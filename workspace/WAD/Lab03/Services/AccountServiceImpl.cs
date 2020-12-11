using Lab03.Models;
using Lab03.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab03.Services
{
    public class AccountServiceImpl : IAccountService
    {
        private readonly Context context;

        public AccountServiceImpl(Context context)
        {
            this.context = context;
        }

        public bool CheckLogin(string accountNo, string pinCode)
        {
            Account oldAccount = context.Accounts
                .SingleOrDefault(a => a.AccountNo.Equals(accountNo));

            if(oldAccount != null)
            {
                if(oldAccount.Equals(pinCode))
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        public Account CheckLoginV2(string accountNo, string pinCode)
        {
            Account oldAccount = context.Accounts
                .Where(a => a.AccountNo.Equals(accountNo) && a.PinCode.Equals(pinCode))
                .SingleOrDefault(a => a.AccountNo.Equals(accountNo));

            if (oldAccount != null)
            {
                return oldAccount;
            }

            return null;
        }


        public void Create(Account account)
        {
            Account oldAccount = context.Accounts.SingleOrDefault(a => a.AccountNo.Equals(account.AccountNo));
            if (oldAccount == null)
            {
                context.Accounts.Add(account);
                context.SaveChanges();
            }

        }

        public void Delete(string accountNo)
        {
            Account oldAccount = context.Accounts.SingleOrDefault(a => a.AccountNo.Equals(accountNo));
            if (oldAccount == null)
            {
                context.Accounts.Remove(oldAccount);
                context.SaveChanges();
            }
        }

        public Account FindByAccountNo(string accountNo)
        {
            Account oldAccount = context.Accounts.SingleOrDefault(a => a.AccountNo.Equals(accountNo));
            if (oldAccount == null)
            {
                return oldAccount;
            }

            return null;
        }

        public List<Account> GetAccounts()
        {
            return context.Accounts.ToList();
        }

        public void Update(Account account)
        {
            Account oldAccount = context.Accounts.SingleOrDefault(a => a.AccountNo.Equals(account.AccountNo));
            if (oldAccount == null)
            {
                oldAccount.AccountName = account.AccountName;
                oldAccount.PinCode = account.PinCode;
                oldAccount.Address = account.Address;
                oldAccount.Balance = account.Balance;
                oldAccount.IsAdmin = account.IsAdmin;

                context.SaveChanges();
            }
        }
    }
}
