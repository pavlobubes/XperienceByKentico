﻿using CMS;
using CMS.Core;
using CMS.DataEngine;
using CMS.IO;

using Kentico.Xperience.AzureStorage;

using DancingGoat.Web;

using Kentico.Xperience.Cloud;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

// Registers the storage module into the system
[assembly: RegisterModule(typeof(StorageInitializationModule))]

namespace DancingGoat.Web
{
    public class StorageInitializationModule() : Module(nameof(StorageInitializationModule))
    {
        /// <summary>
        /// Local directory used for deployment of blob storage contents.
        /// </summary>
        private const string LOCAL_STORAGE_ASSETS_DIRECTORY_NAME = "$StorageAssets";


        /// <summary>
        /// Default container name within the blob storage.
        /// </summary>
        private const string CONTAINER_NAME = "default";


        /// <summary>
        /// Gets the web hosting environment information.
        /// </summary>
        public IWebHostEnvironment Environment => Service.Resolve<IWebHostEnvironment>();

        // Module class constructor, the system registers the module


        // Contains initialization code that is executed when the application starts
        protected override void OnInit()
        {
            base.OnInit();

            if (Environment.IsQa() || Environment.IsUat() || Environment.IsProduction())
            {
                // Maps the assets directory (e.g. media files) to the Azure storage provider
                MapAzureStoragePath($"~/assets/");
            }
            else
            {
                // Maps contents of the assets directory which are not handled by the CD tool (media files)
                // to the dedicated local folder.
                MapLocalStoragePath($"~/assets/media");
            }
        }


        private void MapAzureStoragePath(string path)
        {
            // Creates a new StorageProvider instance for Azure
            var provider = AzureStorageProvider.Create();

            // Specifies the target container
            provider.CustomRootPath = CONTAINER_NAME;
            provider.PublicExternalFolderObject = false;

            StorageHelper.MapStoragePath(path, provider);
        }


        private void MapLocalStoragePath(string path)
        {
            // Creates a new StorageProvider instance for local storage
            var provider = StorageProvider.CreateFileSystemStorageProvider();

            provider.CustomRootPath = $"{LOCAL_STORAGE_ASSETS_DIRECTORY_NAME}/{CONTAINER_NAME}";

            StorageHelper.MapStoragePath(path, provider);
        }
    }
}
