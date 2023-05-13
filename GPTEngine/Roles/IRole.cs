using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPTEngine.Roles
{
    public enum ContentType { Architect, Coder, Developer, KidsBookWriter, ABiasedIdiot, APoet }
    public enum RoleType { System, Assistant, User }
    internal interface IRole
    {
        public string Content { get; }
        public ContentType ContentType { get; }
        public RoleType RoleType { get; }

        public GPTMessage GetSetupMessage();
    }
}
