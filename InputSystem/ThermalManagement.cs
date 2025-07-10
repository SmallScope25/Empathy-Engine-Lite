// ================================================================================================
// ThermalManagement.cs - Core thermal system definitions
// ================================================================================================

using UnityEngine;

namespace UniversalFramework.ThermalManagement
{
    /// <summary>
    /// Core thermal state enumeration
    /// </summary>
    public enum ThermalState
    {
        Cool,
        Normal,
        Optimal,
        Warm,
        Hot,
        Critical
    }
    
    /// <summary>
    /// Input-specific thermal state for input devices
    /// </summary>
    public enum InputThermalState
    {
        Cool,
        Normal, 
        Warm,
        Hot,
        Critical
    }
    
    /// <summary>
    /// Basic thermal manager interface
    /// </summary>
    public interface IThermalManager
    {
        ThermalState CurrentThermalState { get; }
        float CurrentTemperature { get; }
        void StartMonitoring();
        void StopMonitoring();
    }
    
    /// <summary>
    /// Universal thermal manager - coordinates BCT and Empathy Engine thermal systems
    /// </summary>
    public class ThermalManager : MonoBehaviour, IThermalManager
    {
        public ThermalState CurrentThermalState { get; private set; } = ThermalState.Normal;
        public float CurrentTemperature { get; private set; } = 25.0f;
        
        public void StartMonitoring()
        {
            // Start thermal monitoring
        }
        
        public void StopMonitoring()
        {
            // Stop thermal monitoring
        }
    }
}
