using Microsoft.AspNetCore.Components.Testing;
using System;
using Xunit;
using FetchData = BlazorWasmSample.Pages.FetchData;

namespace DevOpsBlazor.UnitTests
{
    public class FetchDataPageUnitTests
    {
        TestHost host = new TestHost();

        [Fact(DisplayName = "見出し１の確認")]
        public void ShouldRenderWeatherForecast()
        {
            host.AddMockHttp();
            var component = host.AddComponent<FetchData>();
            Assert.Equal("Weather forecast", component.Find("h1").InnerText);

        }

        [Fact(DisplayName = "メッセージの確認")]
        public void ShouldRenderWelcomeMessage()
        {
            host.AddMockHttp();
            var component = host.AddComponent<FetchData>();
            Assert.Equal("This component demonstrates fetching data from the server.", component.Find("p").InnerText);
        }

        [Fact(DisplayName = "天気の情報が表示されているかの確認")]
        public void DisplaysLoadingStateThenRendersSuppliedData()
        {
            // Set up a mock HttpClient that we'll be able to use to test arbitrary responses
            var req = host.AddMockHttp().Capture("/sample-data/weather.json");

            // Initially shows loading state
            var component = host.AddComponent<FetchData>();
            Assert.Contains("Loading...", component.GetMarkup());

            // Now simulate a response from the HttpClient
            host.WaitForNextRender(() => req.SetResult(new[]
                    {
                        new FetchData.WeatherForecast { Summary = "First" },
                        new FetchData.WeatherForecast { Summary = "Second" },
                    })
            );

            // Now we should be displaying the data
            Assert.DoesNotContain("Loading...", component.GetMarkup());
            Assert.Collection(component.FindAll("tbody tr"),
                row => Assert.Contains("First", row.OuterHtml),
                row => Assert.Contains("Second", row.OuterHtml));
        }
    }
}