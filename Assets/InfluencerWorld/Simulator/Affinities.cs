using System;
using UnityEngine;

namespace InfluencerWorld.Simulator
{
    [Serializable]
    public class Affinities
    {
        public float val1;
        public float val2;
        public float val3;
        public int   likeCount;
        public bool  didLike;

        public void CalculateTotalAffinity(TweetData data)
        {
            float a = Mathf.Abs(data.Content1 - val1);
            float b = Mathf.Abs(data.Content2 - val2);
            float c = Mathf.Abs(data.Content3 - val3);
            
            didLike = ((a + b + c) / 3.0f) < .25f;
            if (didLike) likeCount++;
        }
    }
}
