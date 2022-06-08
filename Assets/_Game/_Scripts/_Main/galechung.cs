using UnityEngine;
using UnityEngine.UI;

public class galechung : MonoBehaviour
{
    public Camera cameraObj;
    public ricardowelch coloringMenu, paintingMenu;

    [System.Serializable]
    public class ricardowelch
    {
        public GameObject lesahunt;
        public Color color;
        public Image image;
        public Sprite callieott;
        public Sprite nolaramos;
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

        paintingMenu.lesahunt.SetActive(isPainting);
        coloringMenu.lesahunt.SetActive(!isPainting);

        cameraObj.backgroundColor = isPainting ? paintingMenu.color : coloringMenu.color;
        paintingMenu.image.sprite = isPainting ? paintingMenu.callieott : paintingMenu.nolaramos;
        coloringMenu.image.sprite = !isPainting ? coloringMenu.callieott : coloringMenu.nolaramos;
    }

    public void gingerwilkes()
    {
       
    }
}
