# Ultimate-Maps-forged-alliance

1) finish your map (hightmap, decals, mex positions,...)

2) download the latest version of the script

3) add the _script.lua, _options.lua and _tables.lua file to your map

4) rename everything properly and adjust the path at the beginning of _script.lua
   (be careful, the map will be automatically renamed when you upload it.
    Take that into account for the path, if it is wrong, the map wont work.)
    
5) Open the map and select the mex/hydro you want to link to a player 
   (i.e. player 3)

6) Add their number to the _tables.lua file (in this example) at the 
   3rd line of the table

-- dynamic spawns work now --

7) Select the mexes you want to have spawnable by options and 
   add them to the _tables.lua file

8) go to the _options.lua file and move the option you need over 
   the commentblock
8.1) if your default option doesnt have key = 1, change the default in 
     the script too (at the top, i.e. local middlemex = Scenario... or 1)
     
-- custom options work now --

9) add wrecks to your map and add them to "ARMY_17", put them in 
   different groups (i.e. Optional_Wreckage_2)
   
10)uncomment the option

-- spawnable reclaim works now --

11) add some area definition to your map

12) -> options file, maybe look at the code a bit to adjust it to your map
    (ask CookieNoob to help you)

-- map expansion to larger area works now --

13) add "AdaptiveMap = true," to the scenario.lua file (this will enable a special version of "closed spot")



you can still change the map and add decals or even change the hightmap

if you add mexes and remove some, dont forget to adjust the table!
