using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace TechnaminDemo
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
