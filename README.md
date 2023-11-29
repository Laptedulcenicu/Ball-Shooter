# Ball-Shooter

![Screenshot_2](https://github.com/Laptedulcenicu/Ball-Shooter/assets/43432500/03f519e3-be64-4dcb-a21b-cc15216c90e0)

Task

Gameplay
On the screen, there is a ball-player in the bottom left corner, and the goal in the top right corner, where the ball should reach. Obstacles block the path. The player's ball creates shots based on its size; the path must be cleared for the player's ball to bounce along the cleared track towards the final goal.

Prototype
When tapping on the player's ball, a shot-ball starts to detach. The player's ball shrinks in size proportionally to the growth of the shot-ball's size and depends on the duration of the tap (the longer, the smaller). Upon release, the shot travels towards the goal, and upon colliding with the first obstacle, it "infects" obstacles within its radius, causing them to explode.
The shot's power - the "infection" radius - depends on the size of the shot-ball; the larger it is, the greater the radius. The closer the obstacles are to each other, the easier they are to infect. For isolated obstacles, small shots are needed to avoid depleting the entire size of the player's ball.

After clearing the area, the player's ball advances towards the goal. At the end, its size is reduced, but it should have enough space to navigate freely between obstacles, jumping through the center of the track. The track decreases in size along with the ball's size.

At the end, there should be a door. The door opens when the ball approaches within 5 meters of it.

If the player holds the tap for too long, and the player's ball completely transforms into a shot (pick a minimum critical size) - it's a loss. If there weren't enough shots to clear the path - it's a loss.

Initially, the ball's size should be more than enough with a 20% margin for completion.

https://github.com/Laptedulcenicu/Ball-Shooter/assets/43432500/d601508c-0835-49ea-afc8-459b5c835075

