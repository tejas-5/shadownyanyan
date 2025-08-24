using UnityEngine;

/// <summary>
/// ใช้จัดการ IgnoreCollision ระหว่าง Tag ที่กำหนด
/// ใส่ไว้ใน GameManager หรือ EmptyObject ได้เลย
/// </summary>
public class IgnoreCollisionByTag : MonoBehaviour
{
    [System.Serializable]
    public class IgnorePair
    {
        public string tagA;
        public string tagB;
    }

    [Header("กำหนดคู่ Tag ที่จะ Ignore")]
    public IgnorePair[] ignorePairs;

    void Start()
    {
        foreach (var pair in ignorePairs)
        {
            IgnoreCollision(pair.tagA, pair.tagB);
        }
    }

    void IgnoreCollision(string tagA, string tagB)
    {
        GameObject[] objsA = GameObject.FindGameObjectsWithTag(tagA);
        GameObject[] objsB = GameObject.FindGameObjectsWithTag(tagB);

        foreach (var objA in objsA)
        {
            Collider2D colA = objA.GetComponent<Collider2D>();
            if (colA == null) continue;

            foreach (var objB in objsB)
            {
                Collider2D colB = objB.GetComponent<Collider2D>();
                if (colB == null) continue;

                Physics2D.IgnoreCollision(colA, colB, true);
            }
        }
    }
}