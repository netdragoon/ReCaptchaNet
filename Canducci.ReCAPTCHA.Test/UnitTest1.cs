using NUnit.Framework;
namespace Canducci.ReCAPTCHA.Test
{
    [TestFixture]
    public class UnitTest1
    {
        [TestCase]
        public void TestMethod1()
        {
            ReCaptchaResponse resp = new ReCaptchaResponse("0000", ":::1");
            Assert.False(resp.Success);
        }
    }
}
