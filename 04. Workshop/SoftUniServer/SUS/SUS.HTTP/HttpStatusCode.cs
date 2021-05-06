using System;
using System.Collections.Generic;
using System.Text;

namespace SUS.HTTP
{
    public enum HttpStatusCode
    {
        OK = 200, 
        MobedPermanently = 301,
        Found = 302,
        TemporaryRedirect = 307,
        NotFound = 404, 
        ServerError = 500,
    }
}
