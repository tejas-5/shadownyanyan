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

        if (realPC == null || shadowPC == null || shadowFollower == null)
            Debug.LogError("Make sure both players have PlayerController and the shadow has ShadowFollower.");
    }

    void Start()
    {
        realListener = realCam.GetComponent<AudioListener>();
        shadowListener = shadowCam.GetComponent<AudioListener>();

        // Initialize last real pos
        _lastRealPos = realPlayer.transform.position;

        SetView(0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SetView(1 - currentIndex);
    }

    void SetView(int newIndex)
    {
        // Save real's spot when leaving real
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

        // Shadow follows only in real view
        shadowFollower.followReal = showReal;

        // Position newly active character
        if (showReal)
        {
            realPlayer.transform.position = _lastRealPos;
        }
        else
        {
            // Shadow spawns at where real was last
            shadowPlayer.transform.position = _lastRealPos;
        }

        // Audio Listeners
        realListener.enabled = showReal;
        shadowListener.enabled = !showReal;

        // Toggle GameObject active states
        realPlayer.SetActive(showReal);
        shadowPlayer.SetActive(!showReal);
    }
}
