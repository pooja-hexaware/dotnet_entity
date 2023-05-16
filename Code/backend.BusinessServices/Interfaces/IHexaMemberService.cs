using backend.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.BusinessServices.Interfaces
{
    public interface IHexaMemberService
    {      
        IEnumerable<HexaMember> GetAll();
        HexaMember Get(string id);
        HexaMember Save(HexaMember hexamember);
        HexaMember Update(string id, HexaMember hexamember);
        bool Delete(string id);

    }
}
