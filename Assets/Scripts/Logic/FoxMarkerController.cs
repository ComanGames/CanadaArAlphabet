using System;
using UnityEngine;
using Vuforia;

namespace Logic
{
    public class FoxMarkerController :MonoBehaviour, ITrackableEventHandler
    {
        public Sprite Image;
        public Action MarkerDetectedAction;
        void Start()
        {
            TrackableBehaviour mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }

        public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED || newStatus == TrackableBehaviour.Status.TRACKED || newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
                OnTrackingFound();
            else
                OnTrackingLost();
        }



        private void OnTrackingFound()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Enable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = true;
            }

            // Enable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = true;
            }
            if (MarkerDetectedAction != null)
                MarkerDetectedAction();
        }


        private void OnTrackingLost()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Disable rendering:
            foreach (Renderer component in rendererComponents)
                component.enabled = false;

            // Disable colliders:
            foreach (Collider component in colliderComponents)
                component.enabled = false;

        }
        
    }
}