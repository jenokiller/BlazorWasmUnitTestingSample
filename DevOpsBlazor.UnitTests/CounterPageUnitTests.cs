using Microsoft.AspNetCore.Components.Testing;
using System;
using Xunit;
using Counter = BlazorWasmSample.Pages.Counter;

namespace DevOpsBlazor.UnitTests
{
    public class CounterPageUnitTests
    {
        TestHost host = new TestHost();

        [Fact(DisplayName = "���o��1�̊m�F")]
        public void ShouldRenderCounter()
        {
            var component = host.AddComponent<Counter>();
            Assert.Equal("Counter", component.Find("h1").InnerText);
        }

        [Fact(DisplayName = "�J�E���^�[�̃X�^�[�g���[���ł��邱��")]
        public void CountStartsAtZero()
        {
            var component = host.AddComponent<Counter>();
            Assert.Equal("Current count: 0", component.Find("p").InnerText);
        }

        [Fact(DisplayName = "�{�^���������ƃJ�E���^�[�����₹�邱��")]
        public void CanIncrementCount()
        {
            var component = host.AddComponent<Counter>();

            component.Find("button").Click();

            Assert.Equal("Current count: 1", component.Find("p").InnerText);
        }
    }
}