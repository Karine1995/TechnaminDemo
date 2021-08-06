using Microsoft.Extensions.Configuration;

namespace TechnaminDemo.Infrastructure
{
    public class ApplicationConfiguration 
    {
        private readonly IConfiguration _configuration;

        public ApplicationConfiguration(IConfiguration configuration) => _configuration = configuration;

        public void BuildApplicationSetting()
        {
            User.Username = _configuration["User:Username"];
            User.Password = _configuration["User:Password"];
        }

    }
}
