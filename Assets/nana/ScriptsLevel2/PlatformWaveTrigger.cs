using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformWaveTrigger : MonoBehaviour
{
    public float delayBetweenEach = 0.3f;
    public Transform moveTargetPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered ArrivalZone! เริ่มเคลื่อนพื้น");
            StartCoroutine(MovePlatformsOneByOne());
        }
    }

    IEnumerator MovePlatformsOneByOne()
    {
        var platforms = Object.FindObjectsByType<MovingPlatformControlled>(FindObjectsSortMode.None);

        List<MovingPlatformControlled> sorted = new List<MovingPlatformControlled>(platforms);
        sorted.Sort((a, b) => a.transform.position.x.CompareTo(b.transform.position.x));

        foreach (var platform in sorted)
        {
            if (platform != null)
            {
                platform.StartMoving(moveTargetPoint.position);
                yield return new WaitForSeconds(delayBetweenEach);
            }
        }
    }
}