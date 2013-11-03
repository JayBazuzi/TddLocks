TDD and Thread Safety
=========

A common question when first learning about Test-Driven Development is "How do I test multithreaded code?".

This repository is my exploration of that question, inspired by some work I did with my team way back in 2004 
(http://blogs.msdn.com/b/jaybaz_ms/archive/2004/05/06/127480.aspx) and a more recent video by Venkat Subramaniam 
(http://www.agilealliance.org/resources/learning-center/test-driving-and-unit-testing-thread-safety).

As for the approach, just about any time someone says "TDD on X is hard" the correct response is "Refector to 
decouple it". In this case, I decoupled the thread-sensitive functionality from the locking mechanism.

Branches
======
The `master` branch represents the initial problem.

`traditional-lock` is the conventional solution, of surrounding the thread-sensitive code with a `lock` statement.

`CyrusN-ILock` is the abstract locking mechanism that we came up with 9 years ago. We didn't know how to TDD back then. This time, I did it test-first all the way.

`IDisposableLockToken` modifies the `CyrusN-Ilock` with some other ideas.

Coding practices
=======

I stuck to a strict RED/GREEN/REFACTOR cycle.

I used nCrunch to make the edit/build/test cycle as fast as possible. 

Every time I made a change, I check in, typically in the following forms:

    RED: FooShouldBar

Introduced a new test. The description need only be the name of the test, if the test is well-named.

    GREEN: FooShouldBar

Made this test pass. Usually the name of the test sufficient, since the actual implemenation is either trivial or 
ugly, or both.
    
    REFACTOR: Extract Method `Baz`

I strive to use small, automated refactorings. Therminolgy for this description comes from Fowler's [Refactoring 
Catalog](www.refactoring.com/catalog/).

In my commit history, I see that the time between commits varied widely. Sometimes I needed to think about my next
step; sometimes my kids got my attention. Sometimes I took a big step. But when things were going smoothly, I could 
make a change and commit in a minute or two.
