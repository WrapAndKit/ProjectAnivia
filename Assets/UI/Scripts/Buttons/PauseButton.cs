using UnityEngine;

namespace Assets.UI.Scripts.Buttons {
    internal sealed class PauseButton : ButtonBehaviour {

        #region Data

        #endregion
        public override void ButtonClicked() {
            Time.timeScale = 0f;
        }
    }
}
