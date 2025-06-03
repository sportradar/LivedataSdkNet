Livedata SDK .NET
----------------
Livedata SDK is a client library that enables easier integration with the Livedata XML feed. SDK exposes XML feed service interface in a more user-friendly way and isolates the client from having to do XML feed parsing, proper connection handling, error recovery, event queuing and dispatching. It also makes a client solution more stable and robust when it comes to feed handling, especially with the release of new and updated XML feed versions.

### CONFIGURATION
SDK configuration is stored in a dedicated section of the bookmaker software configuration file. This is usually app.config or web.config for web projects. Make sure that SDK configuration section is properly configured. 
A minimal configuration looks like this:
```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
    <configSections>
        <section name="Sdk" type="Sportradar.LiveData.Sdk.Services.SdkConfiguration.Sections.SdkConfigurationSection, Sportradar.LiveData.Sdk" />
    </configSections>
    <Sdk>
        <LiveScout ScoutUsername="xxx" ScoutPassword="xxx" />

        <!-- This line enables JWT based authentication. Currently available only in 1.1.16-beta -->
        <Auth ClientId="xxx" Kid="xxx" Tenant="xxx" PemPath="xxx" />
    </Sdk>
</configuration>
```
Sportradar.LiveData.Sdk refers to the Sportradar.LiveData.Sdk.dll file and we named the section "Sdk". xxx are the correct credentials. Note that configSection needs to be on top of the file and you need to provide the actual credentials. For more configuration options please refer to the documentation under Sportradar.LiveData.Sdk.Services.SdkConfiguration section.

> **_NOTE:_** Login option with ScoutUsername and ScoutPassword is going to be deprecated soon and replaced by JWT based authentication, controlled by new Auth section of SDK configuration.

### Usage
##### Add reference to SDK project
In Visual Studio you first need to add a "Reference" to Sportradar.LiveData.Sdk.dll in the project or install Sportradar.LiveData.Sdk nuget package. The project is built for .NET 4.8 Framework and .NET Core 6. Intellisense uses the Sportradar.LiveData.Sdk.xml file (located in the same directory as DLL).
##### Initialize the SDK
```C#
Sdk.Instance.Initialize();
```
Here you might want to pass a different configuration section name or pass on your implementation of the IDeadLetterQueue interface if you would like to log and/or report all invalid/undelivered SDK messages and events.
##### Start SDK instance and register for global SDK events
```C#
Sdk.Instance.OnQueueLimits += OnQueueLimit;
Sdk.Instance.Start();
```
Queue limit notifications are useful to give you alerts when message queue congestion starts to build up (or has settled down) so that you can be proactive about it.
##### Monitor SDK queue statistics
By looking at the Sdk.Instance.QueueStats you can see various performance characteristics and statistics of the underlying SDK dispatcher queues.
##### Start SDK provider and register for provider events
Start SDK providers for those XML feeds that you intend to use (e.g. LiveScout)
```C#
if (Sdk.Instance.LiveScout != null)
{
     Sdk.Instance.LiveScout.OnOpened += LiveScout_OnOpened;
     Sdk.Instance.LiveScout.OnClosed += LiveScout_OnClosed;
     Sdk.Instance.LiveScout.OnMatchList += OnMatchList;
     Sdk.Instance.LiveScout.OnMatchStop += OnMatchStop;
     Sdk.Instance.LiveScout.OnMatchUpdate += OnMatchUpdate;
     Sdk.Instance.LiveScout.OnScoutInfo += OnScoutInfo;
     Sdk.Instance.LiveScout.OnMatchBookingReply += OnMatchBookingReply;
     Sdk.Instance.LiveScout.OnMatchData += OnMatchData;
     Sdk.Instance.LiveScout.OnLoginFailed += OnLoginFailed;
     Sdk.Instance.LiveScout.Start();
}
else
{
    throw new ApplicationException("Error initializing SDK.LiveScout provider");
}
```
If you don’t call Sdk.Instance.Initialize() accessing Sdk.Instance.LiveScout will throw an InitException. SDK provider(s) will try to connect to the XML feed server and keep the connection alive. If the connection is lost the provider will try to reconnect automatically and you will be informed of this through corresponding events.
##### Stop SDK providers and unregister from provider events
In the finally block you can stop all SDK providers and unregister from provider events.
```C#
if (Sdk.Instance.LiveScout != null)
{
    Sdk.Instance.LiveScout.Stop();
    
     Sdk.Instance.LiveScout.OnOpened -= LiveScout_OnOpened;
     Sdk.Instance.LiveScout.OnClosed -= LiveScout_OnClosed;
     Sdk.Instance.LiveScout.OnMatchList -= OnMatchList;
     Sdk.Instance.LiveScout.OnMatchStop -= OnMatchStop;
     Sdk.Instance.LiveScout.OnMatchUpdate -= OnMatchUpdate;
     Sdk.Instance.LiveScout.OnScoutInfo -= OnScoutInfo;
     Sdk.Instance.LiveScout.OnMatchBookingReply -= OnMatchBookingReply;
     Sdk.Instance.LiveScout.OnMatchData -= OnMatchData;
     Sdk.Instance.LiveScout.OnLoginFailed -= OnLoginFailed;
}
```
##### Stop the SDK instance and unregister from global SDK events
After all SDK providers have been stopped it is time to shut down the main SDK instance.
```C#
Sdk.Instance.OnQueueLimits -= OnQueueLimit;
Sdk.Instance.Stop();
```
> **_NOTE:_**  Livedata SDK is a singleton. There should be only one active SDK instance per process. If using multiple processes (e.g. failover setup) avoid running SDK instances in parallel, especially if the same access credentials are used. Otherwise you may end up having an inconsistent SDK error recovery state and run into problems due to server-side limits.

### Logs
SDK will make various logs during its operation. Logs are organized into various categories, based on whether these are critical alerts, invalid messages received, configuration updates, message traffic, etc. Level of logging can be configured through each feed configuration element in the "Sdk" configuration section as shown in configuration example.

### Gotchas
SDK generates implicit "*bet stop*" message after disconnect and does automatic error recovery. It does however not keep track of bet clearings!
If you are disconnected for a long time it may happen that after you come back the match is already over. In that time-frame bets were not accepted (so you are safe) but it might still be necessary to clear the bets placed at the begining of the match. In that (rare) case it is up to you to invoke [GetMatchStatus]() method to obtain bet clearings to do correct pay-outs (if / when required).

<!--If match is suspended or cancelled you will receive OnMetaInfo event and see the change periodically in OnAlive event as AliveEventArgs.Alive.EventHeaders[x].Status,
but again if you get disconnected for a longer period of time and miss that match suspended/cancelled event you should explicitly invoke the GetEventStatus to get the final match status.-->

SDK generates explicit "bet stop" message if a client gets disconnected from XML feeds and also performs automatic error recovery on behalf of the client.

### Documentation

[API docs](https://sportradar.github.io/LivedataSdkNet/api/Sportradar.LiveData.Sdk.Services.Sdk.html) 
