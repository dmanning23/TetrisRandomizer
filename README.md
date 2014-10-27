TetrisRandomizer
==============

This is a bag randomizer for when you don't want pure random numbers.
For example, random numbers in games are actually not fun at all. Like in Tetris, the shape randomizer should only be sort-of random so the player doesn't get a bunch of S or Z pieces in a row. This code does the bag randomizing... give it a max number and call Next(), it will give a sort-of random number bewteen 0 and max num.

keep in mind for true TGM randomization, there are a few things needed... TGM randomizer should pre-seed the bag with SZSZ. Also it should never give S Z or O as the first piece. this stuff left as an "exercise for the reader" ;)
