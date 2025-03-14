//--------------------------------------------------------------------------------------------------
// <auto-generated>
//
//     This code was generated by code generator tool.
//
//     To customize the code use your own partial class. For more info about how to use and customize
//     the generated code see the documentation at https://docs.xperience.io/.
//
// </auto-generated>
//--------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using CMS.ContentEngine;

namespace XperienceAdapter.Models.ReusableContentTypes.DancingGoat.Image
{
	/// <summary>
	/// Represents a content item of type <see cref="Image"/>.
	/// </summary>
	[RegisterContentTypeMapping(CONTENT_TYPE_NAME)]
	public partial class Image : IContentItemFieldsSource
	{
		/// <summary>
		/// Code name of the content type.
		/// </summary>
		public const string CONTENT_TYPE_NAME = "DancingGoat.Image";


		/// <summary>
		/// Represents system properties for a content item.
		/// </summary>
		[SystemField]
		public ContentItemFields SystemFields { get; set; }


		/// <summary>
		/// ImageThumbnail.
		/// </summary>
		public ContentItemAsset ImageThumbnail { get; set; }


		/// <summary>
		/// ImageTitle.
		/// </summary>
		public string ImageTitle { get; set; }


		/// <summary>
		/// ImageDescription.
		/// </summary>
		public string ImageDescription { get; set; }
	}
}