using CriticalMass.TagNode.API.Extend;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TagNode.Controllers
{
    [AllowCrossSiteJson]
    [TokenCheck]
    public class BaseController: ControllerBase
    {
        public BaseController() { 
            
        }
    }
}
