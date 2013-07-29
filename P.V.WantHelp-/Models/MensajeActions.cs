using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P.V.WantHelp_.Models
{
    public class MensajeActions
    {
        PlataformaVirtualEntities server;
        public MensajeActions()
        {
            server = new PlataformaVirtualEntities();
        }
        public List<mensajes> getMensajes(int msn)
        {
            return server.mensajes.Take(10).Where(a=>a.idSe==msn).OrderByDescending(a => a.id).ToList();
        }
        public List<Respuestas_Chat> getMensajesR(int p)
        {
            return server.Respuestas_Chat.Take(4).Where(a => a.idSe == p).OrderByDescending(a => a.id).ToList();
        }
    }
}