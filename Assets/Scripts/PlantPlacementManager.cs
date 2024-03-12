using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlantPlacementManager : MonoBehaviour
{
    public GameObject[] flowers;
    public XROrigin sessionOrigin;
    public ARRaycastManager raycastManager;
    public ARPlaneManager planeManager;

    private List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();

    private void Update()
    {
        if(Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // shoot raycast
            // place the objects randomly
            // disable the planes and the plane manager

            bool collision = raycastManager.Raycast(Input.mousePosition, raycastHits, TrackableType.PlaneWithinPolygon);

            if(collision)
            {
                GameObject _object = Instantiate(flowers[Random.Range(0, flowers.Length - 1)]);
                _object.transform.position = raycastHits[0].pose.position;

            }


            foreach (var plane in planeManager.trackables)
            {
                plane.gameObject.SetActive(false);
            }

            planeManager.enabled = false;
        }
    }
}
