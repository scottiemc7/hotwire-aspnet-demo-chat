# Hotwire Asp.Net Core Chat Demo

A port of the [Hotwire Rails Chat Demo](https://github.com/hotwired/hotwire-rails-demo-chat) to asp.net core

* Razor Pages, EF Core, SQLite
* SignalR to deliver [Turbo Streams](https://turbo.hotwire.dev/handbook/streams) messages
* [Fluid](https://github.com/sebastienros/fluid) for out of band template rendering

To start, go to `./WebApplication` and run:

```
npm ci
dotnet build
dotnet tool restore
dotnet ef database update --no-build
dotnet run
```

Then open https://localhost:5001 and try it out.