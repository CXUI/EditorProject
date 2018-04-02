using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TestEditorWindow : EditorWindow
{

    public GameObject obj;
    public List<GameObject> listObj = new List<GameObject>();

    private float slide = 1;
    private bool isbool = false;

    //序列化自身
    private SerializedObject _serializedObject;
    //序列化属性
    private SerializedProperty _serializedProperty;

    [MenuItem("ShowWindows/Win")]
    public static void ShowWindow()
    {
        //初始化自身
        TestEditorWindow window = GetWindow<TestEditorWindow>("显示窗口");
        window.Show();
    }

    public void OnEnable()
    {

        _serializedObject = new SerializedObject(this);

        _serializedProperty = _serializedObject.FindProperty("listObj");
    }


    //每帧大约更新100次
    public void OnGUI()
    {
        //开始水平绘制
        EditorGUILayout.BeginHorizontal();
        //与左边框的距离
        GUILayout.Space(100);
        //给obj赋值
        obj = (GameObject)EditorGUILayout.ObjectField("预制体", obj, typeof(GameObject), true);

        slide = EditorGUILayout.Slider("滑动框", slide, 0, 2);

        //结束绘制
        EditorGUILayout.EndHorizontal();


        //开始垂直绘制
        EditorGUILayout.BeginVertical();

        isbool = EditorGUILayout.Toggle("单选框", isbool);

        //更新
        _serializedObject.Update();

        //开始检查更新
        EditorGUI.BeginChangeCheck();

        //显示子属性
        EditorGUILayout.PropertyField(_serializedProperty, true);

        //判断检查是否结束
        if (EditorGUI.EndChangeCheck())
            //如果修改，则应用属性修改
            _serializedObject.ApplyModifiedProperties();

        //结束垂直绘制
        EditorGUILayout.EndVertical();
    }

	 
}
