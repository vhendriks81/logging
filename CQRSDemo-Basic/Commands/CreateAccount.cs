
namespace CQRSDemo.Commands
{
    using Destructurama.Attributed;

    public class CreateAccount : BaseCommand
    {
        public string Name { get; set; }


        public string EmailAddress { get; set; }
    }
}
