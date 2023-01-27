# Bookmaker SDK

Bookmaker SDK is a client library that enables easier integration with the Betradar XML feeds. 
SDK exposes XML feed service interface in a more user-friendly way and isolates the client from having to do XML feed parsing, 
proper connection handling, error recovery, event queuing and dispatching. 
It also makes a client solution more stable and robust when it comes to feed handling, 
especially with the release of new and updated XML feed versions.

# ChangeLog:

## 2.26.0.0 2023-01-26
MatchUpdate extended with new property - SubTeam  
MatchHeader extended with new property - VbpClassification  
ScoutEvent extended with new poperty - PitchingSubstitution  
OddsSuggestions, ScoutOdds, ScoutOddsField had been removed from SDK  
Changed default value for SchemaValidationStrictness from 'STRICT' to 'ON'  
Added new configuration properties for logging to Common section - MaxSizeRollBackups and MaximumFileSize  

## 2.25.0.0 2022-09-22 
LiveData update for Ice Hockey  
ScoutEvent extended with new properties - positionPlayerPitching, freeKickReason.  
Suspensions was replaced with new entity with powerplay under MatchUpdate.  
MatchHeader extended with new properties - team1Division, team2Division.  

## 2.24.0.0  2022-08-25
LiveData update for Basketball  
ScoutEvent extended with new properties - Spot, HomePlayers, AwayPlayers, HappenedAt, ScoreTypeQualifier, ShotDistance, TippedTo, FoulTypeDescriptor, FoulTypeQualifier  

## 2.23.0.0  2022-07-14
BM SDK config to use new endpoint for livedata replay server  
Sport id and match id filters added to match list request  

## 2.22.0.0  2022-02-16
LiveData update for Basketball  
ScoutEvent extended with new properties - HomePlayerStatsTotal, AwayPlayerStatsTotal, HomePlayerStatsP1, AwayPlayerStatsP1, HomePlayerStatsP2, AwayPlayerStatsP2, HomePlayerStatsP3, AwayPlayerStatsP3, HomePlayerStatsP4, AwayPlayerStatsP4, HomePlayerStatsOt, AwayPlayerStatsOt, HomeTimeOnCourt, AwayTimeOnCourt  
LiveData update for Baseball  
ScoutEvent extended with new properties - AtBatNumber, AtBatPitchNumber, BatBallDistance, BatBallX, BatBallY, ExtraInfoKabaddi, FieldingPlayers, PreliminaryMatchStatistics, ActualMatchStatistics, HomeTeamStatsTotal, AwayTeamStatsTotal, HomeTeamStatsP1, AwayTeamStatsP1, HomeTeamStatsP2, AwayTeamStatsP2, HomeTeamStatsP3, AwayTeamStatsP3, HomeTeamStatsP4, AwayTeamStatsP4, HomeTeamStatsOt, AwayTeamStatsOt  
LiveData - default production address changed to livedata.betradar.com  

## 2.21.0.0  2021-12-10
LiveData: added support for green cards (field hockey)  

## 2.20.0.0  2021-10-04
Live Data - new data points added to Ice Hockey (added Players Time on Ice event, added Attacking Players event, added Premium Data Availability event)  
Added UnavailablePlayersHome, UnavailablePlayersAway to ScoutEvent  
Added HomeState, AwayState and Venue to MatchHeader  

## 2.19.1.0  2021-09-16
Vfc: internal Odds id field increase from int to long  

## 2.19.0.0  2021-08-18
Live Data: American Football - New data points added  

## 2.18.0.0  2021-05-17
LiveData: Added MatchUpdate.Scores to get list of scores (may contain sub-score)  

## 2.17.1.0  2020-12-11
Fix: LiveData: concurrency issue when resubscribing to matches  

## 2.17.0.0  2020-11-19
LiveData update for NFL - new property ScoutEntity.DriveInfoStatus  

## 2.16.0.0  2020-09-17
LiveData: added attributes for NFL and CS:GO  

## 2.15.0.0  2020-08-11
LiveOdds: Added new event status for MLB  
LiveData: Added FormatType.RegularInnings  
LiveData: Added support for new MLB match status  

## 2.14.0.0  2020-06-22
LiveData update for NFL Premium product  
Added MatchProperties and MatchTeams to MatchUpdate  
Added attributes for NFL Premium update - extended ScoutEvent  

## 2.13.0.0  2020-02-11
LiveData MatchHeader - added ExtMatchId, Var, TeamMatch, TeamMatchId, IsCancelled  
LiveData ScoutHeader - added Uuid, PitchType, PitchSpeed, BattingAverages, BatBallSpeed, BatBallAngle, BatBallDirection, Structure, MonsterType, DragonType, WardsPlaced, ChampionDamage  
Changing default pull intervals for LCoO to initial delay of 7s and regular delay of 12s  
Fix: converting type to the EventType enum no longer throws exception  
Fixed configuration parsing for Mono  

## 2.12.0.0  2019-03-13
LiveData update: 
added property Order to the Player  
added property MatchStatus to ScoutEvent  
added property SportId to MatchHeader  
LiveData max match list interval increased to 300h  

## 2.11.0.0  2019-01-24
Added NumberOfWinners property to the EventInfoEntity  
Configuration logging levels are used when configuring logger appenders  

## 2.10.0.0  2018-10-17
Updated xsd schema for LiveData and LiveOdds  update 2018.5  
Added AFTER_GOLDEN_SET adn AWAITING_GOLDEN_SET to match status enum  

## 2.9.0.0  2018-05-18
In MatchHeader type of property Delivery changed from Team? to int? to support cricket values  
Added value 1020-SurfaceType to EventType enum  
Fix: naming of property PentaltyRuns to PenaltyRuns in MatchHeader  
Fix: BetStop property IsArtifical renamed to IsArtificial  

## 2.8.0.0  2018-03-27
Updated LiveData schema  
Added properties Behinds and Goals to LiveScout entity  

## 2.7.0.0  2018-01-22
MatchUpdate property PossesionTeam renamed to PossessionTeam  
Updated to latest LiveData schema  
Added MatchStatusId to MatchUpdate entity for LiveScout  
Added property ExtraInfoMoba to ScoutEvent entity  
Added property Jerseys to MatchUpdate for LiveScout  
Added Team1Natural and Team2Natural to MatchHeader entity  

## 2.6.3.0  2017-09-18
Enum EventType marked obsolete  
Added TypeId property to ScoutEvent  

## 2.6.2.0  2017-08-29
Added EXTREME value to WeatherConditions enum  
Added properties TouchdownType and ConversionType to ScoutEvent  

## 2.6.1.0  2017-07-11
Fixed Pitcher Hand value mapping to enum  
Fixed Innings parsing  
Changed LiveScout test port to 2047  
Updated OddsCreator with latest wsdl  added GetTennisMatchInfo  

## 2.6.0.0  2017-05-30
LiveScout: added Gold and Networth property to entity MatchUpdate; property Innings changed to List<Innings>  
LiveOdds: added property StatusId  
General: BetStopReason Id property changed from string to int  

## 2.5.7.0  2017-03-30
Fixed LiveOdds schema for TvChannel property  
Updated LiveScout schema  added CoverageStatusId  

## 2.5.6.1  2017-03-29
Fixed issue with Lcoo encoding  

## 2.5.6.0  2017-03-28
Fixed settings of VirtualGameId and RaceDayNumber in virtual sports  
Added UniqueId to home and away team property  
Changed hostname for VFL feed  
Added new EventTypes for LiveScout  

## 2.5.5.0  2017-03-21
Minor fixed for AliveWithOutrights  
Implemented support for HomeCompetitors & AwayCompetitors  

## 2.5.4.0  2017-03-15
VTO added virtualgameId field  
VFC added some additional checks for outrights headers  

## 2.5.3.0  2017-03-07
Changed how it fetches data for Lcoo feed  previously in some rare cases throwed exception  

## 2.5.2.0  2017-02-07
LiveOdds fixed case where in some situation IsConnectionStable was wrongly set  

## 2.5.1.0  2017-01-31
To LiveOdds feed added CoveredFrom property  indicates whether the match is being covered from a television feed or the scout is at the match venue  

## 2.5.0.0  2017-01-16
LiveScout score can have score1 sub element for example tiebreak, minor breaking change  

## 2.4.6.0  2016-12-13
minor changes  

## 2.4.5.0  2016-10-05
LiveOdds XSD has changed  

## 2.4.4.0  2016-10-04
LiveOdds/LiveScout 2016.5 release changes  

## 2.4.3.0  2016-09-15
LCoO schema changed, void factor is now String  
LiveOddsTestManager StartMatchReplay added fast forward option  

## 2.4.2.0  2016-07-26
LiveOdds/LiveScout 2016.4 release changes  
RaceDay EndTime and RaceDayNumber nullable  

## 2.4.1.0  2016-07-06
LCoO fetch URL changed from www.betradar.com to getxml.betradar.com  

## 2.4.0.0  2016-06-24
Virtual Football Cup support  
GetEventList has been split to 2 different calls. One with events ids and another with date interval  

## 2.3.13.0  2016-05-26
LiveScout XSD was updated, made according changes in the SDK  

## 2.3.12.0  2016-05-23
LiveOdds/LiveScout 2016.3 release changes  

## 2.3.11.0  2016-05-12
LCoO Goal type added  
LCoO FixtureEntity Players added  

## 2.3.10.0 2016-04-12
LCoO RoundInfoEntity Id will be null if not present in XML  
LCoO TextEntity Id, Superid, TeamId will be null if not present in XML  
LCoO Goal/Card Doubtful will be parsed correctly  

## 2.3.9.0  2016-04-13
LiveOdds/LiveScout 2016.2 release changes  
LCoO added AAMSCalendarID  
With introduction of new sport there are over 100 new score types so we changed MatchUpdate.Score from IDictionary<ScoreType, HomeAway<double>> to IDictionary<String, HomeAway<double>>  
Changed default setting of RestartOnParseError to false  

## 2.3.8.0  2016-03-31
Added support for multiple matches per current request  
Fixed set score splitting  

## 2.3.7.0  2016-03-23
LiveOdds connection parameters have changed. liveodds.betradar.com:1981/1980 -> liveplex.betradar.com:1961/1960. Check your firewall rules  

## 2.3.6.0  2016-02-15
LiveOdds/LiveScout 2016.1 release changes  
XSD schema validation strictness is now configurable  
LiveScout use matchsubscription XML element to subscribe  

## 2.3.5.0  2015-12-08
LiveOdds/LiveScout 2015.6 release changes  

## 2.3.4.0  2015-12-03
LCoO venue text now gets populated even if no translations are set  

## 2.3.3.0  2015-11-10
LCoO BetResultEntity.Status and OddsEntity.Id are nullable  
VHC now uses vsportsodds.betradar.com url as default  
cancelbet was added to VHC and VDR schema  

## 2.3.2.0  2015-10-19
LiveOdds/LiveScout 2015.5 release changes  
Feeds will now restart on any parse error by default  
SdkLogger now deletes logger files even if in non default folder  

## 2.3.1.0  2015-09-28
SingleHeaderEvent and SingleHeaderWithOddsEvent are now Serializable  
LCoO FeedType information added to LCoO entities  
LCoO venue text now gets populated correctly  
ILiveOddsTestManager ChangeXmlConfig support added  
SdkConfigurationMessageDispatcher NumDispatchers maximum possible value increased from 8 to 64  

## 2.3.0.0  2015-08-19
LiveOdds/LiveScout 2015.4 release changes  
Extended LiveScout interface with OnOpened, OnClosed  

## 2.2.2.0 2015-07-31
LCoO was missing StatusInfo SDK data structure  
Extended LiveScout EventType with new events  

## 2.2.1.0  2015-07-16
Some SDK entities were missing Serializable interface  

## 2.2.0.0  2015-07-06
Virtual Basketball League support  
ScoutEvent PCount renamed to PitchCount  

## 2.1.17.0  2015-06-16
LiveOdds/LiveScout 2015.3 release changes  

## 2.1.16.0  2015-05-18
LiveOdds schema was missing "awaiting_sd" status  
VHC staging hostname fix  
LCoO HttpQueueFetcher set proxy to null to disable automatic proxy detection  

## 2.1.15.0  2015-04-13
LCoO fixture timezone in now configurable  
Fixed OddsCreator service url  

## 2.1.14.0  2015-03-18
Fixed LiveOdds schema  
Extended ILiveOddsTestManager  
VTO test=true now connects to virtualstaging2.betradar.com  

## 2.1.13.0 2015-02-18
Round added to LO schema which is used in VTO  

## 2.1.12.0  2015-02-18
Added MatchStatus cancelled which is used in VTO  

## 2.1.11.0  2015-02-17
Fixed LiveScout parsing  

## 2.1.10.0  2015-02-10
Updated SDK for 2015.1 server update  

## 2.1.9.0  2015-01-29
LCoO updated to latest schema  
RestartOnParseError option added  
LiveOddsTestManager added reset xml config request to force update check  

## 2.1.8.0  2014-12-09
LCoO Timestamp is optional, so now its nullable.  
LCoO EventName was not being populated  
EventOddsField now has ViewIndex to indicate original order  
Updated SDK for 2014.6 server update  

## 2.1.7.0  2014-10-20
Updated SDK for 2014.5 server update  
PlayerPosition changed from enum to string to support other sports  

## 2.1.6.0  2014-10-08
NodaTime dependency was missing  
Fix: LCoO Competitors Texts list was empty  

## 2.1.5.0  2014-10-06
Fix: LCoO player list was always full even if null data was received  
Fix: LCoO player entity TextEntity was not populated correctly  

## 2.1.4.0  2014-09-30
LCoO schema was updated  
Changed parsing of LCoO message creation time, it is now in UTC  

## 2.1.3.0  2014-09-22
Schema was missing after_sd status  

## 2.1.2.0
BookEvents returns request id  
Reduced min key strength  
Artificial BetStop has undefined event status  

## 2.1.1.0  2014-08-21
OddsCreator namespace fix  
There were 2014.4 changes missing  
CipherSettings error better logging  
LiveOddsGUI if Test="true" StartAuto is called when connection stable  
Lcoo was missing some dlls in merged dll  

## 2.1.0.0  2014-08-06
Support for Life Cycle of Odds feed  
Support for Virtual Tennis Open feed  
Updated SDK for 2014.4 server update  
ILiveOddsTestManager StartMatchReplay fix  
Sdk logging fix  
Sdk injection fixes  
Removed Active property from OddsEntityBase  

## 2.0.2.0  2014-07-31
BetCancel StartTime and EndTime should be nullable  
ConnectionData increased default SendTimeout and ReceiveTimeout  
Sdk resolver config fix  

## 2.0.1.0  2014-07-22
Logging fix. Stats and config are not per feed anymore  
Nuget 4.5 .NET package fix  

## 2.0.0.0  2014-07-03
Initial release  
Added support for VHC, VDR, LivePlex, Soccer Roulette  
Some major changes to interfaces, namespaces, classes, logging, ...  
New error manager  
