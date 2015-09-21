# NetLegacySupport

Library helps supporting old .NET frameworks like .NET 2.0 and 3.5.
This is a backport from .NET Core. Following classes are provided:

 - System.Action
 - System.Tuple
 - System.Collections.Concurrent.ConcurrentDictionary

## System.Action

Action and Func is quite tricky to use in a multi target framework project because 2.0, 3.0 and 3.5 framework just provided subset of them.

 - .NET Framework 2.0, 3.0 supports only Action\<T\>
 - .NET Framework 3.5 supports Action, Func has up to 4 parameters.
 - .NET Framework 4.0 supports Action, Func has up to 16 parameters.

To deal with this problem, this library provides missing classes in target framework.

#### Where can I get it?

```
PM> Install-Package NetLegacySupport.Action
```

#### Code that you can write.

```csharp
Func<int, int, int, int, long> f =
    (a, b, c, d) => { return (long)a + b + c + d; };
Console.WriteLine(f(1, 2, 3, 4)); // 10
```

## System.Tuple

Until .NET Framework 4, tuple was not supported. But it's an essential class that makes your code terse.

#### Where can I get it?

```
PM> Install-Package NetLegacySupport.Tuple
```

#### Code that you can write.
```csharp
Tuple<int, string> t = Tuple.Create(1, "One");
Console.WriteLine(t); // (1, "One")
```

## ConcurrentDictionary

ConcurrentDictionary is quite usuful dictionary with a thread-safe feature.
If your project is targeted toward .NET 3.5 only, 
[Task Parallel Library for .NET 3.5](https://www.nuget.org/packages/TaskParallelLibrary/) can be an option.

#### Where can I get it?

```
PM> Install-Package NetLegacySupport.ConcurrentDictionary
```

#### Code that you can write.

```csharp
// New instance. (from http://www.dotnetperls.com/concurrentdictionary)
var con = new ConcurrentDictionary<string, int>();
con.TryAdd("cat", 1);
con.TryAdd("dog", 2);

// Try to update if value is 4 (this fails).
con.TryUpdate("cat", 200, 4);

// Try to update if value is 1 (this works).
con.TryUpdate("cat", 100, 1);

// Write new value.
Console.WriteLine(con["cat"]);
```
