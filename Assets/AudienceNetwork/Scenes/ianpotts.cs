using UnityEngine;
using UnityEngine.SceneManagement;

public class ianpotts : MonoBehaviour
{
    
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
                return;
            }
        }
    }

    public void julietteambrose()
    {
        SceneManager.LoadScene("SettingsScene");
    }
}
