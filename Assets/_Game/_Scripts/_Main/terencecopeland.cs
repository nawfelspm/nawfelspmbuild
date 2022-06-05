using UnityEngine;
using UnityEngine.UI;

public class terencecopeland : MonoBehaviour
{
    public Camera cameraObj;
    public harrisonjennings coloringMenu, paintingMenu;

    [System.Serializable]
    public class harrisonjennings
    {
        public GameObject carissacline;
        public Color color;
        public Image image;
        public Sprite rhondavega;
        public Sprite sheiladick;
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

        paintingMenu.carissacline.SetActive(isPainting);
        coloringMenu.carissacline.SetActive(!isPainting);

        cameraObj.backgroundColor = isPainting ? paintingMenu.color : coloringMenu.color;
        paintingMenu.image.sprite = isPainting ? paintingMenu.rhondavega : paintingMenu.sheiladick;
        coloringMenu.image.sprite = !isPainting ? coloringMenu.rhondavega : coloringMenu.sheiladick;
    }

    public void adelineberman()
    {
       
    }
}
