# AsyncPlayground #

I never really caught on to using ```Async``` properly, so I created this project for my own edification. The ```AsyncPlayground``` library has simple examples of most functions of ```Async``` you could create. If you poke around you will see some of the results of my decompiling to investigate the generated IL. I intended to turn my investigations into an article, but never got around to it.

## Key take-aways: ##

- Once you commit to ```Async``` it's computation expressions all the away up and down your code, which limits your coding style and restricts your ability to use the functional coding paradigms you would like to use, unless you short-circuit the situation by resorting to ```Async.RunSynchronously``` (see the next bullet point).
- A lot of the literature you will find on ```Async``` resorts to using ```RunSynchronously``` precisely because of the situation I described above. This is fine for many use cases, but beware of introducing this into certain production code situations because ```RunSynchronously``` is blocking, hence you may loose the entire benefit you were trying to gain with ```Async```, and it introduces quite a bit of computational overhead. Most of the time (that is in the cases where you want ```Async``` to not block the thread), you probably want to use ```AwaitTask```...and you are now committed to coding in the computational expression style. THIS IS SELDOM EXPLICITLY EXPLAINED IN THE LITERATURE.

## Reading ##

There are lots of articles and books that explain ```Async```. They may work for you. Personally, I had to create this project to solidify my understanding (encapsulated in *Key take-aways*).

I suggest bookmarking the MSDN articles on "Computation Expressions" and "Async", and return to them again and again until you get it.

[Computation Expressions](http://msdn.microsoft.com/en-us/library/dd233182.aspx)

[Asynchronous Workflows](https://msdn.microsoft.com/en-us/library/dd233250.aspx)

[Control.Async<'T> Type](http://msdn.microsoft.com/en-us/library/vstudio/ee370518.aspx)

[Control.Async Class](http://msdn.microsoft.com/en-us/library/ee370232.aspx)














