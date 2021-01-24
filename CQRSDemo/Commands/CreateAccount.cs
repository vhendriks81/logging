
namespace CQRSDemo.Commands
{
    using Destructurama.Attributed;

    public class CreateAccount : BaseCommand
    {
        [LogMasked(ShowFirst=3, PreserveLength=true)]
        public string Name { get; set; }    

        
        [LogMasked(ShowFirst=3, PreserveLength=true)]
        public string EmailAddress { get; set; }
    }
}