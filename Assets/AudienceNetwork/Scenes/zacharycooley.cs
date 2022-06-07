using UnityEngine;
using UnityEngine.SceneManagement;

public class zacharycooley : MonoBehaviour
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

    public void aimeedwyer()
    {
        SceneManager.LoadScene("SettingsScene");
    }
}
