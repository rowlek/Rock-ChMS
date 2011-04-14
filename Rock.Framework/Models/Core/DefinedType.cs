//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the T4\Model.tt template.
//
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

using Rock.Models;

namespace Rock.Models.Core
{
    [Table( "coreDefinedType" )]
    public partial class DefinedType : ModelWithAttributes, IAuditable
    {
		public Guid Guid { get; set; }
		
		public bool System { get; set; }
		
		public int? FieldTypeId { get; set; }
		
		public int Order { get; set; }
		
		[MaxLength( 100 )]
		public string Name { get; set; }
		
		public string Description { get; set; }
		
		public DateTime? CreatedDateTime { get; set; }
		
		public DateTime? ModifiedDateTime { get; set; }
		
		public int? CreatedByPersonId { get; set; }
		
		public int? ModifiedByPersonId { get; set; }
		
		[NotMapped]
		public override string AuthEntity { get { return "Core.DefinedType"; } }

		public virtual ICollection<DefinedValue> DefinedValues { get; set; }

		public virtual FieldType FieldType { get; set; }

		public virtual Crm.Person CreatedByPerson { get; set; }

		public virtual Crm.Person ModifiedByPerson { get; set; }
    }

    public partial class DefinedTypeConfiguration : EntityTypeConfiguration<DefinedType>
    {
        public DefinedTypeConfiguration()
        {
			this.HasOptional( p => p.FieldType ).WithMany( p => p.DefinedTypes ).HasForeignKey( p => p.FieldTypeId );
			this.HasOptional( p => p.CreatedByPerson ).WithMany().HasForeignKey( p => p.CreatedByPersonId );
			this.HasOptional( p => p.ModifiedByPerson ).WithMany().HasForeignKey( p => p.ModifiedByPersonId );
		}
    }
}