### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System.AEntitySystem&lt;T&gt;](./DefaultEcs-System-AEntitySystem-T-.md 'DefaultEcs.System.AEntitySystem&lt;T&gt;')
## #ctor(DefaultEcs.EntitySet, DefaultEcs.System.SystemRunner&lt;T&gt;) `constructor`
Initialise a new instance of the [DefaultEcs.System.AEntitySystem&lt;T&gt;](./DefaultEcs-System-AEntitySystem-T-.md 'DefaultEcs.System.AEntitySystem&lt;T&gt;') class with the given [DefaultEcs.EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet') and [DefaultEcs.System.SystemRunner&lt;T&gt;](./DefaultEcs-System-SystemRunner-T-.md 'DefaultEcs.System.SystemRunner&lt;T&gt;').
### Parameters

<a name='DefaultEcs-System-AEntitySystem-T---ctor(DefaultEcs-EntitySet-_DefaultEcs-System-SystemRunner-T-)-set'></a>
`set`
>The [DefaultEcs.EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet') on which to process the update.

<a name='DefaultEcs-System-AEntitySystem-T---ctor(DefaultEcs-EntitySet-_DefaultEcs-System-SystemRunner-T-)-runner'></a>
`runner`
>The [DefaultEcs.System.SystemRunner&lt;T&gt;](./DefaultEcs-System-SystemRunner-T-.md 'DefaultEcs.System.SystemRunner&lt;T&gt;') used to process the update in parallel if not null.
### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')
>[set](#DefaultEcs-System-AEntitySystem-T---ctor(DefaultEcs-EntitySet-_DefaultEcs-System-SystemRunner-T-)-set 'DefaultEcs.System.AEntitySystem&lt;T&gt;.#ctor(DefaultEcs.EntitySet, DefaultEcs.System.SystemRunner&lt;T&gt;).set') is null.
