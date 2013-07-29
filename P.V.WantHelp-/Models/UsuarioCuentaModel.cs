using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P.V.WantHelp_.Models
{
    //public class UsuarioCuentaModel
    //{
    //}
    public class msnSend
    {
        public string id { set; get; }
        public string msn { set; get; }
    }
    public class MensajesView
    {
        public string nick { set; get; }
        public string mmensaje { set; get; }
        public string fecha { set; get; }
    }
    public class MensajesViewR
    {
        public string nickR { get; set; }
        public string mensajeR { get; set; }
        public string fechaR{get;set;}
        public string puntos { get; set; }
    }
}