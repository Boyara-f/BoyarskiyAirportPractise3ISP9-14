﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BoyarskiyAirport.DB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class AirportEntities : DbContext
    {
        public AirportEntities()
            : base("name=AirportEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Aircompany> Aircompany { get; set; }
        public virtual DbSet<AirPort> AirPort { get; set; }
        public virtual DbSet<Buyer> Buyer { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Flight> Flight { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Passengers> Passengers { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Plane> Plane { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tickets> Tickets { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<VW_PlanesnowFly> VW_PlanesnowFly { get; set; }
        public virtual DbSet<VW_PlanesPassengers> VW_PlanesPassengers { get; set; }
    
        public virtual int PC_AircompanyTicetsSumm(Nullable<int> iDCompany)
        {
            var iDCompanyParameter = iDCompany.HasValue ?
                new ObjectParameter("IDCompany", iDCompany) :
                new ObjectParameter("IDCompany", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PC_AircompanyTicetsSumm", iDCompanyParameter);
        }
    
        public virtual ObjectResult<PC_AllPlanesInPort_Result> PC_AllPlanesInPort(Nullable<int> portId)
        {
            var portIdParameter = portId.HasValue ?
                new ObjectParameter("PortId", portId) :
                new ObjectParameter("PortId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PC_AllPlanesInPort_Result>("PC_AllPlanesInPort", portIdParameter);
        }
    
        public virtual ObjectResult<PC_AllPortsInCity_Result> PC_AllPortsInCity(Nullable<int> cityId)
        {
            var cityIdParameter = cityId.HasValue ?
                new ObjectParameter("CityId", cityId) :
                new ObjectParameter("CityId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PC_AllPortsInCity_Result>("PC_AllPortsInCity", cityIdParameter);
        }
    
        public virtual ObjectResult<PC_AllPortsOfCountry_Result> PC_AllPortsOfCountry(Nullable<int> countryId)
        {
            var countryIdParameter = countryId.HasValue ?
                new ObjectParameter("CountryId", countryId) :
                new ObjectParameter("CountryId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PC_AllPortsOfCountry_Result>("PC_AllPortsOfCountry", countryIdParameter);
        }
    
        public virtual int PC_CostCount(Nullable<int> ticetId)
        {
            var ticetIdParameter = ticetId.HasValue ?
                new ObjectParameter("TicetId", ticetId) :
                new ObjectParameter("TicetId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PC_CostCount", ticetIdParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    }
}