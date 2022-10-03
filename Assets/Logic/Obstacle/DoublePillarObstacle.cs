using System;
using UnityEngine;

namespace Assets.Logic.Obstacle {
    public sealed class DoublePillarObstacle : ObstacleBehaviour {

        #region Data

        private PillarBehaviour p_topColumn;

        private PillarBehaviour p_bottomColumn;

        #endregion

        private void Awake() {
            p_randomizer = new System.Random();
        }

        private void FixedUpdate() {
            if (Mathf.Abs(transform.position.x - GameInfo.CameraTarget.transform.position.x) > 10f)
                gameObject.SetActive(false);
        }

        public override void SetColumns(SObstacleInfo info) {
            SetTopColumn(info.topColumns);
            SetBottomColumn(info.bottomColumns);
        }

        private void SetTopColumn(GameObject[] array) {
            var topIndex = p_randomizer.Next(0, array.Length);
            if (p_topColumn?.gameObject != array[topIndex]) {
                if (p_topColumn != null) {
                    GameObject.Destroy(p_topColumn.gameObject);
                }
                var top = GameObject.Instantiate(array[topIndex], transform);
                p_topColumn = top.GetComponent<PillarBehaviour>();
            }
        }

        private void SetBottomColumn(GameObject[] array) {
            var bottomIndex = p_randomizer.Next(0, array.Length);
            if (p_bottomColumn?.gameObject != array[bottomIndex]) {
                if (p_bottomColumn != null) {
                    GameObject.Destroy(p_bottomColumn.gameObject);
                }
                var top = GameObject.Instantiate(array[bottomIndex], transform);
                p_bottomColumn = top.GetComponent<PillarBehaviour>();
            }
        }


        public override void SetGaps(params float[] gaps) {
            if (gaps.Length != 1)
                throw new ArgumentException($"{gameObject.name} contains only one gap");
            var posY = transform.position.y;
            var botPosY = 2f;//-p_bottomColumn.GetComponent<PolygonCollider2D>().ClosestPoint(transform.position).y;
            var topPosY = 2f;//-p_topColumn.GetComponent<PolygonCollider2D>().ClosestPoint(transform.position).y;
            p_bottomColumn.transform.position += Vector3.down * (botPosY + gaps[0] / 2f);
            p_topColumn.transform.position += Vector3.up * (topPosY + gaps[0] / 2f);
        }

        public override void SetHeights(params float[] heights) {
            if (heights.Length != 1)
                throw new ArgumentException($"{gameObject.name} contains only one gap");
            p_bottomColumn.transform.position += Vector3.up * heights[0];
            p_topColumn.transform.position += Vector3.up * heights[0];
        }


    }
}
