namespace RatingService.Logger
{
    public class FakeLogger
    {
        private readonly ILogger _logger;
        public FakeLogger(ILogger logger)
        {
            _logger = logger;
        }
        public void Log(string message)
        {
            _logger.LogInformation(message);
        }
    }
}
