using Assets.Logic.Pooling;
using System;
using UnityEngine;

namespace Assets.Logic.Obstacle {

    [Serializable]
    public struct SObstacleInfo {
        public string name;

        public GameObject[] topColumns;

        public GameObject[] bottomColumns;

        [HideInInspector]
        public ObjectPooling<ObstacleBehaviour> pool;

    }
}
