//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder.Embedded v10.2.1+25a20cf
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Infrastructure.ModelsBuilder;
using Umbraco.Cms.Core;
using Umbraco.Extensions;

namespace Umbraco.Cms.Web.Common.PublishedModels
{
	/// <summary>Blogs</summary>
	[PublishedModel("blogs")]
	public partial class Blogs : PublishedContentModel, IBasicDetail
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "10.2.1+25a20cf")]
		public new const string ModelTypeAlias = "blogs";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "10.2.1+25a20cf")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "10.2.1+25a20cf")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public new static IPublishedContentType GetModelContentType(IPublishedSnapshotAccessor publishedSnapshotAccessor)
			=> PublishedModelUtility.GetModelContentType(publishedSnapshotAccessor, ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "10.2.1+25a20cf")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(IPublishedSnapshotAccessor publishedSnapshotAccessor, Expression<Func<Blogs, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(publishedSnapshotAccessor), selector);
#pragma warning restore 0109

		private IPublishedValueFallback _publishedValueFallback;

		// ctor
		public Blogs(IPublishedContent content, IPublishedValueFallback publishedValueFallback)
			: base(content, publishedValueFallback)
		{
			_publishedValueFallback = publishedValueFallback;
		}

		// properties

		///<summary>
		/// Pin Blog
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "10.2.1+25a20cf")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("pinBlog")]
		public virtual global::Umbraco.Cms.Core.Models.PublishedContent.IPublishedContent PinBlog => this.Value<global::Umbraco.Cms.Core.Models.PublishedContent.IPublishedContent>(_publishedValueFallback, "pinBlog");

		///<summary>
		/// Breadcrumbs
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "10.2.1+25a20cf")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("breadcrumbs")]
		public virtual string Breadcrumbs => global::Umbraco.Cms.Web.Common.PublishedModels.BasicDetail.GetBreadcrumbs(this, _publishedValueFallback);

		///<summary>
		/// Description
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "10.2.1+25a20cf")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("description")]
		public virtual string Description => global::Umbraco.Cms.Web.Common.PublishedModels.BasicDetail.GetDescription(this, _publishedValueFallback);

		///<summary>
		/// Hide From Search
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "10.2.1+25a20cf")]
		[ImplementPropertyType("hideFromSearch")]
		public virtual bool HideFromSearch => global::Umbraco.Cms.Web.Common.PublishedModels.BasicDetail.GetHideFromSearch(this, _publishedValueFallback);

		///<summary>
		/// Hide From Site Map
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "10.2.1+25a20cf")]
		[ImplementPropertyType("hideFromSiteMap")]
		public virtual bool HideFromSiteMap => global::Umbraco.Cms.Web.Common.PublishedModels.BasicDetail.GetHideFromSiteMap(this, _publishedValueFallback);

		///<summary>
		/// Hide From Xml Sitemap
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "10.2.1+25a20cf")]
		[ImplementPropertyType("hideFromXmlSitemap")]
		public virtual bool HideFromXmlSitemap => global::Umbraco.Cms.Web.Common.PublishedModels.BasicDetail.GetHideFromXmlSitemap(this, _publishedValueFallback);

		///<summary>
		/// Meta Data
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "10.2.1+25a20cf")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("metaData")]
		public virtual global::MetaMomentum.Models.MetaValues MetaData => global::Umbraco.Cms.Web.Common.PublishedModels.BasicDetail.GetMetaData(this, _publishedValueFallback);

		///<summary>
		/// No Index No follow
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "10.2.1+25a20cf")]
		[ImplementPropertyType("noIndexNoFollow")]
		public virtual bool NoIndexNoFollow => global::Umbraco.Cms.Web.Common.PublishedModels.BasicDetail.GetNoIndexNoFollow(this, _publishedValueFallback);

		///<summary>
		/// H1 Title
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "10.2.1+25a20cf")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("pageTitle")]
		public virtual string PageTitle => global::Umbraco.Cms.Web.Common.PublishedModels.BasicDetail.GetPageTitle(this, _publishedValueFallback);

		///<summary>
		/// Search Engine Change Frequency
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "10.2.1+25a20cf")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("searchEngineChangeFrequency")]
		public virtual string SearchEngineChangeFrequency => global::Umbraco.Cms.Web.Common.PublishedModels.BasicDetail.GetSearchEngineChangeFrequency(this, _publishedValueFallback);

		///<summary>
		/// Search Engine Relative Priority
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "10.2.1+25a20cf")]
		[ImplementPropertyType("searchEngineRelativePriority")]
		public virtual decimal SearchEngineRelativePriority => global::Umbraco.Cms.Web.Common.PublishedModels.BasicDetail.GetSearchEngineRelativePriority(this, _publishedValueFallback);

		///<summary>
		/// Url Alias
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "10.2.1+25a20cf")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("umbracoUrlAlias")]
		public virtual string UmbracoUrlAlias => global::Umbraco.Cms.Web.Common.PublishedModels.BasicDetail.GetUmbracoUrlAlias(this, _publishedValueFallback);
	}
}
