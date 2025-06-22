using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public LiftController lift; // ลิฟต์ที่จะควบคุม

    public void ToggleLift()
    {
        lift.Toggle();
    }
}