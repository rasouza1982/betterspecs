# BetterSpecs ![alt tag](https://travis-ci.org/ycodeteam/betterspecs.svg?branch=master)
Spec is a great tool in the behavior-driven development (BDD) process of writing human readable specifications that direct and validate the development of your application. BetterSpecs is the simple way to bring the power of spec to your MSTest tool. 

## Install
To install Betterspec in your MSTest project use this command:

```csharp
PM> Install-Package BetterSpecs
```

## using Better spec

### Import class
```csharp
using BetterSpecs;

[TestClass]
public class SpecContextTests : SpecContext
{
  ...
}
````

### Context
```csharp
[TestMethod]
public void describe_speccontext_while_using_it()
{
    context["when use SpecContext class"] = () =>
    {
        it["it is work very well"] = () => Assert.IsTrue(true);
    };
}
````

### mixin contexts
```csharp
[TestMethod]
public void describe_speccontext_while_using_it()
{
    context["when use SpecContext class"] = () =>
    {
        context["with two context"] = () =>
        {
            it["it is work very well"] = () => Assert.IsTrue(true);
        };
    };
}
````

### before and let
```csharp
[TestMethod]
public void describe_speccontext_while_using_it()
{
    context["when use SpecContext class"] = () =>
    {
        let = () => Console.WriteLine("Calling 'let'");
        before = () => Console.WriteLine("Calling 'before'");
        
        it["it is work very well"] = () => Assert.IsTrue(true);
    };
}
````

### Output spec
When run tests, the result in Test Explore will be like this:

```
when use SpecContext class
with other internal context
    it is work very well
    it is work very well
    it is work very well
with second internal context
    it is work very well too!!!
Great!!!
```
