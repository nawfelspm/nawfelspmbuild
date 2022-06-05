using UnityEngine;

public class amosmiles : MonoBehaviour
{
    public AudioClip clickSound, cameraSound;

    public static amosmiles USE;

    private AudioSource meredithruss;

    private void Awake()
    {
       
        if (USE == null)
        {
            USE = this;
            DontDestroyOnLoad(gameObject);

            meredithruss = transform.GetChild(0).GetComponent<AudioSource>();

            janisdubois();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void janisdubois()
    {
        
        AudioListener.volume = PlayerPrefs.GetInt("MusicSetting", 1);
    }

    public void mayrawarren()
    {
        AudioListener.volume = AudioListener.volume == 1 ? 0 : 1;

        PlayerPrefs.SetInt("MusicSetting", (int)AudioListener.volume);
        PlayerPrefs.Save();
    }

    public void darcyraymond(AudioClip clip)
    {
        meredithruss.PlayOneShot(clip);
    }
}
