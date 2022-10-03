#if UNITY_EDITOR

using Assets.Logic.Other.Jump;
using Assets.Logic.Other.Movement;
using Assets.Logic.Player;
using Assets.UnityExtentions.Editors.Enums;
using System;
using UnityEditor;
using UnityEngine;

namespace Assets.UnityExtentions.Editors {

    [CustomEditor(typeof(PlayerBehaviour))]
    [CanEditMultipleObjects]
    public sealed class PlayerEditor : Editor {

        #region Data

        private MovementStyle p_movementStyle;

        private JumpStyle p_jumpStyle;

        private PlayerBehaviour p_player;

        private SerializedObject p_movement;

        private SerializedObject p_jump;

        private SerializedProperty p_scoreIncrement;

        #endregion

        private void OnEnable() {
            p_player = (PlayerBehaviour)target;
            if (p_player.MovementBehaviour is null)
                return;
            p_movement = new SerializedObject(p_player.MovementBehaviour);
            p_jump = new SerializedObject(p_player.JumpBehaviour);
            p_scoreIncrement = serializedObject.FindProperty("p_scoreIncrement");
        }

        public override void OnInspectorGUI() {
            serializedObject.Update();
            if (p_scoreIncrement is null)
                return;
            CreateHeaderGUI();
            EditorGUILayout.Slider(p_scoreIncrement, 0.01f, 1f, "Score increment: ");
            CreateMovementPropertyGUI();
            CreateJumpPropertyGUI();
            CheckStyles();
            serializedObject.ApplyModifiedProperties();
        }

        private void CreateMovementPropertyGUI() {
            CreatePropertyLabel("Movement properties");
            p_movementStyle = (MovementStyle)EditorGUILayout.EnumPopup("Movement: ", p_movementStyle);
            OnMovementInspectorGUI();
        }

        private void CreateJumpPropertyGUI() {
            CreatePropertyLabel("Jump properties");
            p_jumpStyle = (JumpStyle)EditorGUILayout.EnumPopup("Jump: ", p_jumpStyle);
            OnJumpInspectorGUI();
        }

        public void OnMovementInspectorGUI() {
            p_movement.Update();
            var p_speed = p_movement.FindProperty("p_speed");
            EditorGUILayout.Slider(p_speed, 1f, 10f, "Speed: ");
            p_movement.ApplyModifiedProperties();
        }

        public void OnJumpInspectorGUI() {
            p_jump.Update();
            var p_jumpForce = p_jump.FindProperty("p_jumpForce");
            var p_maxSpeed = p_jump.FindProperty("p_maxSpeed");
            EditorGUILayout.Slider(p_jumpForce, 750f, 1500f, "Jump force: ");
            EditorGUILayout.Slider(p_maxSpeed, 1f, 10f, "Max speed: ");
            p_jump.ApplyModifiedProperties();
        }

        private void CreateHeaderGUI() {
            var style = new GUIStyle(GUI.skin.label) {
                alignment = TextAnchor.MiddleCenter,
                fontSize = 20,
                fontStyle = FontStyle.Bold,
                fixedHeight = 25f
            };
            EditorGUILayout.LabelField("Player properties", style);
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

        private void CheckStyles() {
            CheckMovementStyle();
            CheckJumpStyle();
        }

        private void CheckMovementStyle() {
            if (p_movementStyle is MovementStyle.ConstantHorizontalMovement) {
                if (!(p_player.MovementBehaviour is ConstantHorizontalMovement)) {
                    GameObject.Destroy(p_player.MovementBehaviour);
                    p_player.gameObject.AddComponent<ConstantHorizontalMovement>();
                }
                else
                    return;
            }
            else {
                throw new ArgumentException("This movement style undefined!");
            }
        }
        private void CheckJumpStyle() {
            if (p_jumpStyle is JumpStyle.UncontrollableJump) {
                if (!(p_player.JumpBehaviour is UncontrollableJump)) {
                    GameObject.Destroy(p_player.JumpBehaviour);
                    p_player.gameObject.AddComponent<UncontrollableJump>();
                }
                else
                    return;
            }
            else {
                throw new ArgumentException("This jump style undefined!");
            }
        }
    }
}

#endif