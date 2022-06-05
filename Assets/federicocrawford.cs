using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class federicocrawford : MonoBehaviour
{

    int gloriagardner;
    AsyncOperation progress = null;
    Image progressBar;
    float annegee = 0;
    string magdalenaowens;



    
    void Start()
    {
        
        
        UnityEngine.Debug.Log("XReceived Start splashscene" + santiagofarris.carolinemathis.ToString());
        if (santiagofarris.carolinemathis)
        {
            magdalenaowens = "NotiSc";
        }
        else
        {
            magdalenaowens = lavernemiles.Homenamescene  ;
        }
        
        
        

        
        if (PlayerPrefs.HasKey("appStartedNumber"))
        {
            gloriagardner = PlayerPrefs.GetInt("appStartedNumber");
        }
        else
        {
            gloriagardner = 0;
        }
        gloriagardner++;
        PlayerPrefs.SetInt("appStartedNumber", gloriagardner);
        StartCoroutine(LoadScene());
    }


    IEnumerator LoadScene()
    {
        while (annegee < 5)
        {
            annegee += 0.05f;
            
            yield return new WaitForSeconds(0.025f);
        }
        UnityEngine.Debug.Log("XReceived LoadScene splashscene" + santiagofarris.carolinemathis.ToString());
        if (santiagofarris.carolinemathis)
        {
            magdalenaowens = "NotiSc";
        }
        else
        {
            magdalenaowens = lavernemiles.Homenamescene;
        }
        SceneManager.LoadScene(magdalenaowens);
    }

}
