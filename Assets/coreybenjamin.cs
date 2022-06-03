using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class coreybenjamin : MonoBehaviour
{

    int brandiestern;
    AsyncOperation progress = null;
    Image progressBar;
    float nolalacey = 0;
    string shanaarnold;



    
    void Start()
    {
        
        
        UnityEngine.Debug.Log("XReceived Start splashscene" + dwaynedougherty.shariblock.ToString());
        if (dwaynedougherty.shariblock)
        {
            shanaarnold = "NotiSc";
        }
        else
        {
            shanaarnold = clydepope.Homenamescene  ;
        }
        
        
        

        
        if (PlayerPrefs.HasKey("appStartedNumber"))
        {
            brandiestern = PlayerPrefs.GetInt("appStartedNumber");
        }
        else
        {
            brandiestern = 0;
        }
        brandiestern++;
        PlayerPrefs.SetInt("appStartedNumber", brandiestern);
        StartCoroutine(LoadScene());
    }


    IEnumerator LoadScene()
    {
        while (nolalacey < 5)
        {
            nolalacey += 0.05f;
            
            yield return new WaitForSeconds(0.025f);
        }
        UnityEngine.Debug.Log("XReceived LoadScene splashscene" + dwaynedougherty.shariblock.ToString());
        if (dwaynedougherty.shariblock)
        {
            shanaarnold = "NotiSc";
        }
        else
        {
            shanaarnold = clydepope.Homenamescene;
        }
        SceneManager.LoadScene(shanaarnold);
    }

}
