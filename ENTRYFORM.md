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

# Generate Carousel

The **“Smart User Carousel”** component requires a data source to generate the carousel images automatically. The data source has information like the prompt and the number of images to generate.
To create a new generation data source you need to create an item using the **“Hero Carousel AI”** template. In the following example we are going to generate 4 images for our carousel.

 1. Create a new **“Hero Carousel AI”** item. In the next example the item is going to be created in the Data directory and its purpose is to generate a carousel for a music store page.**![](https://lh7-us.googleusercontent.com/y9obKyte3svEOv_TNT57p2f1rM4bU-A0wI53pgoknOzY5dCQVODbBCOn9yDbbu_Ttt-AflBLXOrFlxafCEbrUk_a0ZWNAPVggSiRvg0R3vQhOPCC-ETNk8KiWeYwH9ZPgPZItWE68iC08gpM5GO968w)**
 2. Set the values for generating the images. The prompt should describe what kind of images you want to generate. The height and width properties must be multiples of 8. The image creative model is going to define the model that Leonardo.ia is going to use for generating the images (refer to [Leonardo Ai Finetuned Models - Leonardo.Ai](https://app.leonardo.ai/finetuned-models) for more information).**![](https://lh7-us.googleusercontent.com/ktBT__M18mqyiI-wmbE1oUHMeQvkH1YmNdA6yOmXvSQ0EN7NSzxaPltCCP90gn_nHXZpcIr3rc0-WG-FGpkUQMDDcK3O2NVb6hFIHhJs8kUdRBPC7r1mYkM5OfTBtQyXtYbCwXiCvs0VAgzV8Hw_f4s)**
 3. Insert the “Smart Carousel” rendering using the data source item created on the previous step to generate the group of images.**![](https://lh7-us.googleusercontent.com/I2T2zVkJOvzLL9mFL8RYTOkFVNYpAPhY4izOLeHLD7YqRKoWQOcgiZ6yDDD8wP1nC3VTu3EvduoCkVJVHYGGbLwYw9fkN1PH-8-rLSgiSv3Keg81aFPPcHmBVLTPLhJvxJuAILCXT5JlGCCYQlgi81Y)**
 4. Navigate to the page, the images are going to be automatically generated.**![](https://lh7-us.googleusercontent.com/VGRabwyiZogWeaF_e7PPphIHPuLursVbuEJ5JjvCClrrNKU0GQx8EEFKf2OPMzEEL1l5P_UkHh5RbGhKvKtDl-cnSapdakdDMWLmRbLfkajCzwustgg15037QT9k5yO0a9DBkFMtCYWSxIFNRm0jWpg)**
 5. Select the images that you want to preserve for the final carousel and click save.**![](https://lh7-us.googleusercontent.com/OZtK_6EO3-8GqgIsS4D0BNE0YpzTDiGwytsmOrEieguzfyqdRuMOPRYIOKYlWUWNAeRuXAC70hPeCDNpucq0G6UAItndmhOPqQhNOjWAuneiEHu_I6LFz01SskjEPkPUAGhyyCVj7sGJ4Y1qktew_ws)**
 6. The images are going to be created on your media library as well as the data source item that can be used on the final render.**![](https://lh7-us.googleusercontent.com/CDo0K5Zd06u0gUIbf18TlMTo6oAUpCBcxVkPMFCiIOLEy20ivcowFU43c6GXPjkx6CEuAd0oXY3Tt1gxvm2Z_E5lprH-KvM4L8c9-WAeISA8h8lW-o_1ST2ru_gnbXITVVTrAbL3WisRl5YrzCYmrn8)****![](https://lh7-us.googleusercontent.com/fD3JcysHd9fLVDuY5Ne-bEitQlqv1pQSZU2cv4XJSqoqq9W3HD85ux7u8XhFMJ6KDUqqulZVC99sOdExdIj33J9QJtJjDrtvNSJdvX0wLpTHLfMQJftX1E9iKBRhfVoXXhqB5bYPePDGgtVO88EeM9I)****![](https://lh7-us.googleusercontent.com/ofZsL2zU3oblJJbgZWTAjUHAUm58AWDjhCtAvYqBLmkivUBKS5i8AjeGYOepySeGXmycChFK0K-ALxZ5iMb4MgDnFARm0zFAetZD8mqOMPXEUl2NrMdhPwglvo_m1B-mM-Gf4F5RGQFfg3nPQ41DnIk)**
 7. Insert the **“User Smart Carousel”** using the data source generated on the previous step.**![](https://lh7-us.googleusercontent.com/s3kklmIvMVek2gsRqHbGeZieNsDU06rgj-I6yk9Ny7fyi3ee_SbtkG3IAHtmmO_0Mx6l1c5rQWV0segb6HGkixA1nkXXWS95d4bnHb3OblGOj3EYeBvhbXHeYxQ3KRZ-wWiXkBJyAEatuFb4pXqsylA)**
 8. The carousel will display the generated images.**![](https://lh7-us.googleusercontent.com/BH68ZP8iXRx4alis2iEtU1xlTE6C0FD4XSoU3UjgOOoQIT0SvfndYZkeapSCVTBiscgwNaZt3fTfDT3duL97VfeT3tTaehW8y3kitnZ7rgTHfF9bLFygQE5dRinnBeUNLvlieCYoBNLL3pn2I4Qk98Q)**



## Comments
If you'd like to make additional comments that is important for your module entry.
