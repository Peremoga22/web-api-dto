using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppApi
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Books
        {
            public const string GetAll = Base + "/book";
            public const string Update = Base + "/book/{Id:guid}";
            public const string Delete = Base + "/book/{id:guid}";
            public const string Get = Base + "/book/{id:guid}";
            public const string Create = Base + "/book";
        }
        public static class Identity
        {
            public const string Login = Base + "/identity/login";
            public const string Register = Base + "/identity/register";
        }
    }
}
