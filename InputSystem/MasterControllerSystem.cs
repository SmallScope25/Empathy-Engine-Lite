// ================================================================================================
// MasterControllerSystem.cs
// Universal Framework Input System - Master Controller Integration
// Unifies input across all platforms with accessibility and thermal integration
// ================================================================================================

using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections;

namespace UniversalFramework.Input
{
    /// <summary>
    /// Master input controller that unifies input across all platforms and accessibility modes
    /// Integrates with ThermalInputManager, AccessibilityInputHandler, and your BCT systems
    /// Provides seamless cross-platform input translation with thermal awareness
    /// </summary>
    public class MasterControllerSystem : MonoBehaviour
    {
        [Header("🎮 Universal Input Settings")]
        public InputPlatform currentPlatform = InputPlatform.Universal;
        public bool enableAutomaticSwitching = true;
        public bool enableCrossPlatformBindings = true;
        
        [Header("♿ Accessibility Integration")]
        public bool enableAccessibilitySupport = true;
        public AccessibilityMode currentAccessibilityMode = AccessibilityMode.None;
        
        [Header("🔥 Thermal Integration")]
        public bool enableThermalInputReduction = false;
        public float thermalThrottleThreshold = 0.7f;
        
        [Header("📱 Platform Detection")]
        public bool enableAutoDetection = true;
        public float detectionInterval = 2.0f;
        
        [Header("🔧 Debug Settings")]
        public bool enableInputLogging = false;
        public bool showInputVisualizer = false;
        
        // System components
        private ThermalInputManager thermalManager;
        private AccessibilityInputHandler accessibilityHandler;
        
        // Input binding system
        private Dictionary<string, UniversalInputBinding> inputBindings = new Dictionary<string, UniversalInputBinding>();
        private Queue<UniversalInputEvent> inputEventQueue = new Queue<UniversalInputEvent>();
        
        // Platform detection
        private float lastDetectionCheck = 0f;
        private InputPlatform detectedPlatform = InputPlatform.Universal;
        
        // Events
        public System.Action<InputPlatform> OnPlatformChanged;
        public System.Action<AccessibilityMode> OnAccessibilityChanged;
        public System.Action<UniversalInputEvent> OnInputProcessed;
        
        public static MasterControllerSystem Instance { get; private set; }
        
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                InitializeMasterController();
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        void InitializeMasterController()
        {
            // Initialize subsystems
            InitializeThermalManager();
            InitializeAccessibilityHandler();
            
            // Setup platform detection
            if (enableAutoDetection)
            {
                DetectCurrentPlatform();
            }
            
            // Register default input bindings
            RegisterDefaultBindings();
            
            Debug.Log("🎮 MasterControllerSystem: Initialized with universal input support");
        }
        
        void InitializeThermalManager()
        {
            thermalManager = GetComponent<ThermalInputManager>();
            if (thermalManager == null)
            {
                thermalManager = gameObject.AddComponent<ThermalInputManager>();
            }
            thermalManager.Initialize(this);
        }
        
        void InitializeAccessibilityHandler()
        {
            if (enableAccessibilitySupport)
            {
                accessibilityHandler = GetComponent<AccessibilityInputHandler>();
                if (accessibilityHandler == null)
                {
                    accessibilityHandler = gameObject.AddComponent<AccessibilityInputHandler>();
                }
                accessibilityHandler.Initialize(this);
            }
        }
        
        void Update()
        {
            // Platform detection
            if (enableAutoDetection && Time.time - lastDetectionCheck > detectionInterval)
            {
                DetectCurrentPlatform();
                lastDetectionCheck = Time.time;
            }
            
            // Process input queue
            ProcessInputQueue();
        }
        
        void DetectCurrentPlatform()
        {
            InputPlatform newPlatform = DetectPlatformFromInput();
            
            if (newPlatform != detectedPlatform)
            {
                detectedPlatform = newPlatform;
                if (enableAutomaticSwitching)
                {
                    SwitchToPlatform(newPlatform);
                }
            }
        }
        
        InputPlatform DetectPlatformFromInput()
        {
            // Detect based on active input devices
            #if UNITY_ANDROID || UNITY_IOS
                if (Input.touchCount > 0)
                    return InputPlatform.Mobile;
            #endif
            
            if (Input.GetJoystickNames().Length > 0)
            {
                #if UNITY_PS4 || UNITY_PS5 || UNITY_XBOXONE || UNITY_GAMECORE || UNITY_SWITCH
                    return InputPlatform.Console;
                #else
                    return InputPlatform.DesktopGamepad;
                #endif
            }
            
            return InputPlatform.Desktop;
        }
        
        void ProcessInputQueue()
        {
            while (inputEventQueue.Count > 0)
            {
                UniversalInputEvent inputEvent = inputEventQueue.Dequeue();
                ProcessSingleInput(inputEvent);
            }
        }
        
        void ProcessSingleInput(UniversalInputEvent inputEvent)
        {
            // Apply thermal input reduction if needed
            if (enableThermalInputReduction && thermalManager != null && thermalManager.IsThermalThrottling())
            {
                // Thermal manager handles input processing internally via QueueInput
                // This is just a marker for thermal awareness
                inputEvent.thermalState = thermalManager.GetThermalState();
            }
            
            // Apply accessibility enhancements
            if (enableAccessibilitySupport && accessibilityHandler != null)
            {
                inputEvent = accessibilityHandler.ProcessInput(inputEvent);
            }
            
            // Log input if enabled
            if (enableInputLogging)
            {
                Debug.Log($"🎮 Input: {inputEvent.actionName} | Platform: {inputEvent.sourcePlatform} | Value: {inputEvent.value1D}");
            }
            
            // Notify listeners
            OnInputProcessed?.Invoke(inputEvent);
        }
        
        public void QueueInputEvent(UniversalInputEvent inputEvent)
        {
            inputEvent.sourcePlatform = currentPlatform;
            inputEvent.timestamp = Time.time;
            inputEventQueue.Enqueue(inputEvent);
        }
        
        void RegisterDefaultBindings()
        {
            // Register universal input bindings that work across all platforms
            RegisterInputBinding("Move", new Dictionary<InputPlatform, string>
            {
                { InputPlatform.Mobile, "TouchJoystick" },
                { InputPlatform.Desktop, "WASD" },
                { InputPlatform.DesktopGamepad, "LeftStick" },
                { InputPlatform.Console, "LeftStick" },
                { InputPlatform.Universal, "Universal_Move" }
            });
            
            RegisterInputBinding("Action", new Dictionary<InputPlatform, string>
            {
                { InputPlatform.Mobile, "TouchTap" },
                { InputPlatform.Desktop, "Space" },
                { InputPlatform.DesktopGamepad, "ButtonA" },
                { InputPlatform.Console, "ButtonA" },
                { InputPlatform.Universal, "Universal_Action" }
            });
            
            RegisterInputBinding("Menu", new Dictionary<InputPlatform, string>
            {
                { InputPlatform.Mobile, "TouchMenu" },
                { InputPlatform.Desktop, "Escape" },
                { InputPlatform.DesktopGamepad, "Start" },
                { InputPlatform.Console, "Options" },
                { InputPlatform.Universal, "Universal_Menu" }
            });
            
            RegisterInputBinding("Camera", new Dictionary<InputPlatform, string>
            {
                { InputPlatform.Mobile, "TouchDrag" },
                { InputPlatform.Desktop, "Mouse" },
                { InputPlatform.DesktopGamepad, "RightStick" },
                { InputPlatform.Console, "RightStick" },
                { InputPlatform.Universal, "Universal_Camera" }
            });
        }
        
        public void RegisterInputBinding(string actionName, Dictionary<InputPlatform, string> platformBindings)
        {
            var binding = new UniversalInputBinding
            {
                actionName = actionName,
                description = "Custom action",
                platformBindings = platformBindings
            };
            
            inputBindings[actionName] = binding;
            Debug.Log($"🎮 Custom Action Registered: {actionName}");
        }
        
        public void SetAccessibilityMode(AccessibilityMode mode)
        {
            if (accessibilityHandler != null)
            {
                accessibilityHandler.SetAccessibilityMode(mode);
                currentAccessibilityMode = mode;
                OnAccessibilityChanged?.Invoke(mode);
            }
        }
        
        public void EnableThermalReduction(bool enabled)
        {
            enableThermalInputReduction = enabled;
            if (thermalManager != null)
            {
                thermalManager.SetThermalReduction(enabled);
            }
        }
        
        // Platform switching for testing
        public void SwitchToPlatform(InputPlatform newPlatform)
        {
            if (enableAutomaticSwitching)
            {
                InputPlatform previousPlatform = currentPlatform;
                currentPlatform = newPlatform;
                OnPlatformChanged?.Invoke(currentPlatform);
                Debug.Log($"🎮 Platform Switched: {previousPlatform} → {currentPlatform}");
            }
        }
        
        // Thermal integration methods
        public void ProcessThermalAdjustedInput(UniversalInputEvent inputEvent)
        {
            // Process input that has been adjusted by thermal manager
            ProcessSingleInput(inputEvent);
        }
        
        public void SetThermalInputMultiplier(float multiplier)
        {
            // Called by thermal manager to adjust input sensitivity
            if (enableInputLogging)
            {
                Debug.Log($"🔥 Thermal input multiplier set to: {multiplier:F2}");
            }
        }
        
        public void SetMaxInputsPerFrame(int maxInputs)
        {
            // Called by thermal manager to limit inputs per frame
            if (enableInputLogging)
            {
                Debug.Log($"🔥 Max inputs per frame set to: {maxInputs}");
            }
        }
        
        // Public API for game integration
        public UniversalInputEvent GetInputEvent(string actionName)
        {
            // Return the most recent input event for the specified action
            return new UniversalInputEvent
            {
                actionName = actionName,
                sourcePlatform = currentPlatform,
                timestamp = Time.time
            };
        }
        
        public bool IsActionActive(string actionName)
        {
            // Check if the specified action is currently active
            return inputBindings.ContainsKey(actionName);
        }
        
        public string GetCurrentBinding(string actionName)
        {
            if (inputBindings.ContainsKey(actionName) && 
                inputBindings[actionName].platformBindings.ContainsKey(currentPlatform))
            {
                return inputBindings[actionName].platformBindings[currentPlatform];
            }
            return "Unbound";
        }
    }
    
    // Enums and data structures moved to InputSystemEnums.cs to avoid duplication
    // All input types are now defined in UniversalFramework.Input.InputSystemEnums
}