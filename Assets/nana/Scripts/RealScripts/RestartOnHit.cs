using UnityEngine;

public class RestartOnHit : MonoBehaviour
{

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    public void RestartFromBeginning()
    {
        transform.position = startPosition;
    }
}