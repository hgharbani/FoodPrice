using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IMaterialRepositories
    {
        List<Material> GetAllMaterials();
        Material GetMaterialById(int materialId);
        bool InsertMaterial(Material material);
        bool UpdateMaterial(Material material);
        bool DeleteMaterial(Material material);
        bool DeleteMaterial(int materialId);
        void Save();
    }
}
