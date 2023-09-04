using CityInfo.API.Controllers;

namespace CityInfo.API.Services
{
    public class LocalMailService : ILocalMailService
    {
        private readonly string _mailTo = string.Empty;
        private readonly string _mailFrom = string.Empty;
        private readonly ILogger<PointOfInterestController> _logger;
        public LocalMailService(
            ILogger<PointOfInterestController> logger,

            IConfiguration configuration)
        {
                _mailTo = configuration["mailSettings:mailToAddress"];
                _mailFrom = configuration["mailSettings:mailFromAddress"];
                _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public void Send(string subject, string message)
        {
            _logger.LogInformation($"${_mailTo} {_mailFrom} Subject:{subject}, Message:{message}");
        }
    }
}
