using UnityEngine;
using UnityEngine.UI;

public class lincolncoker : MonoBehaviour
{
    public Camera cameraObj;
    public nestorjeffers coloringMenu, paintingMenu;

    [System.Serializable]
    public class nestorjeffers
    {
        public GameObject vernachase;
        public Color color;
        public Image image;
        public Sprite melissagleason;
        public Sprite kaseymccain;
    }

    void Awake()
    {
        Camera.main.aspect = 16 / 9f;
    }

    void Start()
    {
                OnMenuButtonClicked(PlayerPrefs.GetInt("isPainting", 0) == 1);
    }

    public void OnMenuButtonClicked(bool isPainting)
    {
        PlayerPrefs.SetInt("isPainting", isPainting ? 1 : 0);
        PlayerPrefs.Save();

        paintingMenu.vernachase.SetActive(isPainting);
        coloringMenu.vernachase.SetActive(!isPainting);

        cameraObj.backgroundColor = isPainting ? paintingMenu.color : coloringMenu.color;
        paintingMenu.image.sprite = isPainting ? paintingMenu.melissagleason : paintingMenu.kaseymccain;
        coloringMenu.image.sprite = !isPainting ? coloringMenu.melissagleason : coloringMenu.kaseymccain;
    }

    public void mandydodge()
    {
       
    }
}
