# SharpGrammar

// TODO: write intro

## Creating a Grammar
### Processables

A SharpGrammar grammar is created implicitly by defining at least one `Processable`. A `Processable` is a building block that can be evaluated within a given context (TODO: link to context). Evaluation of a `Processable` is triggered by calling its `.Process()` method.

```C#
var food = Rule.ChooseRandom("pizza", "salad");
food.Process(); // returns either "pizza" or "salad"
```

`Processable`s can be concatenated with the `+` operator and strings are implicitly converted.

```C#
// note that dinnerSentence is not a string, but a Processable.
var dinnerSentence = "Today I'll have " + food + " for dinner.";

dinnerSentence.Process(); // returns either "Today I'll have pizza for dinner." or "Today I'll have salad for dinner."
```
In this example the strings `"Today I'll have "` and `" for dinner."` are converted to `Processable`s that always evaluate to the respective strings.

### Context

Every `Processable` is processed within a context. The context is provided by the `IContext` interface. `IContext` provides random number generation as well as some memory functionality. An `IContext` object does not have to be created manually, the `.Process()` method creates context for you. If you decide to manually create a context, e.g. to have control over the seed of the RNG, you can just pass it into the `.Process()` method.

```C#
var context = new Context(seed: 1337);
food.Process(context);
```

The contexts memory functionality is also accessed via `Processable`s. These `Processable`s (and some others, too) do not produce any result, they return an empty string.

```C#
var inconsistentSentence = "I like " + food + ", because " + food + " is delicious.";
inconsistentSentence.Process(); // This could return an inconsistent sentence, since food is evaluated twice.

var consistentSentence = Memory.Set("myFood", food, true) +
    "I like " + Memory.Get("myFood") + ", because " + Memory.Get("myFood") + " is delicious.";
consistentSentence.Process(); // This always returns a consistent sentence. 
```

## A Comprehensive List of built-in Processables

// TODO

## Extending SharpGrammar

// TODO
