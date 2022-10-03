using UnityEngine;

namespace Assets.Logic.Other.Jump {
    public sealed class UncontrollableJump : JumpBehaviour {

        #region Data

        #endregion

        private void Start() {
            p_rigidbody2d = GetComponent<Rigidbody2D>();
        }

        private void Update() {
            if (!GameInfo.IsPlaying)
                return;
            if (p_rigidbody2d.velocity.y > p_maxSpeed)
                p_rigidbody2d.velocity = new Vector2(p_rigidbody2d.velocity.x, p_maxSpeed);
        }

        public override void Jump() {
            p_rigidbody2d.AddForce(Vector2.up * p_jumpForce, ForceMode2D.Force);
            GameInfo.AudioManager.PlaySFX("Flap");
        }
    }
}
