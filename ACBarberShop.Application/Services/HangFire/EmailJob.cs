using ACBarberShop.Application.Services.Implemetations;

namespace ACBarberShop.Application.Services.HangFire
{
    public class EmailJob
    {
        private readonly EmailService _emailService;

        public EmailJob(EmailService emailService)
        {
            _emailService = emailService;
        }

        public void Execute()
        {
            _emailService.SendEmail();
        }
    }
}
