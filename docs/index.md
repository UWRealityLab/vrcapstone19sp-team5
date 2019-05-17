<nav class="main-nav">
  <ul>
    <li><a href="/vrcapstone19sp-team5">Updates Blog</a></li>
    <li><a href="/vrcapstone19sp-team5/proposal">Proposal</a></li>
    <li><a href="/vrcapstone19sp-team5/PRD">PRD</a></li>
  </ul>
</nav>

# Week 7 - Environments and Leap motion
## May 17th, 2019

With the wheelchair finished (aside from a tweak or two), the entire group is focused exclusively on constructing environments and getting the LeapMotion to work. While Ilya worked on the wheelchair, for the first 6 weeks, the rest of the team was hard at work plotting out the environment and constructing elevators and other various appliances.

Luke has been hard at work on the Leap Motion: This week I was working on getting leap motion integrated into our library scene. I started off by just testing the leap motion interactions in a test environment to be sure that I knew how to get it to work in a simple setting. This consisted of making a simple cube and seeing if it fell through the floor immediately, if it bugged the headset out, or if it couldn’t be grasped. After working in the test environment and getting everything to work, I began trying to put the leap motion interaction behavior into our library scene. In order to do this, I had to put the leap rig onto our wheelchair prefab so that the leap camera would move with the wheelchair. This was the point at which I encountered several issues.

<video controls="controls">
  <source type="video/mp4" src="img/leapMotionVideo.mp4"></source>
  <p>Your browser does not support the video element.</p>
</video>

The hands refused to show up in the library scene, it was unclear where to put the leap rig prefab so that the camera would be able to see the hands, and the leap software kept presenting me with update warnings. I updated the leap software, then set to work on fixing these bugs. After many attempts, I was able to successfully get the hands to show up in front of the wheelchair. I then set out to try to interact with objects in the library scene with the leap motion hands. When I attempted to grab a nearby monitor on a desk in the library, the entire scene glitched terribly, as the leap hands couldn’t discern which collider they were trying to interact with. This was fixed by getting rid of a mesh collider on the monitor, but introduced a new issue in which the wheelchair went flying upon the leap hands grabbing anything. I attempted to fix this by increasing the mass of the wheelchair, which seemed to fix the problem for now (this will need to be adjusted later). I've made some decent progress here:

![hands](img/leapmotionHands.jpg)

I will be continuing to work on getting the leap motion interactions to be more seamless, especially because there is currently an issue where if the leap hands touch the wheels of the wheelchair, the wheelchair goes flying (which, needless to say, is not ideal). Hopefully I’ve seen the last of the issues that can and should pop up and once we fix them, we can focus more on refining the interaction behavior of our objects with the leap motion hands.

Kyle has been mostly working on the elevator and library scenes: This week was mostly testing and refining the environments in VR.

I encountered a lot of issues as tends to happen with somewhat foreign code. Although I've seen it in action, I wasn't the one to code it. I wasted a lot of time dealing with the issue that the wheelchair doesn’t move when the wheels are rotated. I added some debugging snippets in Ilya’s code for the wheelchair and found that the rotation of the controllers weren’t detected in Unity, and the problem persisted even after rebooting. In the end, removing the controllers from the workstation and re-pairing fixed the issue.

We also run into the issue that prefabs imported into the scenes lost some properties — some public fields were reset when the prefab is imported. We found that it was caused by importing SteamVR from an external package instead of the Asset Store.

After successfully importing the wheelchair into the scenes, I found that the scaling of objects in the scenes are not realistic — the wheelchair was very small compared to everything else. I rescaled the wheelchair to make it the appropriate size relative to the bookshelves, and had to fix the force of the wheels to make it move fast enough. Then I found the elevator to be way too large, so I shrinked it to a relatively reasonable size. We will need to shrink it down even more so the wheelchair can’t turn around in it. Unfortunately our current elevator is not very-well designed so resizing it breaks a lot of things.

After talking to Ilya and Luke, I realized that the library scene we have right now is far from good — many blocks are overlapping so they blink a lot in the actual game, the walls are crossing, textures are not aligned and the elevator design is way too ugly. I have been working on a remake of the library scene we have got. The work was not very technical, but did take time and patience.

The scene we showed last week at the MVP report was not perfect: the elevator does not work properly, and as mentioned, is way too ugly; the textures aren't aligned; different objects intersect so the overlapping areas flicker in the game; the scaling of objects and the wheelchair doesn't look realistic. Also, internally, the game object hierarchy was a mess --- things aren't named properly, the parent-child relationships were not reasonable.

Therefore, I started by fixing the internal design issues, by creating lots of prefabs of bookshelves, table-chair groups, floors and walls to regroup everything and keep them organized. As mentioned, I scaled everything to match the size of the wheelchair. The elevator was intentionally scaled down so that the wheelchair could barely fit in there.

Also, I modified the design of the library a bit to make it more realistic. In the previous versions of the library, bookshelves were placed like a maze. This was intentional, because we want the user to have an inconvenient experience, but it is not common for real-world library to arrange bookshelves like that. Therefore, I instead placed other obstacles in the walkways betwen the shelves, e.g. chairs, printers, etc., to make the scene more realistic. I also made the walkways between shelves more narrow to create more challenge for the player.

For the elevator, I'm glad that I decided to give up and find a working elevator online. It took some effort to set up, but the result is really nice. The new elevator shows the current floor the elevator is on, and the interior is well decorated. We will replace the buttons with LeapMotion controllable ones in the following week which is going to take some effort, once we get LeapMotion working in our test environments. Here is a video clip of the elevator working in the library:

<video controls="controls">
  <source type="video/mp4" src="img/NewElevator.mp4"></source>
  <p>Your browser does not support the video element.</p>
</video>

David and Ilya were mostly working on two halves of the same project: Ilya was designing and modeling the restaurant, while David was working on the bathroom, and also giving his inputs on the restaurant: I mostly spent my time dealing with the same issues Kyle was: the bathroom scaling was off, and there were very many overlapping and flickering textures. The bathroom was constructed with some basic free prefabs, but I'm likely to redo it completely. This week I dealt with the resizing issue by completely rescaling things, and reconstructing the scene based on the scale of the wheelchair. By doing so, we hope to avoid the issue of having to mess with the forces applied to the wheelchair. Ilya and I have been in contact with Julie, a manual wheelchair user mentioned earlier, constantly discussing what works and what doesn't. We're representing a social group we aren't a part of, so consulting is important to actively depict difficulties. We've decided on making the bathroom narrow, with barely enough space to turn around. The end goal here is to force an 8-point turn. Furthermore, we're moving the sinks around so that they're just slightly too tall for the wheelchair user to use. We want things to be pretty bad for the user.

There's really not much technical detail for this week in all honesty, it was mostly just modeling and remodeling various prefabs and fixing the scaling. The biggest technical aspect I can think of was mostly by messing with the tiling and offset of materials so that things wouldn't look overlapped.

Ilya was mostly dealing with the restaurant scene: This week, I was going over several designs and concepts for the restaurant. At the moment, I don't have anything truly concrete, like a floorplan, but I plan to visit the various restaurants that Julie recommends in order to actually recreate an accurate setting for the user. For the most part, David and I are coordinating the bathroom and restaurant, as they're connected in the same scene. We plan to have the scene open up with the user in an elevator. It dings and opens up to a fairly fancy restaurant. While normally, the bathroom would be located on another floor, we already have a scene (the library) dealing with elevators, so the bathroom will conveniently be located on the same floor. Of course, getting there is a completely different story. It'll be a veritable obstacle course. We're likely to eventually add human models, sitting around, chatting, making ambient noise. We are unlikely to fully animate them - we only have ten weeks and we've devoted a large part of that time towards the wheelchair and environments. Animation is a stretch goal.

As a last note, a small bug occurs with the wheelchair. The wheels of the wheelchair are custom 80-sided polygons. The cylinders of Unity made for a bumpy ride, and 80 sides makes the whole process very smooth. However, said 80 sides enable Unity's physics to act a bit screwy, letting the wheelchair make very sharp and fast turns. This isn't something we want, as that would let the player navigate very easily. We're planning on introducing a snippet of code to slow down the turning. A pseudocode example would be:

```
if(rWheel.velocity > 0 AND lWheel.velocity == 0) //turn
  rWheel.velocity /= 2; //vice versa for lWheel.
```

For next week, David and I plan to continue refining and working on the restaurant/bathroom, consulting with Julie all the while. Kyle plans to coordinate with Luke to get LeapMotion working in the library.


---

# Week 6 - Minimum Viable Product and Holsters
## May 10th, 2019

We're starting to get into the endgame here. This week we finished our MVP to mostly our satisfaction. We've finally managed to deal with the rotation bug and got the wheelchair working. An explanation requires some context:

![holster](img/holster1.jpg)
![holster](img/holster2.jpg)

Seen above, Ilya spent several hours putting together holsters made out of wood, foam rubber, and duct tape. These holsters are basically what makes the wheelchair work. In the past, we didn't have a consistent position for the controllers. We'd constantly go back and forth each time we duct taped them to the wheel for testing. By having a stable and consistent position, we were finally able to work out the code necessary to keep things working. The holster is made out of a wood backing, overlaid with foam rubber to keep the controllers snug. This whole thing is kept together by duct tape. The rotation of the controllers when the wheels spin directly corresponds to the velocity of the wheels in game, and thus, their movement. We got the main part of the project working. This is incredibly powerful, as we now have a wheelchair prefab that we can literally just drop into whatever environment we want, no need for adjustments. We ran into a few scaling and size issues, but that's easily dealt with by adjusting a few numbers.

A big problem we encountered was the tilting of the wheelchair:

![tilt](img/tilt.png)

This was a weird bug where the chair would eventually rotate whenever the wheels rotated. We couldn't simply freeze the z-rotation to prevent this from happening since that messed with turning and other functions. We ended up just making an invisible axle/seat that would keep the wheels connected, and then figured out the position and direction the chair should be appearing in and facing based on invisible GameObjects that where placed at the center of each wheel, and then just teleported it there:

```
void Update()
    {
        center = (point1.transform.position + point2.transform.position) / 2;
        center.y = center.y + 0.173f;
        gameObject.transform.position = center;


        direction = point1.transform.position - point2.transform.position;
        direction = Quaternion.AngleAxis(90, Vector3.up) * direction;
        gameObject.transform.rotation = Quaternion.LookRotation(direction);

    }
```

Obviously this worked, as seen in this video:

<video controls="controls">
  <source type="video/mp4" src="img/wheelchairAtWork.mp4"></source>
  <p>Your browser does not support the video element.</p>
</video>

Something to consider is that the wheelchair's 80-side wheels create smooth movement, but allow for very quick turns. Far quicker than the actual forward movement. This is a bit wonky, and also counterproductive, as someone is able to make a very quick 180 just by spinning the two wheels. We want to make the turning far less precise and far less powerful to more accurately match an actual wheelchair.
It's likely we'll do this with something like:

```
PSEUDOCODE
if(wheel.rotationalVelocity is positive AND otherwheel.rotationalVelocity is negative) {
  wheel.rotationalVelocity is divided by two;
  otherwheel.rotationalVelocity is divided by two;
}
```

Overall, the wheelchair is dealt with, and we're just tweaking it to iron out some kinks. The people that have tried it reported minimal motion sickness. We can slow the wheelchair down to alleviate this somewhat, but VR that has movement will always have some kind of small amount of motion sickness, which is just par for the course. If we somehow figured out a way to deal with that last bit, we'd probably high-key revolutionize VR. So, you know, not likely.

On the topic of environments, now that we've completed the wheelchair, we've decided to scale down our project slightly. Before, we had 3 scenarios plotted out, but have decided to instead do only 2 scenarios to impose a rough 7-10 minute constraint on playtime. We have two scenarios planned out:

The first is the restaurant. Having been in talks with a manual wheelchair user, We've decided on having a scenario where you come into a restaurant with your family. Having been pushing a wheelchair all day, your hands are dirty, so you're asked to go to the bathroom. You'll have to navigate an obstacle course of tables and other things to get to the bathroom. Upon arrival, the bathroom's narrow corridors will mean that to get out, you'll have to either ride backwards perfectly, or do an annoying 8-point turn to turn around effectively. We hope that this will drive home a few issues. Some subtle nuances to include is showing how actually reaching an elevated sink while sitting is troublesome and the like.

Our second scenario is navigating a library with narrow shelves and the like. You can only go forwards, and encountering an obstacle will force you to wheel backwards since there isn't room to turn around. Furthermore, the purpose of this scenario is to reach a working elevator. The plan is to have 2 elevators in the scene, and no matter which one the user heads for, the first one they arrive at will be out of order, forcing them to head across the library to get to the other working elevator. Upon arrival, they'll realize that they have to press the button to open it, and then quickly turn around and get into the elevator backwards since there isn't much room to turn around in a wheelchair, and they need to push buttons in order to actually get to their destination. The implications here are obvious. As mentioned at the start of this blog, we hope to instill some empathy into the user.

On next week's agenda:

Ilya: will mostly be working on modelling the restaurant and figuring out good obstacles to place everywhere. Tables, chairs, the layout of the restaurant, etc. Textures will be created and more.

Luke: Is working on getting leap motion interaction to work in the environment, more specifically, trying to get the buttons on the elevator to be pushable so that you can go up and down/call the elevator and to get the door in the library to be able to be pulled outwards.

Kyle and David: Refining/remaking the library and the bathroom, fixing models and scaling, textures, overlapping objects, replacing plane walls with 3D walls, etc.

---
# Week 5 - Demos and Expensive Bike tires
## May 3rd, 2019

We finally managed to put together the chair at last!

![chair](img/chairwheel.jpg)

The wheels were a lot more expensive than we thought, totallying to about $120 for the two of them. The chair cost $2. This week we mostly were coding and modeling our scenes. Later today we plan to meet up with a manual wheelchair user to get their thoughts on our plans for the experience.

We're still facing the bug featuring rotation of the wheels, but I (Ilya Kucherov) have a few ideas on a solution.

Primarily, I'd like to construct a holder for the controller that will be duct taped to the wheel. This will let me just put the controller in and take it out whenever I want. Ideally, the box would be oriented in such a way as to align the orbitals of the controller along the x-axis. Essentially, when I spin it, I want the controller's rotation to go from 0 to 360 rather than making the weird negative and positive number leaps it enjoys. If I orient it properly, rather than taking the relative rotation between frames, I can just hook up the wheel directly to the change in x-axis rotation for the controller. Of course, I'd need to convert the negative rotation values to positive. Euler angles seem to not work for some reason, so this is a hopeful solution - just orienting the controller properly to create the proper axis so that we can FINALLY get a live demo working.

<video controls="controls">
  <source type="video/mp4" src="img/libraryScene.mp4"></source>
  <p>Your browser does not support the video element.</p>
</video>

As mentioned earlier, we've done some great work featuring the scenes. The above showcases the basic library scene that we're considering.

We've also finally gotten started on messing with LeapMotion. We're using the code of Operator 1983, a previous capstone project, that created physical representations of the hands and allowed them to actually interact with things in the environment. Instead of just fingertips, the whole hand will have a constantly shifting hitbox. Things should go well on this front, but we're still figuring things out. Our current VR Headset has the leapmotion camera superglued to the front, meaning we get an experience without controllers, which is what we're going for with the whole wheelchair experience.

Motion sickness is still a threat, but we can't deal with that until we get our wheelchair rotation working.

As a general update for the team members and what we plan to do in the future:

Ilya: Working on physical wheelchair-virtual wheelchair mapping
Luke: Working on making leap motion interactions in the VR scenes
David and Kyle: working on the bathroom interaction and the finishing touches of the library interaction, general scene planning.

# Week 4 - Wheelchair Progress and Environments
### April 26th, 2019

---
This week we made some real progress in translating the rotation of the controllers into the rotation of the wheels on a wheelchair.

<video controls="controls">
  <source type="video/mp4" src="img/Week4.mp4"></source>
  <p>Your browser does not support the video element.</p>
</video>

One of the major bugs we're facing on this front at the moment is rotation in regards to the X axis. The movement of the wheels is being determined by the difference in Quaternion rotation positions every frame and then having that difference accessed by another script to divide it by delta time:
```
void Update()
    {
        orientation1 = orientation2;
        orientation2 = gameObject.transform.rotation;

        Quaternion relative_rotation = Quaternion.Inverse(orientation1) * orientation2; // difference between quaternions

        relative_rotation.ToAngleAxis(out degree, out axis);

        if (axis.y < 0) //backwards rotation
        {
            degree *= -1; //will make degree appear backwards for force conversion
        }


    }
```
This has the unfortunate side effect of taking only the rotation of the controllers relative to the ground. While this is enough to get us off the ground, we still need to smooth out the movement and get the actual rotations working. We plan to do so by averaging the movement of 5 frames, but that's getting ahead of ourselves.

As before, the plan remains to acquire a real chair and bike wheels, and rig it with some kind of material underneath the tires to provide resistance, much like a still exercise bike. While we have movement, we're still working out the kinks.

On the environment side, we've actively planned out at least 2 of our three scenarios. One of the scenarios will involve the culmination of several things: First, you're in a restaurant. Having spent all day turning dirty wheels, your hands are pretty messy. This should get one of the messages across. Upon arriving at the restroom, you'll find that you can barely see yourself in the mirror, due to your sitting position. Furthermore, after washing your hands, you'll find it incredibly hard to leave the bathroom, having to coordinate an 8-point turn just to leave the bathroom due to the narrow hallway design common in most areas.

![floorplan](img/floorplan1.jpg)
![floorplan](img/floorplan2.jpg)
![floorplan](img/floorplan3.jpg)

For our next scenario, we plan to have an elevator that's usually available broken, forcing you, in your wheelchair, to navigate across a troublesome indoor environment (one of the CSE buildings perhaps) in order to reach the other elevator across the building. We're specifically trying to make as hostile an environment as possible.

Our last scenario features public transport, although we're still working on that one.

We have been experimenting with some interactable elements of the environments. Here is a short video demo of an automatic door
that stays open for 5 seconds, which might be too short for wheelchair users.

<video controls="controls" width="640" height="480">
  <source type="video/mp4" src="img/autodoordemo.mp4"></source>
  <p>Your browser does not support the video element.</p>
</video>

On the topic of motion sickness, we've actually found that there isn't all that much to be had. The speed of the wheelchair and the natural physical feedback you get by spinning the controllers counteracts a fair amount of it. This will be mitigated even more by actual wheels keeping the controllers steady.

This next week is going to mostly be working out the kinks of the wheelchairs and hopefully getting a physical prototype working, and putting the wheelchair into an actual environment.

---
# Week 3 - Wheelchair Controls and Environment
### April 18th, 2019

One of the big centerpieces of our project is the controls. It's easy enough to just create a VR environment and everything, apply textures, scale a few doors, script a few elevators, but ultimately, our project comes down to the user experience of using an real(read: fake) wheelchair to really experience what it's like to be disabled in the modern world.

We've primarily decided to use a combination of the Windows Mixed Reality headset and Leap Motion, a device that tracks your hands. With some help, we hope to implement a customized interaction system to allow the hands to actually interact with things in the environment, rather than just the finger tips.

![Leap Motion In game!](img/leapmotion.jpg)

Our idea is to strap the controllers to the center of each wheel on the real-life wheelchair, and when the person spins the wheels, the controllers spin. Their rotation can be directly translated into forwards motion in the virtual environment. Essentially, we are technically working controller free.

We decided on using the Leap Motion over just the controllers because of a couple of reasons: If we used only one controller for the wheels and kept a controller for interaction, we would lose the ability to turn the wheelchair (rotating only one wheel). If we used the controllers to turn the wheel and also interact with things, whenever the person wanted to move around in the wheelchair, they'd have to put the controllers in their lap, which is a horrible user experience. By combining the Leap Motion and the controllers, we hope to create a really accurate and physical experience for the user. This is all to drive home the difficulties of using a wheelchair.

A problem that we're going to continue to run into is motion sickness. This is the biggest problem for our entire project: movement without physical feedback/stimuli. We're attempting to tackle this as best we can, to make the user feel as if they're really in a wheelchair, to provide as much physical feedback to their motions in game as we possibly could.

As a last note to mention: The Mixed Reality Headset can't actually track controllers that are outside of a certain range. One might think this is a problem: If the controllers aren't tracked, then how will the wheels turn? This is solved by the inherent properties of the controllers. They're connected to the computer via Bluetooth, and still report their orbitals at all times. Even if the controllers are outside of effective range, the system can still detect them spinning! All we have to do is make the model invisible and we're in business.

This next week is mostly going to be attempting to test how bad the motion sickness is and trying to get ahold of bike tires and old chairs.

---
# Week 1/2 - Main Ideas and Plans
### April 12th, 2019

This week we managed to come to a consensus on what we want our main project to be and did massive planning on basic interactions and ideas.

We've decided to focus on an Educational/Empathy based experience, where the user will go through the daily life of someone who is disabled, namely, in a wheelchair.

In doing so, we hope to create a sense of empathy for the disabled, and possibly inspire the user to create a more welcoming environment for the disabled, such as advocating ramps, etc., having experienced a small fraction of what life is like for them.

![Make-Shift Wheelchair](img/wheelchairImage.jpg)

A key part of the experience will be rigging a chair, seen above, to be a wheelchair, where we'll attach the motion controllers to the sides of the wheel.

The user will constantly have to turn the wheels of the chair to be able to move around in the virtual environment, which helps add enormous authenticity to the experience. The chair will be elevated slightly to prevent it from actually moving when they turn the wheels, and straps will be attached from the wheels to their wrists to create the illusion of resistance (otherwise they'd be spinning the wheels in midair). This will also physically exhaust the user, which also helps build empathy as they're experiencing the same exhaustion an actual disabled person would experience from rolling around in a wheelchair all day.

The user will have to navigate through an area on this virtual wheelchair. Obviously, this environment will be specifically designed to be inconvenient, such as disabled elevators and the like. Staircases will be blocked off, and numerous other precautions taken. It's likely that we'll model the virtual environment after the CSE building, or perhaps a simplified version of downtown Seattle.
