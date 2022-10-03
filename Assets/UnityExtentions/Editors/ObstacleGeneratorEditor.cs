#if UNITY_EDITOR

using Assets.Logic.Obstacle;
using UnityEditor;
using UnityEngine;

namespace Assets.UnityExtentions.Editors {

    [CustomEditor(typeof(ObstacleGenerator))]
    [CanEditMultipleObjects]
    public sealed class ObstacleGeneratorEditor : Editor {

        #region Data

        private SerializedProperty p_obstaclesInfo;

        private SerializedProperty p_obstaclePrefab;

        private SerializedProperty p_spawnOffset;

        private SerializedProperty P_INCREMENT_STEP;

        private SerializedProperty P_DISTANCE;

        private SerializedProperty P_MIN_GAP;

        private SerializedProperty P_MAX_GAP;

        private SerializedProperty P_MIN_HEIGHT;

        private SerializedProperty P_MAX_HEIGHT;

        private ObstacleGenerator p_generator;

        private int p_styleIndex;

        #endregion

        private void OnEnable() {
            p_generator = (ObstacleGenerator)target;
            p_obstaclesInfo = serializedObject.FindProperty("p_obstaclesInfo");
            p_obstaclePrefab = serializedObject.FindProperty("p_obstaclePrefab");
            p_spawnOffset = serializedObject.FindProperty("p_spawnOffset");
            P_INCREMENT_STEP = serializedObject.FindProperty("P_INCREMENT_STEP");
            P_DISTANCE = serializedObject.FindProperty("P_DISTANCE");
            P_MIN_GAP = serializedObject.FindProperty("P_MIN_GAP");
            P_MAX_GAP = serializedObject.FindProperty("P_MAX_GAP");
            P_MIN_HEIGHT = serializedObject.FindProperty("P_MIN_HEIGHT");
            P_MAX_HEIGHT = serializedObject.FindProperty("P_MAX_HEIGHT");
        }

        public override void OnInspectorGUI() {
            serializedObject.Update();
            CreateHeaderGUI();
            CreateObstacleInfoGUI();
            CreateObstacleLimitsGUI();
            serializedObject.ApplyModifiedProperties();
        }

        private void CreateHeaderGUI() {
            var style = new GUIStyle(GUI.skin.label) {
                alignment = TextAnchor.MiddleCenter,
                fontSize = 20,
                fontStyle = FontStyle.Bold,
                fixedHeight = 25f
            };
            EditorGUILayout.LabelField("Obstacle generator properties", style);
            EditorGUILayout.Space(10);
        }

        private void CreatePropertyLabel(string text) {
            var style = new GUIStyle(GUI.skin.label) {
                alignment = TextAnchor.MiddleCenter,
                fontSize = 16,
                fontStyle = FontStyle.Bold,
                fixedHeight = 21f
            };
            EditorGUILayout.LabelField(text, style);
            EditorGUILayout.Space(5);
        }

        private void CreateObstacleInfoGUI() {
            CreatePropertyLabel("Obstacle info");
            EditorGUILayout.PropertyField(p_obstaclesInfo, new GUIContent("Obstacle variability: "));
            EditorGUILayout.PropertyField(p_obstaclePrefab, new GUIContent("Obstacle prefab: "));
            p_styleIndex = EditorGUILayout.Popup("Current style: ", p_styleIndex, p_generator.ObstacleStyles);
            p_generator.SetStyle(p_generator.ObstacleStyles[p_styleIndex]);
        }

        private void CreateObstacleLimitsGUI() {
            CreatePropertyLabel("Obstacle limits");
            EditorGUILayout.IntSlider(p_spawnOffset, 5, 20, "Spawn offset: ");
            EditorGUILayout.Slider(P_INCREMENT_STEP, 0.01f, 1f, "Difficulty increment: ");
            EditorGUILayout.Slider(P_DISTANCE, 2f, 10f, "Spawn distance: ");
            EditorGUILayout.Slider(P_MIN_GAP, 1f, 5f, "Min gap: ");
            EditorGUILayout.Slider(P_MAX_GAP, 1f, 5f, "Max gap: ");
            EditorGUILayout.IntSlider(P_MIN_HEIGHT, -3, 3, "Min height: ");
            EditorGUILayout.IntSlider(P_MAX_HEIGHT, -3, 3, "Max height: ");
        }
    }
}

#endif