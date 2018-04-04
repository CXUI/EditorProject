using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ShowEditorT))]
public class EditorT : Editor
{

    public ShowEditorT editorT;

    public void OnEnable()
    {
         editorT=target as ShowEditorT;
    }


    public override void OnInspectorGUI()
    {
        EditorGUILayout.BeginVertical();

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("编辑");
        EditorGUILayout.Space(); EditorGUILayout.Space();
        editorT.id = EditorGUILayout.IntField("ID:", editorT.id);
        EditorGUILayout.Space(); EditorGUILayout.Space();
        editorT.names = EditorGUILayout.TextField("Name:", editorT.names);
        EditorGUILayout.Space(); EditorGUILayout.Space();
        EditorGUILayout.LabelField("简介");
        editorT.introduce = EditorGUILayout.TextArea("简介:", GUILayout.MinHeight(100));


        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        editorT.height = EditorGUILayout.Slider("Height:", editorT.height, 0, 230);

        LineColor(editorT.height, "Height",150,200);
    

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        editorT.weight = EditorGUILayout.Slider("Weight:", editorT.weight, 0, 200);

        LineColor(editorT.weight, "Weight",100,180);
       


        EditorGUILayout.EndVertical();
    }

    /// <summary>
    /// 根据数值不同，显示出不同的颜色
    /// </summary>
    /// <param name="values"></param>
    /// <param name="valueName"></param>
    public void LineColor(float values,string valueName,int num1,int num2)
    {
        if (values < num1)
        {
            GUI.color = Color.red;
        }
        else if (values > num2)
        {
            GUI.color = Color.yellow;
        }
        else
        {
            GUI.color = Color.green;
        }

        Rect rect = GUILayoutUtility.GetRect(50, 50);
        EditorGUI.ProgressBar(rect, values / 100, valueName);
        GUI.color = Color.red;
    }

}
