# Non-alloc Enumeration
Non-alloc enumerables for Unity structures and C# `IList`/`IReadOnlyList` interfaces.


## Supported Unity enumerations
- `Transform`: default children enumerator allocates the enumerator object.
  Use the idiom `foreach (Transform t in transform.EnumerateNonAlloc())` to use a non-alloc enumerable instead.
- `Input.touches`: calling `Input.touches` allocates the array of touches each time you call it.
  Use the idiom `foreach (Touch t in InputTouches.EnumerateNonAlloc())` to use a non-alloc enumerable instead.
- `Input.accelerationEvents`: calling `Input.accelerationEvents` allocates the array of acceleration events each time you call it.
  Use the idiom `foreach (AccelerationEvent a in InputAccelerationEvents.EnumerateNonAlloc())` to use a non-alloc enumerable instead.
- (Unity 2021+ only) `GameObject` and `Component`: use the extension methods `EnumerateComponents`, `EnumerateComponentsInChildren` and `EnumerateComponentsInParent` to enumerate components using pooled lists.
  Heap memory may be allocated if there are no pooled lists available or if the pooled list isn't big enough to hold all values, but overall repeated calls will end up being non-alloc.
- (Unity 2021+ only) `Renderer`: use the extension methods `EnumerateMaterials`, `EnumerateSharedMaterials` and `EnumerateClosestReflectionProbes` to enumerate materials and reflection probe info from a renderer using pooled lists. The same caveats from enumerating components mentioned above apply.
- `Rect`: use the idiom `foreach (Vector2 corner in rect.EnumerateCorners())` to enumerate a Rect's 4 corners.
- `Bounds`: use the idiom `foreach (Vector3 corner in bounds.EnumerateCorners())` to enumerate a Bounds' 8 corners.


## Supported C# enumerations
By default, all built-in generic arrays and container classes like `List<>`, `Dictionary<,>` and `HashSet<,>` return struct enumerators when used in `foreach` blocks, so there are no "EnumerateNonAlloc" for them.

In case you are using `IList<>` and `IReadOnlyList<>` interfaces directly, though, the enumerator used in `foreach` blocks get boxed and allocate heap memory.
Use the idiom `foreach (var value in someIListOrIReadOnlyList.EnumerateNonAlloc())` to use a non-alloc enumerable instead.