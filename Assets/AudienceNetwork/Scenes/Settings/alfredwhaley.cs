using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class alfredwhaley : MonoBehaviour
{
    private static string jeanniebridges = "URL_PREFIX";

    public InputField urlPrefixInput;
    public Text sdkVersionText;

    private string hesteracevedo;

    
    public static void katecrockett()
    {
        string prefix = PlayerPrefs.GetString(jeanniebridges, "");
        AudienceNetwork.AdSettings.SetUrlPrefix(prefix);
    }

    void Start()
    {
        hesteracevedo = PlayerPrefs.GetString(jeanniebridges, "");
        urlPrefixInput.text = hesteracevedo;
        sdkVersionText.text = AudienceNetwork.SdkVersion.Build;
    }

    public void OnEditEnd(string prefix)
    {
        hesteracevedo = prefix;
        SaveSettings();
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetString(jeanniebridges, hesteracevedo);
        AudienceNetwork.AdSettings.SetUrlPrefix(hesteracevedo);
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
