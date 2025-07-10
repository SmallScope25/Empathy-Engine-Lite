using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UniversalCharacterFramework
{
    /// <summary>
    /// Mixed-Initiative Cultural Authenticity Engine - Core Character DNA Processing
    /// Converts identity strings into structured data using reasoning-based cultural validation
    /// Supports swappable knowledge domains (Cultural, Historical, Scientific, Genre-specific)
    /// Integrates with existing AudioVisualSyncHub and thermal systems
    /// Foundation module for Universal Procedural Intelligence Framework
    /// </summary>
    [Serializable]
    public class CharacterDNA
    {
        [Header("Core Identity Components")]
        public string characterName;
        public string culturalIdentity;
        public string personalityArchetype;
        public string visualStyle;
        public string demographicProfile;
        public string emotionalDuality;
        
        [Header("Mixed-Initiative System Data")]
        public DataSetConstraints activeDataSet = DataSetConstraints.CulturalAuthenticity;
        public AuthenticityReasoning authenticityReasoning;
        public CommunityValidationStatus validationStatus;
        public MixedInitiativeState collaborationState;
        
        [Header("Generated Data")]
        public CharacterTraits traits;
        public AnimationData animationData;
        public AudioProfile audioProfile;
        public VisualMarkers visualMarkers;
        public BehavioralPatterns behaviorPatterns;
        
        [Header("Integration Compatibility")]
        public bool audioVisualSyncCompatible = true;
        public bool thermalSystemIntegration = true;
        public float culturalComplexityScore = 0.7f;
        
        // Constructor for DNA string processing with dataset constraints
        public CharacterDNA(string dnaString, DataSetConstraints dataSet = DataSetConstraints.CulturalAuthenticity)
        {
            activeDataSet = dataSet;
            ProcessDNAString(dnaString);
            InitiateMixedInitiativeValidation();
            GenerateCharacterData();
        }
        
        private void ProcessDNAString(string dnaString)
        {
            string[] components = dnaString.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
            
            if (components.Length >= 6)
            {
                characterName = components[0].Trim();
                culturalIdentity = components[1].Trim();
                personalityArchetype = components[2].Trim();
                visualStyle = components[3].Trim();
                demographicProfile = components[4].Trim();
                emotionalDuality = components[5].Trim();
            }
            else
            {
                Debug.LogWarning($"DNA string incomplete: {dnaString}. Using defaults for missing components.");
                FillDefaults();
            }
        }
        
        private void FillDefaults()
        {
            if (string.IsNullOrEmpty(characterName)) characterName = "Unknown_Character";
            if (string.IsNullOrEmpty(culturalIdentity)) culturalIdentity = "Generic_Cultural_Background";
            if (string.IsNullOrEmpty(personalityArchetype)) personalityArchetype = "Balanced_Neutral";
            if (string.IsNullOrEmpty(visualStyle)) visualStyle = "Contemporary_Casual";
            if (string.IsNullOrEmpty(demographicProfile)) demographicProfile = "Adult_Neutral";
            if (string.IsNullOrEmpty(emotionalDuality)) emotionalDuality = "Calm_Thoughtful";
        }
        
        private void InitiateMixedInitiativeValidation()
        {
            authenticityReasoning = new AuthenticityReasoning
            {
                culturalValidationRequired = RequiresCulturalValidation(),
                communityConsultationNeeded = RequiresCommunityConsultation(),
                historicalAccuracyChecks = RequiresHistoricalValidation(),
                sensitivityValidation = RequiresSensitivityValidation()
            };
            
            validationStatus = new CommunityValidationStatus
            {
                isValidated = false,
                pendingConsultation = authenticityReasoning.communityConsultationNeeded,
                validationTimestamp = DateTime.Now,
                consultationPartners = IdentifyConsultationPartners()
            };
            
            collaborationState = new MixedInitiativeState
            {
                humanInput = true,
                aiGeneration = true,
                communityValidation = authenticityReasoning.culturalValidationRequired,
                iterativeRefinement = true
            };
        }
        
        private void GenerateCharacterData()
        {
            traits = GenerateCharacterTraits();
            animationData = GenerateAnimationData();
            audioProfile = GenerateAudioProfile();
            visualMarkers = GenerateVisualMarkers();
            behaviorPatterns = GenerateBehavioralPatterns();
            
            // Calculate cultural complexity for thermal optimization
            culturalComplexityScore = CalculateCulturalComplexity();
        }
        
        private CharacterTraits GenerateCharacterTraits()
        {
            return new CharacterTraits
            {
                primaryPersonality = ExtractPrimaryPersonality(),
                culturalTraits = ExtractCulturalTraits(),
                emotionalRange = ParseEmotionalDuality(),
                socialBehaviors = GenerateSocialBehaviors(),
                conflictResolutionStyle = DetermineConflictStyle(),
                leadershipApproach = DetermineLeadershipStyle()
            };
        }
        
        private AnimationData GenerateAnimationData()
        {
            return new AnimationData
            {
                culturalGestures = ExtractCulturalGestures(),
                personalityAnimations = GeneratePersonalityAnimations(),
                emotionalExpressions = GenerateEmotionalExpressions(),
                walkingStyle = DetermineWalkingStyle(),
                idleAnimations = GenerateIdleAnimations(),
                culturalCelebrationMoves = ExtractCelebrationMoves()
            };
        }
        
        private AudioProfile GenerateAudioProfile()
        {
            return new AudioProfile(this);
        }
        
        private VisualMarkers GenerateVisualMarkers()
        {
            return new VisualMarkers
            {
                culturalClothing = ExtractCulturalClothing(),
                personalityColors = DeterminePersonalityColors(),
                culturalArtifacts = IdentifyCulturalArtifacts(),
                bodyLanguageStyle = DetermineBodyLanguage(),
                facialFeatures = GenerateFacialFeatures(),
                culturalTattoos = ExtractCulturalMarkings()
            };
        }
        
        private BehavioralPatterns GenerateBehavioralPatterns()
        {
            return new BehavioralPatterns
            {
                decisionMakingStyle = DetermineDecisionStyle(),
                stressResponses = GenerateStressResponses(),
                socialInteractionStyle = DetermineSocialStyle(),
                learningPreferences = DetermineLearningStyle(),
                conflictAvoidance = DetermineConflictAvoidance(),
                culturalRituals = ExtractCulturalRituals()
            };
        }
        
        // Cultural validation helper methods
        private bool RequiresCulturalValidation()
        {
            return !culturalIdentity.Equals("Generic_Cultural_Background", StringComparison.OrdinalIgnoreCase);
        }
        
        private bool RequiresCommunityConsultation()
        {
            // Check if represents marginalized or specific cultural communities
            string[] consultationRequired = { "Indigenous", "African", "Latino", "Asian", "Caribbean", "Middle_Eastern" };
            return consultationRequired.Any(culture => culturalIdentity.Contains(culture));
        }
        
        private bool RequiresHistoricalValidation()
        {
            return visualStyle.Contains("Historical") || visualStyle.Contains("Traditional");
        }
        
        private bool RequiresSensitivityValidation()
        {
            return RequiresCommunityConsultation() || RequiresHistoricalValidation();
        }
        

        
        private List<string> IdentifyConsultationPartners()
        {
            var partners = new List<string>();
            
            if (culturalIdentity.Contains("Peruvian"))
                partners.Add("Peruvian_Cultural_Consultants");
            if (culturalIdentity.Contains("Cuban"))
                partners.Add("Cuban_Cultural_Consultants");
            if (culturalIdentity.Contains("African"))
                partners.Add("African_Diaspora_Consultants");
                
            return partners;
        }
        
        // Data extraction helper methods
        private string ExtractPrimaryPersonality()
        {
            return personalityArchetype.Split('_')[0];
        }
        
        private List<string> ExtractCulturalTraits()
        {
            var traits = new List<string>();
            string[] cultures = culturalIdentity.Split('-');
            
            foreach (string culture in cultures)
            {
                traits.AddRange(GetCulturalTraits(culture.Trim()));
            }
            
            return traits;
        }
        
        private List<string> GetCulturalTraits(string culture)
        {
            var traitMap = new Dictionary<string, List<string>>
            {
                ["Peruvian"] = new List<string> { "Family_Oriented", "Resilient", "Hospitable", "Community_Focused" },
                ["Cuban"] = new List<string> { "Expressive", "Musical", "Passionate", "Adaptive" },
                ["Japanese"] = new List<string> { "Respectful", "Detail_Oriented", "Disciplined", "Group_Harmony" },
                ["Brazilian"] = new List<string> { "Warm", "Festive", "Optimistic", "Inclusive" }
            };
            
            return traitMap.ContainsKey(culture) ? traitMap[culture] : new List<string> { "Universal_Human_Traits" };
        }
        
        private EmotionalRange ParseEmotionalDuality()
        {
            string[] emotions = emotionalDuality.Split('_');
            return new EmotionalRange
            {
                primaryEmotion = emotions.Length > 0 ? emotions[0] : "Neutral",
                secondaryEmotion = emotions.Length > 1 ? emotions[1] : "Balanced",
                emotionalSpectrum = CalculateEmotionalSpectrum(emotions)
            };
        }
        
        private float CalculateEmotionalSpectrum(string[] emotions)
        {
            // Simple emotional complexity calculation
            return emotions.Length * 0.5f;
        }
        
        private float CalculateCulturalComplexity()
        {
            float complexity = 0.5f; // Base complexity
            
            // Add complexity for multiple cultural identities
            if (culturalIdentity.Contains("-"))
                complexity += 0.2f;
                
            // Add complexity for historical elements
            if (visualStyle.Contains("Historical") || visualStyle.Contains("Traditional"))
                complexity += 0.15f;
                
            // Add complexity for emotional duality
            if (emotionalDuality.Contains("_"))
                complexity += 0.1f;
                
            return Mathf.Clamp(complexity, 0f, 1f);
        }
        
        // Placeholder methods for detailed generation (to be implemented)
        private List<string> GenerateSocialBehaviors() => new List<string> { "Culturally_Appropriate_Social_Behavior" };
        private string DetermineConflictStyle() => "Context_Appropriate_Conflict_Resolution";
        private string DetermineLeadershipStyle() => "Cultural_Leadership_Style";
        private List<string> ExtractCulturalGestures() => new List<string> { "Cultural_Gesture_Set" };
        private List<string> GeneratePersonalityAnimations() => new List<string> { "Personality_Animation_Set" };
        private List<string> GenerateEmotionalExpressions() => new List<string> { "Emotional_Expression_Set" };
        private string DetermineWalkingStyle() => "Cultural_Walking_Style";
        private List<string> GenerateIdleAnimations() => new List<string> { "Cultural_Idle_Animations" };
        private List<string> ExtractCelebrationMoves() => new List<string> { "Cultural_Celebration_Dances" };
        private List<string> ExtractMusicInfluences() => new List<string> { "Cultural_Music_Influences" };
        private string DetermineTempoPreferences() => "Personality_Based_Tempo";
        private Dictionary<string, string> MapEmotionalMusic() => new Dictionary<string, string>();
        private VoiceProfile GenerateVoiceProfile() => new VoiceProfile();
        private List<string> IdentifyCulturalInstruments() => new List<string> { "Cultural_Instruments" };
        private string GenerateCombatMusic() => "Combat_Music_Style";
        private List<string> ExtractCulturalClothing() => new List<string> { "Cultural_Clothing_Style" };
        private List<string> DeterminePersonalityColors() => new List<string> { "Personality_Color_Palette" };
        private CulturalArtifacts IdentifyCulturalArtifacts() => new CulturalArtifacts
        {
            primaryCulture = culturalIdentity,
            jewelry = new List<string> { "Traditional_Jewelry" },
            textiles = new List<string> { "Cultural_Patterns" },
            colors = new List<string> { "Cultural_Colors" },
            symbolism = new List<string> { "Cultural_Symbols" },
            performance = new List<string> { "Traditional_Arts" },
            appropriationRisk = 0.3f,
            authenticityLevel = 0.8f,
            communityConsultationRequired = RequiresCommunityConsultation()
        };
        private string DetermineBodyLanguage() => "Cultural_Body_Language";
        private List<string> GenerateFacialFeatures() => new List<string> { "Cultural_Facial_Features" };
        private List<string> ExtractCulturalMarkings() => new List<string> { "Cultural_Markings" };
        private string DetermineDecisionStyle() => "Cultural_Decision_Making";
        private List<string> GenerateStressResponses() => new List<string> { "Cultural_Stress_Responses" };
        private string DetermineSocialStyle() => "Cultural_Social_Style";
        private string DetermineLearningStyle() => "Cultural_Learning_Style";
        private string DetermineConflictAvoidance() => "Cultural_Conflict_Avoidance";
        private List<string> ExtractCulturalRituals() => new List<string> { "Cultural_Rituals" };
        
        // Test method for Maya Reyes example
        public static CharacterDNA CreateMayaReyes()
        {
            return new CharacterDNA("Maya_Reyes -> Peruvian-Cuban -> Confident_Anxious -> Vintage_Military -> Adult_Female -> Protective_Leader");
        }
    }
    
    // Supporting data structures for CharacterDNA
    
    public enum DataSetConstraints
    {
        CulturalAuthenticity,
        HistoricalAccuracy,
        ScientificRealism,
        GenreSpecific,
        UniversalApproach
    }
    
    [Serializable]
    public class AuthenticityReasoning
    {
        public bool culturalValidationRequired;
        public bool communityConsultationNeeded;
        public bool historicalAccuracyChecks;
        public bool sensitivityValidation;
        public string reasoningChain;
        public List<string> validationSteps;
    }
    
    [Serializable]
    public class CommunityValidationStatus
    {
        public bool isValidated;
        public bool pendingConsultation;
        public DateTime validationTimestamp;
        public List<string> consultationPartners;
        public List<string> feedback;
        public float validationScore;
    }
    
    [Serializable]
    public class MixedInitiativeState
    {
        public bool humanInput;
        public bool aiGeneration;
        public bool communityValidation;
        public bool iterativeRefinement;
        public int iterationCount;
        public float collaborationBalance;
    }
    
    [Serializable]
    public class CharacterTraits
    {
        public string primaryPersonality;
        public List<string> culturalTraits;
        public EmotionalRange emotionalRange;
        public List<string> socialBehaviors;
        public string conflictResolutionStyle;
        public string leadershipApproach;
        
        // Audio Profile Properties
        public float confidence = 0.5f;
        public float creativity = 0.5f;
        public float energy = 0.5f;
        public float calm = 0.5f;
        public float anxiety = 0.5f;
        public float fierce = 0.5f;
    }
    
    [Serializable]
    public class EmotionalRange
    {
        public string primaryEmotion;
        public string secondaryEmotion;
        public float emotionalSpectrum;
        public List<string> emotionalTriggers;
        public List<string> calmingFactors;
    }
    
    [Serializable]
    public class AnimationData
    {
        public List<string> culturalGestures;
        public List<string> personalityAnimations;
        public List<string> emotionalExpressions;
        public string walkingStyle;
        public List<string> idleAnimations;
        public List<string> culturalCelebrationMoves;
        public float energyLevel = 0.5f;
    }
    
    // AudioProfile and VisualMarkers classes moved to dedicated files
    // to avoid namespace conflicts
    
    [Serializable]
    public class EmotionalDuality
    {
        public string primaryEmotion;
        public string secondaryEmotion;
        public float blendRatio = 0.5f;
        public float intensity = 0.7f;
        public List<string> emotionalTriggers = new List<string>();
        public List<string> calmingFactors = new List<string>();
        
        public EmotionalDuality()
        {
            primaryEmotion = "Neutral";
            secondaryEmotion = "Balanced";
        }
        
        public EmotionalDuality(string primary, string secondary, float blend = 0.5f)
        {
            primaryEmotion = primary;
            secondaryEmotion = secondary;
            blendRatio = blend;
        }
    }
    
    [Serializable]
    public class VoiceProfile
    {
        public string accent;
        public string tonality;
        public float pitch;
        public float cadence;
        public List<string> culturalExpressions;
    }
    
    [Serializable]
    public class BehavioralPatterns
    {
        public string decisionMakingStyle;
        public List<string> stressResponses;
        public string socialInteractionStyle;
        public string learningPreferences;
        public string conflictAvoidance;
        public List<string> culturalRituals;
    }
}