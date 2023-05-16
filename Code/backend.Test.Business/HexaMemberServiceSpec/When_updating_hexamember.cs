using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using backend.BusinessEntities.Entities;


namespace backend.Test.Business.HexaMemberServiceSpec
{
    public class When_updating_hexamember : UsingHexaMemberServiceSpec
    {
        private HexaMember _result;
        private HexaMember _hexamember;

        public override void Context()
        {
            base.Context();

            _hexamember = new HexaMember
            {
                name = "name",
                age = 16,
                address = 36.32,
                phone = 24,
                project = 29,
                aa = new DateTime(),
                bb = false,
                cc = 86
            };

            _hexamemberRepository.Update(_hexamember.Id, _hexamember).Returns(_hexamember);
            
        }
        public override void Because()
        {
            _result = subject.Update(_hexamember.Id, _hexamember);
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _hexamemberRepository.Received(1).Update(_hexamember.Id, _hexamember);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<HexaMember>();

            _result.ShouldBe(_hexamember);
        }
    }
}