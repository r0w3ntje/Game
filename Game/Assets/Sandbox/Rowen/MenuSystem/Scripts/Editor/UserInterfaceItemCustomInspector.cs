using UnityEditor;
using UnityEngine;

namespace r0w3ntje.MenuSystem
{
    [CustomEditor(typeof(UserInterfaceItem))]
    public class UserInterfaceItemCustomInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            DrawLayout();
        }

        private void DrawLayout()
        {
            var userInterfaceItem = target as UserInterfaceItem;
            if (userInterfaceItem == null) return;

            EditorGUILayout.Space();

            userInterfaceItem.visibleInAllMenus = EditorGUILayout.Toggle("Visible In All Menus", userInterfaceItem.visibleInAllMenus);
            if (userInterfaceItem.visibleInAllMenus) return;

            EditorGUILayout.Space();

            userInterfaceItem.animationType = (AnimationType)EditorGUILayout.EnumPopup("Animation Type", userInterfaceItem.animationType);

            EditorGUILayout.Space();

            EditorGUILayout.BeginHorizontal();
            userInterfaceItem.transInDuration = EditorGUILayout.FloatField("Trans In Duration", userInterfaceItem.transInDuration);
            userInterfaceItem.transOutDuration = EditorGUILayout.FloatField("Trans Out Duration", userInterfaceItem.transOutDuration);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();

            EditorGUILayout.BeginHorizontal();
            userInterfaceItem.transInDelay = EditorGUILayout.FloatField("Trans In Delay", userInterfaceItem.transInDelay);
            userInterfaceItem.transOutDelay = EditorGUILayout.FloatField("Trans Out Delay", userInterfaceItem.transOutDelay);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();

            switch (userInterfaceItem.animationType)
            {
                case AnimationType.Color:
                    userInterfaceItem.transInColor = EditorGUILayout.ColorField("Trans In Color", userInterfaceItem.transInColor);
                    userInterfaceItem.transOutColor = EditorGUILayout.ColorField("Trans Out Color", userInterfaceItem.transOutColor);
                    break;

                case AnimationType.Position:
                    userInterfaceItem.transInPosition = EditorGUILayout.Vector3Field("Trans In Position", userInterfaceItem.transInPosition);
                    userInterfaceItem.transOutPosition = EditorGUILayout.Vector3Field("Trans Out Position", userInterfaceItem.transOutPosition);
                    break;

                case AnimationType.Scale:
                    userInterfaceItem.transInScale = EditorGUILayout.Vector3Field("Trans In Scale", userInterfaceItem.transInScale);
                    userInterfaceItem.transOutScale = EditorGUILayout.Vector3Field("Trans Out Scale", userInterfaceItem.transOutScale);
                    break;
            }
        }
    }
}