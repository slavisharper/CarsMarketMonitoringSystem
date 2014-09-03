#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the FluentMappingGenerator.ttinclude code generation file.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Data.Common;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;
using Telerik.OpenAccess.Metadata.Relational;

namespace CarsMarketMonitoringSystem.MySqlConnector
{

	public partial class FluentModelMetadataSource : FluentMetadataSource
	{
		
		protected override IList<MappingConfiguration> PrepareMapping()
		{
			List<MappingConfiguration> mappingConfigurations = new List<MappingConfiguration>();

            var salesMapping = new MappingConfiguration<SaleModel>();
            salesMapping.MapType(sale => new
            {
                SaleId = sale.SaleId,
                CarId = sale.CarId,
                SellerId = sale.SellerId,
                Price = sale.Price,
                Date = sale.Date,
            }).ToTable("Sales");
            salesMapping.HasProperty(s => s.SaleId).IsIdentity();
            mappingConfigurations.Add(salesMapping);

			return mappingConfigurations;
		}
		
		protected override void SetContainerSettings(MetadataContainer container)
		{
			container.Name = "FluentModel";
			container.DefaultNamespace = "CarsMarketMonitoringSystem.MySqlConnector";
			container.NameGenerator.SourceStrategy = Telerik.OpenAccess.Metadata.NamingSourceStrategy.Property;
			container.NameGenerator.RemoveCamelCase = false;
		}
	}
}
#pragma warning restore 1591