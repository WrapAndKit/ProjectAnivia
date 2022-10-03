using UnityEngine;

namespace Assets.UI.Scripts {
    internal sealed class ExitButton : ButtonBehaviour {

        #region Data

        #endregion

        public override void ButtonClicked() {
            Application.Quit();
        }
    }
}
