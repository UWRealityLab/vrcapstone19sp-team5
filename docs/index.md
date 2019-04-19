<nav class="main-nav">
  <ul>
    <li><a href="/vrcapstone19sp-team5">Updates Blog</a></li>
    <li><a href="/vrcapstone19sp-team5/proposal">Proposal</a></li>
    <li><a href="/vrcapstone19sp-team5/PRD">PRD</a></li>
  </ul>
</nav>

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
