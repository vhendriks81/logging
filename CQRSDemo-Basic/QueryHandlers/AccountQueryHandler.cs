using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CQRSDemo.Queries;
using CQRSDemo.Queries.Models;
using MediatR;

namespace CQRSDemo.QueryHandlers
{
    public class AccountQueryHandler
        : IRequestHandler<QueryAccounts, IEnumerable<Account>>
    {
        public Task<IEnumerable<Account>> Handle(QueryAccounts request, CancellationToken cancellationToken)
        {
            var accounts = new List<Account>();
            accounts.Add(new Account { Id = Guid.NewGuid(), Name = "SomeName", EmailAddress = "Someone@example.com"});
            accounts.Add(new Account { Id = Guid.NewGuid(), Name = "SomeOtherName", EmailAddress = "SomeoneElse@example.com"});

            return Task.FromResult((IEnumerable<Account>)accounts);
        }
    }
}