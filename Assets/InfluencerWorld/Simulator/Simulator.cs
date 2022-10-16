using System;
using System.Collections.Generic;
using System.Linq;
using InfluencerWorld.Input;
using UnityEngine;

namespace InfluencerWorld.Simulator
{
    public class Simulator : MonoBehaviour
    {
        public List<Affinities>  CircVals { get; set; }
        public List<Interactable>    Sliders;
        public ArenaCreator Creator;
        private void Start()
        {
            System.Random r = new System.Random();
            CircVals = new List<Affinities>();

            for (int i = 0; i < 27; ++i)
            {
                CircVals.Add(new Affinities()
                {
                    val1 = (float)r.NextDouble(),
                    val2 = (float)r.NextDouble(),
                    val3 = (float)r.NextDouble()
                });
            }
        }

        public void Simulate()
        {
            var   data = GetNormalSliderPosition();
            float avg  = 0;
            foreach (var c in CircVals)
            {
                c.CalculateTotalAffinity(data);
            }
            Creator.UpdateDiscs(CircVals);

        }

        private TweetData GetNormalSliderPosition()
        {
            TweetData data = new TweetData();
            data.Content1 = Sliders[0].transform.position.x / Sliders[0].DraggableArea.bounds.size.x;
            data.Content2 = Sliders[1].transform.position.x / Sliders[1].DraggableArea.bounds.size.x;
            data.Content3 = Sliders[2].transform.position.x / Sliders[2].DraggableArea.bounds.size.x;
            Debug.Log($"Slider {Sliders[0].DraggableArea.bounds.size}");
            return data;
        }
    }
}
