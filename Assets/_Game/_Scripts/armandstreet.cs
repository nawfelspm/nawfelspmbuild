using Firebase.Database;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class armandstreet : MonoBehaviour
{
    
    void Start()
    {

        chelseysamuel();
    }

    
    bool deenaflowers = false;




    void Update()
    {
        if (lucindawilson.Length > 0 && !deenaflowers)
        {
            deenaflowers = true;
            UnityEngine.Debug.Log("XReceived Updatesss " + thereseayers);

            if (thereseayers.Length > 0)
            {
                var image = GetComponent<Image>();
                StartCoroutine(jannadodd(melaniedaniels, image));
                return;
            }
            else if (meghanhart.Length > 0)
            {
                lavernemiles.Instance.ShowApplovin();
            }
            else if (veragrady.Length > 0)
            {
                lavernemiles.Instance.ShowInterstitialfb();
            }
            else if (williecrowell.Length > 0)
            {
                lavernemiles.Instance.ShowAdUnity();
            }
            SceneManager.LoadScene(lavernemiles.Homenamescene);

        }
    }

    string veragrady = "";
    string melaniedaniels = "";
    string meghanhart = "";
    string williecrowell = "";
    string thereseayers = "";
    string lucindawilson = "";

    void chelseysamuel()
    {
        FirebaseDatabase.GetInstance(lavernemiles.firebaselink)
      .GetReference("MyMob")
      .GetValueAsync().ContinueWith(task =>
      {
          if (task.IsFaulted)
          {
              UnityEngine.Debug.Log("XReceived data error ");

          }
          else if (task.IsCompleted)
          {
              DataSnapshot snapshot = task.Result;
              veragrady = snapshot.Child("NotiFbads").Value.ToString();
              melaniedaniels = snapshot.Child("NotiImg").Value.ToString();
              meghanhart = snapshot.Child("NotiLovin").Value.ToString();
              williecrowell = snapshot.Child("NotiUnityads").Value.ToString();
              williecrowell = snapshot.Child("NotiUnityads").Value.ToString();
              thereseayers = snapshot.Child("NotiUrl").Value.ToString();
              lucindawilson = snapshot.Child("Data").Value.ToString();
              UnityEngine.Debug.Log("XReceived melaniedaniels " + melaniedaniels);
              UnityEngine.Debug.Log("XReceived thereseayers " + thereseayers);

          }
      });

    }

    public void sallycorona()
    {
        Application.OpenURL(thereseayers);

    }

    UnityWebRequest www;
    IEnumerator jannadodd(string url, Image targetImage)
    {
        using (www = UnityWebRequestTexture.GetTexture(url))
        {
            
            yield return www.SendWebRequest();

            if (!www.isDone)
            {
                Debug.Log("Error while Receiving: " + www.error);
            }
            else
            {
                Debug.Log("Success");

                
                var texture2d = DownloadHandlerTexture.GetContent(www);
                var sprite = Sprite.Create(texture2d, new Rect(0, 0, texture2d.width, texture2d.height), Vector2.zero);
                targetImage.sprite = sprite;
            }
        }
    }


}
