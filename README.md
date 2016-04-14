# SparkleSharp

C# bindings for Sparkle

## Installation instructions

- Install Xamarin Studio 6 or greater (currently in the Beta channel)
- Clone this repository (preferrably as a submodule in your main project)
- From your Xamarin.Mac project, right click on the solution and select *Add* -> *Add Existing Project* and select **Sparkle.csproj**
- Right click on your Xamarin.Mac project's References and select *Edit References*
- Go to to *Projects* tab and check the box for the Sparkle project
- Right click on your Xamarin.Mac project and select *Options*
- Go to the *Build* -> *Mac Build* submenu
- In *Additional mmp arguments* enter **--link_flags="-Wl,-rpath -Wl,@loader_path/../Frameworks"** - remember do to this for all your project configurations
- Finally, follow [Sparkle's own documentation](https://sparkle-project.org/documentation/) to set your appcast URL and add a "Check for Updates" menu item
