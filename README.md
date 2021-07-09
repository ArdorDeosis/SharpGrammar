# SharpGrammar

:construction: _write intro_

## Creating a Grammar
### Processables

A SharpGrammar grammar is created by defining at least one `Processable`. A `Processable` is a building block that can be evaluated within a given [context](#context). Evaluation of a processable is triggered by calling its `.Process()` method.

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
_Note that the strings_ "Today I'll have " _and_ " for dinner." _are converted to processables that always evaluate to the respective strings._

#### Instantiating Processables

With the intention to make composition of processables more readable, they are created through factory-pattern methods, implicit conversion and operators (instead of directly calling constructors).

Instead of calling ...

```C#
Processable a = new ValueProcessable("pizza");
Processable b = new OneOfProcessable("salad", a);
Processable c = new ProcessableList("I like to eat ", b);
```
... you call ...

```C#
Processable a = "pizza";
Processable b = Take.OneOf("salad", a);
Processable c = "I like to eat " + b;
```

## Using Context

Every processable is processed within a context. The context is provided by the `IContext` interface. `IContext` provides basic random number generation and is extensible with modules. To process a `Processable` within a created context, just pass it into the `.Process(IContext context)` method.

```C#
var context = new Context(seed: 1337);
Console.WriteLine(food.Process(context));
```

#### Extending Context

To extend the functionality of a context, you can bind modules to it. You can bind an existing instance...

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

:construction:
