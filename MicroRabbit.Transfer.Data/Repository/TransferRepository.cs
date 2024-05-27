using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Transfer.Data.Repository
{
    public class TransferRepository : ITransferRepository
    {
        private TransferDbContext _context;

        public TransferRepository(TransferDbContext context)
        {
            _context = context;
        }
        public void AddTransferLog(TransferLog log)
        {
            _context.Add(log);
            _context.SaveChanges();
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
           return _context.TransferLogs;
        }
    }
}
