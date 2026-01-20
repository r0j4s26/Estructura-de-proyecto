using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;

namespace DA
{
    public class ProductoDA : IProductoDA
    {
        public Task<Guid> Agregar(ProductoRequest producto)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> Editar(Guid Id, ProductoRequest producto)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> Eliminar(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductoResponse>> Obtener()
        {
            throw new NotImplementedException();
        }

        public Task<ProductoResponse> Obtener(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
