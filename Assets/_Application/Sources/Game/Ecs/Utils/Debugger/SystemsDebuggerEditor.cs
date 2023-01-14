using UnityEditor;

namespace Sources.Game.Ecs.Utils.Debugger
{
    [CustomEditor(typeof(SystemsDebugger))]
    [CanEditMultipleObjects]
    public class SystemsDebuggerEditor : Editor 
    {
        SerializedProperty lookAtPoint;
    
        void OnEnable()
        {
            lookAtPoint = serializedObject.FindProperty("lookAtPoint");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(lookAtPoint);
            serializedObject.ApplyModifiedProperties();
        }
    }
}