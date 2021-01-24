
namespace CQRSDemo.Queries.Models
{
    using System;
    using Destructurama.Attributed;

    public class Account
    {
        public Guid Id { get; set; }

        [LogMasked(ShowFirst=3, PreserveLength=true)]
        public string Name { get; set; }

        [LogMasked(ShowFirst=3, PreserveLength=true)]
        public string EmailAddress { get; set; }
    }
}