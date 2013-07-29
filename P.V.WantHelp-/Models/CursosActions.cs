using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P.V.WantHelp_.Models
{
    public class CursosActions
    {
        PlataformaVirtualEntities server;
        public CursosActions()
        {
            server = new PlataformaVirtualEntities();
        }
        public List<Cursos> getCursos()
        {
            return server.Cursos.ToList();
        }
        public List<sesiones> getSesiones(int idCuros)
        {
            return server.sesiones.Where(a => a.idCu == idCuros).ToList();
        }
    }
}