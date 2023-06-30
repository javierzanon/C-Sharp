using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace bpssgestion
{
    public class bpssdbparametros
    {
        public class BuscarDocumento
        {
            public List<bpssgestion.bpssdb.dbdocumentotipo> documentotipo;
            public List<bpssgestion.bpssdb.dbdocumentoestado> documentoestado;
            public List<bpssgestion.bpssdb.dbarea> area;  
            public List<bpssgestion.bpssdb.dblote> lote;

            public List<bpssgestion.bpssdb.dbusuario> usuario;
            
        }
        public class NuevoFormulario
        {
            public List<bpssgestion.bpssdb.dbdocumentotipo> documentotipo;
            public List<bpssgestion.bpssdb.dbarea> area;  
            public List<bpssgestion.bpssdb.dblote> lote;
        }
        public class DocumentoDescripcion
        {
            public bpssgestion.bpssdb.dbdocumentoExtendido documentoExtendido;
            public List<bpssgestion.bpssdb.dbdocumentodescripcion> descripcionesTodas;

            public List<bpssgestion.bpssdb.dbdocumentodescripcion> descripcionesCargadas;

        }
    }
}