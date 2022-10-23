using System;
using System.Collections;
using System.Collections.Generic;
using StocksGame.Runtime;
using StocksGame.StockSource.Runtime;
using UnityEngine;

public class Runner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string      stockSourceData = Resources.Load<TextAsset>("adaniports").text;
        StockSource stockSource     = new StockSource();
        stockSource.Load(stockSourceData,new DateTime(2010,10,10),new DateTime(2010,11,10));
        
        // Act
        StockView stockView = new GameObject("View").AddComponent<StockView>();
        stockView.Show(stockSource);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
