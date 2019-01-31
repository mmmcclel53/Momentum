// <copyright file="Achievements.cs" company="Jan Ivar Z. Carlsen, Sindri Jóelsson">
// Copyright (c) 2016 Jan Ivar Z. Carlsen, Sindri Jóelsson. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace CloudOnce
{
    using System.Collections.Generic;
    using Internal;

    /// <summary>
    /// Provides access to achievements registered via the CloudOnce Editor.
    /// This file was automatically generated by CloudOnce. Do not edit.
    /// </summary>
    public static class Achievements
    {
        private static readonly UnifiedAchievement s_meteorMazeWelcome = new UnifiedAchievement("MeteorMazeWelcome",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "MeteorMazeWelcome"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "MeteorMazeWelcome"
#endif
            );

        public static UnifiedAchievement MeteorMazeWelcome
        {
            get { return s_meteorMazeWelcome; }
        }

        private static readonly UnifiedAchievement s_customizeShip = new UnifiedAchievement("CustomizeShip",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "CustomizeShip"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "CustomizeShip"
#endif
            );

        public static UnifiedAchievement CustomizeShip
        {
            get { return s_customizeShip; }
        }

        private static readonly UnifiedAchievement s_apprenticeRank = new UnifiedAchievement("ApprenticeRank",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "ApprenticeRank"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "ApprenticeRank"
#endif
            );

        public static UnifiedAchievement ApprenticeRank
        {
            get { return s_apprenticeRank; }
        }

        private static readonly UnifiedAchievement s_adeptRank = new UnifiedAchievement("AdeptRank",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "AdeptRank"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "AdeptRank"
#endif
            );

        public static UnifiedAchievement AdeptRank
        {
            get { return s_adeptRank; }
        }

        private static readonly UnifiedAchievement s_veteranRank = new UnifiedAchievement("VeteranRank",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "VeteranRank"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "VeteranRank"
#endif
            );

        public static UnifiedAchievement VeteranRank
        {
            get { return s_veteranRank; }
        }

        private static readonly UnifiedAchievement s_expertRank = new UnifiedAchievement("ExpertRank",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "ExpertRank"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "ExpertRank"
#endif
            );

        public static UnifiedAchievement ExpertRank
        {
            get { return s_expertRank; }
        }

        private static readonly UnifiedAchievement s_eliteRank = new UnifiedAchievement("EliteRank",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "EliteRank"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "EliteRank"
#endif
            );

        public static UnifiedAchievement EliteRank
        {
            get { return s_eliteRank; }
        }

        private static readonly UnifiedAchievement s_aceRank = new UnifiedAchievement("AceRank",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "AceRank"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "AceRank"
#endif
            );

        public static UnifiedAchievement AceRank
        {
            get { return s_aceRank; }
        }

        private static readonly UnifiedAchievement s_legendRank = new UnifiedAchievement("LegendRank",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "LegendRank"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "LegendRank"
#endif
            );

        public static UnifiedAchievement LegendRank
        {
            get { return s_legendRank; }
        }

        private static readonly UnifiedAchievement s_mythicRank = new UnifiedAchievement("MythicRank",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "MythicRank"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "MythicRank"
#endif
            );

        public static UnifiedAchievement MythicRank
        {
            get { return s_mythicRank; }
        }

        private static readonly UnifiedAchievement s_transcendentRank = new UnifiedAchievement("TranscendentRank",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "TranscendentRank"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "TranscendentRank"
#endif
            );

        public static UnifiedAchievement TranscendentRank
        {
            get { return s_transcendentRank; }
        }

        private static readonly UnifiedAchievement s_stars100 = new UnifiedAchievement("Stars100",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "100Stars"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "Stars100"
#endif
            );

        public static UnifiedAchievement Stars100
        {
            get { return s_stars100; }
        }

        private static readonly UnifiedAchievement s_stars200 = new UnifiedAchievement("Stars200",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "200Stars"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "Stars200"
#endif
            );

        public static UnifiedAchievement Stars200
        {
            get { return s_stars200; }
        }

        private static readonly UnifiedAchievement s_stars300 = new UnifiedAchievement("Stars300",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "300Stars"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "Stars300"
#endif
            );

        public static UnifiedAchievement Stars300
        {
            get { return s_stars300; }
        }

        private static readonly UnifiedAchievement s_stars400 = new UnifiedAchievement("Stars400",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "400Stars"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "Stars400"
#endif
            );

        public static UnifiedAchievement Stars400
        {
            get { return s_stars400; }
        }

        private static readonly UnifiedAchievement s_stars500 = new UnifiedAchievement("Stars500",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "500Stars"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "Stars500"
#endif
            );

        public static UnifiedAchievement Stars500
        {
            get { return s_stars500; }
        }

        private static readonly UnifiedAchievement s_stars600 = new UnifiedAchievement("Stars600",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "600Stars"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "Stars600"
#endif
            );

        public static UnifiedAchievement Stars600
        {
            get { return s_stars600; }
        }

        private static readonly UnifiedAchievement s_easy15TimeTrials = new UnifiedAchievement("Easy15TimeTrials",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "Easy15TimeTrials"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "Easy15TimeTrials"
#endif
            );

        public static UnifiedAchievement Easy15TimeTrials
        {
            get { return s_easy15TimeTrials; }
        }

        private static readonly UnifiedAchievement s_medium10TimeTrials = new UnifiedAchievement("Medium10TimeTrials",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "Medium10TimeTrials"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "Medium10TimeTrials"
#endif
            );

        public static UnifiedAchievement Medium10TimeTrials
        {
            get { return s_medium10TimeTrials; }
        }

        private static readonly UnifiedAchievement s_hard5TimeTrials = new UnifiedAchievement("Hard5TimeTrials",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "Hard5TimeTrials"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "Hard5TimeTrials"
#endif
            );

        public static UnifiedAchievement Hard5TimeTrials
        {
            get { return s_hard5TimeTrials; }
        }

        private static readonly UnifiedAchievement s_timeTrials30 = new UnifiedAchievement("TimeTrials30",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "TimeTrials30"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "TimeTrials30"
#endif
            );

        public static UnifiedAchievement TimeTrials30
        {
            get { return s_timeTrials30; }
        }

        private static readonly UnifiedAchievement s_completionist = new UnifiedAchievement("Completionist",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "Completionist"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "Completionist"
#endif
            );

        public static UnifiedAchievement Completionist
        {
            get { return s_completionist; }
        }

        public static readonly UnifiedAchievement[] All =
        {
            s_meteorMazeWelcome,
            s_customizeShip,
            s_apprenticeRank,
            s_adeptRank,
            s_veteranRank,
            s_expertRank,
            s_eliteRank,
            s_aceRank,
            s_legendRank,
            s_mythicRank,
            s_transcendentRank,
            s_stars100,
            s_stars200,
            s_stars300,
            s_stars400,
            s_stars500,
            s_stars600,
            s_easy15TimeTrials,
            s_medium10TimeTrials,
            s_hard5TimeTrials,
            s_timeTrials30,
            s_completionist,
        };

        public static string GetPlatformID(string internalId)
        {
            return s_achievementDictionary.ContainsKey(internalId)
                ? s_achievementDictionary[internalId].ID
                : string.Empty;
        }

        private static readonly Dictionary<string, UnifiedAchievement> s_achievementDictionary = new Dictionary<string, UnifiedAchievement>
        {
            { "MeteorMazeWelcome", s_meteorMazeWelcome },
            { "CustomizeShip", s_customizeShip },
            { "ApprenticeRank", s_apprenticeRank },
            { "AdeptRank", s_adeptRank },
            { "VeteranRank", s_veteranRank },
            { "ExpertRank", s_expertRank },
            { "EliteRank", s_eliteRank },
            { "AceRank", s_aceRank },
            { "LegendRank", s_legendRank },
            { "MythicRank", s_mythicRank },
            { "TranscendentRank", s_transcendentRank },
            { "Stars100", s_stars100 },
            { "Stars200", s_stars200 },
            { "Stars300", s_stars300 },
            { "Stars400", s_stars400 },
            { "Stars500", s_stars500 },
            { "Stars600", s_stars600 },
            { "Easy15TimeTrials", s_easy15TimeTrials },
            { "Medium10TimeTrials", s_medium10TimeTrials },
            { "Hard5TimeTrials", s_hard5TimeTrials },
            { "TimeTrials30", s_timeTrials30 },
            { "Completionist", s_completionist },
        };
    }
}
