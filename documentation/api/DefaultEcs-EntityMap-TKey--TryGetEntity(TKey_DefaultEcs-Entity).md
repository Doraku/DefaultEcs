#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[EntityMap&lt;TKey&gt;](./DefaultEcs-EntityMap-TKey-.md 'DefaultEcs.EntityMap&lt;TKey&gt;')
## EntityMap&lt;TKey&gt;.TryGetEntity(TKey, DefaultEcs.Entity) Method
Gets the [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') associated with the specified key.  
```csharp
public bool TryGetEntity(TKey key, out DefaultEcs.Entity entity);
```
#### Parameters
<a name='DefaultEcs-EntityMap-TKey--TryGetEntity(TKey_DefaultEcs-Entity)-key'></a>
`key` [TKey](./DefaultEcs-EntityMap-TKey-.md#DefaultEcs-EntityMap-TKey--TKey 'DefaultEcs.EntityMap&lt;TKey&gt;.TKey')  
The key of the [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') to get.  
  
<a name='DefaultEcs-EntityMap-TKey--TryGetEntity(TKey_DefaultEcs-Entity)-entity'></a>
`entity` [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity')  
When this method returns, contains the [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') associated with the specified key, if the key is found; otherwise, an invalid [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity'). This parameter is passed uninitialized.  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if the [EntityMap&lt;TKey&gt;](./DefaultEcs-EntityMap-TKey-.md 'DefaultEcs.EntityMap&lt;TKey&gt;') contains an [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') with the specified key; otherwise, false.  
