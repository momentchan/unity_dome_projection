using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DomeSystem {
    public class DomeCameraComposite : MonoBehaviour {
        [SerializeField] private Vector3Int resolution;
        [SerializeField] private List<DomeCamera> cameras;

        void Start() {
            cameras.ForEach(c => c.Setup(resolution.x, resolution.y, resolution.z));
        }

        private void OnDestroy() {
            cameras.ForEach(c => c.Release());
        }
    }

    public enum CameraDir { Top, Left, Right, Bottom }

    [System.Serializable]
    public class DomeCamera {
        public Camera camera;
        public CameraDir direction;
        public Material material;
        private RenderTexture renderTexture;

        public void Setup(int width, int height, int depth) {
            renderTexture = new RenderTexture(width, height, depth) {
                filterMode = FilterMode.Bilinear,
                antiAliasing = 1,
                hideFlags = HideFlags.HideAndDontSave,
                wrapMode = TextureWrapMode.Clamp,
                autoGenerateMips = false,
                anisoLevel = 0
            };
            material.mainTexture = renderTexture;
            camera.targetTexture = renderTexture;
        }

        public void Release() {
            if (renderTexture != null) {
                camera.targetTexture = null;
                renderTexture.Release();
                Object.Destroy(renderTexture);
            }
        } 
    }
}