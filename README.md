# Controls Tips
This package allows you to create Zelda: BOTW style UI controls tips.

![image](https://github.com/Bogenbai/Unity-ControlsTips/assets/26659946/3d524fb1-c801-4030-9271-bb7231b2d79d)

## Installing
1. Install ControlsTips.unitypackage into your project.

2. Move *ControlsTips ScrollView* from Prefabs folder into your canvas in your scene.

3. Configure tips list in component script  on *Controls Tips ScrollView* GameObject.
![image](https://github.com/Bogenbai/Unity-ControlsTips/assets/26659946/be17ff41-436b-4f58-8d33-2486d20f37e9)


* *Name* - Key for you to call the methods for actions with a specific tip.
* *Key Image* - Image of the key to be displayed on the screen.
* *Tip Description* - Description of the key action to be displayed on the screen.

## How to use it?

Now, when you've added *ControlsTips ScrollView* GameObject into your scene, you can simply call `ShowTip()` and `HideTip()` methods in your scripts.
*ControlsTips* is singleton, so you can call it like this:

*Example:*
```
if (isGrounded())
{
  ControlsTips.Instance.ShowTip("Jump");
}
else
{
  ControlsTips.Instance.HideTip("Jump");
}
```
