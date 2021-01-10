using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class ControlManager : MonoBehaviour
    {

        Camera cam;

        #region Singleton
        static ControlManager mInstance;
        public static ControlManager Instance
        {
            get
            {
                if (mInstance == null) mInstance = new GameObject("ControlsManager").AddComponent<ControlManager>();
                return mInstance;
            }
        }
        #endregion

        #region MonoBehavior Methods Start, Awake, Update etc
        private void Awake()
        {
            cam = Camera.main;
            DontDestroyOnLoad(this.gameObject);
        }
        private void Update()
        {
            if (enablePhysicsInput) UpdateMouseHit();
        }
        #endregion

        #region Input Wrapper
        public Ray GetClickRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
        public bool IsMouse0Down()
        {
            return Input.GetMouseButtonDown(0);
        }
        #endregion

        #region Control Controls
        bool enablePhysicsInput = true;
        public void disablePhysicsInputs()
        {
            enablePhysicsInput = false;
        }
        #endregion // Control Which controls to enable and disable
        
        
        #region Mouse Methods
        public RaycastHit mouse0hit;
        void UpdateMouseHit()
        { 
            if (IsMouse0Down())
            {
                Ray ray = GetClickRay();
                if (Physics.Raycast(ray, out mouse0hit))
                {
                    // Write Code For Ray Hit; 
                }
            }
        }
        #endregion  //Advance Mouse Method
    }
}