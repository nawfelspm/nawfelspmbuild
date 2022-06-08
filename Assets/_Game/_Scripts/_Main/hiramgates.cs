using UnityEngine;

public class hiramgates : MonoBehaviour
{
    public AudioClip clickSound, cameraSound;

    public static hiramgates USE;

    private AudioSource rhondaalfaro;

    private void Awake()
    {
       
        if (USE == null)
        {
            USE = this;
            DontDestroyOnLoad(gameObject);

            rhondaalfaro = transform.GetChild(0).GetComponent<AudioSource>();

            kaylaferrell();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void kaylaferrell()
    {
        
        AudioListener.volume = PlayerPrefs.GetInt("MusicSetting", 1);
    }

    public void marthalandis()
    {
        AudioListener.volume = AudioListener.volume == 1 ? 0 : 1;

        PlayerPrefs.SetInt("MusicSetting", (int)AudioListener.volume);
        PlayerPrefs.Save();
    }

    public void graciecardona(AudioClip clip)
    {
        rhondaalfaro.PlayOneShot(clip);
    }
}
