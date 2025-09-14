using UnityEngine;
using UnityEngine.Audio;

public class DebugAudioTest : MonoBehaviour
{
    [Header("Audio Mixer Groups")]
    public AudioMixerGroup masterGroup;
    public AudioMixerGroup bgmGroup;
    public AudioMixerGroup seGroup;

    [Header("Audio Clips")]
    public AudioClip masterClip;
    public AudioClip bgmClip;
    public AudioClip seClip;

    private AudioSource audioSource;

    void Start()
    {
        // เตรียม AudioSource ไว้เล่นเสียง
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U)) // ทดสอบ Master
        {
            PlayTestSound(masterClip, masterGroup);
            Debug.Log("▶ Master Test Sound");
        }

        if (Input.GetKeyDown(KeyCode.I)) // ทดสอบ BGM
        {
            PlayTestSound(bgmClip, bgmGroup);
            Debug.Log("▶ BGM Test Sound");
        }

        if (Input.GetKeyDown(KeyCode.O)) // ทดสอบ SE
        {
            PlayTestSound(seClip, seGroup);
            Debug.Log("▶ SE Test Sound");
        }
    }

    private void PlayTestSound(AudioClip clip, AudioMixerGroup group)
    {
        if (clip == null || group == null)
        {
            Debug.LogWarning("⚠️ Missing Clip or MixerGroup!");
            return;
        }

        audioSource.outputAudioMixerGroup = group;
        audioSource.PlayOneShot(clip);
    }
}