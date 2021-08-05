# csharp-events

## Delegates
```csharp
public delegate void MyDelegate(object? sender, EventArgs e);
```
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
```csharp
public event EventHandler<T> WorkPerformed;
```
- Provide notifications and send data through EventArgs
- Uses a delegate to route itself to an event listener
- Events are declared in a class using the `event` keyword
- Think of it as a wrapper for a delegate

## Event Handlers
```csharp
static void WorkCompleted(object sender, EventArgs e)
{
    Console.WriteLine("Worker is done");
}
```
- Methods invoked through delegates
- Receive and process EventArgs data
- Standard way in .NET to send events and data
- EventHandler<T> is a custom delegate with an EventArgs of type T. Easier than writing your own delegate

## Delegate inference
```csharp
void Main()
{
    var worker = new Worker();
    worker.WorkPerformed += Worker_WorkPerformed;
}
    
private static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
{
    // ...
}
```

## Anonymous methods
Anonymous methods allow event handler code to be hooked directly to an invent. Anonymous methods are defined using the delegate keyword
```csharp
worker.workedPerformed += delegate(object sender, EventArgs e)
{
    // ...
}
```

## Lambda
- A concise inline method

```csharp
SubmitButton.Click += (s,e) => MessageBox.Show("Button Clicked");
```

- ```(s,e)``` Inline method parameters
- The compiler looks at the delegate behind the event and the types behind its method signature to infer the data types
- ```=>``` Lambda operator
- ```MessageBox.Show("Button Clicked");``` Message body

## Delegates in .NET
The .NET framework provides several different delegates that provide flexible options
- Built-in to .NET framework
- Avoids having to write the custom delegate code
- Handle scenarios that handle one or more input parameters
- Save typing when working with custom delegates
- It's a matter of preference. Some people prefer to declare the delegates at the top of the class
- ```Action<T>``` provides a delegate that accepts a single parameter and returns no value
- You can pass as many type as you want to ```Action<T>```. For example, ```Action<T1,T2,T3>```
- ```Func<T,TResult>``` - provides a delegate that accepts a single parameter and a return value of type TResult
- ```Func<string, bool>``` is equivalent to declaring a delegate that accepts a string and returns a boolean
