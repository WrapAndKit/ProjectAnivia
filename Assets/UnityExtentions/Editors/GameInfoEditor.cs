#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace Assets.UnityExtentions.Editors {

    //[CustomEditor(typeof(GameInfo))]
    [CanEditMultipleObjects]
    public sealed class GameInfoEditor : Editor {

        #region Data

        private SerializedProperty p_cameraTarget;
        private SerializedProperty p_player;

        private string p_buttonName {
            get {
                return GameInfo.IsViewMode ? "Playing mode" : "View mode";
            }
        }

        #endregion

        private void OnEnable() {
            p_player = serializedObject.FindProperty("p_player");
            p_cameraTarget = serializedObject.FindProperty("p_cameraTarget");
        }

        public override void OnInspectorGUI() {
            serializedObject.Update();
            CreateHeaderGUI();
            if (GameInfo.IsViewMode)
                CreateAttentionGUI();
            else
                CreatePropertiesGUI();
            CreateSwitchModeGUI();
            serializedObject.ApplyModifiedProperties();
        }

        private void CreateHeaderGUI() {
            var style = new GUIStyle(GUI.skin.label) {
                alignment = TextAnchor.MiddleCenter,
                fontSize = 20,
                fontStyle = FontStyle.Bold,
                fixedHeight = 25f
            };
            GUILayout.Label("Game info: ", style);
            GUILayout.Space(10);
        }

        private void CreateAttentionGUI() {
            var style = new GUIStyle(GUI.skin.label) {
                alignment = TextAnchor.MiddleCenter,
                fontSize = 15,
                fontStyle = FontStyle.Bold,
                fixedHeight = 25f
            };
            GUILayout.Label("View mode", style);
            GUILayout.Space(10);
        }

        private void CreateSwitchModeGUI() {
            if (GUILayout.Button(p_buttonName)) {
                if (Application.isPlaying)
                    Debug.Log("You cann't switch mode while playing!");
                else
                    GameInfo.SwitchVPMode();
            }
        }

        private void CreatePropertiesGUI() {
            EditorGUILayout.PropertyField(p_player, new GUIContent("Player: "));
            EditorGUILayout.PropertyField(p_cameraTarget, new GUIContent("Camera target: "));
        }
    }
}

#endif