// ================================================================================================
// InputSystemEnums.cs
// Universal Framework Input System - Supporting Enums and Data Structures
// Shared enums and interfaces for the complete input system
// ================================================================================================

using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections;
using ThermalState = UniversalFramework.ThermalManagement.ThermalState;

namespace UniversalFramework.Input
{
    /// <summary>
    /// Input platform types supported by the Universal Framework
    /// Covers all major gaming platforms and accessibility modes
    /// </summary>
    public enum InputPlatform
    {
        Mobile,
        MobileAR,
        MobileTablet,
        Desktop,
        DesktopGamepad,
        Console,
        Switch,
        VR,
        Universal
    }
    
    /// <summary>
    /// Accessibility modes implementing "Power-Ups, Not Accommodations" philosophy
    /// Each mode provides gameplay advantages while addressing accessibility needs
    /// </summary>
    public enum AccessibilityMode
    {
        None,
        MotorAssist,
        CognitiveAssist,
        VisualAssist,
        HearingAssist,
        Universal
    }
    
    // ThermalState enum is defined in UniversalFramework.ThermalManagement
    // and imported via using alias at the top of this file
    
    /// <summary>
    /// Input quality levels based on thermal and performance conditions
    /// </summary>
    public enum InputQuality
    {
        Ultra,
        High,
        Medium,
        Low,
        Emergency
    }
    
    /// <summary>
    /// Feedback types for accessibility and user experience
    /// </summary>
    public enum FeedbackType
    {
        Success,
        Information,
        Warning,
        Error,
        PowerUp,
        Guidance,
        Achievement,
        Navigation
    }
    
    /// <summary>
    /// UI component types for universal scaling
    /// </summary>
    public enum UIComponentType
    {
        Button,
        Text,
        Image,
        Slider,
        Toggle,
        Dropdown,
        InputField,
        Panel,
        ScrollView,
        Custom
    }
    
    /// <summary>
    /// Platform types for cross-platform compatibility
    /// </summary>
    public enum PlatformType
    {
        Mobile,
        Tablet,
        Desktop,
        Console,
        VR,
        Web,
        Universal
    }
    
    /// <summary>
    /// Universal input event data structure
    /// Carries all input information across the framework
    /// </summary>
    [System.Serializable]
    public class UniversalInputEvent
    {
        public string actionName;
        public Vector2 value2D;
        public float value1D;
        public bool isPressed;
        public bool isHeld;
        public bool isReleased;
        public float holdDuration;
        public InputPlatform sourcePlatform;
        public float timestamp;
        public AccessibilityMode accessibilityMode;
        public ThermalState thermalState;
        public InputQuality inputQuality;
        public Dictionary<string, object> customData;
        
        public UniversalInputEvent()
        {
            customData = new Dictionary<string, object>();
            timestamp = Time.time;
            accessibilityMode = AccessibilityMode.None;
            thermalState = ThermalState.Cool;
            inputQuality = InputQuality.High;
        }
    }
    
    /// <summary>
    /// Universal input binding configuration
    /// Maps actions to platform-specific inputs
    /// </summary>
    [System.Serializable]
    public class UniversalInputBinding
    {
        public string actionName;
        public string description;
        public Dictionary<InputPlatform, string> platformBindings;
        public bool isAccessibilityEnabled = true;
        public float thermalWeight = 1.0f; // How much this action affects thermal load
        public AccessibilityMode[] supportedAccessibilityModes;
        public bool allowCustomization = true;
        
        public UniversalInputBinding()
        {
            platformBindings = new Dictionary<InputPlatform, string>();
            supportedAccessibilityModes = new AccessibilityMode[] { AccessibilityMode.Universal };
        }
    }
    
    /// <summary>
    /// Input buffer for timing assistance
    /// Helps with accessibility and input prediction
    /// </summary>
    [System.Serializable]
    public class InputBuffer
    {
        public UniversalInputEvent bufferedInput;
        public float bufferTime;
        public bool isActive;
        public float expirationTime;
        
        public InputBuffer(UniversalInputEvent inputEvent, float bufferDuration)
        {
            bufferedInput = inputEvent;
            bufferTime = bufferDuration;
            isActive = true;
            expirationTime = Time.time + bufferDuration;
        }
        
        public bool IsExpired()
        {
            return Time.time > expirationTime;
        }
    }
    
    /// <summary>
    /// Thermal input configuration
    /// Manages input reduction based on thermal state
    /// </summary>
    [System.Serializable]
    public class ThermalInputConfig
    {
        public ThermalState triggerState = ThermalState.Hot;
        public float inputReductionFactor = 0.5f;
        public int maxInputsPerFrame = 5;
        public float cooldownPeriod = 2.0f;
        public bool enableEmergencyMode = true;
    }
    
    /// <summary>
    /// Accessibility input configuration
    /// Defines power-ups and enhancements for each accessibility mode
    /// </summary>
    [System.Serializable]
    public class AccessibilityInputConfig
    {
        public AccessibilityMode mode;
        public float timingMultiplier = 1.0f;
        public float inputBufferTime = 0.0f;
        public bool enableInputPrediction = false;
        public bool enableAlternativeInputs = false;
        public string[] activePowerUps;
        public Dictionary<string, float> customSettings;
        
        public AccessibilityInputConfig()
        {
            customSettings = new Dictionary<string, float>();
            activePowerUps = new string[0];
        }
    }
    
    /// <summary>
    /// Platform-specific input configuration
    /// Handles platform detection and input mapping
    /// </summary>
    [System.Serializable]
    public class PlatformInputConfig
    {
        public InputPlatform platform;
        public string[] supportedInputs;
        public float inputSensitivity = 1.0f;
        public bool enableTouchInput = false;
        public bool enableGamepadInput = false;
        public bool enableKeyboardInput = false;
        public bool enableMouseInput = false;
        public Dictionary<string, string> inputMappings;
        
        public PlatformInputConfig()
        {
            inputMappings = new Dictionary<string, string>();
            supportedInputs = new string[0];
        }
    }
    
    /// <summary>
    /// UI scaling configuration for different platforms and accessibility needs
    /// </summary>
    [System.Serializable]
    public class UIScalingConfig
    {
        public PlatformType targetPlatform;
        public AccessibilityMode accessibilityMode;
        public float baseScale = 1.0f;
        public float minScale = 0.5f;
        public float maxScale = 3.0f;
        public bool enableDynamicScaling = true;
        public bool enableThermalAdjustment = true;
        public Vector2 referenceResolution = new Vector2(1920, 1080);
    }
    
    /// <summary>
    /// Cross-platform save data configuration
    /// Manages data synchronization across platforms
    /// </summary>
    [System.Serializable]
    public class CrossPlatformSaveConfig
    {
        public bool enableCloudSync = true;
        public bool enableLocalBackup = true;
        public string saveFileExtension = ".sav";
        public int maxBackupFiles = 5;
        public float autoSaveInterval = 60.0f;
        public string[] syncedDataTypes;
        
        public CrossPlatformSaveConfig()
        {
            syncedDataTypes = new string[] { "PlayerProgress", "Settings", "Achievements" };
        }
    }
    
    /// <summary>
    /// Interface for input processors
    /// Allows modular input processing pipeline
    /// </summary>
    public interface IInputProcessor
    {
        UniversalInputEvent ProcessInput(UniversalInputEvent inputEvent);
        bool CanProcess(UniversalInputEvent inputEvent);
        int ProcessingPriority { get; }
    }
    
    /// <summary>
    /// Interface for platform bridges
    /// Enables platform-specific functionality
    /// </summary>
    public interface IPlatformBridge
    {
        void Initialize();
        bool IsSupported(PlatformType platform);
        void SaveData(string key, object data);
        T LoadData<T>(string key);
        void ShowNativeDialog(string title, string message);
        void RequestPermission(string permission);
    }
    
    /// <summary>
    /// Interface for thermal monitoring
    /// Integrates with BCT Thermal Module
    /// </summary>
    public interface IThermalMonitor
    {
        ThermalState GetCurrentThermalState();
        float GetThermalLevel();
        bool IsThrottling();
        void RegisterThermalCallback(System.Action<ThermalState> callback);
    }
    
    /// <summary>
    /// Interface for accessibility enhancement
    /// Supports the "Power-Ups, Not Accommodations" philosophy
    /// </summary>
    public interface IAccessibilityEnhancer
    {
        void EnableEnhancement(AccessibilityMode mode);
        void DisableEnhancement(AccessibilityMode mode);
        string[] GetActivePowerUps(AccessibilityMode mode);
        void CustomizeEnhancement(AccessibilityMode mode, Dictionary<string, object> settings);
    }
    
    /// <summary>
    /// Static utility class for input system helpers
    /// </summary>
    public static class InputSystemUtilities
    {
        public static InputPlatform DetectCurrentPlatform()
        {
            #if UNITY_ANDROID || UNITY_IOS
                return Application.isMobilePlatform ? InputPlatform.Mobile : InputPlatform.MobileTablet;
            #elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_STANDALONE_LINUX
                return InputPlatform.Desktop;
            #elif UNITY_PS4 || UNITY_PS5 || UNITY_XBOXONE || UNITY_GAMECORE || UNITY_SWITCH
                return InputPlatform.Console;
            #elif UNITY_VR
                return InputPlatform.VR;
            #else
                return InputPlatform.Universal;
            #endif
        }
        
        public static AccessibilityMode[] GetSupportedAccessibilityModes()
        {
            return new AccessibilityMode[]
            {
                AccessibilityMode.MotorAssist,
                AccessibilityMode.CognitiveAssist,
                AccessibilityMode.VisualAssist,
                AccessibilityMode.HearingAssist,
                AccessibilityMode.Universal
            };
        }
        
        public static ThermalState ConvertBCTThermalLevel(float thermalLevel)
        {
            if (thermalLevel < 0.2f) return ThermalState.Optimal;
            if (thermalLevel < 0.4f) return ThermalState.Warm;
            if (thermalLevel < 0.7f) return ThermalState.Hot;
            return ThermalState.Critical;
        }
        
        public static InputQuality GetInputQualityForThermalState(ThermalState thermalState)
        {
            switch (thermalState)
            {
                case ThermalState.Optimal: return InputQuality.Ultra;
                case ThermalState.Warm: return InputQuality.High;
                case ThermalState.Hot: return InputQuality.Medium;
                case ThermalState.Critical: return InputQuality.Low;
                default: return InputQuality.High;
            }
        }
    }
}