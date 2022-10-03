using UnityEngine;

namespace Assets.Logic.Obstacle {
    public abstract class ObstacleBehaviour : MonoBehaviour {

        #region Data 

        private protected System.Random p_randomizer;

        #endregion

        public abstract void SetColumns(SObstacleInfo info);

        public abstract void SetGaps(params float[] gaps);

        public abstract void SetHeights(params float[] heights);
    }
}