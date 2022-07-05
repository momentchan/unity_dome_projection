using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DomeSystem {
    public class DomeMaster : MonoBehaviour {
        [SerializeField] private Vector3Int resolution;
        [SerializeField] private DomeSimulator simulator;

        private Camera masterCamera;
        private RenderTexture masterTexture;

        void Start() {
            masterTexture = new RenderTexture(resolution.x, resolution.y, resolution.z, RenderTextureFormat.ARGB32) {
                antiAliasing = 1,
                wrapMode = TextureWrapMode.Clamp,
                filterMode = FilterMode.Bilinear
            };

            masterCamera = GetComponent<Camera>();
            masterCamera.targetTexture = masterTexture;

            simulator.SetMasterTexture(masterTexture);
        }

        // Update is called once per frame
        void Update() {

        }
    }
}