#if UNITY_EDITOR

using Assets.Logic.Other.Jump;
using UnityEditor;

namespace Assets.UnityExtentions {
    [CanEditMultipleObjects]
    [CustomEditor(typeof(JumpBehaviour), true)]
    public sealed class JumpEditor : Editor {

        #region Data

        #endregion

        private void OnEnable() {
        }

        public override void OnInspectorGUI() {
        }
    }
}

#endif