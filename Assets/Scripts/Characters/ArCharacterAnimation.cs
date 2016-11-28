using System;
using UnityEngine;

namespace Characters
{
    public class ArCharacterAnimation : MonoBehaviour
    {
        public Action OnAnimationDone;

        public void AnimationDone()
        {
            if(OnAnimationDone!=null)
                OnAnimationDone();
        }
    }
}