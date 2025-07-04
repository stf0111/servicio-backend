using Acceso_Datos;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Logica_Bodegas
    {
        Datos_Bodegas op = new Datos_Bodegas();

        public List<BODEGA> SeleccionarBodegas()
        {
            return op.SeleccionarBodegas();
        }

        public BODEGA SeleccionarBodegaPorCodigo(string codigoBOD)
        {
            return SeleccionarBodegas().FirstOrDefault(bod => bod.BOD_COD == codigoBOD);
        }

        public string InsertarBodega(BODEGA nuevaBodega)
        {
            return op.insertarBodega(nuevaBodega);
        }

        public string ModificarBodega(BODEGA bodegaModificada)
        {
            // Delega la modificación a la capa de datos
            return op.modificarBodega(bodegaModificada);
        }

        public string EliminarBodega(string codigo)
        {
            // Delega la eliminación a la capa de datos
            return op.eliminarBodega(codigo);
        }
    }
}
