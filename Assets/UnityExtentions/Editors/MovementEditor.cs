#if UNITY_EDITOR

using Assets.Logic.Other.Movement;
using UnityEditor;

namespace Assets.UnityExtentions.Editors {
    [CanEditMultipleObjects]
    [CustomEditor(typeof(MovementBehaviour), true)]
    public sealed class MovementEditor : Editor {

        #region Data

        #endregion

        private void OnEnable() {
        }

        public override void OnInspectorGUI() {
        }
    }
}

#endif