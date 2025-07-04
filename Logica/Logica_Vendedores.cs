using Acceso_Datos;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Logica_Vendedores
    {
        Datos_Vendedores op = new Datos_Vendedores();

        public List<VENDEDOR> SeleccionarVendedor()
        {
            return op.SeleccionarVendedor();
        }

        public VENDEDOR SeleccionarVendedorPorCedula(string cedula)
        {
            return SeleccionarVendedor().Where(v => v.VEN_CEDULA == cedula).SingleOrDefault();
        }

        public string insertarVendedor(VENDEDOR nuevoVendedor)
        {
            return op.insertarVendedor(nuevoVendedor);
        }

        public string modificarVendedor(VENDEDOR vendedorModificado)
        {
            return op.modificarVendedor(vendedorModificado);
        }

        public string eliminarVendedor(string cedula)
        {
            return op.eliminarVendedor(cedula);
        }
    }
}
