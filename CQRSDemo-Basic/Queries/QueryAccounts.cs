namespace CQRSDemo.Queries
{
    using System.Collections.Generic;
    using CQRSDemo.Queries.Models;
    using Destructurama.Attributed;
    using MediatR;

    public class QueryAccounts : BaseQuery, IRequest<IEnumerable<Account>>
    {
        public string EmailAddress { get; set; }
    }
}
