# A man is not dead while his name is still spoken.

Based on [GNU Terry Pratchett](http://www.gnuterrypratchett.com/). Project for adding the header to ASP.NET core web projects.

In Terry Pratchett's Discworld series, the clacks are a series of semaphore towers loosely based on the concept of the telegraph. Invented by an artificer named Robert Dearheart, the towers could send messages "at the speed of light" using standardized codes. Three of these codes are of particular import:

* **G:** send the message on
* **N:** do not log the message
* **U:** turn the message around at the end of the line and send it back again

When Dearheart's son John died due to an accident while working on a clacks tower, Dearheart inserted John's name into the overhead of the clacks with a "GNU" in front of it as a way to memorialize his son forever (or for at least as long as the clacks are standing.)

# How to use

1. Add reference to [the nuget package](https://www.nuget.org/packages/clacks.overhead) to your `project.json` file
2. In `Startup.cs`, add the middleware with `IApplicationBuilder.RememberTerryPratchett()` extension method, before any other middleware

```
using clacks.overhead;

...
public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
{
...
    app.RememberTerryPratchett();
...
}
