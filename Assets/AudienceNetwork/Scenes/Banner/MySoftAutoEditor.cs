using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class MySoftAutoEditor: MonoBehaviour
{


   
 
    [MenuItem("AssetDatabase/Mysoft Auto Editor")]
    static void renameclasses()
    {
 
AssetDatabase.RenameAsset("Assets/peppa pig desmondgregory.png", "peppa pig zacharyblock.png");


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}