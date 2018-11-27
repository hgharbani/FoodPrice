using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Repositories;

namespace DataLayer.Services
{
   public class MaterialRepositories:IMaterialRepositories
    {
       private JelvehabKhoramshahrEntities db;
        public MaterialRepositories(JelvehabKhoramshahrEntities context)
        {
            db = context;
        }
        public List<Material> GetAllMaterials()
        {
            return db.Material.ToList();
        }

        public Material GetMaterialById(int materialId)
        {
            return db.Material.Find(materialId);
        }

        public bool InsertMaterial(Material material)
        {
            try
            {
                db.Material.Add(material);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UpdateMaterial(Material material)
        {
            try
            {
                db.Entry(material).State = EntityState.Modified;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteMaterial(Material material)
        {
            try
            {
                db.Entry(material).State = EntityState.Deleted;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteMaterial(int materialId)
        {
            try
            {
                var material = GetMaterialById(materialId);
                DeleteMaterial(material);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
