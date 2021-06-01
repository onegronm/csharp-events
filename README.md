# csharp-events

## Delegates
- A type that represents references to methods with a particular parameter list and return type
- Acts as pipeline between events and event handlers or "function pointer"
- Moves data (EventArgs) from point A to a handler method
- Implicitly inherits from MulticastDelegate class which allows invoking multiple subscribers through an InvocationList
- In an invocation list, only the value of the last delegate is returned
- Multicast delegates are used extensively in event handling
### Uses
- When you want to programmatically change method calls, or plug new code into existing classes
- When you want to define callback methods by referring to a method as a parameter
- When you want to define an asynchronous callback, a common method of notifying a caller when a long process has completed
- When you want to define a custom comparison method and pass that delegate to a sort method


## Events
- Provide notifications and send data through EventArgs
- Uses a delegate to route itself to an event listener
- Events are declared in a class using the `event` keyword
- Think of it as a wrapper for a delegate
### Uses

## Event Handlers
- Methods invoked through delegates
- Receive and process EventArgs data
- Standard way in .NET to send events and data
- EventHandler<T> is a custom delegate with an EventArgs of type T. Easier than writing your own delegate

