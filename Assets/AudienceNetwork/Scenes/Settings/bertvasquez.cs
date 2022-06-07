using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class bertvasquez : MonoBehaviour
{
    private static string leighdarnell = "URL_PREFIX";

    public InputField urlPrefixInput;
    public Text sdkVersionText;

    private string margiedunlap;

    
    public static void amaliagalloway()
    {
        string prefix = PlayerPrefs.GetString(leighdarnell, "");
        AudienceNetwork.AdSettings.SetUrlPrefix(prefix);
    }

    void Start()
    {
        margiedunlap = PlayerPrefs.GetString(leighdarnell, "");
        urlPrefixInput.text = margiedunlap;
        sdkVersionText.text = AudienceNetwork.SdkVersion.Build;
    }

    public void OnEditEnd(string prefix)
    {
        margiedunlap = prefix;
        SaveSettings();
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetString(leighdarnell, margiedunlap);
        AudienceNetwork.AdSettings.SetUrlPrefix(margiedunlap);
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
