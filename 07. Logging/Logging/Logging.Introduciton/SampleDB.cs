namespace Logging.Introduciton
{
    public class SampleDB
    {
        private readonly ILogger<SampleDB> _logger;

        public SampleDB(ILogger<SampleDB> logger)
        {
            this._logger = logger;
        }
        public void Add(int Id)
        {
            _logger.LogInformation("Add Method Called. Id is {Id}", Id);
            _logger.LogError("Error");
        }


    }
}
