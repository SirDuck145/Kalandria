# Kalandria
Kalandria is a passion project somewhere between a MOBA like DOTA 2 and a fast paced RTS such as Starcraft.
### Creating my own art
I love using blender and wanted to get faster at making models.</br>
Not only did I want to get faster, but I wanted more experience rigging my own creations.</br>
I saw someone make a model in ten minutes and got inspired.</br>
![Peasant getting rigged](Screenshots/RiggedPeasant1.png)
While this model took me more than ten minutes to create...
I was happy with the final result of the model, and I had managed to rig it.
Ultimately, I will be recreating this asset... but I figured I would showcase it a little.
![Posed Peasant](Screenshots/RiggedPeasant2.png)
### Main menu
At the moment the main menu is very simplistic.</br>
It has some temp art made by Mikael Gustafsson.</br>
As for features it currently has a play button which connects the user</br>
to the network using Photon Engine's pun.</br>
It then proceeds to load the next room, which is a simple lobby</br>
![Image of the main menu](Screenshots/Menu.png)

### Lobby
Currently the lobby is just a waiting room for a second player to connect</br>
Once the second player is in, the next room will be loaded.</br>
However for testing purposes I created a dev button which can be pressed to load it immediately</br>
![Image of the Lobby](Screenshots/Lobby.png)

### Test Room
This is the very barest of bones for a test room</br>
It simple has the beginnings of each players base,</br>
as well as the player themself who is able to pan around the scene in classic rts style.</br>
The panning itself is highly modifiable, even allowing the player to change the margins at which the camera pans.</br>
![A very ugly test room](Screenshots/TestRoom.png)


## Map(Plan)
The map will be set, something of a similar style to a MOBA map<br/>
On opposite sides of the map each player has a base<br/>
Units can be spawned at each base, they walk along the lanes<br/>
The map will have multiple "Control points" which add cards to the players deck<br/>

## Card Overview(Plan)
The player will have a hand of cards<br/>
These cards can be played for mana which is generated<br/>
every set period of time, for now say every two seconds<br/>
Ever card has a manacost, image, text.<br/>
*Example card 1: Warrior, costs 2 mana, spawns a warrior to walk down a lane*<br/>
playing the card onto a lane targets that lane<br/>
*Example card 2: Rain, costs 1 mana, Lowers soldier moral in an area. (Soldiers can rout I guess idk)*

## Roadmap
First design a simple map with one single lane, no points of holding<br/>
The map will simply have two opposing bases.<br/>
Second implement the warrior card, with no mana cost<br/>
Implement Mana cost, get it to work with the warrior.<br/>

