using UnityEngine;

public class LiftController : MonoBehaviour
{
    public Transform topPoint;
    public Transform bottomPoint;
    public float speed = 2f;

    private bool goingUp = false;
    private bool moving = false;


    void Update()
    {
        if (!moving) return;

        Vector3 target = goingUp ? topPoint.position : bottomPoint.position;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            moving = false; // หยุดเมื่อถึงจุดหมาย
        }

        Debug.Log($"GoingUp: {goingUp}, Moving: {moving}");
        Debug.Log($"Lift Pos: {transform.position}, Target: {(goingUp ? topPoint.position : bottomPoint.position)}");

    }

    public void Toggle()
    {
        goingUp = !goingUp;
        moving = true;
    }

    void OnDrawGizmosSelected()
    {
        if (topPoint != null && bottomPoint != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(topPoint.position, 0.2f);

            Gizmos.color = Color.red;
            Gizmos.DrawSphere(bottomPoint.position, 0.2f);
        }
    }
}
