using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace StocksGame.StockSource.Tests
{
    public class StockSourceTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void NewTestScriptSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator NewTestScriptWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    
        [TestCase("adaniports",3322)]
        [Test]
        public void ShouldLoadDataFromText(string sourcePath,int count)
        {
            // Arrange
            string              stockSourceData = Resources.Load<TextAsset>(sourcePath).text;
            Runtime.StockSource stockSource     = new Runtime.StockSource();
            
            // Act
            stockSource.Load(stockSourceData);

            // Assert
            Assert.AreEqual(count,stockSource.Count);

        }
    }
}
