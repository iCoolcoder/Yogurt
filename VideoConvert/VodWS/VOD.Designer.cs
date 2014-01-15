﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
namespace VodWS
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class VODEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new VODEntities object using the connection string found in the 'VODEntities' section of the application configuration file.
        /// </summary>
        public VODEntities() : base("name=VODEntities", "VODEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new VODEntities object.
        /// </summary>
        public VODEntities(string connectionString) : base(connectionString, "VODEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new VODEntities object.
        /// </summary>
        public VODEntities(EntityConnection connection) : base(connection, "VODEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Asset> Assets
        {
            get
            {
                if ((_Assets == null))
                {
                    _Assets = base.CreateObjectSet<Asset>("Assets");
                }
                return _Assets;
            }
        }
        private ObjectSet<Asset> _Assets;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Assets EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToAssets(Asset asset)
        {
            base.AddObject("Assets", asset);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="TV.VODModel", Name="Asset")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Asset : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Asset object.
        /// </summary>
        /// <param name="assetId">Initial value of the AssetId property.</param>
        /// <param name="assetName">Initial value of the AssetName property.</param>
        /// <param name="description">Initial value of the Description property.</param>
        /// <param name="providerId">Initial value of the ProviderId property.</param>
        public static Asset CreateAsset(global::System.String assetId, global::System.String assetName, global::System.String description, global::System.String providerId)
        {
            Asset asset = new Asset();
            asset.AssetId = assetId;
            asset.AssetName = assetName;
            asset.Description = description;
            asset.ProviderId = providerId;
            return asset;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String AssetId
        {
            get
            {
                return _AssetId;
            }
            set
            {
                if (_AssetId != value)
                {
                    OnAssetIdChanging(value);
                    ReportPropertyChanging("AssetId");
                    _AssetId = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("AssetId");
                    OnAssetIdChanged();
                }
            }
        }
        private global::System.String _AssetId;
        partial void OnAssetIdChanging(global::System.String value);
        partial void OnAssetIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String AssetName
        {
            get
            {
                return _AssetName;
            }
            set
            {
                if (_AssetName != value)
                {
                    OnAssetNameChanging(value);
                    ReportPropertyChanging("AssetName");
                    _AssetName = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("AssetName");
                    OnAssetNameChanged();
                }
            }
        }
        private global::System.String _AssetName;
        partial void OnAssetNameChanging(global::System.String value);
        partial void OnAssetNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                if (_Description != value)
                {
                    OnDescriptionChanging(value);
                    ReportPropertyChanging("Description");
                    _Description = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("Description");
                    OnDescriptionChanged();
                }
            }
        }
        private global::System.String _Description;
        partial void OnDescriptionChanging(global::System.String value);
        partial void OnDescriptionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String ProviderId
        {
            get
            {
                return _ProviderId;
            }
            set
            {
                if (_ProviderId != value)
                {
                    OnProviderIdChanging(value);
                    ReportPropertyChanging("ProviderId");
                    _ProviderId = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("ProviderId");
                    OnProviderIdChanged();
                }
            }
        }
        private global::System.String _ProviderId;
        partial void OnProviderIdChanging(global::System.String value);
        partial void OnProviderIdChanged();

        #endregion

    
    }

    #endregion

    
}
