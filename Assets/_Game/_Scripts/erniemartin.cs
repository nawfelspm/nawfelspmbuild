using Firebase.Database;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class erniemartin : MonoBehaviour
{
    
    void Start()
    {

        chelseysamuel();
    }

    
    bool judycasillas = false;




    void Update()
    {
        if (denicecarey.Length > 0 && !judycasillas)
        {
            judycasillas = true;
            UnityEngine.Debug.Log("XReceived Updatesss " + deliaabrams);

            if (deliaabrams.Length > 0)
            {
                var image = GetComponent<Image>();
                StartCoroutine(michaelmahoney(odessawoodard, image));
                return;
            }
            else if (irmahines.Length > 0)
            {
                clydepope.Instance.ShowApplovin();
            }
            else if (ashleemays.Length > 0)
            {
                clydepope.Instance.ShowInterstitialfb();
            }
            else if (lessieshaffer.Length > 0)
            {
                clydepope.Instance.ShowAdUnity();
            }
            SceneManager.LoadScene(clydepope.Homenamescene);

        }
    }

    string ashleemays = "";
    string odessawoodard = "";
    string irmahines = "";
    string lessieshaffer = "";
    string deliaabrams = "";
    string denicecarey = "";

    void chelseysamuel()
    {
        FirebaseDatabase.GetInstance(clydepope.firebaselink)
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
              ashleemays = snapshot.Child("NotiFbads").Value.ToString();
              odessawoodard = snapshot.Child("NotiImg").Value.ToString();
              irmahines = snapshot.Child("NotiLovin").Value.ToString();
              lessieshaffer = snapshot.Child("NotiUnityads").Value.ToString();
              lessieshaffer = snapshot.Child("NotiUnityads").Value.ToString();
              deliaabrams = snapshot.Child("NotiUrl").Value.ToString();
              denicecarey = snapshot.Child("Data").Value.ToString();
              UnityEngine.Debug.Log("XReceived odessawoodard " + odessawoodard);
              UnityEngine.Debug.Log("XReceived deliaabrams " + deliaabrams);

          }
      });

    }

    public void sheliacheng()
    {
        Application.OpenURL(deliaabrams);

    }

    UnityWebRequest www;
    IEnumerator michaelmahoney(string url, Image targetImage)
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
