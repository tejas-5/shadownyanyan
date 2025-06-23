using UnityEngine;

public class BoxController : MonoBehaviour
{
    public GameObject shadowVersion;  // ตัวเงาของกล่อง

    private void Start()
    {
        SetMode(true);  // เริ่มจากโลกจริง
    }

    // เรียกเมื่อต้องการสลับโลก
    public void SetMode(bool isRealWorld)
    {
        // ถ้าอยู่ในโลกจริง:
        GetComponent<SpriteRenderer>().enabled = isRealWorld;
        GetComponent<Rigidbody2D>().simulated = isRealWorld;
        GetComponent<Collider2D>().enabled = isRealWorld;

        // เงากล่องทำงานตรงข้าม
        shadowVersion.SetActive(!isRealWorld);
    }
}
