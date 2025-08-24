using System.Collections;
using UnityEngine;

public class WorldSwitcher : MonoBehaviour
{
    public GameObject realPlayer;
    public GameObject shadowPlayer;
    public CameraFollow cameraFollow;

    private bool isControllingReal = true;
    private bool isFollowing = true;
    private bool hasSeparated = false;

    void Start()
    {
        if (cameraFollow == null)
            cameraFollow = Camera.main.GetComponent<CameraFollow>();

        realPlayer.SetActive(true);
        shadowPlayer.SetActive(true);

        // 👉 วางเงาไว้ข้างหน้าผู้เล่นนิดหน่อย
        shadowPlayer.transform.position = realPlayer.transform.position + Vector3.right * 1.5f;

        // เริ่มต้นควบคุมผู้เล่นจริง
        SetPlayerControl(realPlayer, true);
        SetPlayerControl(shadowPlayer, false);

        if (cameraFollow != null)
            cameraFollow.SetTarget(realPlayer.transform);

        // ❌ ห้าม Player จริง ชนกับกล่องเงา
        IgnoreCollisionByTag("Player", "ShadowBox");

        // ✅ เพิ่มบรรทัดนี้ ป้องกันผู้เล่นกับเงาชนกัน
        Collider2D realCol = realPlayer.GetComponent<Collider2D>();
        Collider2D shadowCol = shadowPlayer.GetComponent<Collider2D>();
        if (realCol != null && shadowCol != null)
        {
            Physics2D.IgnoreCollision(realCol, shadowCol, true);
        }
    }

    void IgnoreCollisionByTag(string tagA, string tagB)
    {
        GameObject[] objsA = GameObject.FindGameObjectsWithTag(tagA);
        GameObject[] objsB = GameObject.FindGameObjectsWithTag(tagB);

        foreach (var objA in objsA)
        {
            var colA = objA.GetComponent<Collider2D>();
            if (colA == null) continue;

            foreach (var objB in objsB)
            {
                var colB = objB.GetComponent<Collider2D>();
                if (colB == null) continue;

                Physics2D.IgnoreCollision(colA, colB, true);
            }
        }
    }

    void Update()
    {
        // เงาตามตัวจริงก่อนแยกร่าง
        //if (isFollowing)
        {
            //shadowPlayer.transform.position = realPlayer.transform.position;
        }//

        // SPACE = สลับร่าง
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isControllingReal = !isControllingReal;

            GameObject activePlayer = isControllingReal ? realPlayer : shadowPlayer;
            GameObject inactivePlayer = isControllingReal ? shadowPlayer : realPlayer;

            SetPlayerControl(activePlayer, true);
            SetPlayerControl(inactivePlayer, false);

            cameraFollow?.SetTarget(activePlayer.transform);
        }
        

        // R = รีเซ็ตร่าง
        if (Input.GetKeyDown(KeyCode.R))
        {
            isFollowing = true;
            hasSeparated = false;
            isControllingReal = true;

            shadowPlayer.transform.position = realPlayer.transform.position;

            SetPlayerControl(realPlayer, true);
            SetPlayerControl(shadowPlayer, false);

            cameraFollow?.SetTarget(realPlayer.transform);
        }
    }

    void SetPlayerControl(GameObject obj, bool active)
    {
        var pc = obj.GetComponent<PlayerController>();
        if (pc != null) pc.enabled = active;

        // ❌ อย่าปิด Rigidbody2D.simulated เพราะจะทำให้ Collider หายไป!
        // Rigidbody2D ยังเปิดไว้เพื่อไม่ให้ตกทะลุ platform/lift
    }

    // 🎯 ป้องกันการชนกับกล่องชั่วคราวหลังสลับร่าง
    IEnumerator TemporarilyIgnoreBoxCollision(GameObject player)
    {
        Collider2D playerCol = player.GetComponent<Collider2D>();
        if (playerCol == null)
        {
            Debug.LogWarning("⚠️ Player ไม่มี Collider2D!");
            yield break;
        }

        // ✅ หากเป็น Player จริง (ไม่ใช่เงา) ให้ Ignore กล่องชั่วคราว
        if (player.CompareTag("Player"))
        {
            GameObject[] boxes = GameObject.FindGameObjectsWithTag("PushableBox");

            foreach (GameObject box in boxes)
            {
                if (box == null) continue;

                Collider2D boxCol = box.GetComponent<Collider2D>();
                if (boxCol != null)
                {
                    Physics2D.IgnoreCollision(playerCol, boxCol, true);
                }
            }

            yield return new WaitForSeconds(0.1f); // ปรับเวลาได้

            foreach (GameObject box in boxes)
            {
                if (box == null) continue;

                Collider2D boxCol = box.GetComponent<Collider2D>();
                if (boxCol != null)
                {
                    Physics2D.IgnoreCollision(playerCol, boxCol, false);
                }
            }
        }
    }
}