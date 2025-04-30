﻿using System.Diagnostics.CodeAnalysis;
using MonoInjectionTemplate.Utilities;
using UnityEngine;

namespace MonoInjectionTemplate
{
    [SuppressMessage("ReSharper", "Unity.RedundantEventFunction")]
    partial class HackMain : MonoBehaviour
    {
        //private GuiHandler _guiHandler;

        private Mob[] _mobs = { };

        /* - Initializing Methods - */
        private void Awake()
        {
            // This function is called when the class is loaded by the game (prior to attachment)
 
        }

        public void OnEnable()
        {
            // This function is called when the script is enabled by the parent object
        }

        public void Start()
        {
            // This function is called once for each instance of this class,
            // when it starts execution (in this case, attached to an object)
            ConsoleBase.WriteLine("HackMain Start()");
            m_Log.Log("Start()");
            m_Log.Error("Example Error");
            m_Log.Info("Information!");
            EntityUpdate = EntityUpdateFunct(0);
            StartCoroutine(EntityUpdate);
            //_guiHandler = gameObject.AddComponent<GuiHandler>();
        }

        /* - Game Loop Methods - */
        public void Update()
        {
            // This function is called once per frame, it's frequency depends on the frame rate.
            // This is at the beginning of the game logic cycle.
            if (Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log("C key pressed");
                TeleportToLook();
            }
                
        }
        

        private void TeleportToLook()
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
            {
                Debug.Log($"Raycast hit: {hit.collider.name}");
                transform.position = hit.point;
            }
        }

        public void LateUpdate()
        {
            // This function is called once per frame, it's frequency depends on the frame rate.
            // This is at the end of the game logic cycle.

        }

        public void OnGUI()
        {
            // This function is called at the end of the frame, after all game logic.
            // It is called twice per frame: Once for rendering, and once for GUI Events

            GUI.Label(new Rect(10, 10, 300, 100), "Reggie");

            foreach (var mob in _mobs)
            {
                Basic_ESP(mob.transform, mob.name);
            }

        }

        /* - Physics Method - */
        public void FixedUpdate()
        {
            // This function is called at a fixed frequency (Typically 100hz) and is independent of the frame rate.
            // For physics operations.
        }

        /* - Closing Methods - */
        public void OnDisable()
        {
            // This function is called when the instance of the class is disabled by it's parent.
            // The component remains attached, but disabled (Component.ENABLED = false)
        }

        public void OnDestroy()
        {
            // This function is called when the instance of the class is destroyed by it's parent.
            // The component and all it's data are destroyed and must be created again.
        }

    }
}
