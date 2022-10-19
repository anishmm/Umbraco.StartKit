# Umbraco Starter Kit for Umbraco v10

This is a starter kit for Umbraco v10


## If you want a really quick way to get it installed and test it out
Make sure you have downloaded the latest [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0), then copy and paste this into Command Prompt or Windows Terminal or whatever you use:

```
# Ensure we have the latest Umbraco templates
dotnet new -i Umbraco.Templates

# Create solution/project
dotnet new sln --name MyWebsite
dotnet new umbraco -n MyWebsite --friendly-name "Admin User" --email "admin@admin.com" --password "1234567890" --connection-string "Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Umbraco.mdf;Integrated Security=True"
dotnet sln add MyWebsite
dotnet add MyWebsite package UmbracoStartKit

For better SEO 
````````````````
# Install Meta Momentum package 
Install-Package MetaMomentum.Core -Version 2.1.1
Uncomment Master.cshtml -> @await Html.PartialAsync("MetaMomentum/RenderMetaTags", Model.Value("metaData"))

# Run
dotnet run --project MyWebsite

```
**In this starter kit you can see examples of:**

- Blogs
- Case Study
- Search
- Content pages
- Xml Site Map
- Simple Contact Form
	- Configure SMTP details in appsettings.json

I'm sure there are other things too, but have a play anyway.
