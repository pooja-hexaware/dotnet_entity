using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using backend.BusinessEntities.Entities;

namespace backend.Test.Business.HexaMemberServiceSpec
{
    public class When_saving_hexamember : UsingHexaMemberServiceSpec
    {
        private HexaMember _result;

        private HexaMember _hexamember;

        public override void Context()
        {
            base.Context();

            _hexamember = new HexaMember
            {
                name = "name",
                age = 85,
                address = 35.27,
                phone = 87,
                project = 66,
                aa = new DateTime(),
                bb = true,
                cc = 43
            };

            _hexamemberRepository.Save(_hexamember).Returns(true);
        }
        public override void Because()
        {
            _result = subject.Save(_hexamember);
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _hexamemberRepository.Received(1).Save(_hexamember);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<HexaMember>();

            _result.ShouldBe(_hexamember);
        }
    }
}