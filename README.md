
## My Refactoring steps: (For details, please referece each commits in github)
- Check solution files. 
- Move out Item into its own class. (Not allowed to touch)
- Tidy up a bit in Main method.
- Before touching main business logic, analysing the code by writing unit tests. 
	(Build a safety net, make sure tests have 100% code coverage of the main business logic)
- Based on unit tests, start doing code refactoring.
	- Introducing IOperation interface and NormalItem class to manage the most common scenario. (taking the parts out, rerun corresponding tests)
	- Other speical classes are derived from NormalItem, override UpdateQuality method to meet the requirments. 
- Add logic to validate user input. (Quality is between 0 and 50, Name can't be empty)
- Add one more level of abstraction by introducing AbstractItem class. 
- Remove code duplication, move common parts of logic (ex. UpdateSellIn..etc) into AbstractItem class. (Rerun all tests, make sure it stays in Green)
- Add app.config to allow easy adjustment to Quality range. (Set QualityMin=0, QualityMax=50)
- Mionr changes to project file structure, moved DefaultQualityModifier into settings, added new property HasSellInPassed. 


## Todo:
- Logging?
- ItemFactory?


# Gilded Rose Refactoring Kata

Hi and welcome to team Gilded Rose. As you know, we are a small inn with a 
prime location in a prominent city ran by a friendly innkeeper named 
Allison. We also buy and sell only the finest goods. Unfortunately, our 
goods are constantly degrading in quality as they approach their sell by 
date. We have a system in place that updates our inventory for us. It was 
developed by a no-nonsense type named Leeroy, who has moved on to new 
adventures. Your task is to add the new feature to our system so that we 
can begin selling a new category of items. First an introduction to our 
system:

- All items have a SellIn value which denotes the number of days we have 
to sell the item
- All items have a Quality value which denotes how valuable the item is
- At the end of each day our system lowers both values for every item

Pretty simple, right? Well this is where it gets interesting:

- Once the sell by date has passed, Quality degrades twice as fast
- The Quality of an item is never negative
- "Aged Brie" actually increases in Quality the older it gets
- The Quality of an item is never more than 50
- "Sulfuras", being a legendary item, never has to be sold or decreases 
in Quality
- "Backstage passes", like aged brie, increases in Quality as it's SellIn 
value approaches; Quality increases by 2 when there are 10 days or less 
and by 3 when there are 5 days or less but Quality drops to 0 after the 
concert

We have recently signed a supplier of conjured items. This requires an 
update to our system:

- "Conjured" items degrade in Quality twice as fast as normal items

Feel free to make any changes to the UpdateQuality method and add any 
new code as long as everything still works correctly. However, do not 
alter the Item class or Items property as those belong to the goblin 
in the corner who will insta-rage and one-shot you as he doesn't 
believe in shared code ownership (you can make the UpdateQuality 
method and Items property static if you like, we'll cover for you).

Just for clarification, an item can never have its Quality increase 
above 50, however "Sulfuras" is a legendary item and as such its 
Quality is 80 and it never alters.
