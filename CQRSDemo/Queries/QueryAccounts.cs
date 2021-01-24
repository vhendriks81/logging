namespace CQRSDemo.Queries
{
    using System.Collections.Generic;
    using CQRSDemo.Queries.Models;
    using Destructurama.Attributed;
    using MediatR;

    public class QueryAccounts : BaseQuery, IRequest<IEnumerable<Account>>
    {
        [LogMasked(ShowFirst=3, PreserveLength=true)]
        public string EmailAddress { get; set; }
    }
}