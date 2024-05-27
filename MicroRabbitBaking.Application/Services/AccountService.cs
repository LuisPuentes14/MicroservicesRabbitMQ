using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbitBaking.Application.Interfaces;
using MicroRabbitBaking.Application.Models;


namespace MicroRabbitBaking.Application.Services
{
    public class AccountService : IAccountService
    {

        private readonly IAccountRepository _accountRepository;
        private readonly IEventBus eventBus;

        public AccountService(IAccountRepository accountRepository, IEventBus eventBus)
        {
            _accountRepository = accountRepository;
            this.eventBus = eventBus;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }

        public void Transfer(AccountTransfer accountTransfer)
        {
            var createTransferCommand = new CreateTransferCommand(
                accountTransfer.FromAccount,
                accountTransfer.ToAccount, 
                accountTransfer.TrasnferAmount
                );

            eventBus.SendCommand( createTransferCommand );
        }
    }
}
