namespace JoyasNala.Models
{
    public class Pedido
    {
       
            public int Id { get; set; }
            public DateTime Fecha { get; set; }
            public decimal Total { get; set; }
            public string CodigoCompra { get; set; }

            // Relación con Usuario y Productos
            public int UsuarioId { get; set; }
            public Usuario Usuario { get; set; }
            public List<Producto> Productos { get; set; }
        

    }
}
