#### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Command](./DefaultEcs.md#DefaultEcs-Command 'DefaultEcs.Command').[EntityCommandRecorder](./DefaultEcs-Command-EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder')
## #ctor(System.Int32, System.Int32) `constructor`
Creates an [EntityCommandRecorder](./DefaultEcs-Command-EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder') with a custom default size which can grow to a maximum capacity. 
### Parameters

<a name='DefaultEcs-Command-EntityCommandRecorder--ctor(System-Int32-_System-Int32)-defaultCapacity'></a>
`defaultCapacity`

The default size of the [EntityCommandRecorder](./DefaultEcs-Command-EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder').

<a name='DefaultEcs-Command-EntityCommandRecorder--ctor(System-Int32-_System-Int32)-maxCapacity'></a>
`maxCapacity`

The maximum capacity of the [EntityCommandRecorder](./DefaultEcs-Command-EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder').
### Exceptions

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')

[defaultCapacity](#DefaultEcs-Command-EntityCommandRecorder--ctor(System-Int32-_System-Int32)-defaultCapacity 'DefaultEcs.Command.EntityCommandRecorder.#ctor(System.Int32, System.Int32).defaultCapacity') cannot be negative.

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')

[maxCapacity](#DefaultEcs-Command-EntityCommandRecorder--ctor(System-Int32-_System-Int32)-maxCapacity 'DefaultEcs.Command.EntityCommandRecorder.#ctor(System.Int32, System.Int32).maxCapacity') cannot be negative.

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')

[maxCapacity](#DefaultEcs-Command-EntityCommandRecorder--ctor(System-Int32-_System-Int32)-maxCapacity 'DefaultEcs.Command.EntityCommandRecorder.#ctor(System.Int32, System.Int32).maxCapacity') is inferior to [defaultCapacity](#DefaultEcs-Command-EntityCommandRecorder--ctor(System-Int32-_System-Int32)-defaultCapacity 'DefaultEcs.Command.EntityCommandRecorder.#ctor(System.Int32, System.Int32).defaultCapacity').
