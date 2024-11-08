using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityHelper
{
    public class AnimationDotweenTest : MonoBehaviour
    {
        public Button btnPlayForward;
        public Button btnPlayBackward;
        public Button btnRewind;
        public Button btnRestart;
        
        
        public DOTweenAnimationBase dotweenAnimation;

        private void Awake()
        {
            btnPlayForward.onClick.AddListener(dotweenAnimation.PlayForward);
            btnPlayBackward.onClick.AddListener(dotweenAnimation.PlayBackward);
            btnRewind.onClick.AddListener(dotweenAnimation.Rewind);
            btnRestart.onClick.AddListener(dotweenAnimation.Restart);
        }
    }
}