﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spefy.Core.Services.Auth
{
    public interface IAuthorizeService
    {
        public void Authorize();
        public string GetToken();
        public string GetTokenType();
    }
}
