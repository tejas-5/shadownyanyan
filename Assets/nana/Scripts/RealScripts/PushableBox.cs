using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PushableBox : MonoBehaviour
{
    public bool hasLight = true;  // สถานะไฟ เปิด/ปิดกล่องเงา

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.mass = 10f;
    }

    // ฟังก์ชันสำหรับเปิด/ปิดไฟ
    public void SetLightStatus(bool status)
    {
        hasLight = status;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.collider.GetComponent<PlayerController>();
        if (player != null)
        {
            if (!player.isRealPlayer)
            {
                // ถ้าเป็นเงา ให้ box เป็น Static เพื่อไม่ให้ขยับ
                rb.bodyType = RigidbodyType2D.Static;
            }
            else
            {
                // ถ้าเป็นตัวจริง ให้ box เป็น Dynamic เพื่อให้ผลักได้
                rb.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        PlayerController player = collision.collider.GetComponent<PlayerController>();
        if (player != null)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}