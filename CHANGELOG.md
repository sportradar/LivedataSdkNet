# Change Log

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
