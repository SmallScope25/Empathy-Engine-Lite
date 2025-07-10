using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UniversalCharacterFramework
{
    /// <summary>
    /// Mixed-Initiative AudioProfile System - Character Musical DNA Processing
    /// Handles cultural music influences, beat-matching, and audio-visual synchronization
    /// Integrates with Ableton/Arturia/Acid pipeline and existing AudioVisualSyncHub
    /// Supports swappable knowledge domains with reasoning-based cultural music validation
    /// Foundation module for Universal Procedural Intelligence Framework
    /// </summary>
    [Serializable]
    public class AudioProfile
    {
        [Header("Core Audio Properties")]
        public List<string> culturalMusicInfluences;
        public string personalityBasedTempo;
        public Dictionary<string, string> emotionalMusicMapping;
        public VoiceProfile voiceCharacteristics;
        public List<string> culturalInstruments;
        public string combatMusic;
        
        [Header("Cultural Musical Identity")]
        public CulturalMusicData culturalMusic;
        public BeatMatchingProfile beatMatching;
        public EmotionalAudioSignature emotionalSignature;
        public AudioSyncParameters syncParameters;
        
        [Header("Mixed-Initiative Audio Intelligence")]
        public AudioAuthenticityReasoning audioReasoning;
        public CulturalMusicValidation musicValidation;
        public MixedInitiativeAudioState collaborationState;
        
        [Header("Runtime Audio State")]
        public float currentConfidenceLevel;
        public float currentEnergyState;
        public AudioMoodState currentMood;
        
        [Header("External Integration")]
        public bool abletonSyncEnabled = true;
        public bool audioVisualSyncHubCompatible = true;
        public float thermalAudioComplexity = 0.7f;
        
        [Header("Cross-Project Compatibility")]
        public HouseProudBallroomSync houseProudSync;
        public GTSFormationSync gtsSync;
        public WorkplaceBeatSync workplaceSync;
        public BCTAmbientSync bctSync;
        
        [Header("Performance Optimization")]
        public bool thermalOptimizationEnabled = true;
        public AudioPerformanceLevel performanceLevel = AudioPerformanceLevel.Adaptive;
        public float audioComplexityThreshold = 0.8f;
        
        public AudioProfile(CharacterDNA dna)
        {
            InitiateMixedInitiativeAudioValidation(dna);
            ProcessCulturalMusic(dna.culturalIdentity, dna.activeDataSet);
            ProcessBeatMatching(dna.traits, dna.animationData);
            ProcessEmotionalSignature(dna.emotionalDuality, dna.traits);
            ProcessSyncParameters(dna);
            ConfigureCrossProjectCompatibility(dna);
            
            // Initialize runtime state
            currentConfidenceLevel = dna.traits.confidence;
            currentEnergyState = dna.animationData.energyLevel;
            currentMood = AudioMoodState.Neutral;
        }
        
        private void InitiateMixedInitiativeAudioValidation(CharacterDNA dna)
        {
            audioReasoning = new AudioAuthenticityReasoning();
            audioReasoning.characterIdentity = dna.culturalIdentity;
            audioReasoning.validationRequired = true;
            
            musicValidation = new CulturalMusicValidation();
            collaborationState = new MixedInitiativeAudioState();
            
            audioReasoning.reasoningSteps.Add("Initiating cultural music validation for: " + dna.culturalIdentity);
        }
        
        private void ProcessCulturalMusic(string culturalIdentity, string activeDataSet)
        {
            culturalMusic = new CulturalMusicData();
            culturalMusic.primaryCulture = culturalIdentity;
            
            audioReasoning.reasoningSteps.Add("Processing cultural music data for: " + culturalIdentity);
            
            // Process based on active data set type
            switch (activeDataSet.ToLower())
            {
                case "cultural":
                    ProcessCulturalSpecificMusic(culturalIdentity);
                    break;
                case "historical":
                    ProcessHistoricalMusic(culturalIdentity);
                    break;
                case "genre":
                    ProcessGenreMusic(culturalIdentity);
                    break;
                case "scientific":
                    ProcessScientificMusic(culturalIdentity);
                    break;
                case "universal":
                    ProcessUniversalMusic(culturalIdentity);
                    break;
                default:
                    ProcessCulturalSpecificMusic(culturalIdentity);
                    break;
            }
            
            ValidateMusicCulturalAuthenticity(culturalIdentity);
        }
        
        private void ProcessCulturalSpecificMusic(string culturalIdentity)
        {
            audioReasoning.reasoningSteps.Add("Applying culture-specific music framework");
            
            // Split complex cultural identities
            var cultures = culturalIdentity.Split('-');
            
            foreach (var culture in cultures)
            {
                switch (culture.ToLower())
                {
                    case "peruvian":
                        culturalMusic.AddCulturalPattern("Huayno", "Peruvian traditional mountain music");
                        culturalMusic.rhythmPatterns.Add("Huayno_2_4");
                        culturalMusic.instrumentalPreferences.Add("Charango");
                        culturalMusic.instrumentalPreferences.Add("Quena");
                        culturalMusic.keySignatures.Add("A_Minor");
                        culturalMusic.tempoRange = new Vector2(100f, 140f);
                        break;
                        
                    case "cuban":
                        culturalMusic.AddCulturalPattern("Son_Montuno", "Cuban traditional rhythm");
                        culturalMusic.rhythmPatterns.Add("Son_Clave_3_2");
                        culturalMusic.rhythmPatterns.Add("Son_Clave_2_3");
                        culturalMusic.instrumentalPreferences.Add("Tres");
                        culturalMusic.instrumentalPreferences.Add("Bongo");
                        culturalMusic.instrumentalPreferences.Add("Clave");
                        culturalMusic.keySignatures.Add("G_Major");
                        culturalMusic.keySignatures.Add("C_Major");
                        culturalMusic.tempoRange = new Vector2(100f, 160f);
                        break;
                        
                    case "african_american":
                        culturalMusic.AddCulturalPattern("Vogue_Beat", "Ballroom and house music tradition");
                        culturalMusic.rhythmPatterns.Add("Four_On_Floor");
                        culturalMusic.rhythmPatterns.Add("Vogue_Beat_Pattern");
                        culturalMusic.instrumentalPreferences.Add("Synthesizer");
                        culturalMusic.instrumentalPreferences.Add("Drum_Machine");
                        culturalMusic.keySignatures.Add("C_Minor");
                        culturalMusic.keySignatures.Add("F_Minor");
                        culturalMusic.tempoRange = new Vector2(120f, 135f);
                        culturalMusic.culturalMusicNotes.Add("Ballroom and house music - community consultation required");
                        break;
                        
                    case "japanese":
                        culturalMusic.AddCulturalPattern("Gagaku", "Traditional court music");
                        culturalMusic.AddCulturalPattern("Taiko", "Traditional percussion");
                        culturalMusic.rhythmPatterns.Add("Jo_Ha_Kyu");
                        culturalMusic.instrumentalPreferences.Add("Koto");
                        culturalMusic.instrumentalPreferences.Add("Shakuhachi");
                        culturalMusic.instrumentalPreferences.Add("Taiko");
                        culturalMusic.keySignatures.Add("Pentatonic_A");
                        culturalMusic.tempoRange = new Vector2(60f, 120f);
                        break;
                        
                    case "mexican":
                        culturalMusic.AddCulturalPattern("Mariachi", "Traditional ensemble music");
                        culturalMusic.AddCulturalPattern("Ranchera", "Folk song tradition");
                        culturalMusic.rhythmPatterns.Add("Ranchera_3_4");
                        culturalMusic.rhythmPatterns.Add("Mariachi_Pattern");
                        culturalMusic.instrumentalPreferences.Add("Guitarron");
                        culturalMusic.instrumentalPreferences.Add("Vihuela");
                        culturalMusic.instrumentalPreferences.Add("Trumpet");
                        culturalMusic.keySignatures.Add("G_Major");
                        culturalMusic.keySignatures.Add("D_Major");
                        culturalMusic.tempoRange = new Vector2(90f, 150f);
                        break;
                        
                    case "irish":
                        culturalMusic.AddCulturalPattern("Celtic_Traditional", "Irish folk music");
                        culturalMusic.rhythmPatterns.Add("Irish_Jig_6_8");
                        culturalMusic.rhythmPatterns.Add("Irish_Reel_4_4");
                        culturalMusic.instrumentalPreferences.Add("Fiddle");
                        culturalMusic.instrumentalPreferences.Add("Bodhrán");
                        culturalMusic.instrumentalPreferences.Add("Tin_Whistle");
                        culturalMusic.keySignatures.Add("D_Major");
                        culturalMusic.keySignatures.Add("G_Major");
                        culturalMusic.tempoRange = new Vector2(100f, 140f);
                        break;
                        
                    case "indian":
                        culturalMusic.AddCulturalPattern("Raga_Based", "Classical Indian music");
                        culturalMusic.rhythmPatterns.Add("Tabla_Pattern");
                        culturalMusic.instrumentalPreferences.Add("Sitar");
                        culturalMusic.instrumentalPreferences.Add("Tabla");
                        culturalMusic.instrumentalPreferences.Add("Harmonium");
                        culturalMusic.keySignatures.Add("Raga_Yaman");
                        culturalMusic.keySignatures.Add("Raga_Bhairav");
                        culturalMusic.tempoRange = new Vector2(60f, 180f);
                        break;
                        
                    default:
                        // Generic world music patterns
                        culturalMusic.AddCulturalPattern("World_Music", "Generic world music influences");
                        culturalMusic.rhythmPatterns.Add("Generic_World_Pattern");
                        culturalMusic.instrumentalPreferences.Add("Acoustic_Guitar");
                        culturalMusic.instrumentalPreferences.Add("Hand_Percussion");
                        culturalMusic.keySignatures.Add("Natural_Minor");
                        culturalMusic.tempoRange = new Vector2(100f, 140f);
                        culturalMusic.culturalMusicNotes.Add("World music inspired patterns - requires cultural consultation");
                        break;
                }
            }
        }
        
        private void ProcessHistoricalMusic(string culturalIdentity)
        {
            audioReasoning.reasoningSteps.Add("Applying historical music accuracy framework");
            // Framework for historically accurate musical elements based on time period
            culturalMusic.AddHistoricalPatterns(culturalIdentity);
        }
        
        private void ProcessGenreMusic(string culturalIdentity)
        {
            audioReasoning.reasoningSteps.Add("Applying genre music convention framework");
            // Framework for genre-appropriate musical elements
            culturalMusic.AddGenrePatterns(culturalIdentity);
        }
        
        private void ProcessScientificMusic(string culturalIdentity)
        {
            audioReasoning.reasoningSteps.Add("Applying scientific music accuracy framework");
            // Framework for scientifically accurate musical elements
            culturalMusic.AddScientificPatterns(culturalIdentity);
        }
        
        private void ProcessUniversalMusic(string culturalIdentity)
        {
            audioReasoning.reasoningSteps.Add("Applying universal music framework");
            culturalMusic.AddUniversalPatterns();
        }
        
        private void ValidateMusicCulturalAuthenticity(string culturalIdentity)
        {
            musicValidation.culturalIdentity = culturalIdentity;
            musicValidation.validationScore = 0.7f; // Base score
            
            // Check against cultural music database
            var musicDatabase = CulturalMusicDatabase.Instance;
            if (musicDatabase.HasValidatedMusicData(culturalIdentity))
            {
                musicValidation.validationScore = 0.9f;
                musicValidation.isValidated = true;
                musicValidation.validationSource = "Community-validated music database";
                audioReasoning.reasoningSteps.Add("Musical elements validated against community database");
            }
            else
            {
                musicValidation.validationScore = 0.5f;
                musicValidation.requiresMusicCommunityReview = true;
                musicValidation.musicReviewNotes.Add("Musical elements require community validation");
                audioReasoning.reasoningSteps.Add("Musical authenticity requires community review");
            }
        }
        
        private void ProcessBeatMatching(CharacterTraits traits, AnimationData animData)
        {
            beatMatching = new BeatMatchingProfile();
            
            audioReasoning.reasoningSteps.Add("Processing beat-matching profile");
            
            // Base tempo preference from cultural background and personality
            beatMatching.preferredTempo = CalculatePreferredTempo(traits);
            
            // Animation sync parameters with reasoning
            beatMatching.animationSyncTightness = traits.confidence * 0.8f + 0.2f; // 0.2-1.0 range
            beatMatching.rhythmComplexity = traits.creativity;
            beatMatching.offbeatTolerance = 1f - traits.confidence; // More confident = less tolerance for off-beat
            
            // Cultural rhythm influences
            foreach (var pattern in culturalMusic.rhythmPatterns)
            {
                beatMatching.culturalRhythmInfluences.Add(pattern);
            }
            
            // Gesture and breathing sync
            beatMatching.gestureOnBeat = traits.confidence > 0.6f;
            beatMatching.breathingWithPhrase = traits.calm > 0.5f;
            
            // Microtiming variation based on personality
            beatMatching.microtimingVariation = traits.creativity * 0.3f; // 0-0.3 range
            
            audioReasoning.reasoningSteps.Add($"Beat matching configured: tempo={beatMatching.preferredTempo}, sync={beatMatching.animationSyncTightness}");
        }
        
        private float CalculatePreferredTempo(CharacterTraits traits)
        {
            float baseTempo = 120f; // Default BPM
            
            // Adjust based on personality traits
            if (traits.energy > 0.7f) baseTempo += 20f; // High energy = faster tempo
            if (traits.calm > 0.7f) baseTempo -= 15f; // High calm = slower tempo
            if (traits.confidence > 0.8f) baseTempo += 10f; // Confidence = slight tempo increase
            if (traits.anxiety > 0.6f) baseTempo += 15f; // Anxiety = faster tempo
            
            // Cultural music tempo range influence
            if (culturalMusic.tempoRange.x > 0 && culturalMusic.tempoRange.y > 0)
            {
                float culturalMidpoint = (culturalMusic.tempoRange.x + culturalMusic.tempoRange.y) / 2f;
                baseTempo = Mathf.Lerp(baseTempo, culturalMidpoint, 0.6f); // 60% cultural influence
            }
            
            return Mathf.Clamp(baseTempo, 60f, 200f);
        }
        
        private void ProcessEmotionalSignature(EmotionalDuality duality, CharacterTraits traits)
        {
            emotionalSignature = new EmotionalAudioSignature();
            
            audioReasoning.reasoningSteps.Add("Processing emotional audio signature");
            
            // Process primary emotion
            ProcessEmotionalTrait(duality.primaryEmotion, traits, true);
            
            // Process secondary emotion
            ProcessEmotionalTrait(duality.secondaryEmotion, traits, false);
            
            // Blend ratio
            emotionalSignature.emotionalBlendRatio = duality.blendRatio;
            
            audioReasoning.reasoningSteps.Add($"Emotional signature: {duality.primaryEmotion}/{duality.secondaryEmotion} at {duality.blendRatio} blend");
        }
        
        private void ProcessEmotionalTrait(string emotion, CharacterTraits traits, bool isPrimary)
        {
            var intensity = isPrimary ? 1.0f : 0.7f;
            
            switch (emotion.ToLower())
            {
                case "confident":
                    emotionalSignature.confidenceSignature = new AudioSignatureData
                    {
                        intensity = traits.confidence * intensity,
                        frequencyModulation = 1.0f + traits.confidence * 0.2f,
                        dynamicRange = 0.8f + traits.confidence * 0.2f,
                        audioCharacteristics = new List<string> { "Clear", "Projected", "Stable" }
                    };
                    break;
                    
                case "anxious":
                    emotionalSignature.anxietySignature = new AudioSignatureData
                    {
                        intensity = traits.anxiety * intensity,
                        frequencyModulation = 1.0f + traits.anxiety * 0.3f,
                        dynamicRange = 0.6f - traits.anxiety * 0.2f,
                        audioCharacteristics = new List<string> { "Tremulous", "Variable", "Tense" }
                    };
                    break;
                    
                case "fierce":
                    emotionalSignature.fiercenessSignature = new AudioSignatureData
                    {
                        intensity = traits.fierce * intensity,
                        frequencyModulation = 1.1f + traits.fierce * 0.3f,
                        dynamicRange = 0.9f + traits.fierce * 0.1f,
                        audioCharacteristics = new List<string> { "Powerful", "Sharp", "Focused" }
                    };
                    break;
                    
                case "gentle":
                    emotionalSignature.gentlenessSignature = new AudioSignatureData
                    {
                        intensity = traits.calm * intensity,
                        frequencyModulation = 0.9f - traits.calm * 0.1f,
                        dynamicRange = 0.7f + traits.calm * 0.2f,
                        audioCharacteristics = new List<string> { "Soft", "Warm", "Flowing" }
                    };
                    break;
            }
        }
        
        private void ProcessSyncParameters(CharacterDNA dna)
        {
            syncParameters = new AudioSyncParameters();
            
            audioReasoning.reasoningSteps.Add("Processing audio sync parameters");
            
            // Sync tightness based on character traits
            syncParameters.audioVisualSyncTightness = dna.traits.confidence * 0.9f + 0.1f;
            syncParameters.latencyTolerance = (1f - dna.traits.confidence) * 50f; // 0-50ms tolerance
            
            // Ableton Live sync settings
            syncParameters.abletonSyncEnabled = abletonSyncEnabled;
            syncParameters.midiClockSync = true;
            syncParameters.tempoFollowCharacter = true;
            
            // Performance optimization
            syncParameters.thermalAudioComplexity = thermalAudioComplexity;
            syncParameters.adaptiveQuality = true;
            
            audioReasoning.reasoningSteps.Add($"Sync parameters: tightness={syncParameters.audioVisualSyncTightness}, latency={syncParameters.latencyTolerance}ms");
        }
        
        private void ConfigureCrossProjectCompatibility(CharacterDNA dna)
        {
            audioReasoning.reasoningSteps.Add("Configuring cross-project audio compatibility");
            
            // House Proud: Ballroom and Vogue beats
            houseProudSync = new HouseProudBallroomSync();
            if (culturalMusic.rhythmPatterns.Contains("Vogue_Beat_Pattern"))
            {
                houseProudSync.ballroomCompatible = true;
                houseProudSync.vogueBeatSyncEnabled = true;
            }
            
            // GTS: Formation and teamwork rhythms
            gtsSync = new GTSFormationSync();
            gtsSync.formationMarchTempo = beatMatching.preferredTempo;
            gtsSync.teamworkRhythmEnabled = dna.traits.confidence > 0.6f;
            
            // Workplace: Professional and ambient beats
            workplaceSync = new WorkplaceBeatSync();
            workplaceSync.ambientProductivityTempo = Mathf.Clamp(beatMatching.preferredTempo * 0.8f, 80f, 120f);
            workplaceSync.focusRhythmEnabled = dna.traits.calm > 0.5f;
            
            // BCT: Underwater and marine ambient
            bctSync = new BCTAmbientSync();
            bctSync.underwaterAmbientEnabled = true;
            bctSync.marineRhythmCompatible = culturalMusic.tempoRange.x < 100f; // Slower tempos for underwater
        }
        
        // Runtime state management
        public void UpdateAudioState(float confidence, float energy, AudioMoodState mood)
        {
            currentConfidenceLevel = confidence;
            currentEnergyState = energy;
            currentMood = mood;
            
            // Update beat matching profile
            beatMatching.UpdateForRuntimeState(confidence, energy, mood);
            
            // Update emotional signatures
            UpdateEmotionalSignatures(confidence, energy, mood);
            
            // Thermal optimization
            if (thermalOptimizationEnabled)
            {
                AdjustForThermalState();
            }
        }
        
        private void UpdateEmotionalSignatures(float confidence, float energy, AudioMoodState mood)
        {
            // Adjust confidence signature
            if (emotionalSignature.confidenceSignature != null)
            {
                emotionalSignature.confidenceSignature.intensity = 
                    Mathf.Lerp(emotionalSignature.confidenceSignature.intensity, confidence, 0.1f);
            }
            
            // Adjust other signatures based on current state
            switch (mood)
            {
                case AudioMoodState.Confident:
                    if (emotionalSignature.confidenceSignature != null)
                        emotionalSignature.confidenceSignature.intensity *= 1.2f;
                    break;
                case AudioMoodState.Anxious:
                    if (emotionalSignature.anxietySignature != null)
                        emotionalSignature.anxietySignature.intensity *= 1.3f;
                    break;
                case AudioMoodState.Fierce:
                    if (emotionalSignature.fiercenessSignature != null)
                        emotionalSignature.fiercenessSignature.intensity *= 1.4f;
                    break;
            }
        }
        
        private void AdjustForThermalState()
        {
            var thermalMonitor = ThermalMonitor.Instance;
            if (thermalMonitor != null)
            {
                float thermalComplexity = thermalMonitor.GetCurrentPerformanceMultiplier();
                
                // Adjust audio complexity based on thermal state
                culturalMusic.SimplifyForPerformance(thermalComplexity);
                
                // Adjust beat matching complexity
                beatMatching.rhythmComplexity *= thermalComplexity;
                
                // Update audio complexity score
                thermalAudioComplexity = thermalComplexity;
            }
        }
        
        // Mixed-initiative collaboration methods
        public void AcceptCulturalMusicSuggestion(string suggestion, string source)
        {
            musicValidation.communitySuggestions.Add(suggestion);
            musicValidation.suggestionSources.Add(source);
            
            audioReasoning.reasoningSteps.Add($"Community suggestion accepted: {suggestion} from {source}");
            
            // Update validation score
            musicValidation.validationScore = Mathf.Min(1.0f, musicValidation.validationScore + 0.1f);
        }
        
        public void RequestCommunityMusicValidation()
        {
            musicValidation.requiresMusicCommunityReview = true;
            musicValidation.reviewRequestTimestamp = System.DateTime.Now;
            
            audioReasoning.reasoningSteps.Add("Community music validation requested");
        }
        
        public string GetCulturalMusicDescription()
        {
            var description = "Cultural Music Profile:\n";
            description += $"Primary Culture: {culturalMusic.primaryCulture}\n";
            description += $"Rhythm Patterns: {string.Join(", ", culturalMusic.rhythmPatterns)}\n";
            description += $"Instruments: {string.Join(", ", culturalMusic.instrumentalPreferences)}\n";
            description += $"Tempo Range: {culturalMusic.tempoRange.x}-{culturalMusic.tempoRange.y} BPM\n";
            description += $"Validation Score: {musicValidation.validationScore:F2}\n";
            
            if (musicValidation.requiresMusicCommunityReview)
            {
                description += "⚠️ Requires community validation\n";
            }
            
            return description;
        }
        
        public string GetReasoningTrace()
        {
            return string.Join("\n", audioReasoning.reasoningSteps);
        }
    }
    
    // Supporting data structures
    
    [Serializable]
    public class CulturalMusicData
    {
        public string primaryCulture;
        public List<string> rhythmPatterns = new List<string>();
        public List<string> instrumentalPreferences = new List<string>();
        public List<string> keySignatures = new List<string>();
        public List<string> timeSignatures = new List<string>();
        public Vector2 tempoRange = new Vector2(120f, 140f);
        public List<string> culturalMusicNotes = new List<string>();
        public Dictionary<string, string> culturalPatterns = new Dictionary<string, string>();
        
        public void AddCulturalPattern(string patternName, string description)
        {
            culturalPatterns[patternName] = description;
            culturalMusicNotes.Add($"{patternName}: {description}");
        }
        
        public void AddHistoricalPatterns(string culturalIdentity)
        {
            // Add historical period-appropriate patterns
            rhythmPatterns.Add("Historical_Pattern");
            culturalMusicNotes.Add("Historical music patterns applied");
        }
        
        public void AddGenrePatterns(string culturalIdentity)
        {
            // Add genre-specific patterns
            rhythmPatterns.Add("Genre_Pattern");
            culturalMusicNotes.Add("Genre music patterns applied");
        }
        
        public void AddScientificPatterns(string culturalIdentity)
        {
            // Add scientifically accurate patterns
            rhythmPatterns.Add("Scientific_Pattern");
            culturalMusicNotes.Add("Scientific music patterns applied");
        }
        
        public void AddUniversalPatterns()
        {
            // Add universal music patterns
            rhythmPatterns.Add("Universal_Pattern");
            instrumentalPreferences.Add("Universal_Instruments");
            keySignatures.Add("C_Major");
            culturalMusicNotes.Add("Universal music patterns applied");
        }
        
        public string GetTimeSignature()
        {
            return timeSignatures.Count > 0 ? timeSignatures[0] : "4/4";
        }
        
        public string GetKeySignature()
        {
            return keySignatures.Count > 0 ? keySignatures[0] : "C_Major";
        }
        
        public string GetPrimaryRhythmPattern()
        {
            return rhythmPatterns.Count > 0 ? rhythmPatterns[0] : "Standard_4_4";
        }
        
        public void SimplifyForPerformance(float complexityMultiplier)
        {
            // Reduce musical complexity for thermal optimization
            int targetPatterns = Mathf.Max(1, Mathf.RoundToInt(rhythmPatterns.Count * complexityMultiplier));
            if (rhythmPatterns.Count > targetPatterns)
            {
                rhythmPatterns.RemoveRange(targetPatterns, rhythmPatterns.Count - targetPatterns);
            }
            
            int targetInstruments = Mathf.Max(1, Mathf.RoundToInt(instrumentalPreferences.Count * complexityMultiplier));
            if (instrumentalPreferences.Count > targetInstruments)
            {
                instrumentalPreferences.RemoveRange(targetInstruments, instrumentalPreferences.Count - targetInstruments);
            }
        }
    }
    
    [Serializable]
    public class BeatMatchingProfile
    {
        [Range(60f, 200f)]
        public float preferredTempo = 120f;
        
        [Range(0f, 1f)]
        public float animationSyncTightness = 0.8f;
        
        [Range(0f, 1f)]
        public float rhythmComplexity = 0.5f;
        
        [Range(0f, 1f)]
        public float offbeatTolerance = 0.3f;
        
        public bool gestureOnBeat = true;
        public bool breathingWithPhrase = true;
        
        [Range(0f, 0.5f)]
        public float microtimingVariation = 0.1f;
        
        public AnimationCurve energyResponseCurve;
        public List<string> culturalRhythmInfluences = new List<string>();
        
        public void UpdateForRuntimeState(float confidence, float energy, AudioMoodState mood)
        {
            // Adjust beat matching based on current character state
            animationSyncTightness = Mathf.Lerp(animationSyncTightness, confidence * 0.9f + 0.1f, 0.1f);
            
            // Adjust tempo based on energy level
            float targetTempo = preferredTempo * (0.8f + energy * 0.4f); // 80%-120% of preferred tempo
            preferredTempo = Mathf.Lerp(preferredTempo, targetTempo, 0.05f);
            
            // Adjust complexity based on mood
            switch (mood)
            {
                case AudioMoodState.Confident:
                    rhythmComplexity = Mathf.Lerp(rhythmComplexity, 0.8f, 0.1f);
                    break;
                case AudioMoodState.Anxious:
                    rhythmComplexity = Mathf.Lerp(rhythmComplexity, 0.3f, 0.1f);
                    break;
                case AudioMoodState.Fierce:
                    rhythmComplexity = Mathf.Lerp(rhythmComplexity, 0.9f, 0.1f);
                    offbeatTolerance = Mathf.Lerp(offbeatTolerance, 0.1f, 0.1f); // Very tight timing when fierce
                    break;
            }
        }
    }
    
    [Serializable]
    public class EmotionalAudioSignature
    {
        public AudioSignatureData confidenceSignature;
        public AudioSignatureData anxietySignature;
        public AudioSignatureData fiercenessSignature;
        public AudioSignatureData gentlenessSignature;
        
        [Range(0f, 1f)]
        public float emotionalBlendRatio = 0.5f;
        
        public float currentEmotionalIntensity = 0.5f;
        public List<string> activeEmotionalModifiers = new List<string>();
    }
    
    [Serializable]
    public class AudioSignatureData
    {
        public float intensity;
        public float frequencyModulation;
        public float dynamicRange;
        public List<string> audioCharacteristics = new List<string>();
        public AnimationCurve intensityCurve;
    }
    
    [Serializable]
    public class AudioSyncParameters
    {
        [Range(0f, 1f)]
        public float audioVisualSyncTightness = 0.8f;
        
        [Range(0f, 100f)]
        public float latencyTolerance = 20f; // milliseconds
        
        public bool abletonSyncEnabled = true;
        public bool midiClockSync = true;
        public bool tempoFollowCharacter = true;
        
        public float thermalAudioComplexity = 0.7f;
        public bool adaptiveQuality = true;
        
        public int sampleRate = 48000;
        public int bufferSize = 512;
    }
    
    [Serializable]
    public class AudioAuthenticityReasoning
    {
        public string characterIdentity;
        public bool validationRequired = true;
        public List<string> reasoningSteps = new List<string>();
        public float reasoningConfidence = 0.7f;
        public string validationStatus = "Pending";
    }
    
    [Serializable]
    public class CulturalMusicValidation
    {
        public string culturalIdentity;
        public float validationScore = 0.5f;
        public bool isValidated = false;
        public bool requiresMusicCommunityReview = false;
        public string validationSource;
        public List<string> musicReviewNotes = new List<string>();
        public List<string> communitySuggestions = new List<string>();
        public List<string> suggestionSources = new List<string>();
        public System.DateTime reviewRequestTimestamp;
    }
    
    [Serializable]
    public class MixedInitiativeAudioState
    {
        public bool collaborationActive = false;
        public float humanInput = 0.5f;
        public float aiGeneration = 0.5f;
        public string currentFocus = "CulturalMusic";
        public List<string> pendingValidations = new List<string>();
    }
    
    // Cross-project compatibility structures
    [Serializable]
    public class HouseProudBallroomSync
    {
        public bool ballroomCompatible = false;
        public bool vogueBeatSyncEnabled = false;
        public float ballroomTempo = 128f;
        public List<string> ballroomCategories = new List<string>();
    }
    
    [Serializable]
    public class GTSFormationSync
    {
        public float formationMarchTempo = 120f;
        public bool teamworkRhythmEnabled = true;
        public float coordinationBeat = 0.8f;
        public List<string> formationPatterns = new List<string>();
    }
    
    [Serializable]
    public class WorkplaceBeatSync
    {
        public float ambientProductivityTempo = 90f;
        public bool focusRhythmEnabled = true;
        public float concentrationBeat = 0.6f;
        public List<string> workplaceRhythms = new List<string>();
    }
    
    [Serializable]
    public class BCTAmbientSync
    {
        public bool underwaterAmbientEnabled = true;
        public bool marineRhythmCompatible = false;
        public float underwaterTempo = 70f;
        public List<string> marineAmbientPatterns = new List<string>();
    }
    
    // Enums
    public enum AudioMoodState
    {
        Neutral,
        Confident,
        Anxious,
        Fierce,
        Gentle,
        Excited,
        Calm,
        Focused,
        Playful
    }
    
    public enum AudioPerformanceLevel
    {
        Low,
        Medium,
        High,
        Ultra,
        Adaptive
    }
    
    // Singleton pattern for cultural music database
    public class CulturalMusicDatabase
    {
        private static CulturalMusicDatabase _instance;
        public static CulturalMusicDatabase Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CulturalMusicDatabase();
                return _instance;
            }
        }
        
        private Dictionary<string, bool> validatedMusicData = new Dictionary<string, bool>();
        
        public bool HasValidatedMusicData(string culturalIdentity)
        {
            return validatedMusicData.ContainsKey(culturalIdentity) && validatedMusicData[culturalIdentity];
        }
        
        public void AddValidatedMusicData(string culturalIdentity)
        {
            validatedMusicData[culturalIdentity] = true;
        }
    }
}