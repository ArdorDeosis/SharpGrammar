# SharpGrammar

:construction: _write intro_

## Creating a Grammar
### Processables

A SharpGrammar grammar is created implicitly by defining at least one `Processable`. A `Processable` is a building block that can be evaluated within a given [context](#context). Evaluation of a processable is triggered by calling its `.Process()` method.

```C#
var food = Rule.SelectRandom("pizza", "salad");

// prints either "pizza" or "salad"
Console.WriteLine(food.Process());
```

Processables can be concatenated with the `+` operator and strings are implicitly converted.

```C#
// note that dinnerSentence is not a string, but a Processable.
var dinnerSentence = "Today I'll have " + food + " for dinner.";

// prints either    "Today I'll have pizza for dinner."
// or               "Today I'll have salad for dinner."
Console.WriteLine(dinnerSentence.Process());
```
_Note that the strings _"Today I'll have "_ and _" for dinner."_ are converted to processables that always evaluate to the respective strings._

#### Instantiating Processables

With the intention to make composition of processables more readable, they are created through factory-pattern methods, implicit conversion and operators in the `SharpGrammar.API` namespace (instead of directly calling constructors).

Instead of calling ...

```C#
Processable a = new ValueProcessable("pizza");
Processable b = new SelectRandomProcessable("salad", a);
Processable c = new ProcessableList("I like to eat ", b);
```
... you call ...

```C#
Processable a = "pizza";
Processable b = Rule.SelectRandom("salad", a);
Processable c = "I like to eat " + b;
```

### Context

Every processable is processed within a context. The context is provided by the `IContext` interface. `IContext` provides random number generation as well as some memory functionality. A context does not have to be created manually, the `.Process()` method creates context for you. If you decide to manually create a context, e.g. to have control over the seed of the RNG, you can just pass it into the `.Process()` method.

```C#
var context = new Context(seed: 1337);
Console.WriteLine(food.Process(context));
```

The context's memory functionality is also accessed via `Processable`s. These `Processable`s (and some others, too) do not produce any result, they return an empty string.

```C#
// This could produce an inconsistent sentence, since food is evaluated twice.
var inconsistentSentence = "I like " + food + ", because " + food + " is delicious.";

// This always produces a consistent sentence.
var consistentSentence = Memory.Set("myFood", food, true) +
    "I like " + Memory.Get("myFood") + ", because " + Memory.Get("myFood") + " is delicious.";
```

## A Comprehensive List of built-in Processables

:construction: _link all entries to their own documentation pages_

### SharpGrammar.API.Rule

* Rule.Nothing
* Rule.Value
* Rule.OneOf
* Rule.Iterate

### SharpGrammar.API.Memory

* Memory.Set
* Memory.SetIfUnset
* Memory.Unset
* Memory.Get
* Memory.TryGet
* Memory.SetNumber
* Memory.SetNumberIfUnset
* Memory.IncrementNumber
* Memory.DecrementNumber
* Memory.UnsetNumber
* Memory.GetNumber
* Memory.TryGetNumber

### SharpGrammar.API.Flow

* Flow.Repeat
* Flow.If

### SharpGrammar.API.Command

* Command.Do
* Command.Transform


## Extending SharpGrammar

:construction:
