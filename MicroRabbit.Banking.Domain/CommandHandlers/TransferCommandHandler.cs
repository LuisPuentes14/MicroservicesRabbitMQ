using MediatR;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Events;
using MicroRabbit.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Banking.Domain.CommandHandlers
{

    public class TransferCommandHandler : IRequestHandler<CreateTransferCommand, bool>
    {

        private readonly IEventBus bus;

        public TransferCommandHandler(IEventBus bus)
        {
            this.bus = bus;
        }

        public Task<bool> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            bus.Publish(new TransferCreatedEvent(request.To, request.From, request.Amount));

            return Task.FromResult(true);
        }
    }
}
