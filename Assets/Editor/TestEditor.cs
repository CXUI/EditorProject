using UnityEngine;
using UnityEditor;
 

[CustomEditor(typeof(ShowText))]
public class TestEditor:Editor
{
    public ShowText _text;
    

    public void OnEnable()
    {
        _text = target as ShowText;
    }



    public override void OnInspectorGUI()
    {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label(_text.value);
        EditorGUILayout.EndHorizontal();
    }

    public void OnSceneGUI()
    {
        Handles.Label(_text.transform.position, _text.value);
    }
  
  
}
