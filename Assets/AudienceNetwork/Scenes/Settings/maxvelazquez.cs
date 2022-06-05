using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class maxvelazquez : MonoBehaviour
{
    private static string angiecorona = "URL_PREFIX";

    public InputField urlPrefixInput;
    public Text sdkVersionText;

    private string sherrystanley;

    
    public static void evelynhardin()
    {
        string prefix = PlayerPrefs.GetString(angiecorona, "");
        AudienceNetwork.AdSettings.SetUrlPrefix(prefix);
    }

    void Start()
    {
        sherrystanley = PlayerPrefs.GetString(angiecorona, "");
        urlPrefixInput.text = sherrystanley;
        sdkVersionText.text = AudienceNetwork.SdkVersion.Build;
    }

    public void OnEditEnd(string prefix)
    {
        sherrystanley = prefix;
        SaveSettings();
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetString(angiecorona, sherrystanley);
        AudienceNetwork.AdSettings.SetUrlPrefix(sherrystanley);
    }

    public void AdViewScene()
    {
        SceneManager.LoadScene("AdViewScene");
    }

    public void InterstitialAdScene()
    {
        SceneManager.LoadScene("InterstitialAdScene");
    }

    public void RewardedVideoAdScene()
    {
        SceneManager.LoadScene("RewardedVideoAdScene");
    }
}
