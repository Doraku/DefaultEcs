### [DefaultEcs](./DefaultEcs 'DefaultEcs')
### [DefaultEcs.System.ParallelSystem&lt;T&gt;](./DefaultEcs-System-ParallelSystem-T- 'DefaultEcs.System.ParallelSystem&lt;T&gt;')
## #ctor(DefaultEcs.System.ISystem&lt;T&gt;, DefaultEcs.System.SystemRunner&lt;T&gt;, DefaultEcs.System.ISystem&lt;T&gt;[]) `constructor`
Initialises a new instance of the [DefaultEcs.System.ParallelSystem&lt;T&gt;](./DefaultEcs-System-ParallelSystem-T- 'DefaultEcs.System.ParallelSystem&lt;T&gt;') class.
### Parameters

<a name='DefaultEcs-System-ParallelSystem-T---ctor(DefaultEcs-System-ISystem-T--_DefaultEcs-System-SystemRunner-T--_DefaultEcs-System-ISystem-T---)-mainSystem'></a>
`mainSystem`

The [DefaultEcs.System.ISystem&lt;T&gt;](./DefaultEcs-System-ISystem-T- 'DefaultEcs.System.ISystem&lt;T&gt;') instance to be updated on the calling thread.

<a name='DefaultEcs-System-ParallelSystem-T---ctor(DefaultEcs-System-ISystem-T--_DefaultEcs-System-SystemRunner-T--_DefaultEcs-System-ISystem-T---)-runner'></a>
`runner`

The [DefaultEcs.System.SystemRunner&lt;T&gt;](./DefaultEcs-System-SystemRunner-T- 'DefaultEcs.System.SystemRunner&lt;T&gt;') used to process the update in parallel if not null.

<a name='DefaultEcs-System-ParallelSystem-T---ctor(DefaultEcs-System-ISystem-T--_DefaultEcs-System-SystemRunner-T--_DefaultEcs-System-ISystem-T---)-systems'></a>
`systems`

The [DefaultEcs.System.ISystem&lt;T&gt;](./DefaultEcs-System-ISystem-T- 'DefaultEcs.System.ISystem&lt;T&gt;') instances.
