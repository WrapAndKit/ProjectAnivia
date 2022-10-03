using UnityEngine;

namespace Assets.Logic.Player {

    public sealed class CameraTargetBehaviour : MonoBehaviour {
        #region Data 

        private Transform p_player;

        [SerializeField]
        [Range(-5f, 5f)]
        private float p_offset;

        #endregion

        private void Awake() {
            p_player = GameInfo.Player.transform;
        }

        private void FixedUpdate() {
            if (GameInfo.IsPlaying) {
                transform.position = new Vector3(p_player.position.x + p_offset, transform.position.y, p_player.position.z);
            }
            if (GameInfo.IsViewMode) {
                transform.position += Vector3.right * p_player.gameObject.GetComponent<PlayerBehaviour>().MovementBehaviour.Speed * Time.fixedDeltaTime;
            }
        }
    }
}
