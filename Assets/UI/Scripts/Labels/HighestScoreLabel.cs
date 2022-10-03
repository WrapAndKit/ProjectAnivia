using UnityEngine;

namespace Assets.UI.Scripts.Labels {
    internal sealed class HighestScoreLabel : LabelBehaviour {

        #region Data

        #endregion

        private void OnEnable() {
            SetText($"Highest score: {PlayerPrefs.GetInt("HighestScore", 0)}m");
        }
    }
}
