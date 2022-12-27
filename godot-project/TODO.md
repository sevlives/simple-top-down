# TODO
- [x] Pick a project architecture - *Using hierarchical structure*
    - [ ] Stick with it
- [ ] Learn how to merge *correctly* in git bash
- [ ] Background image
- Player
    - [ ] Add Lerp, acceleration and friction to forward and backward movement
    - [x] Turret that follows mouse, but slowly
- Enemies
    - [ ] Enemy movement
    - [ ] Enemies track targets
    - [ ] Attack targets
- Create projectiles
    - [ ] Draw a curved line (the tethers)
    - [ ] Characters can fire projectiles
    - [ ] Do damage
- Basic UI
    - [ ] Health/ damage system
    - [ ] Target reticle that follows raycast from turret to show turret heading
- Pause Menu
    - [x] ~~Add script to program GRatio into MarginContainers~~ *Used `CenterContainers` instead*
    - [x] When opened centered in Camera
    - [x] When active toggle between mouse cursors
    - [ ] Working buttons
        - [ ] Close game
        - [ ] Return to title
- Debug
    - [x] Create direction visualizer scene
- Global Members
    - [ ] Get mouse position and store globally maybe?

## Bugs/ Issues
- [x] Turret refuses to rotate when mouse is opposite of active tank rotation in a 180' arc
    - Made tank body and turret sibling nodes, thus decoupling parent / child relationship in rotation

## Critically read code I don't understand
- Ui.DebugOverlay

# Things learned in Godot / game engines
- `_Process()` vs `_PhysicsProcess()` (and `_UnhandledInput()`) - [YT video](https://www.youtube.com/watch?v=UrbcDJFLPc0)
    - `_Process()` happens as fast as Godot can render
        - Data processing jobs, non-display, non-timing
            - Generate level, save, cache
        - Do work as fast as possible (*Do it NOW*)
        - __NOT__ node manipulation
            - Moving/ translating a character
    - `_PhysicsProcess()` happnes more consistently
        - Handeling results of physics calculations
        - Consistent timing, display movement, translating/ manipulating nodes on screen
    - `_UnhandledInput()` called near end of input chain
        - Use this and keep unneeded input checks out of `_PhysicsProcess()` (*which checks input every .0166 sec!*)
        - Is only called when an event has occured
        - Used for inputs that are not every frame
            - Maybe movement input can be called in `_PhysicsProcess()`
- Art, at least 2d, default facing is to the right. If your import is facing "up" all code will be rotated 90'
    - If you're desired behavior is off by 90', you are on the wrong axis #basic algebra
    - [Article](https://www.alanzucconi.com/2016/02/03/2d-rotations/) says sine and cosine are the same function, only shifted 90'
        - Sin crosses (0, 0) and (pi, 0) while cosine crosses (1pi/2, 0) and (3pi/2, 0)
    - To change axis in code 2 options
        - Rotating relevant vector EX:`.Rotated(Mathf.Pi*0.5f)`
        - Changing relevant vector to EX:`_vector = (-_vector.y, _vector.x)`
- For smooth `LookAt()`, create vector from object to target using `target.GlobalPosition - GlobalPosition` - [YT video](https://www.youtube.com/watch?v=ciT_jDol9G8)
    - Find angle of vector with `Angle()` then use `LerpAngle()` instead of `LookAt()`
    - For constant rotation, create a `_rotationSpeed` constant multiplied by `delta` to get allowed rotation per frame (`_angleDelta`)
        - Use `LerpAngle()` with full weight of `1` to get direction object must rotate to match target
        - Limit the angle with `Clamp()` by +/- `_angleDelta` (*the amount of rotation allowed per frame*)
- `Lerp()` = `from` + (`to`-`from`) * `weight`(range 0-1)
    - Use `LerpAngle()` for liner interpolation of angles
- Can draw child behind parent in Inspector by changing `Visibility`
- __UI Nodes__
    - Control as root (vs CanvasLayer)
        - You can't adjust anchors for children of containers, suggest using `CenterContainers` / others to achieve needs
# Things learned in C#
- __Use `properties` not `fields`__
    - Fields are for class internal data
    - Properties are for exposing data for class external use
- Property wrapper pattern
    - Create a private field and then access it with a public property getter / setter method
- `object[]` is a type. It is an array of objects, where objects are a base type in C#. This means the array can store a collection of elements of any type in the array
- `GetMethod(string _methodName)` has method `.Invoke(_obj, _array)` where `_array` is an array of arguments to pass to the method being invoked
- `abstract` methods. Their implementation is required by the class implementing the relevant interface/ abstract class <u>but</u> do not have default "use case" (*implementation*)
    - `virtual` methods have a default use case, therefor <u>do not</u> require implementation in derived classes
- Difference between <u>declaring</u> and <u>initializing</u> a variable
    - Declaring is when you name a variable and specifiy type
        - Optionally you can initialize the same time you declare for values that you don't intend to change
    - Initializing is when you assign a value to a variable
        - For values that change during runtime, usually you initialize separately
- __Naming__
    - Do not share names between classes and namespaces, C# will prioritize namespace over object type
    - Instead of using `enum State` which is vague, opt for `AnimationState` or `MovementState`
        - I learned of `AnimationState` from F.E.A.R.'s GOAP AI design pattern, which includes only 3 states `Goto, Animate, Use Smart Object`
        - I learned of `MovementState` from ChatGPT to by using verbs to describe states `standing, walking, falling`
    - Instead of a base class named `BaseState` in the player controller, opt for `PlayerState`
        - For AI opt for `CharacterState`

# Inspiration
### Things mentioned in Godot discord
- `Load()` and `Preload()`
- Autotile set

### Cool things seen on YT
- Moving text that appears on screen, then moves off - [YT video](https://www.youtube.com/watch?v=4nHxqTmB_TY) @3:08

# Follow up questions / need research
## Godot follow up
- Kinematic2D.Rotate
- Different Godot key node types, need to read thru metadeta and docs and use each of these and their methods once to get a feel for the use cases
    - Node
        - Control
        - Node 2D
        - CanvasLayer
        - `VisibilityNotifier` node
- Removing and adding nodes from scenes
    - Using `QueueFree()` and `Instance()`
- `WeakReference` class
- Learn about `Transform2d` https://docs.godotengine.org/en/3.5/tutorials/math/matrices_and_transforms.html
    - Interesting looking [article](https://www.alanzucconi.com/2016/02/10/tranfsormation-matrix/)
- Learn about `vector math` https://docs.godotengine.org/en/3.5/tutorials/math/vector_math.html#doc-vector-math

## C# follow up
- Difference between *value* types and *reference* types
    - `Value` type ex: `int, float` store date directly
    - `Reference` type ex: `object, array` store a reference to the data
- Difference between fields and properties and when to use each
- `null` value, seems to be used often for booleans 
    - Apparently `default` value is different
- What is useful in `Reflection` module, besides `FieldInfo, MethodInfo, PropertyInfo`
- Singletons
    - Only every one instance of that class during the apps run time
- Data Binding
    - Deals with UI
    - `INotifyPropertyChanged` interface
