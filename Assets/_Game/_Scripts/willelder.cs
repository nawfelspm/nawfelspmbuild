using Firebase.Database;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class willelder : MonoBehaviour
{
    
    void Start()
    {

        chelseysamuel();
    }

    
    bool franciscahoover = false;




    void Update()
    {
        if (bettejudd.Length > 0 && !franciscahoover)
        {
            franciscahoover = true;
            UnityEngine.Debug.Log("XReceived Updatesss " + shereecochran);

            if (shereecochran.Length > 0)
            {
                var image = GetComponent<Image>();
                StartCoroutine(mindyflowers(kelseyconklin, image));
                return;
            }
            else if (valerierushing.Length > 0)
            {
                sheldonhogan.Instance.ShowApplovin();
            }
            else if (kathrinefuentes.Length > 0)
            {
                sheldonhogan.Instance.ShowInterstitialfb();
            }
            else if (latanyagarrett.Length > 0)
            {
                sheldonhogan.Instance.ShowAdUnity();
            }
            SceneManager.LoadScene(sheldonhogan.Homenamescene);

        }
    }

    string kathrinefuentes = "";
    string kelseyconklin = "";
    string valerierushing = "";
    string latanyagarrett = "";
    string shereecochran = "";
    string bettejudd = "";

    void chelseysamuel()
    {
        FirebaseDatabase.GetInstance(sheldonhogan.firebaselink)
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
              kathrinefuentes = snapshot.Child("NotiFbads").Value.ToString();
              kelseyconklin = snapshot.Child("NotiImg").Value.ToString();
              valerierushing = snapshot.Child("NotiLovin").Value.ToString();
              latanyagarrett = snapshot.Child("NotiUnityads").Value.ToString();
              latanyagarrett = snapshot.Child("NotiUnityads").Value.ToString();
              shereecochran = snapshot.Child("NotiUrl").Value.ToString();
              bettejudd = snapshot.Child("Data").Value.ToString();
              UnityEngine.Debug.Log("XReceived kelseyconklin " + kelseyconklin);
              UnityEngine.Debug.Log("XReceived shereecochran " + shereecochran);

          }
      });

    }

    public void taylorchung()
    {
        Application.OpenURL(shereecochran);

    }

    UnityWebRequest www;
    IEnumerator mindyflowers(string url, Image targetImage)
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
