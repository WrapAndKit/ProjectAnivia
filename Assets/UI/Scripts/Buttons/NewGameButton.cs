using Assets.Logic.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.UI.Scripts {
    internal sealed class NewGameButton : ButtonBehaviour {

        #region Data

        #endregion

        public override void ButtonClicked() {
            GameInfo.ClearScore();
            GameInfo.IsPlaying = true;
            GameInfo.Player?.GetComponent<PlayerBehaviour>().FallAsleep();
            Time.timeScale = 1f;
            SceneManager.LoadScene(1);
        }
    }
}
