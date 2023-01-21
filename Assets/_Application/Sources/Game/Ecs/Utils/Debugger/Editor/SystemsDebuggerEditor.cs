using System.Collections.Generic;
using Sources.Game.Ecs.Utils.Debugger;
using UnityEditor;

namespace _Application.Sources.Game.Ecs.Utils.Debugger.Editor
{
    [CustomEditor(typeof(SystemsDebugger))]
    [CanEditMultipleObjects]
    public class SystemsDebuggerEditor : UnityEditor.Editor 
    {
        public bool _showFixeds;
        public List<bool> _showFixedsInd = new();
        
        void OnEnable()
        {
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            SystemsDebugData systemsDebugData = SystemsDebugger.SystemsDebugData;
            List<SystemsGroupDebugData> fixedDatas = systemsDebugData.FixedDatas;


            SerializedProperty serializedProperty = serializedObject.FindProperty("lookAtPoint");

            _showFixeds = EditorGUILayout.BeginFoldoutHeaderGroup(_showFixeds, "Fixed Systems");
            if (_showFixeds)
            {
                while (_showFixedsInd.Count < fixedDatas.Count)
                {
                    _showFixedsInd.Add(false);
                }
                for (int i = 0; i < fixedDatas.Count; i++)
                {
                    // _showFixedsInd[i] = EditorGUILayout.BeginFoldoutHeaderGroup(_showFixedsInd[i], $"Iteration {i + 1}");
                    // if (_showFixedsInd[i])
                    // {
                        List<SystemDebugData> systemDebugDatas = fixedDatas[i].SystemsData;
                        for (int j = 0; j < systemDebugDatas.Count; j++)
                        {
                            SystemDebugData systemDebugData = systemDebugDatas[j];
                            EditorGUILayout.LabelField($"{systemDebugData.Ticks} {systemDebugData.Name}");
                        }
                    // }
                    // EditorGUILayout.EndFoldoutHeaderGroup();
                }
            }
            EditorGUILayout.EndFoldoutHeaderGroup();
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}