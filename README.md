First of all I recommend changing your console color, for the best visual experience. If you don't know how follow the pictures bellow.
1. Right click.
2. Choose properties.
3. Go to color menu.
4. Select Background color.
5. Choose white color from the pallete.
6. Click OK / Finish
7. Now following the same steps change the TEXT Color to black




![First step](https://user-images.githubusercontent.com/77575817/172133894-6dc60363-0549-413a-832b-757bf9b8c559.png)




![Second step](https://user-images.githubusercontent.com/77575817/172134079-6de6a4af-3f3b-469e-9a2b-5964bb99e778.png)





Personally I am aware of three different variations of the rules, so if you play by a different rules, please understand.
The code of the game is basic implementation of the most importand rules and bonuses, there is much more to be implemented, so the game can be fully realistic.
Many on the bonuses are not here, but the most common are here:


1. 10 J Q (K) (K A)
2. (10) J Q K (A)
3. (9 10) (10) Q K A


I suggest to read the rules first, if you don't know them. - https://belot.bg/belot/rules/


The basics are:

1. Each player draws 5 cards.
2. Each player chooses type of game.
3. The biggest type of game wins, and the game is played by the current type's rules.
4. Each player draws 3 more cards.
5. Each player says if they have some kind of a bonus.
6. The game starts.

In my implementaion all of those things happen automatically, except the game type's choosing, which is the only user input needed.


The first part of the game:
1. Shows the first 5 cards in your hand.
2. You choose a game type.



![First step](https://user-images.githubusercontent.com/77575817/172137832-6530a963-5f36-4f1c-a007-39acfe0e2589.png)


The second part of the game:
1. The computer chooses game type.
2. Game is comparing game types.
3. Selected game type is shown on the console.
4. You and the computer receive three more cards each.
5. Bonus is collected (if any).
6. Each card in hand has it's own points which are collected.
7. Bonus and points are combined.
8. The game compares total sum of points for you and the computer.
9. Winner is choosen.


![Second Draw](https://user-images.githubusercontent.com/77575817/172138494-46c16679-8b24-4adc-8569-a7a8f0ef06a7.png)
