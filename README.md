# Patterns
A sandbox for the testing and storage of useful software patterns.

## Recursion

Towers Of Brahma (or Hanoi)
This is a famous recursion problem and the pattern I am using is the most basic use of recursion to solve it.

## Strategy Pattern  
The strategy pattern helps mitigate the tight coupling inherent in the use of static methods. For example take 
this method
```
    public static string HasWithin(string searchFor, string searchWithin)
    {
        // implentation //
    }
```
There is no way to replace the use of that static method when trying to mock items within a test project.
Using the Strategy pattern we can implement a way to inject a different implementation during a test projects
execution.
![alt text](http://java.dzone.com/sites/all/files/strategy_pattern.png)

Here is the main method for using the strategy:
```
    public static T For<T>() where T : class, IStrategy
```
then to use the method:
```
    Strategy.For<IStringSearch>().HasWithin(searchFor, searchWithin)
```