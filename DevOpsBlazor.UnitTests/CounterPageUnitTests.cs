using Microsoft.AspNetCore.Components.Testing;
using System;
using Xunit;
using Counter = BlazorWasmSample.Pages.Counter;

namespace DevOpsBlazor.UnitTests
{
    public class CounterPageUnitTests
    {
        TestHost host = new TestHost();

        [Fact(DisplayName = "見出し1の確認")]
        public void ShouldRenderCounter()
        {
            var component = host.AddComponent<Counter>();
            Assert.Equal("Counter", component.Find("h1").InnerText);
        }

        [Fact(DisplayName = "カウンターのスタートがゼロであること")]
        public void CountStartsAtZero()
        {
            var component = host.AddComponent<Counter>();
            Assert.Equal("Current count: 0", component.Find("p").InnerText);
        }

        [Fact(DisplayName = "ボタンを押すとカウンターが増やせること")]
        public void CanIncrementCount()
        {
            var component = host.AddComponent<Counter>();

            component.Find("button").Click();

            Assert.Equal("Current count: 1", component.Find("p").InnerText);
        }
    }
}