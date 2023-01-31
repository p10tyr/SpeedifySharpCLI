# SpeedifySharpCLI
An open source C# wrapper package for Speedify CLI

This package requires you to provide the path to speedifyCLI and 
- will run the executable with no shell
- will capture the output and try to parse the json results to strongly typed objects
- will support commands (soon?)

## How to use?

Register a singleton of SpeedifySharp is you want to use it in your DI

```services.AddSingleton<SpeedifySharp>();```
 
 TODO - Need to add IOPtion so we can set the path (or search paths?)
 
 when you going to work with the object you just need to set the path first time if using Singleton (or everytime if you just newing it up)
 
 eg,
 ```_speedify.SetPathAndFileName(@"C:\Program Files (x86)\Speedify\speedify_cli.exe");```
