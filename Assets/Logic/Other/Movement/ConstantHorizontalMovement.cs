using UnityEngine;

namespace Assets.Logic.Other.Movement {

    public sealed class ConstantHorizontalMovement : MovementBehaviour {

        #region Data

        #endregion

        private void Start() {
            p_rigidbody2d = GetComponent<Rigidbody2D>();
        }

        public override void Move() {
            p_rigidbody2d.velocity = Vector2.right * p_speed;
        }
    }
}
