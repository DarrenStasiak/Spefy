using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spefy.Contract.Dtos.User.ValueObjects;

namespace Spefy.Contract.Dtos.User
{
    public class UserDataDto
    {
        public BasicUserDataDto BasicUserData { get; set; }
        public string Uri { get; set; }
        public string Name { get; set; }
        public Dictionary<string, string> ExternalUrls { get; set; }
        public string Type { get; set; }
        public string Product { get; set; }
        public string Href { get; set; }
        public ExplicitContentDto explicitContent { get; set; }
        public FollowersDto followers { get; set; }

    }
}
