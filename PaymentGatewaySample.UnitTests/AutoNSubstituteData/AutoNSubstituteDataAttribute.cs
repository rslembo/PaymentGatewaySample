using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Xunit2;

namespace PaymentGatewaySample.UnitTests.AutoNSubstituteData
{
    public class AutoNSubstituteDataAttribute : AutoDataAttribute
    {
        public AutoNSubstituteDataAttribute()
            : base(() => new Fixture()
                .Customize(new AutoNSubstituteCustomization()))
        {
            #pragma warning disable CS0618 // Type or member is obsolete
            Fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            #pragma warning restore CS0618 // Type or member is obsolete
        }
    }
}