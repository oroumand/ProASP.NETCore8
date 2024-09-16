namespace Logging.SeqSample
{
    public class SampleDB
    {
        private readonly ILogger<SampleDB> _logger;

        public SampleDB(ILogger<SampleDB> logger)
        {
            _logger = logger;
        }
        public void Add(int Id)
        {
            using(var scope = _logger.BeginScope("Alireza"))
            {
                _logger.LogInformation("Log In Alireza Scope 01 {@ID}", Id);
                _logger.LogInformation("Log In Alireza Scope 02 {@ID}", Id);

            }
            _logger.LogInformation("Log Out Alireza Scope 01 {@ID}", Id);

            _logger.LogInformation("Add Method Called. Id is {Id}", Id);
            _logger.LogError("Error");
        }


    }
}
