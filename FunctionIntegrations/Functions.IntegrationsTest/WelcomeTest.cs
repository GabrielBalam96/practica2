using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Functions.IntegrationsTest
{
    [Collection(nameof(TestCollecion))]
    public class WelcomeTest
    {
        private TestFixture testFixture;
        private HttpResponseMessage httpResponseMessage;

        public WelcomeTest(TestFixture fixture)
        {
            testFixture = fixture;
        }
        [Fact]
        public async Task  WhenfunctionIsInvoked()
        {
            httpResponseMessage = await testFixture.Client.GetAsync("api/Welcome/?name=GabrielBalam");
            Assert.True(httpResponseMessage.IsSuccessStatusCode);
        }

        [Fact]
        public async Task WhenResponseWnWith()
        {
            httpResponseMessage = await testFixture.Client.GetAsync("api/Welcome/?name=GabrielBalam");
            Assert.EndsWith("Success.", await httpResponseMessage.Content.ReadAsStringAsync());
        }
    }
}
