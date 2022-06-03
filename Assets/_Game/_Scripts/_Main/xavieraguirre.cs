using UnityEngine;

public class xavieraguirre : MonoBehaviour
{
    public AudioClip clickSound, cameraSound;

    public static xavieraguirre USE;

    private AudioSource hildakirk;

    private void Awake()
    {
       
        if (USE == null)
        {
            USE = this;
            DontDestroyOnLoad(gameObject);

            hildakirk = transform.GetChild(0).GetComponent<AudioSource>();

            esperanzabrand();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void esperanzabrand()
    {
        
        AudioListener.volume = PlayerPrefs.GetInt("MusicSetting", 1);
    }

    public void molliekiser()
    {
        AudioListener.volume = AudioListener.volume == 1 ? 0 : 1;

        PlayerPrefs.SetInt("MusicSetting", (int)AudioListener.volume);
        PlayerPrefs.Save();
    }

    public void elainemelendez(AudioClip clip)
    {
        hildakirk.PlayOneShot(clip);
    }
}
