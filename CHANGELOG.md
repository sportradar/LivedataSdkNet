# Change Log

## [1.1.15] - 2025-04-08
Update for MatchFormat - THREEPOINTCONVERSIONYARDLINE has been added to FormatType enum.

## [1.1.14] - 2025-03-27
ScoutEvent extended with PointInGameNumber property.

MatchHeader extended with new properties:
- IsRTS
- ExpectedLatencyLevel
- ExpectedLatencyLevelString

New enum added - LatencyLevel

## [1.1.13] - 2025-03-25
Traffic logs now include time since last message.

FinalConfidence for ScoutEvent has been changed from string to integer.

PlayerStatistics for ScoutEvent has been extended with new properties:
- HomePlayerStatsSet1
- HomePlayerStatsSet2
- HomePlayerStatsSet3
- HomePlayerStatsSet4
- HomePlayerStatsSet5
- AwayPlayerStatsSet1
- AwayPlayerStatsSet2
- AwayPlayerStatsSet3
- AwayPlayerStatsSet4
- AwayPlayerStatsSet5

Statistics and PlayerStatistics for ScoutEvent has been extended:
- TeamPlayerStats added to Statistics

New type added - TeamPlayerStats

New enum added - TeamPlayerStatsType

## [1.1.12] - 2024-10-18
MatchUpdate extended with new properties
- TryCount
- Fouls  

ScoutEvent extended with new properties
- BallEvent
- PlayerId
- TrackCoordinates
- FinalConfidence

- Player extended with new property - SpecificContracts

## [1.1.11] - 2024-08-23
Updated LiveScoutFeedProvider.Unsubscribe to send a single batch "matchunsubscription" request instead of individual "matchstop" requests for each match ID.

## [1.1.10] - 2024-06-03
ScoutEvent extended with new properties:
- Statistics
- OnDeck
- InHole
- NumberOfShots
- PointOutcome
- Situation
- ErrorType
- ShotSequence
- PrimaryShotType
- SecondaryShotType
- LastStroke
- ExtraInfoTennis
- SupervisorAction

New types added:
- Statistics
- BattersStatsTotal
- PitchersStatsTotal
- TeamStats
- PlayerStats
- Stats

New TeamStatsType enum added.
EventType enum updated.

## [1.1.9] - 2024-03-11
PlayerStatistics is added only for ScoutEvent with event type 1714
TeamStatistics is added only for ScoutEvent with event type 1743

FormatType enum is extended with new value - ONEPOINTCONVERSIONYARDLINE

## [1.1.8] - 2024-03-01

Enhanced login failure messaging to include specific reasons and error codes for better diagnostics.

Lineups extended with new property - Preliminary

ScoutEvent extended with new properties:
 - RefsTime
 - PlayerStatistics
 - TeamStatistics

The following properties in ScoutEvent are marked as Obsolete and moved to PlayerStatistics:
 - HomePlayerStatsTotal
 - HomePlayerStatsP1
 - HomePlayerStatsP2
 - HomePlayerStatsP3
 - HomePlayerStatsP4
 - HomePlayerStatsOt
 - AwayPlayerStatsTotal
 - AwayPlayerStatsP1
 - AwayPlayerStatsP2
 - AwayPlayerStatsP3
 - AwayPlayerStatsP4
 - AwayPlayerStatsOt

New properties included in PlayerStatistics:
 - HomePitchersStatsTotal
 - HomeBattersStatsTotal
 - AwayPitchersStatsTotal
 - AwayBattersStatsTotal
 
The following properties in ScoutEvent are marked as Obsolete and moved to TeamStatistics:
 - HomeTeamStatsTotal
 - HomeTeamStatsP1
 - HomeTeamStatsP2
 - HomeTeamStatsP3
 - HomeTeamStatsP4
 - HomeTeamStatsOt
 - AwayTeamStatsTotal
 - AwayTeamStatsP1
 - AwayTeamStatsP2
 - AwayTeamStatsP3
 - AwayTeamStatsP4
 - AwayTeamStatsOt

New properties included in TeamStatistics:
 - HomeTeamStatsI1
 - HomeTeamStatsI2
 - HomeTeamStatsI3
 - HomeTeamStatsI4
 - HomeTeamStatsI5
 - HomeTeamStatsI6
 - HomeTeamStatsI7
 - HomeTeamStatsI8
 - HomeTeamStatsI9
 - HomeTeamStatsIe
 - AwayTeamStatsI1
 - AwayTeamStatsI2
 - AwayTeamStatsI3
 - AwayTeamStatsI4
 - AwayTeamStatsI5
 - AwayTeamStatsI6
 - AwayTeamStatsI7
 - AwayTeamStatsI8
 - AwayTeamStatsI9
 - AwayTeamStatsIe

## [1.1.7] - 2024-01-16

ScoutEvent extended with new properties - ScorerNotConfirmed.

Introduced a new ScoutFeedType: FULL_PAGINATED. Receive full paginated match updates through the new event: Services.Sdk.Instance.LiveScout.OnMatchUpdateFullPaginated.

## [1.1.6] - 2023-11-08

LiveData update for Soccer.
ScoutEvent extended with new properties - HomePlayerStats, AwayPlayerStats.

List of SubTeams added to MatchUpdate, SubTeam property is deprecated.

## [1.1.5] - 2023-10-10

New match format type added - USESOVERS.

LiveData update for Soccer.
ScoutEvent extended with new properties - ExtraInfoSoccer.

LiveData update for Waterpolo.
ScoutEvent extended with new property - ExtraInfoWaterpolo.

LiveData update for NHL.
ScoutEvent extended with new properties - ShotProjectedGoalRate, ShotRatingCategory, ShotSpeed, ShotType.

## [1.1.4] - 2023-06-15

LiveData update for Snooker.
ScoutEvent extended with new poperties - PointsUntilSnookerNeeded, PossibleBreak, MaxBreakFrame, PointsRemaining, Reds.
Removed PrevPitcher property from ScoutEvent.

## [1.1.3] - 2023-05-30

LiveData update for Snooker.
ScoutEvent extended with new poperties - PointsUntilSnookerNeeded, PossibleBreak, MaxBreakFrame, PointsRemaining, Reds.
Removed PrevPitcher property from ScoutEvent.

## [1.1.2] - 2023-03-14

LiveData update for MLB.
ScoutEvent extended with new properties - FirstBasePlayer, SecondBasePlayer, ThirdBasePlayer, HomeRunsHome, HomeRunsAway, PrevPitcher, NextBatter, TotalPitchCount.

## [1.1.1] - 2023-01-26

MatchUpdate extended with new property - SubTeam
MatchHeader extended with new property - VbpClassification
ScoutEvent extended with new property - PitchingSubstitution
OddsSuggestions, ScoutOdds, ScoutOddsField have been removed from SDK
Changed default value for SchemaValidationStrictness from 'STRICT' to 'ON'
Added new configuration properties for logging to Common section - MaxSizeRollBackups and MaximumFileSize

## [1.1.0-beta] - 2022-10-31

Removed support of LiveOdds, LCOO and Odds Creator feeds. Only LiveScout feed remains supported.

## [1.0.3] - 2022-09-22

LiveData update for Ice Hockey.
ScoutEvent extended with new properties - positionPlayerPitching, freeKickReason.
Suspensions was replaced with new entity with powerplay under MatchUpdate.
MatchHeader extended with new properties - team1Division, team2Division.

## [1.0.2] - 2022-08-25

LiveData update for Basketball.
ScoutEvent extended with new properties - Spot, HomePlayers, AwayPlayers, HappenedAt, ScoreTypeQualifier, ShotDistance, TippedTo, FoulTypeDescriptor, FoulTypeQualifier.

## [1.0.1] - 2022-08-19

BM SDK config to use new endpoint for livedata replay server.
Sport id and match id filters added to match list request.

## [1.0.0] - 2022-05-31

Based on [BookmakerSdk 2.22](https://sdk.sportradar.com/bookmaker/net2).
Solution structure has been simplified by merging all SDK subprojects into single one. This has affected namespaces.
Changed project target platforms to .NET Framework 4.8 and .NET 6.0.
