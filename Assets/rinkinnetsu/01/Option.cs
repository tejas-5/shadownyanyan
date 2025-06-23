using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Slider volumeSlider;  // 拖动到对应的Slider
    public AudioSource backgroundMusic;  // 背景音乐的AudioSource组件

    void Start()
    {
        // 设置默认音量为 100%
        if (volumeSlider != null && backgroundMusic != null)
        {
            // 先从 PlayerPrefs 获取音量设置，如果没有则默认音量为 100%
            float savedVolume = PlayerPrefs.GetFloat("Volume", 1f);  // 默认音量是 1 (100%)

            volumeSlider.value = savedVolume;  // 设置 Slider 初始值
            backgroundMusic.volume = savedVolume;  // 设置背景音乐的音量

            // 监听音量变化
            volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        }
    }

    // 音量变化时的回调函数
    void OnVolumeChanged(float value)
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.volume = value;  // 调节音量
        }

        // 保存音量设置
        PlayerPrefs.SetFloat("Volume", value);
    }
}