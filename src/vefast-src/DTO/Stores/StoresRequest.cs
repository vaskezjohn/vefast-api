using System;
namespace vefast_src.DTO.Stores
{
    public class StoresRequest
    {           
            public string name { get; set; }
            public bool active { get; set; }
            public Guid Company_id { get; set; }        
    }
}
