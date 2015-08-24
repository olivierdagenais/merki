# Server Side #
  1. Create a new Mercurial repository
  1. Publish the new repository
    * e.g. right-click on it and select "Web Server..." and hit start

## Troubleshooting ##
  * Configure the web server as follows:
    * Push Requires SSL => false
    * Allow Push => 

# Client Side #
  1. Compile the solution, copy the binaries somewhere (c:\Program Files\Merki for example)
    * Requires Visual Studio 2010, Express will do
  1. Launch Merki, which will ask for a repository to clone
    * Give it the URL from server step #2

## Troubleshooting ##
  * Ensure "hg", the command-line client, is on the path
    * Having [TortoiseHg](http://tortoisehg.bitbucket.org/) installed should do this automatically