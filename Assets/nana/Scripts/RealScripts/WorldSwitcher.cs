using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

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

        // เปิดใช้งานทั้งสองตัว
        realPlayer.SetActive(true);
        shadowPlayer.SetActive(true);

        // ตั้งให้ควบคุมแค่ตัวจริง
        SetPlayerControl(realPlayer, true);
        SetPlayerControl(shadowPlayer, false);

        // ให้เงาตามตัวจริง
        shadowPlayer.transform.position = realPlayer.transform.position;

        if (cameraFollow != null)
            cameraFollow.SetTarget(realPlayer.transform);
    }

    void Update()
    {
        // เงาตามผู้เล่นก่อนแยกร่าง
        if (isFollowing)
        {
            shadowPlayer.transform.position = realPlayer.transform.position;
        }

        // SPACE = สลับร่าง
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!hasSeparated)
            {
                // แยกร่างครั้งแรก
                hasSeparated = true;
                isFollowing = false;
                isControllingReal = false;

                SetPlayerControl(realPlayer, false);
                SetPlayerControl(shadowPlayer, true);
                StartCoroutine(TemporarilyIgnoreBoxCollision(shadowPlayer));

                cameraFollow?.SetTarget(shadowPlayer.transform);
            }
            else
            {
                // สลับไปมาระหว่างร่าง
                isControllingReal = !isControllingReal;

                GameObject activePlayer = isControllingReal ? realPlayer : shadowPlayer;
                GameObject inactivePlayer = isControllingReal ? shadowPlayer : realPlayer;

                SetPlayerControl(activePlayer, true);
                SetPlayerControl(inactivePlayer, false);

                StartCoroutine(TemporarilyIgnoreBoxCollision(activePlayer));

                cameraFollow?.SetTarget(activePlayer.transform);
            }
        }

        // R = รีเซ็ต
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
        var rb = obj.GetComponent<Rigidbody2D>();

        if (pc != null) pc.enabled = active;
        if (rb != null) rb.simulated = active;
    }

  

    // 🎯 โค้ดนี้สำคัญ! ป้องกันการชนกับกล่องชั่วคราว
    IEnumerator TemporarilyIgnoreBoxCollision(GameObject player)
    {
        Collider2D playerCol = player.GetComponent<Collider2D>();
        if (playerCol == null)
        {
            Debug.LogWarning("⚠️ Player ไม่มี Collider2D!");
            yield break;
        }

        // ✅ หากเป็นผู้เล่นตัวจริงเท่านั้นถึงจะ Ignore กล่อง
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

            yield return new WaitForSeconds(0.1f);

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
