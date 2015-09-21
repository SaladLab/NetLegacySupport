# NetLegacySupport

Library helps supporting old .NET frameworks like .NET 2.0 and 3.5.
This is a backport from .NET Core.

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

```
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
```
Tuple<int, string> t = Tuple.Create(1, "One");
Console.WriteLine(t); // (1, "One")
```
