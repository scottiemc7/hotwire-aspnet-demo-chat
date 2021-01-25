# Hotwire Asp.Net Core Chat Demo

A port of the [Hotwire Rails Chat Demo](https://github.com/hotwired/hotwire-rails-demo-chat) to asp.net core

* Razor Pages, EF Core, SQLite
* SignalR to deliver [Turbo Streams](https://turbo.hotwire.dev/handbook/streams) messages
* [Fluid](https://github.com/sebastienros/fluid) for out of band template rendering

To start, create the database with the following command and you should be off and running.

`dotnet ef database update`