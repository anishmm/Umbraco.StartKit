# Umbraco Starter Kit for Umbraco v11

This is a starter kit for Umbraco v11.1.0

[![NuGet version (UmbracoStartKit.Core)](https://img.shields.io/nuget/v/UmbracoStartKit.Core.svg?style=flat-square)](https://www.nuget.org/packages/UmbracoStartKit.Core/)


**In this starter kit you can see examples of:**

- Search Service
	@using Umbraco.StartKit.Core.Controllers.Surface
	@using Umbraco.StartKit.Core.Models.ViewModels
	// 
	var searchQuery = Context.Request.Query["q"];
    var page = Context.Request.Query["page"].ToString();
- Content form
