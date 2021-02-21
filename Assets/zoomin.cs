using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomin : MonoBehaviour
{

    [SerializeField] private Transform startMarker = null;
    [SerializeField] private Transform endMarker = null;
    [SerializeField] private float speed = 1.8f;

    private float startTime;
    private float journeyLength;

    private void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    private void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLength;

        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);
    }

}
