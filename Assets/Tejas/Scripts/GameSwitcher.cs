using UnityEngine;

public class GameSwitcher : MonoBehaviour
{
    [Header("Cameras")]
    public Camera realCam;
    public Camera shadowCam;

    [Header("Players")]
    public GameObject realPlayer;
    public GameObject shadowPlayer;

    // Cache these for easy access
    private PlayerController realPC;
    private PlayerController shadowPC;
    private ShadowFollower shadowFollower;

    // Cached AudioListeners
    private AudioListener realListener;
    private AudioListener shadowListener;

    // Remember last real position to spawn shadow there
    private Vector3 _lastRealPos;

    private int currentIndex = 0;  // 0 = real, 1 = shadow

    void Awake()
    {
        // Grab components
        realPC = realPlayer.GetComponent<PlayerController>();
        shadowPC = shadowPlayer.GetComponent<PlayerController>();
        shadowFollower = shadowPlayer.GetComponent<ShadowFollower>();
    }

    void Start()
    {
        realListener = realCam.GetComponent<AudioListener>();
        shadowListener = shadowCam.GetComponent<AudioListener>();

        _lastRealPos = realPlayer.transform.position;

        // Force all GameObjects active first
        realPlayer.SetActive(true);
        shadowPlayer.SetActive(true);

        // Default to real player view
        SetView(0);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SetView(1 - currentIndex);
    }


    void SetView(int newIndex)
    {
        if (currentIndex == 0)
            _lastRealPos = realPlayer.transform.position;

        currentIndex = newIndex;
        bool showReal = (currentIndex == 0);

        // Cameras
        realCam.enabled = showReal;
        shadowCam.enabled = !showReal;

        // Controllers
        realPC.enabled = showReal;
        shadowPC.enabled = !showReal;

        // Shadow follows only when in real view
        shadowFollower.followReal = showReal;

        // Reposition only the controlled player
        if (!showReal)
        {
            shadowPlayer.transform.position = _lastRealPos;
        }

        // Audio
        realListener.enabled = showReal;
        shadowListener.enabled = !showReal;

        // Keep both players always active and visible
    }


}
