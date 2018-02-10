# WEAK
WEAK stands for Write Easily Application Kit. As many others it is a framework designed to help you build rich application by providing custom implementations of commonly used patterns in software development.

WEAK stands for Write Easily Application Kit. As many others it is a framework designed to help you build rich application by providing custom implementations of commonly used patterns in software development.

# Why WEAK ?
Through my job as a developer, I have used many different frameworks but none of them really suited my own preferences, be it too much verbose to use, awkward set up, or just questionable performance. As such I began working on my own framework for my personal projects and WEAK was born.
Though it started as a WPF framework (at first it meant WPF Easy Application Kit !), it became apparent that lot of functionality were not inherent to WPF and the acronym changed signification. The letters WEAK remained, faithful to the main idea behind the framework to handle all references as WeakReference, removing many burdens on the developer for event hook up and other well hidden strong references in complex project resulting too often in memory leaks while still giving a high performance.
Due to its root, WEAK also provide a specialised library for WPF development containing my own idea of the MVVM pattern, commonly used converters, useful markup extensions, attached properties and controls.

# What is in WEAK ?
As for now, WEAK is divided between two libraries, a core WEAK library usable anywhere and a WPF specialised WEAK.Windows library.

WEAK
- Publish-subscribe pattern: high performance intra-application message dispatcher using types as topic, retaining no references on subscribes with different modes of publishing, synchronous, asynchronous for short and long operations (TPL) or using a SynchronizationContext (usually for UI operations)
- Inversion of control pattern: link implementation to interface, a factory handles creations of instance and inject needed parameters in constructor, working in tandem with a set of classes to ensure singleton instance or multi instances, with no strong references retained as always
- Command pattern: undo-redo engine with most used actions built-in, wrapper for list, dictionary and collection, easily extensible
- WIP

WEAK.Windows
- WIP

# Where to with WEAK ?
Since I am building it along my personal projects, other features are still work in progress (mainly a module solution and most of the WEAK.Windows library). A stable release of the core WEAK library should arrive soon as I am close to finishing the first batch of items for it.
Like a lot of people, I have lot of ideas but not much time so things may  move a little slow but I will get there eventually !
