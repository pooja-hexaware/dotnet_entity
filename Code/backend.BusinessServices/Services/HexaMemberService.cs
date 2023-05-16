using backend.BusinessServices.Interfaces;
using backend.Data.Interfaces;
using backend.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.BusinessServices.Services
{
    public class HexaMemberService : IHexaMemberService
    {
        readonly IHexaMemberRepository _HexaMemberRepository;

        public HexaMemberService(IHexaMemberRepository HexaMemberRepository)
        {
           this._HexaMemberRepository = HexaMemberRepository;
        }
        public IEnumerable<HexaMember> GetAll()
        {
            return _HexaMemberRepository.GetAll();
        }

        public HexaMember Get(string id)
        {
            return _HexaMemberRepository.Get(id);
        }

        public HexaMember Save(HexaMember hexamember)
        {
            _HexaMemberRepository.Save(hexamember);
            return hexamember;
        }

        public HexaMember Update(string id, HexaMember hexamember)
        {
            return _HexaMemberRepository.Update(id, hexamember);
        }

        public bool Delete(string id)
        {
            return _HexaMemberRepository.Delete(id);
        }

    }
}
