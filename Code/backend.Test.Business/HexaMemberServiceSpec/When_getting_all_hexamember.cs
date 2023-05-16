using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using backend.BusinessEntities.Entities;

namespace backend.Test.Business.HexaMemberServiceSpec
{
    public class When_getting_all_hexamember : UsingHexaMemberServiceSpec
    {
        private IEnumerable<HexaMember> _result;

        private IEnumerable<HexaMember> _all_hexamember;
        private HexaMember _hexamember;

        public override void Context()
        {
            base.Context();

            _hexamember = new HexaMember{
                name = "name",
                age = 77,
                address = 97.93,
                phone = 77,
                project = 4,
                aa = new DateTime(),
                bb = true,
                cc = 76
            };

            _all_hexamember = new List<HexaMember> { _hexamember};
            _hexamemberRepository.GetAll().Returns(_all_hexamember);
        }
        public override void Because()
        {
            _result = subject.GetAll();
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _hexamemberRepository.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<List<HexaMember>>();

            List<HexaMember> resultList = _result as List<HexaMember>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_hexamember);
        }
    }
}