using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.UI.Scripts {
    internal sealed class MainMenuButton : ButtonBehaviour {

        #region Data

        #endregion

        public override void ButtonClicked() {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }
    }
}
