using backend.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.Data.Interfaces
{
    public interface IHexaMemberRepository : IGetAll<HexaMember>,IGet<HexaMember,string>, ISave<HexaMember>, IUpdate<HexaMember, string>, IDelete<string>
    {
    }
}
