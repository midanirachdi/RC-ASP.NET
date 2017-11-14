using RefugeeCamp.Domain.Models;
using RefugeeCamp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RefugeeCamp.Web.Controllers
{
    public class MedicalFolderAPIController : ApiController
    {
        private GestionMedicalFolder gm = null;
        // GET: api/MedicalFolderAPI
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/MedicalFolderAPI/5
        public medicalfolder Get(int id)
        {
            gm = new GestionMedicalFolder();
            medicalfolder f = gm.findFolderById(id);
            return f;
        }

        // POST: api/MedicalFolderAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MedicalFolderAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MedicalFolderAPI/5
        public void Delete(int id)
        {
        }
    }
}
