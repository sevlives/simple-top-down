# List of things so I don't forget

## TODO
- [ ] Background image
- [ ] Enemies
    - [ ] Enemy movement
    - [ ] Enemies track targets
- [ ] Create projectiles
    - [ ] Draw a curved line (the tethers)
    - [ ] Player able to fire projectiles
- [ ] Basic UI
    - [ ] Health/ damage system
    - [ ] Mouse hidden
        - [ ] Tiny dot to replace mouse
    - [ ] Target reticle that follows raycast from turret
- [x] Turret that follows mouse, but slowly

## Need research
- Learn about `Transform2d` https://docs.godotengine.org/en/3.5/tutorials/math/matrices_and_transforms.html
    - Learn about `vector math` https://docs.godotengine.org/en/3.5/tutorials/math/vector_math.html#doc-vector-math
- Cast ray to mouse position
    - Track turret with ray
- Create a menu
- Singletons
    - Only every one instance of that class during the apps run time
- Data Binding
    - Deals with UI
    - `INotifyPropertyChanged` interface

## Things learned
- Art, at least 2d, default facing is to the right. If your import is facing "up" all code will be rotated 90'
    - If you're desired behavior is off by 90', you are on the wrong axis #basic algebra
    - To change axis in code 2 options
        - Rotating relevant vector `.Rotated(Mathf.Pi*0.5f)`
        - Changing relevant vector to `_vector = (-_vector.y, _vector.x)`
- For smooth `LookAt()`, create vector from object to target using `target.GlobalPosition - GlobalPosition` [YT video](https://www.youtube.com/watch?v=ciT_jDol9G8)
    - Find angle of vector with `Angle()` then use `LerpAngle` instead of `LookAt()`
    - For constant rotation, create a `_rotationSpeed` constant multiplied by `delta` to get allowed rotation per frame (`_angleDelta`)
        - Use `LerpAngle()` with full weight of `1` to get direction object must rotate to match target
        - Limit the angle with `Clamp()` by +/- `_angleDelta` (*the amount of rotation allowed per frame*)
- `Lerp` = `from` + (`to`-`from`) * `weight`(range 0-1)
    - Use `LerpAngle()` for liner interpolation of angles
### Follow up questions
- Kinematic2D.Rotate