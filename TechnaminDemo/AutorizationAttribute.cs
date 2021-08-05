using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnaminDemo
{
    public class AutorizationAttribute : TypeFilterAttribute
    {
        public AutorizationAttribute() 
            : base(typeof(AuthenticationFilter))
        {

        }
    }
}
