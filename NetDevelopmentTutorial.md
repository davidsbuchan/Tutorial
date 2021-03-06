.Net Development Tutorial
=========================

Introduction
------------

This document should take the reader through different .Net development techniques.
By the end of it you will have developed an application, a windows service, and a web service.
Technologies covered will be Threading, Exception Handling, Logging, Configuration, different patterns, Windows Workflow, Unit Testing.

Version Control
---------------

Throughout this document you will use Git for version control. Although SSE uses TFS for version control, using Git will give a better understanding of the likely scenarios you will come up against

### Git Intro

Git is an open source version control system used in very large projects. It can also be used for single person tiny projects.
Source repositories are stored locally along with the application being developed. They can also be stored remotely on a central server for collaborative work (although we won�t be using this method)
**Note**: The complete history of your application is stored in the hidden .git directory at the root folder of the application (or wherever you executed git init command). Therefore if you delete this directory, or the parent directory you lose everything.
Please see https://git-scm.com/docs/gittutorial for a more complete tutorial on using Git.

```git init```

The git init command initialises the repository in the location where the command was executed (usually the root of the application).

```git status```

The git status command shows the current status of the working code on the working branch. It shows any untracked changes, Changes to be committed, 
*Untracked Changes*
These are files and directories that the git repository does not know about and so changes to these files cannot be tracked.
*Changes to be committed*
These are files and directories that are known by git and can be checked into the repository.
*Changes not staged for commit*
These are files that are currently tracked, and have been changed but have not been �staged�, therefore will not be committed on a git commit.

```git commit```

This command is used to commit any changes to the repository in whatever branch you are in (branches will be described later). 
If you don�t know VI (what's wrong with you), it might be wise to either change the default editor or use the commit command in the following way:

```git commit -m "[place comment here]"```

This will perform a commit on all the staged changes and it will apply it to the repository.

```git add [file or files]```

This adds files to the stage area that are currently not being tracked or are being tracked, but are not staged for a commit.

```git log```

This displays the history of the current branch.

### Git Exercise 1
Go through the following steps noting the changes between each step
1.	Download and install git
2.	Open up a command prompt and type git to ensure that it is installed
3.	Go to an empty directory
4.	Type git init
5.	Create a text file in notepad and type something
6.	Save the file
7.	Type git status
8.	Type git add .
The "." means add all untracked files
9.	Type git commit -m "Initial version"
10.	Type git status
11.	Type git log

Make further changes to the file and see how the log changes.
Create other files and add them to the repository either by using git add . or git add [filename].
See how they appear in the log.

### Branching
Branching is the act of creating a pseudo copy of the repository and making changes to this branch and having those changes not affect other branches (copies).

```git branch```

This command lists all the branches in the repository. It also shows which branch is the current branch in use.

```git branch [name]```

This command creates a new branch with whatever name you choose. Please note that simply creating a branch does not make the new branch the current working branch.

```git checkout [name]```

This command changes the working branch to the branch specified in the name.

**Note**: This occurs even if there are staged or unstaged changes. The staged and unstaged changes are not lost when changing to a different branch. The changes appear in the same state when the git status command is used.

### Git Exercise 2
1.	Type git branch
2.	Type git branch development
3.	Type git checkout development
4.	Edit a file
5.	Commit the changes using the techniques in Exercise 1
6.	Type git checkout master
7.	Open the file changed in step 4. Ensure the changes applied are no longer there.
8.	Type git checkout development
9.	Open the file changed in step 4. Ensure the changes have reappeared.

### Merging
Merging is the process of taking changes in one branch and merging them with another branch. This allows initially buggy development to be checked in without harming the production environment. And then only applying the thoroughly tested code into the master branch when happy with it!
*Note*: To merge changes you must be in the destination branch.

```git merge [name]```

This attempts to merge the differences between the named branch and the current branch.
Note: If the changes are simple then by default they will be checked in immediately.

```git merge --no-commit --no-ff [name]```

(please note that there are 2 dashes before no-commit and no-ff)
Use this command to merge changes to another branch, but not to commit immediately.

### Git Exercise 3
1.	Type git checkout development
2.	Edit and save a file
3.	Type git add [file]
4.	Type git commit -m �appropriate comment�
5.	Type git checkout master
6.	Type git merge development
7.	Look at the updated file
8.	Type git checkout development
9.	Edit and save a file
10.	Type git add [file]
11.	Type git commit -m �appropriate comment�
12.	Type git checkout master
13.	Type git merge --no-commit --no-ff development
14.	Type git status
15.	Open the file in notepad

### Differences
Reading the differences between versions of files is an important skill. 

```git diff [filename]```

This command shows the difference between the filename listed and the latest version in the current branch of the repository
This may be difficult to read and understand but it is in a standard format (used by the linux patch command), so take time to attempt to understand it.

```git diff [commit] [commit]```

The [commit] options are the identifiers for 2 different commits. Get these via the git log command

### Conflicts
Fdsafds

### Rolling back
Fdsafdsa

### Ignoring files
By default git will notice all files in the root directory of the repository (the directory with the .git folder) and all sub-directories.
To stop this clutter of information on commands like `git status` you can create a `.gitignore` file and populate it with information on what to ignore. It's best to google what should go in here as it can get quite complicated.

Normally you would want to ignore all binary files

#### .gitignore file
put the following text in a file called .gitignore and place in the root directory of the repository
```
*.exe  
```

Now where you do `git status` any exe file will be ignored. But the .gitignore file will appear!!! Check this in as well as part of the source.

*Note*: Most of this crap is very idiosyncratic

### Visual Studio
Visual studio has got comprehensive source control integration, but for this tutorial I suggest doing manual source control management got get a good understanding on how it works.
Visual Studio express is a free version of Visual Studio that can do most things that you would ever require.
Introduction
When creating a new project several files get created
1.	Solution file
This file has a file extension of .sln. This is the file that you double click on to open the whole project in Visual Studio. Multiple projects can be contained in a single solution file.
2.	Project file(s)
Project files .proj, are stored in directories that hold all the information about that project. 
3.	Code files
We are going to be writing in C# therefore the extension is .cs. These files hold the actual code that you�ll tippy tappy type!
There are other files, but we�ll go over them if and when required.

### Code Basics
We�re going to start off using notepad and the command line, then when it has become significantly complicated, we�ll move onto using Visual Studio
#### HelloWorld.cs
```
namespace Sse.EnergySystems.Sandbox
{
  using System;
  
  public class HelloWorld
  {
    static void Main(string[] args)
    {
      Console.Out.WriteLine("Hello World!");
    }
  }
}
```
Type the above into a texteditor and save it as HelloWorld.cs in a directory. Make this a new directory with nothing in it.
#### Compile and execute
In a command prompt (visual studio command prompt or one with csc.exe in the path) type the following.

```csc HelloWorld.cs```

A HelloWorld.exe file should be created. Type in

```HelloWorld.exe```

Hello World! should appear in the command prompt.

Now create a git repository in this directory and add this file to the repository and commit the changes.

### Build
We are going to use make to control our build process to start off with. Visual Studio can do all this for us (using a much more complex XML based build system, but then we wouldn't learn anything if we allowed Visual Studio to do everything for us)
You can download GNU make for windows. Or if you have visual studio you should already have nmake installed.
#### makefile
Create a file called ```makefile``` in the same directory as HelloWorld.cs with the following text in it:
```
all:
  csc HelloWorld.cs
  
clean:
  del *.exe
```
Please note the csc and del lines should be indented (I've chosen double space).

In the command prompt type ```nmake clean```

The executable file should get deleted. Now type

```nmake```

The executable HelloWorld.exe should be recreated. **Note** the first label that appears in the file is the one that gets executed by default. (google makefile to learn more about it).
You can also type

```nmake all```

To explicitly execute the all label

Briefly, makefiles are dead simple, they are made up of

```
label: dependecyLabel
  command
```

Where the commands are indented and dependencyLabel points to another label in the file. As we go on we'll build on this makefile.
### Hello World 2
Next we're going to create a simple windows forms application.

Make sure everything is committed to the git repository and that there is nothing outstanding.

Branch a development branch and checkout so that the new development branch is the active branch

Update HelloWorld.cs with the following:

```
namespace Sse.EnergySystems.Sandbox
{
  using System;
  using System.Windows.Forms;
  
  public class HelloWorld : Form
  {
    [STAThread]
    static void Main(string[] args)
    {
      Application.Run(new HelloWorld());
    }
  }
}
```

We've added a new line ```using System.Windows.Forms;```. This line adds a reference to the .Net Windows Forms assembly which is required for windows forms applications (obviously).
Next is the addition of ``` : Form``` to the end of the line ```public class HelloWorld : Form```. This changes the class to say that the type HelloWorld *inherits from* Form. Or to put it another way **HelloWorld is a Form**.

```[STAThread]``` tells .Net the threading model to use for this application. Google it if you want, it's not desparately important.

Finally ```Console.out...``` has been changed to ```Application.Run(new HellowWorld());```. This tells .Net to create a new HelloWorld instance and do some magic behind the scenes.

Save the file, type ```nmake```, then type ```HelloWorld.exe``` and up should pop a new blank window.

#### Lets add a button
Update HelloWorld.cs

```
namespace Sse.EnergySystems.Sandbox
{
  using System;
  using System.Windows.Forms;
  
  public class HelloWorld : Form
  {
    private Button button;
  
    public HelloWorld()
	{
	  BuildForm();
	}
  
    [STAThread]
    static void Main(string[] args)
    {
      Application.Run(new HelloWorld());
    }
	
	public void BuildForm()
	{
	  button = new Button();
	  button.Text = "Hello World!";
	  Controls.Add(button);
	}
  }
}
```

Things to note: ```public HelloWorld() {...}``` This is a class constructor and is executed when a new instance of the type is created via the ```new``` keyword. As this has no parameters (nothing inside the ```()```) it is classed as the *default* constructor.

#### Make the button do something
Actions in windows forms are generally done via events.

```
namespace Sse.EnergySystems.Sandbox
{
  using System;
  using System.Windows.Forms;
  
  public class HelloWorld : Form
  {
    private Button button;
  
    public HelloWorld()
	{
	  BuildForm();
	}
  
    [STAThread]
    static void Main(string[] args)
    {
      Application.Run(new HelloWorld());
    }
	
	public void BuildForm()
	{
	  button = new Button();
	  button.Text = "Hello World!";
	  
	  button.Click += ButtonClickMethod;
	  
	  Controls.Add(button);
	}
	
	private void ButtonClickMethod(object sender, System.EventArgs e)
	{
	  MessageBox.Show("Hello World!");
	}
  }
}
```

Things to note. ```button.Click += ButtonClickMethod;``` basically means when the Click event happens, execute the method called ButtonClickMethod. ButtonClickMethod has to have the same number and types of parameters that the Click event expects.