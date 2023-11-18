using GrainInterfaces;
using Microsoft.Extensions.Logging;

namespace Grains;

public class HelloGrain(ILogger<HelloGrain> logger) : Grain, IHello 
{
    ValueTask<string> IHello.SayHello(string greeting)
    {
        logger.LogInformation("""
            SayHello message received: greeting = "{Greeting}"
            """,
            greeting);

        return ValueTask.FromResult($"""

            Client said: "{greeting}", so HelloGrain says: Hello!
            """);
    }
}