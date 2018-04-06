using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;

[CustomEditor(typeof(ShowEditorT))]
public class EditorT : Editor
{

    public ShowEditorT editorT;

    public SavePath savePath;

    public void OnEnable()
    {
        editorT=target as ShowEditorT;

        savePath = target as SavePath;
      
    }


    public override void OnInspectorGUI()
    {
        EditorGUILayout.BeginVertical();

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


        EditorGUILayout.Space();
        EditorGUILayout.Space();
        GUILayout.Space(10);

        EditorGUILayout.LabelField("路径");
        editorT.path = EditorGUILayout.TextField(editorT.path);

        if (GUILayout.Button("Save"))
        {
            Save();
        }
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
            EditorGUILayout.HelpBox("过低！", MessageType.Error);
        }
        else if (values > num2)
        {
            GUI.color = Color.yellow;
            EditorGUILayout.HelpBox("过高！", MessageType.Info);
        }
        else
        {
            GUI.color = Color.green;
            EditorGUILayout.HelpBox("适中！", MessageType.Warning);
        }

        Rect rect = GUILayoutUtility.GetRect(50, 50);
        EditorGUI.ProgressBar(rect, values / 100, valueName);
        GUI.color = Color.white;
    }


    public void HelpBoxE(float number)
    {

    }

    /// <summary>
    /// 保存文本文件
    /// </summary>
    public void Save()
    {
         
            string path = EditorUtility.OpenFolderPanel("选择路径","11111","");

            if (path.Length!=0)
            {
                editorT.path = path;
 
                if (!File.Exists(editorT.path+"\\t"+"\\aw.txt"))
                {

                Directory.CreateDirectory(editorT.path + "\\t");
                    FileStream fs = new FileStream(editorT.path + "\\t" + "\\aw.txt", FileMode.Create, FileAccess.Write);

                    StreamWriter sw = new StreamWriter(fs);

                    sw.WriteLine("11111111");

                    sw.Flush();//清除缓存
                    sw.Close();//关闭读写

                }
                else
                {
                    StreamWriter sw = new StreamWriter(editorT.path + "\\t" + "\\aw.txt", true, Encoding.Default);

                    sw.WriteLine("222222222");
                    sw.Flush();//清除缓存
                    sw.Close();//关闭读写
                }

            }

            
        
    }

}
