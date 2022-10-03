using Assets.Logic.Other;
using UnityEngine;

namespace Assets.UI.Scripts.Toggles {
    internal sealed class ViewModeToggle : ToggleBehaviour {

        #region Data

        #endregion

        private protected override void ValueChanged(bool value) {
            var mode = (value) ? EGameMode.View : EGameMode.Playing;
            PlayerPrefs.SetInt("ViewMode", (int)mode);
            PlayerPrefs.Save();
            GameInfo.SetMode((EGameMode)PlayerPrefs.GetInt("ViewMode", 0));
        }
    }
}
