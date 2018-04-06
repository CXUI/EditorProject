using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SceneTag))]
public class SEditorS :Editor {


    public SceneTag scene;

   public void OnEnable()
    {
          scene = target as SceneTag;
    }

    public void OnDisable()
    {
        Debug.Log("111111111111111111111111111");
    }

    public override void OnInspectorGUI()
    {
        scene.shieldArea = EditorGUILayout.FloatField("半径：", scene.shieldArea);
    }

    void OnSceneGUI()
    {


       
        Handles.color = Color.red;
        Handles.Label(scene.transform.position + Vector3.up * 2,
                scene.transform.position.ToString() + "\nShieldArea: " +
                scene.shieldArea.ToString());

        Handles.color = Color.red;
        Handles.DrawWireArc(scene.transform.position,
                scene.transform.up,
                -scene.transform.right,
                360,
                scene.shieldArea);
        scene.shieldArea =
        Handles.ScaleValueHandle(scene.shieldArea,
                        scene.transform.position + scene.transform.forward * scene.shieldArea,
                        scene.transform.rotation,
                        1,
                        Handles.ConeCap,
                        1);

        //comment by kun 2014.2.18  
        // GUI相关的绘制需要在Handles的绘制之后，否则会被覆盖掉;  
        // 使用Handles.BeginGUI会导致无法旋转摄像机，原因不详;  
        GUILayout.BeginArea(new Rect(Screen.width - 100, Screen.height - 80, 90, 50));
        //Handles.BeginGUI(new Rect(Screen.width - 100, Screen.height - 80, 90, 50));  
        try
        {
            float a = float.Parse(GUILayout.TextField(scene.shieldArea.ToString()));
            scene.shieldArea = a;
        }
        catch (System.Exception ex)
        {

        }
        if (GUILayout.Button("Reset Area"))
            scene.shieldArea = 5;
        //Handles.EndGUI();  
        GUILayout.EndArea();
    }
}
