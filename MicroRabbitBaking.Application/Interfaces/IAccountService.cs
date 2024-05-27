using MicroRabbit.Banking.Domain.Models;
using MicroRabbitBaking.Application.Models;


namespace MicroRabbitBaking.Application.Interfaces
{
    public  interface IAccountService
    {
        IEnumerable<Account> GetAccounts();

        void Transfer(AccountTransfer accountTransfer);
    }
}
