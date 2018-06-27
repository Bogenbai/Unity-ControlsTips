# Controls Tips
This package allows you to create Zelda: BOTW style UI controls tips.

![alt text](https://cdn.discordapp.com/attachments/428973249502642208/461553402065715209/unknown.png)

## Installing
1. Install ControlsTips.unitypackage into your project.

2. Move *ControlsTips ScrollView* from Prefabs folder to your canvas in your scene.

3. Configure tips list in component script  on *Controls Tips ScrollView* GameObject. 
![alt text](https://cdn.discordapp.com/attachments/428973249502642208/461557183822168084/unknown.png)

* *Name* - Key which you will use to call methods for actions with specific tip.
* *Key Image* - Image of the key, which will display on the screen.
* *Tip Description* - Description of the key action, which will display on the screen.

## How to use it?

Now, when you've added *ControlsTips ScrollView GameObject* into your scene, you can simply call `ShowTip()` and `HideTip()` methods in your scripts.
*ControlsTips* is public static class, so you can call it like this:

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
