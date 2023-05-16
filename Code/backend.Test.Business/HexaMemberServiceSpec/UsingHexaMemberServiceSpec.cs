using NSubstitute;
using backend.Test.Framework;
using backend.BusinessServices.Services;
using backend.Data.Interfaces;

namespace backend.Test.Business.HexaMemberServiceSpec
{
    public abstract class UsingHexaMemberServiceSpec : SpecFor<HexaMemberService>
    {
        protected IHexaMemberRepository _hexamemberRepository;

        public override void Context()
        {
            _hexamemberRepository = Substitute.For<IHexaMemberRepository>();
            subject = new HexaMemberService(_hexamemberRepository);

        }

    }
}