using UnityEngine;
using UnityEngine.SceneManagement;

public class norrissheridan : MonoBehaviour
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

    public void veracornelius()
    {
        SceneManager.LoadScene("SettingsScene");
    }
}
