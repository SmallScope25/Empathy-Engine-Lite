using System;
using System.Collections.Generic;
using UnityEngine;

namespace StudioHeartAndSoul
{
    /// <summary>
    /// Core interface for all guidance engines in the Universal Framework
    /// COMPLETE IMPLEMENTATION - Contains ALL shared classes and interfaces
    /// Based on original project artifacts - no external dependencies
    /// </summary>
    public interface IGuidanceEngine
    {
        string Name { get; }
        bool IsEnabled { get; set; }
        GuidancePhilosophy Philosophy { get; set; }
        
        bool IsRelevant(CreativeDecision decision, ProjectContext context);
        GuidanceInsight ProvideInsight(CreativeDecision decision, ProjectContext context, CreatorPreferences preferences);
        void LearnFromChoice(CreativeDecision decision, CreatorResponse response, ProjectOutcome outcome);
        void AdoptPhilosophy(GuidancePhilosophy philosophy);
        void SetOverridePolicy(CreativeOverridePolicy policy);
        void EnableCrossDomainLearning(CrossDomainLearning synergy);
    }

    // ================================================================================================
    // ESSENTIAL CLASSES REQUIRED BY IGUIDANCEENGINE INTERFACE
    // ================================================================================================
    
    [Serializable]
    public class GuidanceInsight 
    { 
        public string engineName;
        public InsightType insightType;
        public float confidence;
        public string suggestion;
        public string reasoning;
        public string implementation;
        public float impact;
        public string primaryMessage;
        public string celebrationMessage;
        public string overrideMessage;
        public string supportMessage;
        public string communityMessage;
        public EmotionalPriority priority;
        public List<string> suggestions = new List<string>();
        public List<string> healingRecommendations = new List<string>();
        public List<string> traumaConsiderations = new List<string>();
        public List<string> foundFamilyOpportunities = new List<string>();
        public List<string> ValidationNotes = new List<string>();
        public bool RequiresCommunityValidation = false;
    }

    [Serializable]
    public class CreatorResponse 
    { 
        public string responseType;
        public float acceptanceLevel;
        public Dictionary<string, object> responseData = new Dictionary<string, object>();
    }

    [Serializable]
    public class ProjectOutcome 
    { 
        public string outcomeType;
        public float successLevel;
        public Dictionary<string, object> outcomeData = new Dictionary<string, object>();
    }

    [Serializable]
    public class CrossDomainLearning 
    { 
        public bool enableCrossPolination = true;
        public bool shareInsightsBetweenEngines = true;
        public bool findUnexpectedConnections = true;
        public bool amplifyCreativeSerendipity = true;
        public bool buildHolisticWisdom = true;

        public void IntegrateEmotionalLearning(CreativeDecision decision, CreatorResponse response, ProjectOutcome outcome) { }
        public void RegisterEmotionalPatterns(object engine) { }
        public void EnableEmotionalSynergy(bool culturalSynergy, bool narrativeSynergy, bool accessibilitySynergy, bool performanceSynergy) { }
    }
    
    public interface IPerformanceOptimizable
    {
        void OptimizeForThermalState(object thermalState);
        void AdjustComplexity(object complexityLevel);
    }
    
    /// <summary>
    /// Extended interface for guidance engines that provide ongoing monitoring
    /// </summary>
    public interface IMonitoringGuidanceEngine : IGuidanceEngine
    {
        void StartMonitoring();
        void StopMonitoring();
        bool IsMonitoring { get; }
        event Action<object> OnGuidanceOpportunityDetected;
    }
    
    /// <summary>
    /// Extended interface for guidance engines that learn and adapt
    /// </summary>
    public interface ILearningGuidanceEngine : IGuidanceEngine
    {
        void ProvideFeedback(object context, object outcome, float effectiveness);
        float LearningConfidence { get; }
        void ResetLearning();
    }
    
    // ================================================================================================
    // CORE ENUMS - SINGLE SOURCE OF TRUTH
    // ================================================================================================
    
    public enum GuidancePhilosophy
    {
        GentleInspiration,
        CollaborativeWisdom,
        CelebrateCreativity,
        EnableFreedom,
        NeverRestrict
    }
    
    public enum CreativeOverridePolicy
    {
        AlwaysEnabled,
        CelebrateOverrides,
        LearnFromOverrides,
        NoJustificationNeeded
    }
    
    public enum GuidanceIntensity
    {
        Silent,
        VeryGentle,
        Gentle,
        Balanced,
        Active,
        Collaborative,
        Adaptive,
        Intuitive,
        Moderate,
        Strong
    }
    
    public enum AudienceType
    {
        KidFriendly,
        Mature,
        Universal
    }

    public enum InsightType
    {
        EmotionalGuidance,
        CulturalGuidance,
        NarrativeGuidance,
        AccessibilityGuidance,
        PerformanceOptimization,
        MetaLearning,
        SerendipityGuidance,
        BiomeGuidance,
        IndustrialGuidance,
        SurrealGuidance,
        SerendipityDiscovery
    }
    
    public enum EngineOutputType
    {
        Guidance,
        Analysis,
        Recommendation,
        Warning,
        Insight,
        Suggestion
    }

    public enum LearningApproach
    {
        CollaborativeEvolution,
        CommunityWisdom,
        SerendipitousDiscovery,
        HolisticGrowth
    }

    public enum AccessibilityApproach2025
    {
        PowerUpInnovation,
        UniversalDesign,
        CommunityPartnered,
        InclusionFirst
    }

    public enum PerformanceApproach
    {
        CreativePreservation,
        ThermalAware,
        AdaptiveOptimization,
        InnovationThroughConstraints
    }

    public enum EmotionalPriority
    {
        Low,
        Medium,
        High,
        Critical
    }

    public enum EmotionalComplexityLevel
    {
        Essential,
        Simplified,
        Balanced,
        Full,
        Adaptive
    }

    public enum AccessibilityLevel
    {
        Basic,
        Standard,
        Enhanced,
        Full
    }

    public enum NarrativeComplexityLevel
    {
        Simple,
        Moderate,
        Complex,
        Adaptive
    }

    public enum CulturalComplexityLevel
    {
        Minimal,
        Essential,
        Moderate,
        Full,
        Adaptive
    }

    public enum EvolutionSpeed
    {
        Slow,
        Moderate,
        Fast,
        Continuous
    }

    public enum WisdomAccumulation
    {
        Linear,
        Logarithmic,
        Exponential
    }

    // ================================================================================================
    // CORE DATA STRUCTURES - SINGLE SOURCE OF TRUTH
    // ================================================================================================
    
    [Serializable]
    public class CreativeDecision 
    { 
        public string primaryAction;
        public string creator;
        public bool involvesTraumaSensitiveContent;
        public bool involvesFoundFamilyNarrative;
        public bool involvesRelationships;
        public bool requiresEmotionalConsideration;
        public bool involvesCharacterDevelopment;
        public bool involvesEmotionalContent;
        public bool involvesNarrativeElements;
        public bool involvesCulturalContent;
        public bool involvesAccessibilityFeatures;
        public float intellectualEngagement;
        public float emotionalResonance;
        public float sharedExperience;
        public float positivePotential;
        public Dictionary<string, object> decisionData = new Dictionary<string, object>();
    }

    [Serializable]
    public class ProjectContext 
    { 
        public string platform;
        public string genre;
        public string targetAudience;
        public bool requiresEmotionalConsideration;
        public bool requiresCulturalValidation;
        public bool requiresAccessibilityFeatures;
        public AudienceType audienceType = AudienceType.Universal;
        public Dictionary<string, object> contextData = new Dictionary<string, object>();
    }

    [Serializable]
    public class CreatorPreferences 
    { 
        public GuidanceIntensity preferredIntensity = GuidanceIntensity.Gentle;
        public float comfortLevel = 0.7f;
        public string experienceType = "balanced";
        public AudienceType audienceType = AudienceType.Universal;
        public Dictionary<string, object> customPreferences = new Dictionary<string, object>();
    }
    
    // Additional guidance classes needed by BiomeGuidanceEngine and IndustrialGuidanceEngine
    [Serializable]
    public class GuidanceContext
    {
        public CreativeDecision decision;
        public ProjectContext project;
        public CreatorPreferences preferences;
        public Dictionary<string, object> contextData = new Dictionary<string, object>();
    }
    
    [Serializable] 
    public class GuidanceResult
    {
        public bool success;
        public GuidanceInsight insight;
        public List<string> recommendations = new List<string>();
        public float confidence;
        public Dictionary<string, object> resultData = new Dictionary<string, object>();
    }
}