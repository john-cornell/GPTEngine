using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPTEngine.Roles
{
    public class Role : IRole
    {
        private readonly RoleBehaviour _roleBehaviour;

        public Role(RoleType roleType, RoleBehaviour roleBehaviour)
        {
            RoleType = roleType;
            _roleBehaviour = roleBehaviour;
        }

        public string Content => _roleBehaviour.Content;

        public ContentType ContentType => _roleBehaviour.ContentType;

        public RoleType RoleType { get; }

        public GPTMessage GetSetupMessage() => new GPTMessage(this.RoleType.ToString().ToLowerInvariant(), Content);
    }
}
