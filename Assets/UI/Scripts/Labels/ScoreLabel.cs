namespace Assets.UI.Scripts.Labels {
    internal sealed class ScoreLabel : LabelBehaviour {
        #region Data

        #endregion

        private void OnEnable() {
            SetText($"Score: {GameInfo.Score}m");
        }

        private void FixedUpdate() {
            SetText($"Score: {GameInfo.Score}m");
        }
    }
}
