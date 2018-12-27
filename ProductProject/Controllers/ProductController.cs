using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductProject.Models;
using ProductProject.Models.dbEntity;

namespace ProductProject.Controllers
{
    public class ProductController : ApiController
    {
        DatabaseManager db = new DatabaseManager();

        public List<Product> Get()
        {
            return db.getAllProducts();
        }

        public IHttpActionResult Get(int id)
        {
            var product = db.getAllProducts().Where(x => x.id == id);
            if (product == null)
                return NotFound();
            else
                return Ok(product);
        }

        public IHttpActionResult Post(Product updateProduct)
        {
            if (updateProduct != null)
            {
                db.updateProduct(updateProduct);
                return Ok(updateProduct);
            }
            else
            {
                return NotFound();
            }


        }

        public IHttpActionResult Put(Product newProduct){
            
            if (newProduct != null)
            {
                db.addProduct(newProduct);
                return Ok(newProduct);
            }
            else {
                return NotFound();
            }

        }

        public IHttpActionResult Delete(int id) {
            var productlist = db.getAllProducts().Where(x => x.id == id);
            if (productlist != null && productlist.Count() > 0)
            {
                Product product = productlist.First();

                db.deleteProduct(product);
                return Ok(product);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
