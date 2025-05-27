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
        if (currentIndex == 0)
            _lastRealPos = realPlayer.transform.position;

        currentIndex = newIndex;
        bool showReal = (currentIndex == 0);

        realCam.enabled = showReal;
        shadowCam.enabled = !showReal;

        realPC.enabled = showReal;
        shadowPC.enabled = !showReal;

        shadowFollower.followReal = showReal;

        if (!showReal)
        {
            shadowPlayer.transform.position = _lastRealPos;
        }
        realListener.enabled = showReal;
        shadowListener.enabled = !showReal;
    }
}
