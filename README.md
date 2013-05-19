# ReadySet

Ready set is a launcher for Windows that will allow you to launch any application that is in your path, open a document in its default application or run a [PowerShell](http://www.microsoft.com/powershell) command.

## Usage

Once ReadySet is running you can use the following key combination to bring up the launcher `Shift+Win+C`. When the launcher is active you can use `Shift+Ctrl+P` to switch to running a PowerShell command and `Shift+Ctrl+C` to switch back to the generic command runner.

## Prerequisites

To run ReadySet you will need the Microsoft .NET framework 4.5 installed, if you don't have it you can download it from [here](http://www.microsoft.com/en-US/download/details.aspx?id=30653).

## Future Plans

* Build in the ability to start the application when the user logs in.
* Give the user the ability to set their preferred default runner.
* Move to plugin based architecture to make it easier to add new command runners.
* Add auto-completion.
* Add a command history on a per-runner basis.
* Ability to customise the global hot key.

## 3rd Party

ReadySet uses some 3rd party libraries to achieve its functionality:

* [WPF NotifyIcon](http://www.hardcodet.net/projects/wpf-notifyicon)

The runner in the icon was retrieved from [The Noun Project](http://thenounproject.com/noun/running/#icon-No246) and is published under a Public Domain Mark.

## Bugs

If you come across an error/bug while using ReadySet feel free to let us know at our [github repository](https://github.com/mlowen/ReadySet/issues).

## Contributing

ReadySet is an [open source](http://en.wikipedia.org/wiki/Open_Source) project released under the MIT license, if you want to contribute feel free to fork the [ReadySet GitHub repository](https://github.com/mlowen/ReadySet).

## License

ReadySet is available under the MIT license which is as follows:

Copyright © 2013 Michael Lowen

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.