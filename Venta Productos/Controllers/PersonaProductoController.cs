using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Cors;
using Modelos;
using Servicio.Persona;
using System;
using System.Net;
using ServicioProducto;
using Servicio.Venta;

namespace Venta_Productos.Controllers
{
    [RoutePrefix("api")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PersonaProductoController : ApiController
    {
        #region Persona
        [HttpPost]
        [Route("persona/crearpersona")]
        [ResponseType(typeof(RespuestaApi))]
        public IHttpActionResult CrearPersona(InfPersona infoPersona)
        {
            PersonaSrv personaServicio = new PersonaSrv();
            try
            {
                var Person = personaServicio.CrearPersona(infoPersona);
                if (Person != null)
                {
                    return Content(HttpStatusCode.OK,
                        new RespuestaApi
                        {
                            codigo = Convert.ToInt32(HttpStatusCode.OK),
                            descripcion = "Persona Creada"
                        });
                }
                else
                {
                    return Content(HttpStatusCode.Continue,
                        new RespuestaApi
                        {
                            codigo = Convert.ToInt32(HttpStatusCode.Continue),
                            descripcion = "No se creo la persona"
                        });
                }

            }
            catch (Exception ex)
            {
                // se agrega a un log el error ex
                return Content(HttpStatusCode.InternalServerError,
                    new RespuestaApi
                    {
                        codigo = 400,
                        descripcion = ex.Message
                    });
            }
        }
        [HttpGet]
        [Route("persona/consultarpersona")]
        [ResponseType(typeof(RespuestaApi))]
        public IHttpActionResult ConsultarPersona()
        {
            PersonaSrv personaServicio = new PersonaSrv();
            try
            {
                var Person = personaServicio.ConsultarPersona();
                if (Person != null)
                {
                    return Content(HttpStatusCode.OK, Person);
                }
                else
                {
                    return Content(HttpStatusCode.OK, Person);
                }

            }
            catch (Exception ex)
            {
                // se agrega a un log el error ex
                return Content(HttpStatusCode.InternalServerError,
                    new RespuestaApi
                    {
                        codigo = 400, // error
                        descripcion = ex.Message
                    });
            }
        }

        [HttpPost]
        [Route("persona/consultarpersonabyid")]
        [ResponseType(typeof(RespuestaApi))]
        public IHttpActionResult ConsultarPersonaById(int IdPersona)
        {
            PersonaSrv personaServicio = new PersonaSrv();
            try
            {
                var Person = personaServicio.ConsultarPersonaById(IdPersona);
                if (Person != null)
                {
                    return Content(HttpStatusCode.OK, Person);
                }
                else
                {
                    return Content(HttpStatusCode.OK, Person);
                }

            }
            catch (Exception ex)
            {
                // se agrega a un log el error ex
                return Content(HttpStatusCode.InternalServerError,
                    new RespuestaApi
                    {
                        codigo = 400, // error
                        descripcion = ex.Message
                    });
            }
        }

        [HttpPost]
        [Route("persona/modificarpersona")]
        [ResponseType(typeof(RespuestaApi))]
        public IHttpActionResult ModificarPersona(InfPersona infoPersona)
        {
            PersonaSrv personaServicio = new PersonaSrv();
            try
            {
                var Person = personaServicio.ModificarPersona(infoPersona);
                if (Person != null)
                {
                    return Content(HttpStatusCode.OK,
                     new RespuestaApi
                     {
                         codigo = Convert.ToInt32(HttpStatusCode.OK),
                         descripcion = "Persona Modificada"
                     });
                }
                else
                {
                    return Content(HttpStatusCode.Continue,
                        new RespuestaApi
                        {
                            codigo = Convert.ToInt32(HttpStatusCode.Continue),
                            descripcion = "No se Modifico la persona"
                        });
                }

            }
            catch (Exception ex)
            {
                // se agrega a un log el error ex
                return Content(HttpStatusCode.InternalServerError,
                    new RespuestaApi
                    {
                        codigo = 400, // error
                        descripcion = ex.Message
                    });
            }
        }
        #endregion
        #region Producto
        [HttpPost]
        [Route("producto/crearproducto")]
        [ResponseType(typeof(RespuestaApi))]
        public IHttpActionResult CrearProducto(InfProducto infProducto)
        {
            ProductoSrv productoSrv = new ProductoSrv();
            try
            {
                var Product = productoSrv.CrearProducto(infProducto);
                if (Product != null)
                {
                    return Content(HttpStatusCode.OK,
                        new RespuestaApi
                        {
                            codigo = Convert.ToInt32(HttpStatusCode.OK),
                            descripcion = "Producto Creado"
                        });
                }
                else
                {
                    return Content(HttpStatusCode.Continue,
                        new RespuestaApi
                        {
                            codigo = Convert.ToInt32(HttpStatusCode.Continue),
                            descripcion = "No se creo el producto"
                        });
                }

            }
            catch (Exception ex)
            {
                // se agrega a un log el error ex
                return Content(HttpStatusCode.InternalServerError,
                    new RespuestaApi
                    {
                        codigo = 400, // error
                        descripcion = ex.Message
                    });
            }
        }
        [HttpGet]
        [Route("producto/consultarproducto")]
        [ResponseType(typeof(RespuestaApi))]
        public IHttpActionResult ConsultarProducto()
        {
            ProductoSrv productoSrv = new ProductoSrv();
            try
            {
                var Produc = productoSrv.ConsultarProducto();
                if (Produc != null)
                {
                    return Content(HttpStatusCode.OK, Produc);
                }
                else
                {
                    return Content(HttpStatusCode.OK, Produc);
                }

            }
            catch (Exception ex)
            {
                // se agrega a un log el error ex
                return Content(HttpStatusCode.InternalServerError,
                    new RespuestaApi
                    {
                        codigo = 400, // error
                        descripcion = ex.Message
                    });
            }
        }

        [HttpPost]
        [Route("producto/consultarproductobyid")]
        [ResponseType(typeof(RespuestaApi))]
        public IHttpActionResult ConsultarProductoById(int IdProducto)
        {
            ProductoSrv productoSrv = new ProductoSrv();
            try
            {
                var Produc = productoSrv.ConsultarProductoId(IdProducto);
                if (Produc != null)
                {
                    return Content(HttpStatusCode.OK, Produc);
                }
                else
                {
                    return Content(HttpStatusCode.OK, Produc);
                }

            }
            catch (Exception ex)
            {
                // se agrega a un log el error ex
                return Content(HttpStatusCode.InternalServerError,
                    new RespuestaApi
                    {
                        codigo = 400, // error
                        descripcion = ex.Message
                    });
            }
        }

        [HttpPost]
        [Route("producto/modificarproducto")]
        [ResponseType(typeof(RespuestaApi))]
        public IHttpActionResult ModificarPersona(InfProducto infProducto)
        {
            ProductoSrv productoSrv = new ProductoSrv();
            try
            {
                var Product = productoSrv.ModificarProducto(infProducto);
                if (Product != null)
                {
                    return Content(HttpStatusCode.OK,
                        new RespuestaApi
                        {
                            codigo = Convert.ToInt32(HttpStatusCode.OK),
                            descripcion = "Producto Modificado"
                        });
                }
                else
                {
                    return Content(HttpStatusCode.Continue,
                        new RespuestaApi
                        {
                            codigo = Convert.ToInt32(HttpStatusCode.Continue),
                            descripcion = "No se modifico el producto"
                        });
                }

            }
            catch (Exception ex)
            {
                // se agrega a un log el error ex
                return Content(HttpStatusCode.InternalServerError,
                    new RespuestaApi
                    {
                        codigo = 400, // error
                        descripcion = ex.Message
                    });
            }
        }
        #endregion
        #region Realizar Venta
        [HttpPost]
        [Route("Venta/crearventa")]
        [ResponseType(typeof(RespuestaApi))]
        public IHttpActionResult CrearVenta(InfVenta infProducto)
        {
            VentaSrv ventaSrv = new VentaSrv();
            try
            {
                var Venta = ventaSrv.CrearVenta(infProducto);
                if (Venta != null)
                {
                    return Content(HttpStatusCode.OK,
                        new RespuestaApi
                        {
                            codigo = Convert.ToInt32(HttpStatusCode.OK),
                            descripcion = "Venta Generada"
                        });
                }
                else
                {
                    return Content(HttpStatusCode.Continue,
                        new RespuestaApi
                        {
                            codigo = Convert.ToInt32(HttpStatusCode.Continue),
                            descripcion = "No se genero la venta"
                        });
                }

            }
            catch (Exception ex)
            {
                // se agrega a un log el error ex
                return Content(HttpStatusCode.InternalServerError,
                    new RespuestaApi
                    {
                        codigo = 400, // error
                        descripcion = ex.Message
                    });
            }
        }

        [HttpPost]
        [Route("Venta/consultarventabyid")]
        [ResponseType(typeof(RespuestaApi))]
        public IHttpActionResult ConsultarVentaById(int IdPersona)
        {
            VentaSrv ventaSrv = new VentaSrv();
            try
            {
                var Venta = ventaSrv.ConsultarVentaId(IdPersona);
                if (Venta != null)
                {
                    return Content(HttpStatusCode.OK, Venta);
                }
                else
                {
                    return Content(HttpStatusCode.OK, Venta);
                }

            }
            catch (Exception ex)
            {
                // se agrega a un log el error ex
                return Content(HttpStatusCode.InternalServerError,
                    new RespuestaApi
                    {
                        codigo = 400, // error
                        descripcion = ex.Message
                    });
            }
        }
        #endregion
    }
}
