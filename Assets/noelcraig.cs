using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class noelcraig : MonoBehaviour
{

    int elisabethoneal;
    AsyncOperation progress = null;
    Image progressBar;
    float lupebrewer = 0;
    string renaeyoung;



    
    void Start()
    {
        
        
        UnityEngine.Debug.Log("XReceived Start splashscene" + courtneypappas.jonisaenz.ToString());
        if (courtneypappas.jonisaenz)
        {
            renaeyoung = "NotiSc";
        }
        else
        {
            renaeyoung = sheldonhogan.Homenamescene  ;
        }
        
        
        

        
        if (PlayerPrefs.HasKey("appStartedNumber"))
        {
            elisabethoneal = PlayerPrefs.GetInt("appStartedNumber");
        }
        else
        {
            elisabethoneal = 0;
        }
        elisabethoneal++;
        PlayerPrefs.SetInt("appStartedNumber", elisabethoneal);
        StartCoroutine(LoadScene());
    }


    IEnumerator LoadScene()
    {
        while (lupebrewer < 5)
        {
            lupebrewer += 0.05f;
            
            yield return new WaitForSeconds(0.025f);
        }
        UnityEngine.Debug.Log("XReceived LoadScene splashscene" + courtneypappas.jonisaenz.ToString());
        if (courtneypappas.jonisaenz)
        {
            renaeyoung = "NotiSc";
        }
        else
        {
            renaeyoung = sheldonhogan.Homenamescene;
        }
        SceneManager.LoadScene(renaeyoung);
    }

}
