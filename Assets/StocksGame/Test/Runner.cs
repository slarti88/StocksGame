using System;
using System.Collections;
using System.Collections.Generic;
using StocksGame.Runtime;
using StocksGame.StockSource.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class Runner : MonoBehaviour
{
    private static readonly DateTime FirstDate = new DateTime(2010, 10, 10);
    private static readonly DateTime LastDate  = new DateTime(2015, 10, 10);

    [SerializeField] private Slider startSlider;
    [SerializeField] private Slider endSlider;

    private DateTime  _start = FirstDate;
    private DateTime  _end   = LastDate;
    private StockView _stockView;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show()
    {
        ShowInternal(_start,_end);
    }

    public void OnStartSliderChanged()
    {
        _start = GetDateTimeBetween(FirstDate, LastDate, startSlider.value);
    }

    public void OnEndSliderChanged()
    {
        _end = GetDateTimeBetween(FirstDate, LastDate, endSlider.value);
    }

    private DateTime GetDateTimeBetween(DateTime firstDate, DateTime lastDate, float val)
    {
        var      dateDiff  = lastDate - firstDate;
        long lerpedVal = (long)(dateDiff.Ticks * (double)val);
        TimeSpan span = TimeSpan.FromTicks(lerpedVal);
        return firstDate + span;
    }
    
    void ShowInternal(DateTime start, DateTime end)
    {
        string      stockSourceData = Resources.Load<TextAsset>("adaniports").text;
        StockSource stockSource     = new StockSource();
        stockSource.Load(stockSourceData,start,end);

        if (_stockView == null)
        {
            _stockView = new GameObject("View").AddComponent<StockView>();
        }
        _stockView.Show(stockSource);
    }
}
