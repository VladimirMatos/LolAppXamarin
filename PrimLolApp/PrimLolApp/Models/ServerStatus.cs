using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimLolApp.Models
{
    
   public class Servers
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("locales")]
        public IList<string> Locales { get; set; }

        [JsonProperty("hostname")]
        public string Hostname { get; set; }

        [JsonProperty("region_tag")]
        public string RegionTag { get; set; }

        [JsonProperty("services")]
        public IList<Service> Services { get; set; }
        public string Region { get; set; }
        
    }
    public class Update
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("heading")]
        public string Heading { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("severity")]
        public string Severity { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("translations")]
        public IList<object> Translations { get; set; }
    }

    public class Incident
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updates")]
        public IList<Update> Updates { get; set; }
    }

    public class Service
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("incidents")]
        public IList<Incident> Incidents { get; set; }
    }

    public class Status
    {
        public IList<Servers> Servers { get; set; }
    }
}
