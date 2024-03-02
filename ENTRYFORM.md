# Hackathon Submission Entry form

> __Important__  
> 
> Copy and paste the content of this file into README.md or face automatic __disqualification__  
> All headlines and subheadlines shall be retained if not noted otherwise.  
> Fill in text in each section as instructed and then delete the existing text, including this blockquote.

You can find a very good reference to Github flavoured markdown reference in [this cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet). If you want something a bit more WYSIWYG for editing then could use [StackEdit](https://stackedit.io/app) which provides a more user friendly interface for generating the Markdown code. Those of you who are [VS Code fans](https://code.visualstudio.com/docs/languages/markdown#_markdown-preview) can edit/preview directly in that interface too.

## Team name
⟹ The Weel of the blackbull battles

## Category
⟹ Best use of AI

## Description
⟹ The “Smart User Carousel" is a hero carousel that use Leonardo AI to get images based on a pront, the idea of the component is get images easaly using AI and saved directly in the media library  for getting them then.


## Video link




## Pre-requisites and Dependencies


-Sitecore Management Services 5.2.113 https://dev.sitecore.net/Downloads/Sitecore_CLI/5x/Sitecore_CLI_52113.aspx

## Installation instructions

-Install Sitecore 10.3.1 standalone

-using the PS Script set the following in these variables:

 -- $Prefix = "wbb-hackaton"

 -- $SitecoreSiteName = "$prefix.local"

 -- $XConnectSiteName = "$prefix.xconnect"

### Run the installation process

-make sure your domain is like this one: https://wbb-hackaton.local/

-clone the main branch in a folder

-open the solution

-build the solution and restore the nuget packages

-using the Website project, deploy the project to the sitecore instance using the publishin process

-Open a PS Terminal in the root of the solution

-execute the following commands
-- dotnet tool restore

-- dotnet sitecore init

-- dotnet sitecore plugin init

-- dotnet sitecore login --authority https://wbb-hackaton.identityserver/ --cm https://wbb-hackaton.local/ --allow-write true

--- do the login process and close the window

-- dotnet sitecore ser push

install the following package in the sc instance

Smart Carousel Items.zip

--in in the folder .\scPackages\Smart Carousel Items.zip

-publish all website




### Configuration
⟹ If there are any custom configuration that has to be set manually then remember to add all details here.

_Remove this subsection if your entry does not require any configuration that is not fully covered in the installation instructions already_

## Usage instructions
⟹ Provide documentation about your module, how do the users use your module, where are things located, what do the icons mean, are there any secret shortcuts etc.

Include screenshots where necessary. You can add images to the `./images` folder and then link to them from your documentation:

![Hackathon Logo](docs/images/hackathon.png?raw=true "Hackathon Logo")

You can embed images of different formats too:

![Deal With It](docs/images/deal-with-it.gif?raw=true "Deal With It")

And you can embed external images too:

![Random](https://thiscatdoesnotexist.com/)

## Comments
If you'd like to make additional comments that is important for your module entry.
