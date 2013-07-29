using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P.V.WantHelp_.Models
{
    public class usuarioRoles : webpages_UsersInRoles
    {
        public usuarioRoles()
        {   
        }
        public Usuario user { set; get; }
    }
}