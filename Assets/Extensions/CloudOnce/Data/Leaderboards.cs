// <copyright file="Leaderboards.cs" company="Jan Ivar Z. Carlsen, Sindri Jóelsson">
// Copyright (c) 2016 Jan Ivar Z. Carlsen, Sindri Jóelsson. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace CloudOnce
{
    using System.Collections.Generic;
    using Internal;

    /// <summary>
    /// Provides access to leaderboards registered via the CloudOnce Editor.
    /// This file was automatically generated by CloudOnce. Do not edit.
    /// </summary>
    public static class Leaderboards
    {
        private static readonly UnifiedLeaderboard s_rankedLeaderboard = new UnifiedLeaderboard("RankedLeaderboard",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "Ranked"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "RankedLeaderboard"
#endif
            );

        public static UnifiedLeaderboard RankedLeaderboard
        {
            get { return s_rankedLeaderboard; }
        }

        private static readonly UnifiedLeaderboard s_levelsLeaderboard = new UnifiedLeaderboard("LevelsLeaderboard",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "Levels"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "LevelsLeaderboard"
#endif
            );

        public static UnifiedLeaderboard LevelsLeaderboard
        {
            get { return s_levelsLeaderboard; }
        }

        private static readonly UnifiedLeaderboard s_timeTrialsEasyLeaderboard = new UnifiedLeaderboard("TimeTrialsEasyLeaderboard",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "TimeTrialsEasy"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "TimeTrialsEasyLeaderboard"
#endif
            );

        public static UnifiedLeaderboard TimeTrialsEasyLeaderboard
        {
            get { return s_timeTrialsEasyLeaderboard; }
        }

        private static readonly UnifiedLeaderboard s_timeTrialsMediumLeaderboard = new UnifiedLeaderboard("TimeTrialsMediumLeaderboard",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "TimeTrialsMedium"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "TimeTrialsMediumLeaderboard"
#endif
            );

        public static UnifiedLeaderboard TimeTrialsMediumLeaderboard
        {
            get { return s_timeTrialsMediumLeaderboard; }
        }

        private static readonly UnifiedLeaderboard s_timeTrialsHardLeaderboard = new UnifiedLeaderboard("TimeTrialsHardLeaderboard",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "TimeTrialsHard"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "TimeTrialsHardLeaderboard"
#endif
            );

        public static UnifiedLeaderboard TimeTrialsHardLeaderboard
        {
            get { return s_timeTrialsHardLeaderboard; }
        }

        public static string GetPlatformID(string internalId)
        {
            return s_leaderboardDictionary.ContainsKey(internalId)
                ? s_leaderboardDictionary[internalId].ID
                : string.Empty;
        }

        private static readonly Dictionary<string, UnifiedLeaderboard> s_leaderboardDictionary = new Dictionary<string, UnifiedLeaderboard>
        {
            { "RankedLeaderboard", s_rankedLeaderboard },
            { "LevelsLeaderboard", s_levelsLeaderboard },
            { "TimeTrialsEasyLeaderboard", s_timeTrialsEasyLeaderboard },
            { "TimeTrialsMediumLeaderboard", s_timeTrialsMediumLeaderboard },
            { "TimeTrialsHardLeaderboard", s_timeTrialsHardLeaderboard },
        };
    }
}
