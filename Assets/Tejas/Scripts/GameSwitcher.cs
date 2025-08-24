using UnityEngine;

public class GameSwitcher : MonoBehaviour
{
    [Header("Cameras")]
    public Camera realCam;
    public Camera shadowCam;

    [Header("Players")]
    public GameObject realPlayer;
    public GameObject shadowPlayer;

    private PlayerController realPC;
    private PlayerController shadowPC;
    private ShadowFollower shadowFollower;

    private AudioListener realListener;
    private AudioListener shadowListener;

    private Vector3 _lastRealPos;

    private int currentIndex = 0;

    void Awake()
    {
        realPC = realPlayer.GetComponent<PlayerController>();
        shadowPC = shadowPlayer.GetComponent<PlayerController>();
        shadowFollower = shadowPlayer.GetComponent<ShadowFollower>();
    }

    void Start()
    {
        realListener = realCam.GetComponent<AudioListener>();
        shadowListener = shadowCam.GetComponent<AudioListener>();

        _lastRealPos = realPlayer.transform.position;

        realPlayer.SetActive(true);
        shadowPlayer.SetActive(true);

        SetView(0);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SetView(1 - currentIndex);
    }

    void SetView(int newIndex)
    {
        currentIndex = newIndex;
        bool showReal = (currentIndex == 0);

        realCam.enabled = showReal;
        shadowCam.enabled = !showReal;

        // แทนการ enable/disable script
        realPC.canControl = showReal;
        shadowPC.canControl = !showReal;

        shadowFollower.SetFollowing(showReal);

        realListener.enabled = showReal;
        shadowListener.enabled = !showReal;
    }

}
