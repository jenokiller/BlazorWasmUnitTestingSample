using Microsoft.AspNetCore.Components.Testing;
using System;
using Xunit;
using Index = BlazorWasmSample.Pages.Index;

namespace DevOpsBlazor.UnitTests
{
    public class IndexPageUnitTests
    {
        TestHost host = new TestHost();

        [Fact(DisplayName = "見出し１の確認")]
        public void ShouldRenderHello()
        {
            var component = host.AddComponent<Index>();
            Assert.Equal("Hello, world!", component.Find("h1").InnerText);

        }

        [Fact(DisplayName = "メッセージの確認")]
        public void ShouldRenderWelcomeMessage()
        {
            var component = host.AddComponent<Index>();
            Assert.Equal("Welcome to your new app.", component.Find("p").InnerText);
        }
    }
}