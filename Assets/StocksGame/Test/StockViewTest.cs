using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace StocksGame.StockView.Tests
{
    public class StockViewTest
    {   
        // A Test behaves as an ordinary method
        [Test]
        public void StockViewTestSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator ShouldShowLineGraphForStocks()
        {
            yield return null;
            
            // Arrange
            string                          stockSourceData = Resources.Load<TextAsset>("adaniports").text;
            StockSource.Runtime.StockSource stockSource     = new StockSource.Runtime.StockSource();
            stockSource.Load(stockSourceData);
            
            // Act
            Runtime.StockView stockView = new GameObject("View").AddComponent<Runtime.StockView>();
            stockView.Show(stockSource);
            
            // TODO: A way to assert that things were drawn
            
            
            yield return null;
        }
    }
}
