using Assets.Logic.Player;
using UnityEngine;

namespace Assets.UI.Scripts {
    internal sealed class BackButton : ButtonBehaviour {

        #region Data

        #endregion

        private void OnEnable() {
            if (GameInfo.Player is null)
                return;
            if (!GameInfo.Player.GetComponent<PlayerBehaviour>().IsAlive) {
                gameObject.SetActive(false);
            }
            else {
                gameObject.SetActive(true);
            }

        }

        public override void ButtonClicked() {
            Time.timeScale = 1f;
        }
    }
}
