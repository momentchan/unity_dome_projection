using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DomeSystem {
    public class DomeSimulator : MonoBehaviour {
        [SerializeField] private MeshRenderer domeMesh;
        [SerializeField] private MeshRenderer floorMesh;

        public void SetMasterTexture(RenderTexture texture) {
            domeMesh.material.SetTexture("_MainTex", texture);
            floorMesh.material.SetTexture("_MainTex", texture);
        }

    }
}