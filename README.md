# SharpGrammar

:construction: _write intro_

## Creating a Grammar
### Processables

A SharpGrammar grammar is created by defining at least one `Processable`. A `Processable` is a building block that can be evaluated within a given [context](#using_context). Evaluation of a processable is triggered by calling its `.Process()` method.

```C#
var food = Take.OneOf("pizza", "salad");

// prints either "pizza" or "salad"
Console.WriteLine(food.Process());
```

Processables can be concatenated with the `+` operator and values like strings are implicitly converted.

```C#
// note that dinnerSentence is not a string, but a Processable.
var dinnerSentence = "Today I'll have " + food + " for dinner.";

// prints either    "Today I'll have pizza for dinner."
// or               "Today I'll have salad for dinner."
Console.WriteLine(dinnerSentence.Process());
```
_Note that the strings_ "Today I'll have " _and_ " for dinner." _are implicitly converted to processables that always evaluate to the respective strings._

#### Instantiating Processables

With the intention to make composition of processables more readable, they are created through factory-pattern methods, implicit conversion and operators (instead of directly calling constructors).

Instead of calling ...

```C#
Processable<string> na = new ValueProcessable<string>("na");
Processable<string> character = new OneOfProcessable<string>(" Batman!", " Robin!");
Processable<string> sentence =
    new ProcessableList<string>(new RepeatProcessable<string>(na, 8), character);
```
... you call ...

```C#
Processable<string> na = "na";
Processable<string> character = Take.OneOf<string>(" Batman!", " Robin!");
Processable<string> song = na.Repeat(8) + character;
```

## Using Context

Every processable is processed within a context. The context is provided by the `IContext` interface. `IContext` provides basic random number generation and is extensible with modules. To process a `Processable` within a specific context, just pass the context into the `.Process(IContext context)` method.

```C#
var context = new Context(1337);
Console.WriteLine(food.Process(context));
```
Although a new context is implicitly created if you don't provide one, creating a context explicitly allows you to specify the seed used for the random number generation and add extension modules.

## Adding Functionality

### Adding Built-In Modules

SharpGrammar provides some built-in extension modules that add extra functionality like counting or memory functionality. (see list below)

Some of these heavily utilize the context, like the processables in the `Memory` namespace. The context does not provide this functionality out-of-the-box, instead a module needs to be added.

This can be done with the `.BindModule()` method either explicitly from an actual instance...

```C#
var context = new Context();
var module = new SomeModule();
context.BindModule(module);
```
...or implicitly by type, if the type has a parameterless constructor.
```C#
var context = new Context();
context.BindModule<SomeModule>();
```
The signature of the `.BindModule()` method allows for a procedural, fluid use.
```C#
var context = new Context()
    .BindModule<SomeModule>()
    .BindModule<AnotherModule>()
    .BindModule(new YetAnotherModule(someParameter));
```

##### Built-In Modules
:construction: _link all entries to their own documentation pages_

|Module|Functionality|
|:-|:-|
|Counting|The `Counting` module provides integer memory and counting functionality.|
|Memory|The `Memory` module provides functionality to save and recall values.|

## Extending SharpGrammar
### Custom Processable-Libraries

The built-in processables cover a lot of common use-cases for generative grammars, but sometimes custom functionality is needed. You can easily provide that with custom written processables. Here is an example of a `Processable<string>` that converts a provided `Processable<string>` to lower case:

```C#
internal record ToLowerProcessable : Processable<string>
{
    private readonly Processable<string> value;

    internal ToLowerProcessable(Processable<string> value)
    {
        this.value = value ??
                     throw new NullReferenceException(nameof(value));
    }

    public override string Process(IContext<string> context) =>
        value.Process(context).ToLower();
}
```

The processable itself and its constructor(s) are kept `internal` and are not meant to be exposed as API. Instead a static API class is used:

```C#
static class StringProcessingExtensions
{
    public static Processable<string> ToLower(this Processable<string> processable) =>
        new ToLowerProcessable(processable);
}
```

### Custom Modules

Modules have no restrictions. They can be bound to a context as seen above ([Adding Functionality](adding_functionality)) and can be retrieved via the `.Get<TModule>()` method. These modules' functionality can be used by processables that need some level of consitency or state.

```C#
context.Get<MyModule>()
```
