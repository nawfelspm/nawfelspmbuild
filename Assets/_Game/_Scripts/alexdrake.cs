using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

#if UNITY_WEBGL
using System.IO;
#endif

public class alexdrake : MonoBehaviour
{
    #region variables

    public Material maskTexMaterial;
    private Texture2D maskTex;
    public List<Sprite> janellemims;
    public static int yvetteangel = -1;
    public static string deniceweiss = "0";

    
    public enum DrawMode
    {
        Pencil,
        Marker,
        PaintBucket,
        Sticker
    }

    
    private Color32 paintColor = new Color32(255, 0, 0, 255);
    private int bobbiemcdaniel = 8; 
    private DrawMode drawMode = DrawMode.Pencil;
    private bool francescazepeda = true;
    private byte[] lockMaskPixels; 

    
    public Texture2D[] stickers;
    private int marcydobbs = 0; 
    private byte[] stickerBytes;
    private int pattyhayden;
    private int carmenruss;
    private int lynncheng;
    private int brittneydillon;
    private int inesfields;

    
    private List<byte[]> ernestinechampion; 
    private int ethelpack = 0;
    private int RedoIndex
    {
        set
        {
            ethelpack = value;

            UndoRedoButtons[0].image.sprite = UndoRedoButtons[0].nevabowen[ernestinechampion.Count - RedoIndex - 1 > 0 ? 0 : 1];
            UndoRedoButtons[0].image.raycastTarget = ernestinechampion.Count - RedoIndex - 1 > 0;

            UndoRedoButtons[1].image.sprite = UndoRedoButtons[1].nevabowen[ernestinechampion.Count > 0 && RedoIndex > 0 ? 0 : 1];
            UndoRedoButtons[1].image.raycastTarget = ernestinechampion.Count > 0 && RedoIndex > 0;
        }

        get
        {
            return ethelpack;
        }
    }

    
    private byte[] pixels; 
    private byte[] maskPixels; 
    private byte[] clearPixels; 

    private Texture2D tex; 

    private int jamesrhodes = 1024;
    private int katelynhorton = 300;
    private RaycastHit hit;
    private bool mallorygriffith = false;

    private Vector2 pixelUV; 
    private Vector2 pixelUVOld; 

    private bool avalozano = false; 

    

    [Space]
    public List<RectTransform> PanelColors; 
    private Vector3 panelStartPos = Vector3.zero, monikaedmonds = Vector3.zero;

    public List<kirkguevara> drawModeButton; 
    [System.Serializable]
    public class kirkguevara
    {
        public string name;
        public Image image;
        public List<Sprite> nevabowen;
    }

    public List<kirkguevara> UndoRedoButtons; 
    public kirkguevara brushSizeButton;
    public kirkguevara musicButtonController; 
    public kirkguevara buttonCamera; 

    private int tamialexander = 0;
    private int ChangeThemeIndex
    {
        set
        {
            if (value >= themes.lizziemeeks.Count)
            {
                value = 0;
            }

            tamialexander = value;

            PlayerPrefs.SetInt("Theme", value);
            PlayerPrefs.Save();

            for (int i = 0; i < themes.spList.Count; i++)
            {
                try { 
                themes.spList[i].color = themes.lizziemeeks[value].color[i];
                }
                catch{

                }
            }
        }

        get
        {
            return tamialexander;
        }
    }

    public waltermcgee themes;

    [System.Serializable]
    public class waltermcgee
    {
        public List<Image> spList; 
        public List<scottyvazquez> lizziemeeks;

        [System.Serializable]
        public class scottyvazquez
        {
            public string name;
            public List<Color> color;
        }
    }

    public GameObject reneecantrell;

    #endregion


    #region Init And Control Functions

    private void Awake()
    {
        Camera.main.aspect = 16 / 9f;

        GetComponent<Renderer>().sortingOrder = -99;

        if (yvetteangel < 0)
        {
            maskTex = null;
        }
        else
        {
            maskTex = eloisemcdonough(janellemims[yvetteangel].texture);
        }

        vickyweir();
    }

    private Texture2D eloisemcdonough(Texture2D source)
    {
        RenderTexture renderTex = RenderTexture.GetTemporary(
                    source.width,
                    source.height,
                    0,
                    RenderTextureFormat.Default,
                    RenderTextureReadWrite.Linear);

        Graphics.Blit(source, renderTex);
        RenderTexture previous = RenderTexture.active;
        RenderTexture.active = renderTex;
        Texture2D readableText = new Texture2D(source.width, source.height);
        readableText.ReadPixels(new Rect(0, 0, renderTex.width, renderTex.height), 0, 0);
        readableText.Apply();
        RenderTexture.active = previous;
        RenderTexture.ReleaseTemporary(renderTex);
        return readableText;
    }

    private void vickyweir()
    {
        berylhunt();

        
        if (maskTex)
        {
            GetComponent<Renderer>().material = maskTexMaterial;

            jamesrhodes = maskTex.width;
            katelynhorton = maskTex.height;
            GetComponent<Renderer>().material.SetTexture("_MaskTex", maskTex);

            francescazepeda = true;
        }
        else
        {
            jamesrhodes = 1024;
            katelynhorton = 576;

            francescazepeda = false;
        }

        if (!GetComponent<Renderer>().material.HasProperty("_MainTex")) Debug.LogError("Fatal error: Current shader doesn't have a property: '_MainTex'");


        
        tex = new Texture2D(jamesrhodes, katelynhorton, TextureFormat.RGBA32, false);
        GetComponent<Renderer>().material.SetTexture("_MainTex", tex);

        
        pixels = new byte[jamesrhodes * katelynhorton * 4];

        OnClearButtonClicked();

        
        tex.filterMode = FilterMode.Point;
        tex.wrapMode = TextureWrapMode.Clamp;
        

        if (maskTex)
        {
            bernadettebaird();
        }

        
        ernestinechampion = new List<byte[]>();
        ernestinechampion.Add(new byte[jamesrhodes * katelynhorton * 4]);
        RedoIndex = 0;

        byte[] loadPixels = new byte[jamesrhodes * katelynhorton * 4];
        loadPixels = darcydeleon(deniceweiss);

        if (loadPixels != null)
        {
            pixels = loadPixels;
            System.Array.Copy(pixels, ernestinechampion[0], pixels.Length);

            tex.LoadRawTextureData(pixels);
            tex.Apply(false);
        }
        else
        {
            System.Array.Copy(pixels, ernestinechampion[0], pixels.Length);
        }

        
        if (francescazepeda)
        {
            lockMaskPixels = new byte[jamesrhodes * katelynhorton * 4];
        }
    }

    private void berylhunt()
    {
        Camera cam = Camera.main;
        
        Mesh go_Mesh = GetComponent<MeshFilter>().mesh;
        go_Mesh.Clear();
        go_Mesh.vertices = new[] {
                cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane + 0.1f)), 
				cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane + 0.1f)), 
				cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, cam.nearClipPlane + 0.1f)), 
				cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane + 0.1f)) 
			};
        go_Mesh.uv = new[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0) };
        go_Mesh.triangles = new[] { 0, 1, 2, 0, 2, 3 };

        go_Mesh.RecalculateNormals();

        go_Mesh.tangents = new[] { new Vector4(1.0f, 0.0f, 0.0f, -1.0f), new Vector4(1.0f, 0.0f, 0.0f, -1.0f), new Vector4(1.0f, 0.0f, 0.0f, -1.0f), new Vector4(1.0f, 0.0f, 0.0f, -1.0f) };

        
        gameObject.AddComponent<MeshCollider>();
    }

    private void bernadettebaird()
    {
        maskPixels = new byte[jamesrhodes * katelynhorton * 4];

        int gaylazimmerman = 0;
        for (int y = 0; y < katelynhorton; y++)
        {
            for (int x = 0; x < jamesrhodes; x++)
            {
                Color c = maskTex.GetPixel(x, y);
                maskPixels[gaylazimmerman] = (byte)(c.r * 255);
                maskPixels[gaylazimmerman + 1] = (byte)(c.g * 255);
                maskPixels[gaylazimmerman + 2] = (byte)(c.b * 255);
                maskPixels[gaylazimmerman + 3] = (byte)(c.a * 255);
                gaylazimmerman += 4;
            }
        }
    }

    private byte[] darcydeleon(string key)
    {
#if UNITY_WEBGL
        string friedaweir = Application.persistentDataPath + "/Landscape" + key + ".sav";
        if (File.Exists(friedaweir))
        {
            return System.Convert.FromBase64String(File.ReadAllText(friedaweir));
        }
        else
        {
            return null;
        }
#else
        if (PlayerPrefs.HasKey(key))
        {
            return System.Convert.FromBase64String(PlayerPrefs.GetString(key));
        }
        else
        {
            return null;
        }
#endif
    }

    private void arlinestrickland(string key)
    {
#if UNITY_WEBGL
        string friedaweir = Application.persistentDataPath + "/Landscape" + key + ".sav";
        string meghangreen = System.Convert.ToBase64String(pixels);
        File.WriteAllText(friedaweir, meghangreen);
#else
        PlayerPrefs.SetString(key, System.Convert.ToBase64String(pixels));
        PlayerPrefs.Save();
#endif
    }

    private void Start()
    {
#if UNITY_ANDROID
        if (timwinter.malindacobb())
        {
            buttonCamera.image.sprite = buttonCamera.nevabowen[0];
            buttonCamera.image.raycastTarget = false;
        }
#endif
        inesnorth((int)DrawMode.Pencil);

        OnDrawModeButtonClicked((int)DrawMode.Pencil);

        OnBrushButtonClicked(PanelColors[(int)drawMode].GetChild(0).GetComponent<vaughnhudson>());

        OnChangeBrushSizeButtonClicked();
        var g = PanelColors[(int)DrawMode.Sticker].GetChild(0);
        OnStickerButtonClicked(PanelColors[(int)DrawMode.Sticker].GetChild(0).GetComponent<vaughnhudson>());

        kaylaferrell();
    }

    private void inesnorth(int current)
    {
        float jackiemansfield = themes.spList[3].rectTransform.rect.height;

        foreach (RectTransform panel in PanelColors)
        {
            panel.offsetMax = new Vector2(0, -jackiemansfield * 2);
            panel.offsetMin = new Vector2(0, -jackiemansfield * 3);
        }

        monikaedmonds = PanelColors[current].localPosition;
        panelStartPos = monikaedmonds;
        panelStartPos.y += (jackiemansfield * 2);

        PanelColors[current].localPosition = panelStartPos;
    }

    private void kaylaferrell()
    {
        
        musicButtonController.image.sprite = musicButtonController.nevabowen[(int)AudioListener.volume];

        
        ChangeThemeIndex = PlayerPrefs.GetInt("Theme", 0);
    }

    private void LateUpdate()
    {
        emiliaadair();

        UpdateTexture();
    }

    private void emiliaadair()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider == null || !hit.collider.gameObject.name.Contains("PaintingBoard"))
                {
                    return;
                }
            }
            else
            {
                RaycastHit2D hit2 = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if (hit2.collider == null || !hit2.collider.gameObject.name.Contains("PaintingBoard"))
                {
                    return;
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (francescazepeda)
            {
                if (!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, 1)) return;
                karlameredith((int)(hit.textureCoord.x * jamesrhodes), (int)(hit.textureCoord.y * katelynhorton));
            }

            if (!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, 1)) { mallorygriffith = true; return; }

            pixelUVOld = pixelUV; 
            pixelUV = hit.textureCoord;
            pixelUV.x *= jamesrhodes;
            pixelUV.y *= katelynhorton;

            if (mallorygriffith) { pixelUVOld = pixelUV; mallorygriffith = false; }

            
            switch (drawMode)
            {
                case DrawMode.Sticker: 
                    jessicabanks((int)pixelUV.x, (int)pixelUV.y);
                    break;

                default: 
                    break;
            }

            avalozano = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, 1)) { mallorygriffith = true; return; }

            
            if (RedoIndex > 0)
            {
                ernestinechampion.RemoveRange(ernestinechampion.Count - RedoIndex, RedoIndex);
            }

            ernestinechampion.Add(new byte[jamesrhodes * katelynhorton * 4]);
            System.Array.Copy(pixels, ernestinechampion[ernestinechampion.Count - 1], pixels.Length);

            RedoIndex = 0;
        }

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            
            if (!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, 1)) { mallorygriffith = true; return; }

            pixelUVOld = pixelUV; 
            pixelUV = hit.textureCoord;
            pixelUV.x *= jamesrhodes;
            pixelUV.y *= katelynhorton;

            if (mallorygriffith) { pixelUVOld = pixelUV; mallorygriffith = false; }

            
            switch (drawMode)
            {
                case DrawMode.Pencil: 
                    rebeccasavage((int)pixelUV.x, (int)pixelUV.y);
                    break;

                case DrawMode.Marker: 
                    rocioorozco((int)pixelUV.x, (int)pixelUV.y);
                    break;

                
                
                

                case DrawMode.PaintBucket: 
                    if (maskTex)
                    {
                        cherimeyers((int)pixelUV.x, (int)pixelUV.y);
                    }
                    else
                    {
                        francisarthur((int)pixelUV.x, (int)pixelUV.y);
                    }
                    break;

                default: 
                    break;
            }

            avalozano = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            
            if (!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, 1)) return;

            pixelUVOld = pixelUV;
        }

        
        if (Vector2.Distance(pixelUV, pixelUVOld) > bobbiemcdaniel)
        {
            switch (drawMode)
            {
                case DrawMode.Pencil: 
                    revakeys(pixelUVOld, pixelUV);
                    break;

                case DrawMode.Marker: 
                    hattiefranco(pixelUVOld, pixelUV);
                    break;

                
                
                

                default: 
                    break;
            }
            pixelUVOld = pixelUV;
            avalozano = true;
        }
    }

    private void karlameredith(int x, int y)
    {
        if (maskTex)
        {
            lizziecahill(x, y);
        }
        else
        {
            kaylawalls(x, y);
        }
    }

    private void lizziecahill(int x, int y)
    {
        

        
        byte hitColorR = maskPixels[((jamesrhodes * (y) + x) * 4) + 0];
        byte hitColorG = maskPixels[((jamesrhodes * (y) + x) * 4) + 1];
        byte hitColorB = maskPixels[((jamesrhodes * (y) + x) * 4) + 2];
        byte hitColorA = maskPixels[((jamesrhodes * (y) + x) * 4) + 3];

        Queue<int> fillPointX = new Queue<int>();
        Queue<int> fillPointY = new Queue<int>();
        fillPointX.Enqueue(x);
        fillPointY.Enqueue(y);

        int ptsx, elizathacker;
        int gaylazimmerman = 0;

        lockMaskPixels = new byte[jamesrhodes * katelynhorton * 4];

        while (fillPointX.Count > 0)
        {

            ptsx = fillPointX.Dequeue();
            elizathacker = fillPointY.Dequeue();

            if (elizathacker - 1 > -1)
            {
                gaylazimmerman = (jamesrhodes * (elizathacker - 1) + ptsx) * 4; 

                if (lockMaskPixels[gaylazimmerman] == 0 
                    && (josefinaadair(maskPixels[gaylazimmerman + 0], hitColorR)) 
                    && (josefinaadair(maskPixels[gaylazimmerman + 1], hitColorG))
                    && (josefinaadair(maskPixels[gaylazimmerman + 2], hitColorB))
                    && (josefinaadair(maskPixels[gaylazimmerman + 3], hitColorA)))
                {
                    fillPointX.Enqueue(ptsx);
                    fillPointY.Enqueue(elizathacker - 1);
                    lockMaskPixels[gaylazimmerman] = 1;
                }
            }

            if (ptsx + 1 < jamesrhodes)
            {
                gaylazimmerman = (jamesrhodes * elizathacker + ptsx + 1) * 4; 
                if (lockMaskPixels[gaylazimmerman] == 0
                    && (josefinaadair(maskPixels[gaylazimmerman + 0], hitColorR)) 
                    && (josefinaadair(maskPixels[gaylazimmerman + 1], hitColorG))
                    && (josefinaadair(maskPixels[gaylazimmerman + 2], hitColorB))
                    && (josefinaadair(maskPixels[gaylazimmerman + 3], hitColorA)))
                {
                    fillPointX.Enqueue(ptsx + 1);
                    fillPointY.Enqueue(elizathacker);
                    lockMaskPixels[gaylazimmerman] = 1;
                }
            }

            if (ptsx - 1 > -1)
            {
                gaylazimmerman = (jamesrhodes * elizathacker + ptsx - 1) * 4; 
                if (lockMaskPixels[gaylazimmerman] == 0
                    && (josefinaadair(maskPixels[gaylazimmerman + 0], hitColorR)) 
                    && (josefinaadair(maskPixels[gaylazimmerman + 1], hitColorG))
                    && (josefinaadair(maskPixels[gaylazimmerman + 2], hitColorB))
                    && (josefinaadair(maskPixels[gaylazimmerman + 3], hitColorA)))
                {
                    fillPointX.Enqueue(ptsx - 1);
                    fillPointY.Enqueue(elizathacker);
                    lockMaskPixels[gaylazimmerman] = 1;
                }
            }

            if (elizathacker + 1 < katelynhorton)
            {
                gaylazimmerman = (jamesrhodes * (elizathacker + 1) + ptsx) * 4; 
                if (lockMaskPixels[gaylazimmerman] == 0
                    && (josefinaadair(maskPixels[gaylazimmerman + 0], hitColorR)) 
                    && (josefinaadair(maskPixels[gaylazimmerman + 1], hitColorG))
                    && (josefinaadair(maskPixels[gaylazimmerman + 2], hitColorB))
                    && (josefinaadair(maskPixels[gaylazimmerman + 3], hitColorA)))
                {
                    fillPointX.Enqueue(ptsx);
                    fillPointY.Enqueue(elizathacker + 1);
                    lockMaskPixels[gaylazimmerman] = 1;
                }
            }
        }
    }

    private void kaylawalls(int x, int y)
    {
        

        
        byte hitColorR = pixels[((jamesrhodes * (y) + x) * 4) + 0];
        byte hitColorG = pixels[((jamesrhodes * (y) + x) * 4) + 1];
        byte hitColorB = pixels[((jamesrhodes * (y) + x) * 4) + 2];
        byte hitColorA = pixels[((jamesrhodes * (y) + x) * 4) + 3];

        Queue<int> fillPointX = new Queue<int>();
        Queue<int> fillPointY = new Queue<int>();
        fillPointX.Enqueue(x);
        fillPointY.Enqueue(y);

        int ptsx, elizathacker;
        int gaylazimmerman = 0;

        lockMaskPixels = new byte[jamesrhodes * katelynhorton * 4];

        while (fillPointX.Count > 0)
        {

            ptsx = fillPointX.Dequeue();
            elizathacker = fillPointY.Dequeue();

            if (elizathacker - 1 > -1)
            {
                gaylazimmerman = (jamesrhodes * (elizathacker - 1) + ptsx) * 4; 

                if (lockMaskPixels[gaylazimmerman] == 0 
                    && (josefinaadair(pixels[gaylazimmerman + 0], hitColorR) || josefinaadair(pixels[gaylazimmerman + 0], paintColor.r)) 
                    && (josefinaadair(pixels[gaylazimmerman + 1], hitColorG) || josefinaadair(pixels[gaylazimmerman + 1], paintColor.g))
                    && (josefinaadair(pixels[gaylazimmerman + 2], hitColorB) || josefinaadair(pixels[gaylazimmerman + 2], paintColor.b))
                    && (josefinaadair(pixels[gaylazimmerman + 3], hitColorA) || josefinaadair(pixels[gaylazimmerman + 3], paintColor.a)))
                {
                    fillPointX.Enqueue(ptsx);
                    fillPointY.Enqueue(elizathacker - 1);
                    lockMaskPixels[gaylazimmerman] = 1;
                }
            }

            if (ptsx + 1 < jamesrhodes)
            {
                gaylazimmerman = (jamesrhodes * elizathacker + ptsx + 1) * 4; 
                if (lockMaskPixels[gaylazimmerman] == 0
                    && (josefinaadair(pixels[gaylazimmerman + 0], hitColorR) || josefinaadair(pixels[gaylazimmerman + 0], paintColor.r)) 
                    && (josefinaadair(pixels[gaylazimmerman + 1], hitColorG) || josefinaadair(pixels[gaylazimmerman + 1], paintColor.g))
                    && (josefinaadair(pixels[gaylazimmerman + 2], hitColorB) || josefinaadair(pixels[gaylazimmerman + 2], paintColor.b))
                    && (josefinaadair(pixels[gaylazimmerman + 3], hitColorA) || josefinaadair(pixels[gaylazimmerman + 3], paintColor.a)))
                {
                    fillPointX.Enqueue(ptsx + 1);
                    fillPointY.Enqueue(elizathacker);
                    lockMaskPixels[gaylazimmerman] = 1;
                }
            }

            if (ptsx - 1 > -1)
            {
                gaylazimmerman = (jamesrhodes * elizathacker + ptsx - 1) * 4; 
                if (lockMaskPixels[gaylazimmerman] == 0
                    && (josefinaadair(pixels[gaylazimmerman + 0], hitColorR) || josefinaadair(pixels[gaylazimmerman + 0], paintColor.r)) 
                    && (josefinaadair(pixels[gaylazimmerman + 1], hitColorG) || josefinaadair(pixels[gaylazimmerman + 1], paintColor.g))
                    && (josefinaadair(pixels[gaylazimmerman + 2], hitColorB) || josefinaadair(pixels[gaylazimmerman + 2], paintColor.b))
                    && (josefinaadair(pixels[gaylazimmerman + 3], hitColorA) || josefinaadair(pixels[gaylazimmerman + 3], paintColor.a)))
                {
                    fillPointX.Enqueue(ptsx - 1);
                    fillPointY.Enqueue(elizathacker);
                    lockMaskPixels[gaylazimmerman] = 1;
                }
            }

            if (elizathacker + 1 < katelynhorton)
            {
                gaylazimmerman = (jamesrhodes * (elizathacker + 1) + ptsx) * 4; 
                if (lockMaskPixels[gaylazimmerman] == 0
                    && (josefinaadair(pixels[gaylazimmerman + 0], hitColorR) || josefinaadair(pixels[gaylazimmerman + 0], paintColor.r)) 
                    && (josefinaadair(pixels[gaylazimmerman + 1], hitColorG) || josefinaadair(pixels[gaylazimmerman + 1], paintColor.g))
                    && (josefinaadair(pixels[gaylazimmerman + 2], hitColorB) || josefinaadair(pixels[gaylazimmerman + 2], paintColor.b))
                    && (josefinaadair(pixels[gaylazimmerman + 3], hitColorA) || josefinaadair(pixels[gaylazimmerman + 3], paintColor.a)))
                {
                    fillPointX.Enqueue(ptsx);
                    fillPointY.Enqueue(elizathacker + 1);
                    lockMaskPixels[gaylazimmerman] = 1;
                }
            }
        }
    }

    private void UpdateTexture()
    {
        if (avalozano)
        {
            avalozano = false;
            tex.LoadRawTextureData(pixels);
            tex.Apply(false);
        }
    }

    #endregion


    #region OnButtonsClicked

    public void OnDrawModeButtonClicked(int drawModeIndex)
    {
        foreach (kirkguevara button in drawModeButton)
        {
            button.image.sprite = button.nevabowen[1];
        }

        drawModeButton[drawModeIndex].image.sprite = drawModeButton[drawModeIndex].nevabowen[0];

        int raquelsmith = (int)drawMode;

        if (raquelsmith == drawModeIndex)
            return;

        inesnorth(raquelsmith);

        PanelColors[raquelsmith].GetComponent<vaughnhudson>().StartMyMoveAction(PanelColors[raquelsmith].localPosition, monikaedmonds, 0.5f);

        PanelColors[drawModeIndex].GetComponent<vaughnhudson>().StartMyMoveAction(PanelColors[drawModeIndex].localPosition, panelStartPos, 0.5f);

        drawMode = (DrawMode)drawModeIndex;
    }

    public void OnBrushButtonClicked(vaughnhudson sender)
    {
        paintColor = sender.GetComponent<Image>().color;
        brushSizeButton.image.color = paintColor; 

        switch (drawMode)
        {
            case DrawMode.Pencil:
            case DrawMode.Marker:
            case DrawMode.PaintBucket:

                int stefanieaguirre = sender.transform.GetSiblingIndex();

                for (int i = 0; i < PanelColors[(int)DrawMode.Pencil].childCount; i++)
                {
                    Vector2 min = PanelColors[(int)DrawMode.Pencil].GetChild(i).GetComponent<RectTransform>().anchorMin;
                    Vector2 max = PanelColors[(int)DrawMode.Pencil].GetChild(i).GetComponent<RectTransform>().anchorMax;

                    if (i == stefanieaguirre)
                    {
                        min.y = 0.34f;
                        max.y = 1f;
                    }
                    else
                    {
                        min.y = 0.22f;
                        max.y = 0.88f;
                    }

                    PanelColors[(int)DrawMode.Pencil].GetChild(i).GetComponent<RectTransform>().anchorMin = min;
                    PanelColors[(int)DrawMode.Pencil].GetChild(i).GetComponent<RectTransform>().anchorMax = max;

                    

                    min = PanelColors[(int)DrawMode.Marker].GetChild(i).GetComponent<RectTransform>().anchorMin;
                    max = PanelColors[(int)DrawMode.Marker].GetChild(i).GetComponent<RectTransform>().anchorMax;

                    if (i == stefanieaguirre)
                    {
                        min.y = 0.34f;
                        max.y = 1f;
                    }
                    else
                    {
                        min.y = 0.22f;
                        max.y = 0.88f;
                    }

                    PanelColors[(int)DrawMode.Marker].GetChild(i).GetComponent<RectTransform>().anchorMin = min;
                    PanelColors[(int)DrawMode.Marker].GetChild(i).GetComponent<RectTransform>().anchorMax = max;
                }

                for (int i = 0; i < PanelColors[(int)DrawMode.PaintBucket].childCount; i++)
                {
                    PanelColors[(int)DrawMode.PaintBucket].GetChild(i).GetChild(0).gameObject.SetActive(false);
                }

                PanelColors[(int)DrawMode.PaintBucket].GetChild(stefanieaguirre).GetChild(0).gameObject.SetActive(true);
                break;
        }
    }

    public void OnStickerButtonClicked(vaughnhudson sender)
    {
        marcydobbs = sender.transform.GetSiblingIndex();

        for (int i = 0; i < PanelColors[(int)DrawMode.Sticker].childCount; i++)
        {
            PanelColors[(int)DrawMode.Sticker].GetChild(i).GetChild(0).gameObject.SetActive(false);
        }

        PanelColors[(int)DrawMode.Sticker].GetChild(marcydobbs).GetChild(0).gameObject.SetActive(true);

        
        pattyhayden = stickers[marcydobbs].width;
        carmenruss = stickers[marcydobbs].height;
        stickerBytes = new byte[pattyhayden * carmenruss * 4];

        int gaylazimmerman = 0;
        for (int y = 0; y < carmenruss; y++)
        {
            for (int x = 0; x < pattyhayden; x++)
            {
                Color helgarubin = stickers[marcydobbs].GetPixel(x, y);
                stickerBytes[gaylazimmerman] = (byte)(helgarubin.r * 255);
                stickerBytes[gaylazimmerman + 1] = (byte)(helgarubin.g * 255);
                stickerBytes[gaylazimmerman + 2] = (byte)(helgarubin.b * 255);
                stickerBytes[gaylazimmerman + 3] = (byte)(helgarubin.a * 255);
                gaylazimmerman += 4;
            }
        }

        
        lynncheng = (int)(pattyhayden * 0.5f);
        brittneydillon = jamesrhodes - pattyhayden;
        inesfields = katelynhorton - carmenruss;
    }

    public void OnChangeBrushSizeButtonClicked()
    {
        bobbiemcdaniel += 8;

        if (bobbiemcdaniel > 24)
        {
            bobbiemcdaniel = 8;
        }

        brushSizeButton.image.sprite = brushSizeButton.nevabowen[(bobbiemcdaniel - 8) / 8];
    }

    public void OnUndoButtonClicked()
    {
        if (ernestinechampion.Count - RedoIndex - 1 > 0)
        {
            System.Array.Copy(ernestinechampion[ernestinechampion.Count - RedoIndex - 2], pixels, ernestinechampion[ernestinechampion.Count - RedoIndex - 2].Length);
            tex.LoadRawTextureData(ernestinechampion[ernestinechampion.Count - RedoIndex - 2]);
            tex.Apply(false);

            RedoIndex++;
        }
    }

    public void OnRedoButtonClicked()
    {
        if (ernestinechampion.Count > 0 && RedoIndex > 0)
        {
            System.Array.Copy(ernestinechampion[ernestinechampion.Count - RedoIndex], pixels, ernestinechampion[ernestinechampion.Count - RedoIndex].Length);
            tex.LoadRawTextureData(ernestinechampion[ernestinechampion.Count - RedoIndex]);
            tex.Apply(false);

            RedoIndex--;
        }
    }

    public void OnClearButtonClicked()
    {
        int gaylazimmerman = 0;
        for (int y = 0; y < katelynhorton; y++)
        {
            for (int x = 0; x < jamesrhodes; x++)
            {
                pixels[gaylazimmerman] = 255;
                pixels[gaylazimmerman + 1] = 255;
                pixels[gaylazimmerman + 2] = 255;
                pixels[gaylazimmerman + 3] = 255;
                gaylazimmerman += 4;
            }
        }
        tex.LoadRawTextureData(pixels);
        tex.Apply(false);

        if (ernestinechampion != null)
        {
            if (RedoIndex > 0)
            {
                ernestinechampion.RemoveRange(ernestinechampion.Count - RedoIndex, RedoIndex);
                RedoIndex = 0;
            }

            ernestinechampion.Add(new byte[jamesrhodes * katelynhorton * 4]);
            System.Array.Copy(pixels, ernestinechampion[ernestinechampion.Count - 1], pixels.Length);
        }
    }

    public void OnScreenshotButtonClicked()
    {
        StartCoroutine(OnSavePictureClickListener());
    }

    private IEnumerator OnSavePictureClickListener()
    {
#if UNITY_ANDROID
        if (timwinter.torifraser())
        {
#endif
        

        
        StartCoroutine(ScreenshotManager.SaveForPaint("MyPicture", "ColoringBook"));
        yield return new WaitForSeconds(1f);
        reneecantrell.SetActive(false);
#if UNITY_ANDROID
        }
        else
        {
            buttonCamera.image.sprite = buttonCamera.nevabowen[0];
            buttonCamera.image.raycastTarget = false;
        }
#endif

        yield return null;
    }

    public void OnMusicControllerButtonClicked()
    {
        hiramgates.USE.marthalandis();

        musicButtonController.image.sprite = musicButtonController.nevabowen[(int)AudioListener.volume];
    }

    public void OnChangeThemeButtonClicked()
    {
        ChangeThemeIndex++;
    }

    public void OnHomeButtonClicked()
    {
        sheldonhogan.Instance.ShowAdMob();

        arlinestrickland(deniceweiss);

        SceneManager.LoadScene("MainScene");
    }

    #endregion


    #region Painting Functions

    private void rebeccasavage(int x, int y)
    {
        int gaylazimmerman = 0;

        
        int katiebravo = bobbiemcdaniel * bobbiemcdaniel;
        int mindymorales = katiebravo << 2;
        int nanettepetty = bobbiemcdaniel << 1;
        for (int i = 0; i < mindymorales; i++)
        {
            int aimeesumner = (i % nanettepetty) - bobbiemcdaniel;
            int stacixiong = (i / nanettepetty) - bobbiemcdaniel;
            if (aimeesumner * aimeesumner + stacixiong * stacixiong < katiebravo)
            {
                if (x + aimeesumner < 0 || y + stacixiong < 0 || x + aimeesumner >= jamesrhodes || y + stacixiong >= katelynhorton) continue;

                gaylazimmerman = (jamesrhodes * (y + stacixiong) + x + aimeesumner) * 4;

                if (!francescazepeda || (francescazepeda && lockMaskPixels[gaylazimmerman] == 1))
                {
                    pixels[gaylazimmerman] = paintColor.r;
                    pixels[gaylazimmerman + 1] = paintColor.g;
                    pixels[gaylazimmerman + 2] = paintColor.b;
                    pixels[gaylazimmerman + 3] = paintColor.a;
                }

            }
        }
    }

    private void rocioorozco(int x, int y)
    {
        int gaylazimmerman = 0;

        
        int katiebravo = bobbiemcdaniel * bobbiemcdaniel;
        int mindymorales = katiebravo << 2;
        int nanettepetty = bobbiemcdaniel << 1;
        for (int i = 0; i < mindymorales; i++)
        {
            int aimeesumner = (i % nanettepetty) - bobbiemcdaniel;
            int stacixiong = (i / nanettepetty) - bobbiemcdaniel;
            if (aimeesumner * aimeesumner + stacixiong * stacixiong < katiebravo)
            {
                if (x + aimeesumner < 0 || y + stacixiong < 0 || x + aimeesumner >= jamesrhodes || y + stacixiong >= katelynhorton) continue;

                gaylazimmerman = (jamesrhodes * (y + stacixiong) + x + aimeesumner) * 4;

                
                if (!francescazepeda || (francescazepeda && lockMaskPixels[gaylazimmerman] == 1))
                {
                    pixels[gaylazimmerman] = (byte)Mathf.Lerp(pixels[gaylazimmerman], paintColor.r, paintColor.a / 255f * 0.1f);
                    pixels[gaylazimmerman + 1] = (byte)Mathf.Lerp(pixels[gaylazimmerman + 1], paintColor.g, paintColor.a / 255f * 0.1f);
                    pixels[gaylazimmerman + 2] = (byte)Mathf.Lerp(pixels[gaylazimmerman + 2], paintColor.b, paintColor.a / 255f * 0.1f);
                    pixels[gaylazimmerman + 3] = (byte)Mathf.Lerp(pixels[gaylazimmerman + 3], paintColor.a, paintColor.a / 255 * 0.1f);
                }

            }
        }
    }

    private void jessicabanks(int px, int py)
    {
        
        int lavernehayden = (int)(px - lynncheng);
        int madgegates = (int)(py - lynncheng);

        if (lavernehayden < 0)
        {
            lavernehayden = 0;
        }
        else {
            if (lavernehayden + pattyhayden >= jamesrhodes) lavernehayden = brittneydillon;
        }

        if (madgegates < 1)
        {
            madgegates = 1;
        }
        else {
            if (madgegates + carmenruss >= katelynhorton) madgegates = inesfields;
        }


        int gaylazimmerman = (jamesrhodes * madgegates + lavernehayden) * 4;
        int helgarubin = 0;

        for (int y = 0; y < carmenruss; y++)
        {
            for (int x = 0; x < pattyhayden; x++)
            {
                helgarubin = (pattyhayden * (y) + x) * 4;

                
                if (stickerBytes[helgarubin + 3] > 0)
                {
                    pixels[gaylazimmerman] = stickerBytes[helgarubin];
                    pixels[gaylazimmerman + 1] = stickerBytes[helgarubin + 1];
                    pixels[gaylazimmerman + 2] = stickerBytes[helgarubin + 2];
                    pixels[gaylazimmerman + 3] = stickerBytes[helgarubin + 3];
                }

                gaylazimmerman += 4;

            } 

            gaylazimmerman = (jamesrhodes * (madgegates == 0 ? 1 : madgegates + y) + lavernehayden + 1) * 4;
        } 
    }

    private void cherimeyers(int x, int y)
    {
        
        byte hitColorR = maskPixels[((jamesrhodes * (y) + x) * 4) + 0];
        byte hitColorG = maskPixels[((jamesrhodes * (y) + x) * 4) + 1];
        byte hitColorB = maskPixels[((jamesrhodes * (y) + x) * 4) + 2];
        byte hitColorA = maskPixels[((jamesrhodes * (y) + x) * 4) + 3];

        if (paintColor.r == hitColorR && paintColor.g == hitColorG && paintColor.b == hitColorB && paintColor.a == hitColorA) return;

        Queue<int> fillPointX = new Queue<int>();
        Queue<int> fillPointY = new Queue<int>();
        fillPointX.Enqueue(x);
        fillPointY.Enqueue(y);

        int ptsx, elizathacker;
        int gaylazimmerman = 0;

        lockMaskPixels = new byte[jamesrhodes * katelynhorton * 4];

        while (fillPointX.Count > 0)
        {
            ptsx = fillPointX.Dequeue();
            elizathacker = fillPointY.Dequeue();

            if (elizathacker - 1 > -1)
            {
                gaylazimmerman = (jamesrhodes * (elizathacker - 1) + ptsx) * 4; 
                if (lockMaskPixels[gaylazimmerman] == 0
                    && josefinaadair(maskPixels[gaylazimmerman + 0], hitColorR)
                    && josefinaadair(maskPixels[gaylazimmerman + 1], hitColorG)
                    && josefinaadair(maskPixels[gaylazimmerman + 2], hitColorB)
                    && josefinaadair(maskPixels[gaylazimmerman + 3], hitColorA))
                {
                    fillPointX.Enqueue(ptsx);
                    fillPointY.Enqueue(elizathacker - 1);
                    suzettepace(gaylazimmerman);
                    lockMaskPixels[gaylazimmerman] = 1;
                }
            }

            if (ptsx + 1 < jamesrhodes)
            {
                gaylazimmerman = (jamesrhodes * elizathacker + ptsx + 1) * 4; 
                if (lockMaskPixels[gaylazimmerman] == 0
                    && josefinaadair(maskPixels[gaylazimmerman + 0], hitColorR)
                    && josefinaadair(maskPixels[gaylazimmerman + 1], hitColorG)
                    && josefinaadair(maskPixels[gaylazimmerman + 2], hitColorB)
                    && josefinaadair(maskPixels[gaylazimmerman + 3], hitColorA))
                {
                    fillPointX.Enqueue(ptsx + 1);
                    fillPointY.Enqueue(elizathacker);
                    suzettepace(gaylazimmerman);
                    lockMaskPixels[gaylazimmerman] = 1;
                }
            }

            if (ptsx - 1 > -1)
            {
                gaylazimmerman = (jamesrhodes * elizathacker + ptsx - 1) * 4; 
                if (lockMaskPixels[gaylazimmerman] == 0
                    && josefinaadair(maskPixels[gaylazimmerman + 0], hitColorR)
                    && josefinaadair(maskPixels[gaylazimmerman + 1], hitColorG)
                    && josefinaadair(maskPixels[gaylazimmerman + 2], hitColorB)
                    && josefinaadair(maskPixels[gaylazimmerman + 3], hitColorA))
                {
                    fillPointX.Enqueue(ptsx - 1);
                    fillPointY.Enqueue(elizathacker);
                    suzettepace(gaylazimmerman);
                    lockMaskPixels[gaylazimmerman] = 1;
                }
            }

            if (elizathacker + 1 < katelynhorton)
            {
                gaylazimmerman = (jamesrhodes * (elizathacker + 1) + ptsx) * 4; 
                if (lockMaskPixels[gaylazimmerman] == 0
                    && josefinaadair(maskPixels[gaylazimmerman + 0], hitColorR)
                    && josefinaadair(maskPixels[gaylazimmerman + 1], hitColorG)
                    && josefinaadair(maskPixels[gaylazimmerman + 2], hitColorB)
                    && josefinaadair(maskPixels[gaylazimmerman + 3], hitColorA))
                {
                    fillPointX.Enqueue(ptsx);
                    fillPointY.Enqueue(elizathacker + 1);
                    suzettepace(gaylazimmerman);
                    lockMaskPixels[gaylazimmerman] = 1;
                }
            }
        }
    }

    private void francisarthur(int x, int y)
    {
        
        byte hitColorR = pixels[((jamesrhodes * (y) + x) * 4) + 0];
        byte hitColorG = pixels[((jamesrhodes * (y) + x) * 4) + 1];
        byte hitColorB = pixels[((jamesrhodes * (y) + x) * 4) + 2];
        byte hitColorA = pixels[((jamesrhodes * (y) + x) * 4) + 3];

        if (paintColor.r == hitColorR && paintColor.g == hitColorG && paintColor.b == hitColorB && paintColor.a == hitColorA) return;

        Queue<int> fillPointX = new Queue<int>();
        Queue<int> fillPointY = new Queue<int>();
        fillPointX.Enqueue(x);
        fillPointY.Enqueue(y);

        int ptsx, elizathacker;
        int gaylazimmerman = 0;

        lockMaskPixels = new byte[jamesrhodes * katelynhorton * 4];

        while (fillPointX.Count > 0)
        {

            ptsx = fillPointX.Dequeue();
            elizathacker = fillPointY.Dequeue();

            if (elizathacker - 1 > -1)
            {
                gaylazimmerman = (jamesrhodes * (elizathacker - 1) + ptsx) * 4; 
                if (lockMaskPixels[gaylazimmerman] == 0
                    && josefinaadair(pixels[gaylazimmerman + 0], hitColorR)
                    && josefinaadair(pixels[gaylazimmerman + 1], hitColorG)
                    && josefinaadair(pixels[gaylazimmerman + 2], hitColorB)
                    && josefinaadair(pixels[gaylazimmerman + 3], hitColorA))
                {
                    fillPointX.Enqueue(ptsx);
                    fillPointY.Enqueue(elizathacker - 1);
                    suzettepace(gaylazimmerman);
                    lockMaskPixels[gaylazimmerman] = 1;
                }
            }

            if (ptsx + 1 < jamesrhodes)
            {
                gaylazimmerman = (jamesrhodes * elizathacker + ptsx + 1) * 4; 
                if (lockMaskPixels[gaylazimmerman] == 0
                    && josefinaadair(pixels[gaylazimmerman + 0], hitColorR)
                    && josefinaadair(pixels[gaylazimmerman + 1], hitColorG)
                    && josefinaadair(pixels[gaylazimmerman + 2], hitColorB)
                    && josefinaadair(pixels[gaylazimmerman + 3], hitColorA))
                {
                    fillPointX.Enqueue(ptsx + 1);
                    fillPointY.Enqueue(elizathacker);
                    suzettepace(gaylazimmerman);
                    lockMaskPixels[gaylazimmerman] = 1;
                }
            }

            if (ptsx - 1 > -1)
            {
                gaylazimmerman = (jamesrhodes * elizathacker + ptsx - 1) * 4; 
                if (lockMaskPixels[gaylazimmerman] == 0
                    && josefinaadair(pixels[gaylazimmerman + 0], hitColorR)
                    && josefinaadair(pixels[gaylazimmerman + 1], hitColorG)
                    && josefinaadair(pixels[gaylazimmerman + 2], hitColorB)
                    && josefinaadair(pixels[gaylazimmerman + 3], hitColorA))
                {
                    fillPointX.Enqueue(ptsx - 1);
                    fillPointY.Enqueue(elizathacker);
                    suzettepace(gaylazimmerman);
                    lockMaskPixels[gaylazimmerman] = 1;
                }
            }

            if (elizathacker + 1 < katelynhorton)
            {
                gaylazimmerman = (jamesrhodes * (elizathacker + 1) + ptsx) * 4; 
                if (lockMaskPixels[gaylazimmerman] == 0
                    && josefinaadair(pixels[gaylazimmerman + 0], hitColorR)
                    && josefinaadair(pixels[gaylazimmerman + 1], hitColorG)
                    && josefinaadair(pixels[gaylazimmerman + 2], hitColorB)
                    && josefinaadair(pixels[gaylazimmerman + 3], hitColorA))
                {
                    fillPointX.Enqueue(ptsx);
                    fillPointY.Enqueue(elizathacker + 1);
                    suzettepace(gaylazimmerman);
                    lockMaskPixels[gaylazimmerman] = 1;
                }
            }
        }
    }

    private bool josefinaadair(byte a, byte b)
    {
        if (a < b)
        {
            a ^= b; b ^= a; a ^= b;
        }

        return (a - b) <= 128;
    }

    private void suzettepace(int gaylazimmerman)
    {
        pixels[gaylazimmerman] = paintColor.r;
        pixels[gaylazimmerman + 1] = paintColor.g;
        pixels[gaylazimmerman + 2] = paintColor.b;
        pixels[gaylazimmerman + 3] = paintColor.a;
    }

    private void revakeys(Vector2 start, Vector2 end)
    {
        int angelinaavalos = (int)start.x;
        int dorothycrump = (int)start.y;
        int winnielatham = (int)end.x;
        int tonilyons = (int)end.y;
        int frankiebenson = Mathf.Abs(winnielatham - angelinaavalos);
        int judiarredondo = Mathf.Abs(tonilyons - dorothycrump);
        int sx, renekeys;
        if (angelinaavalos < winnielatham) { sx = 1; } else { sx = -1; }
        if (dorothycrump < tonilyons) { renekeys = 1; } else { renekeys = -1; }
        int shelbyallison = frankiebenson - judiarredondo;
        bool julianagary = true;
        int alexandrakirk = (int)(bobbiemcdaniel >> 1);
        int imeldarasmussen = 0;
        int imeldamccain;
        while (julianagary)
        {
            imeldarasmussen++;
            if (imeldarasmussen > alexandrakirk)
            {
                imeldarasmussen = 0;
                rebeccasavage(angelinaavalos, dorothycrump);
            }
            if ((angelinaavalos == winnielatham) && (dorothycrump == tonilyons)) julianagary = false;
            imeldamccain = 2 * shelbyallison;
            if (imeldamccain > -judiarredondo)
            {
                shelbyallison = shelbyallison - judiarredondo;
                angelinaavalos = angelinaavalos + sx;
            }
            if (imeldamccain < frankiebenson)
            {
                shelbyallison = shelbyallison + frankiebenson;
                dorothycrump = dorothycrump + renekeys;
            }
        }
    }

    private void hattiefranco(Vector2 start, Vector2 end)
    {
        int angelinaavalos = (int)start.x;
        int dorothycrump = (int)start.y;
        int winnielatham = (int)end.x;
        int tonilyons = (int)end.y;
        int frankiebenson = Mathf.Abs(winnielatham - angelinaavalos);
        int judiarredondo = Mathf.Abs(tonilyons - dorothycrump);
        int sx, renekeys;
        if (angelinaavalos < winnielatham) { sx = 1; } else { sx = -1; }
        if (dorothycrump < tonilyons) { renekeys = 1; } else { renekeys = -1; }
        int shelbyallison = frankiebenson - judiarredondo;
        bool julianagary = true;
        int alexandrakirk = (int)(bobbiemcdaniel >> 1);
        int imeldarasmussen = 0;
        int imeldamccain;
        while (julianagary)
        {
            imeldarasmussen++;
            if (imeldarasmussen > alexandrakirk)
            {
                imeldarasmussen = 0;
                rocioorozco(angelinaavalos, dorothycrump);
            }
            if ((angelinaavalos == winnielatham) && (dorothycrump == tonilyons)) julianagary = false;
            imeldamccain = 2 * shelbyallison;
            if (imeldamccain > -judiarredondo)
            {
                shelbyallison = shelbyallison - judiarredondo;
                angelinaavalos = angelinaavalos + sx;
            }
            if (imeldamccain < frankiebenson)
            {
                shelbyallison = shelbyallison + frankiebenson;
                dorothycrump = dorothycrump + renekeys;
            }
        }
    }

    private void kristasmart(Vector2 start, Vector2 end)
    {
        int angelinaavalos = (int)start.x;
        int dorothycrump = (int)start.y;
        int winnielatham = (int)end.x;
        int tonilyons = (int)end.y;
        int frankiebenson = Mathf.Abs(winnielatham - angelinaavalos);
        int judiarredondo = Mathf.Abs(tonilyons - dorothycrump);
        int sx, renekeys;
        if (angelinaavalos < winnielatham) { sx = 1; } else { sx = -1; }
        if (dorothycrump < tonilyons) { renekeys = 1; } else { renekeys = -1; }
        int shelbyallison = frankiebenson - judiarredondo;
        bool julianagary = true;
        
        int alexandrakirk = (int)(bobbiemcdaniel >> 1); 
        int imeldarasmussen = 0;
        int imeldamccain;
        while (julianagary)
        {
            imeldarasmussen++;
            if (imeldarasmussen > alexandrakirk)
            {
                imeldarasmussen = 0;
                jessicabanks(angelinaavalos, dorothycrump);
            }
            if ((angelinaavalos == winnielatham) && (dorothycrump == tonilyons)) julianagary = false;
            imeldamccain = 2 * shelbyallison;
            if (imeldamccain > -judiarredondo)
            {
                shelbyallison = shelbyallison - judiarredondo;
                angelinaavalos = angelinaavalos + sx;
            }
            if (imeldamccain < frankiebenson)
            {
                shelbyallison = shelbyallison + frankiebenson;
                dorothycrump = dorothycrump + renekeys;
            }
        }
    }

    #endregion


    #region Public Method

    public void margueritereynolds()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void mildredcope()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void dollyackerman()
    {
        Application.Quit();
    }

    public void kristiebender()
    {
     }

    public void rachellowry()
    {
     }

    #endregion
}
