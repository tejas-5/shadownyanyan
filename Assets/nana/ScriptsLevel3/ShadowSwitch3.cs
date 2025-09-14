using UnityEngine;

public class ShadowSwitch3 : MonoBehaviour
{
    public MyLiftController1 lift;
    public KeyCode activateKey = KeyCode.E;
    public Collider2D switchTrigger;

    void Update()
    {
        if (Input.GetKeyDown(activateKey) && switchTrigger.bounds.Contains(transform.position))
        {
            //lift.ActivateLift();
        }
    }
}